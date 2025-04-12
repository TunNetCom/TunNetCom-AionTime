import json
import traceback
from typing import AsyncGenerator, List, Dict, Any
from dataclasses import asdict

from langchain_core.messages import (
    HumanMessage,
    AIMessageChunk,
    BaseMessage,
)

# Import graph, state, config
from src.application.graph.definition import graph
from src.application.graph.state import InputState
from src.infrastructure.llm.configuration import Configuration


class AgentService:
    """Service layer for handling agent interactions."""

    async def stream_chat_response(
        self,
        query: str,
        history: List[BaseMessage],
        conversation_id: str = "default-conv-id",  # Allow passing conversation ID
    ) -> AsyncGenerator[str, None]:
        """Runs the LangGraph agent and yields response chunks and tool events as Server-Sent Events."""

        current_tool_call_id = None
        current_tool_name = None
        accumulated_tool_args = ""
        tool_call_yielded = False

        try:
            # 1. Create the configuration object (Using default for now)
            # In a real app, config might be dynamically loaded or passed
            config_obj = Configuration()
            config_dict = asdict(config_obj)
            runnable_config = {
                "configurable": config_dict,
                "verbose": True,  # Enable verbose logging for debugging
                "metadata": {"conversation_id": conversation_id},  # Use provided ID
            }

            # 2. Prepare initial state for the graph
            messages_for_graph = history + [HumanMessage(content=query)]
            input_state = InputState(messages=messages_for_graph)

            # 3. Stream events from the graph
            async for event in graph.astream_events(
                input=input_state, config=runnable_config, version="v1"
            ):
                kind = event["event"]

                # Event: Token stream from the LLM
                if kind == "on_chat_model_stream":
                    chunk = event["data"]["chunk"]
                    if isinstance(chunk, AIMessageChunk):
                        if chunk.content:
                            # Yield AI content chunk
                            chunk_data = {
                                "type": "ai_response_chunk",
                                "content": chunk.content,
                            }
                            yield f"data: {json.dumps(chunk_data)}\n\n"

                        # Accumulate tool call information from chunks
                        if chunk.tool_call_chunks:
                            for tool_call_chunk in chunk.tool_call_chunks:
                                if tool_call_chunk.get("id"):
                                    current_tool_call_id = tool_call_chunk["id"]
                                if tool_call_chunk.get("name"):
                                    current_tool_name = tool_call_chunk["name"]
                                if tool_call_chunk.get("args"):
                                    accumulated_tool_args += tool_call_chunk["args"]

                                # Yield tool_call event once we have enough info
                                if (
                                    current_tool_call_id
                                    and current_tool_name
                                    and accumulated_tool_args
                                    and not tool_call_yielded
                                ):
                                    try:
                                        tool_args_dict = json.loads(
                                            accumulated_tool_args
                                        )
                                        tool_data = {
                                            "type": "tool_call",
                                            "tool_name": current_tool_name,
                                            "tool_args": tool_args_dict,
                                            "tool_id": current_tool_call_id,
                                        }
                                        yield f"data: {json.dumps(tool_data)}\n\n"
                                        tool_call_yielded = True
                                    except json.JSONDecodeError:
                                        pass  # Args still streaming

                # Event: Tool execution ends
                elif kind == "on_tool_end":
                    tool_output_data = event["data"].get("output")
                    tool_output_content = None
                    tool_name = event["name"]  # Get tool name earlier for logging

                    # --- Improved Tool Output Handling ---
                    try:
                        if isinstance(tool_output_data, BaseMessage):
                            # If output is already a message, extract content
                            tool_output_content = tool_output_data.content
                        elif tool_output_data is not None:
                            # Attempt to serialize complex objects (like dicts/lists) to JSON string
                            try:
                                tool_output_content = json.dumps(tool_output_data)
                            except TypeError:
                                # Fallback for non-serializable objects
                                print(
                                    f"Warning: Tool '{tool_name}' output type {type(tool_output_data)} is not JSON serializable. Falling back to str()."
                                )
                                tool_output_content = str(tool_output_data)
                        else:
                            tool_output_content = ""  # Handle None case explicitly

                        print(
                            f"Debug: Tool '{tool_name}' output processed: {tool_output_content[:200]}..."
                        )  # Log processed output

                    except Exception as tool_proc_err:
                        print(
                            f"Error processing output of tool '{tool_name}': {tool_proc_err}"
                        )
                        tool_output_content = (
                            f"Error processing tool output: {tool_proc_err}"
                        )
                    # --- End Improved Handling ---

                    if current_tool_call_id and tool_output_content is not None:
                        tool_result_data = {
                            "type": "tool_result",
                            "tool_name": tool_name,  # Use captured tool_name
                            "tool_call_id": current_tool_call_id,
                            "content": tool_output_content,  # Use processed content
                        }
                        yield f"data: {json.dumps(tool_result_data)}\n\n"
                    else:
                        print(
                            f"Warning: Could not yield tool_result. ID: {current_tool_call_id}, Content available: {tool_output_content is not None}"
                        )

                    # Reset tool state after tool ends
                    current_tool_call_id = None
                    current_tool_name = None
                    accumulated_tool_args = ""
                    tool_call_yielded = False

            # Indicate the end of the stream
            yield f"data: {json.dumps({'type': 'stream_end'})}\n\n"

        except Exception as e:
            print(f"Error during agent streaming in AgentService: {e}")
            traceback.print_exc()
            # Yield an error event to the client
            error_data = {
                "type": "error",
                "detail": f"Agent streaming failed: {str(e)}",
            }
            yield f"data: {json.dumps(error_data)}\n\n"
