"""Define a custom Reasoning and Action agent.

Works with a chat model with tool calling support.
"""

from datetime import datetime, timezone
from typing import Dict, List, Literal, cast

from langchain_core.messages import AIMessage, BaseMessage
from langchain_core.runnables import RunnableConfig
from langgraph.graph import StateGraph
from langgraph.prebuilt import ToolNode

# Updated imports for new structure
from src.infrastructure.llm.configuration import Configuration
from src.application.graph.state import InputState, State
from src.application import prompts  # Import prompts module

# Import tools from their new locations
from src.infrastructure.tools.tavily import tavily_search_tool
from src.infrastructure.tools.azureDevops import (
    azure_devops_tools,
)

# Import the LLM client implementation
from src.infrastructure.llm.clients import LLMClient

# Combine tools into a single list
# Ensure the list contains the actual tool functions/objects decorated with @tool
ALL_TOOLS = [tavily_search_tool] + azure_devops_tools

# Instantiate the LLM client (or potentially inject it if managing instances centrally)
llm_client = LLMClient()


async def call_model(
    state: State, config: RunnableConfig
) -> Dict[
    str, List[BaseMessage]
]:  # Return type changed to BaseMessage for wider compatibility
    """Call the LLM powering our "agent".

    This function prepares the prompt, initializes the model, and processes the response.

    Args:
        state (State): The current state of the conversation.
        config (RunnableConfig): Configuration for the model run.

    Returns:
        dict: A dictionary containing the model's response message.
    """
    configuration = Configuration.from_runnable_config(config)

    # Load the model using the LLM client
    model = llm_client.load_chat_model(configuration.model).bind_tools(ALL_TOOLS)

    # Format the system prompt using the imported prompts module
    system_message = prompts.SYSTEM_PROMPT.format(
        system_time=datetime.now(tz=timezone.utc).isoformat()
    )

    # Get the model's response
    response = cast(
        AIMessage,
        await model.ainvoke(
            [{"role": "system", "content": system_message}, *state.messages], config
        ),
    )

    # Handle the case when it's the last step and the model still wants to use a tool
    if state.is_last_step and response.tool_calls:
        # Return a BaseMessage instead of AIMessage for potentially simpler handling downstream
        fallback_content = "Sorry, I could not find an answer to your question in the specified number of steps."
        return {"messages": [AIMessage(id=response.id, content=fallback_content)]}

    # Return the model's response as a list to be added to existing messages
    return {"messages": [response]}


# Define a new graph

builder = StateGraph(State, input=InputState, config_schema=Configuration)

# Define the two nodes we will cycle between
builder.add_node("call_model", call_model)  # Reference the local function name
builder.add_node("tools", ToolNode(ALL_TOOLS))

# Set the entrypoint as `call_model`
builder.add_edge("__start__", "call_model")


def route_model_output(state: State) -> Literal["__end__", "tools"]:
    """Determine the next node based on the model's output."""
    last_message = state.messages[-1]
    # Check specifically for AIMessage before accessing tool_calls
    if not isinstance(last_message, AIMessage):
        # If the last message isn't an AIMessage (e.g., HumanMessage if error/interrupt occurred),
        # we should probably end to avoid unexpected loops or errors.
        # Or, handle other message types explicitly if needed.
        print(
            f"Warning: Expected AIMessage in route_model_output, got {type(last_message).__name__}. Ending run."
        )
        return "__end__"

    # If there is no tool call, then we finish
    if not last_message.tool_calls:
        return "__end__"
    # Otherwise we execute the requested actions
    return "tools"


# Add a conditional edge to determine the next step after `call_model`
builder.add_conditional_edges(
    "call_model",
    route_model_output,
)

# Add a normal edge from `tools` to `call_model`
builder.add_edge("tools", "call_model")

# Compile the builder into an executable graph
graph = builder.compile(
    interrupt_before=[],
    interrupt_after=[],
)
graph.name = "AionTime Agent v2"
