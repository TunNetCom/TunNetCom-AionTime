from fastapi import APIRouter, HTTPException, Request, Depends
from typing import List
import json
import uuid  # For generating conversation IDs

from fastapi.responses import StreamingResponse

# Import message classes
from langchain_core.messages import (
    HumanMessage,
    AIMessage,
    ToolMessage,
    BaseMessage,
)

# Updated imports for new structure
from src.api.schemas import ChatRequest, ChatMessage  # Use schemas instead of models
from src.core.limiter import limiter
from src.application.services.agent_service import AgentService  # Import the service

# Create a router instance
router = APIRouter()

# --- Dependency Injection for AgentService (Simple Example) ---
# In a real app, you might use FastAPI's dependency injection system more formally
# or a dedicated dependency injection container.
agent_service_instance = AgentService()


def get_agent_service():
    # This function could potentially do more setup or return different instances
    return agent_service_instance


# --- Helper Functions ---
def convert_api_history_to_lc(history_models: List[ChatMessage]) -> List[BaseMessage]:
    """Converts API ChatMessage history to LangChain BaseMessage list."""
    lc_messages: List[BaseMessage] = []
    for msg in history_models:
        if msg.role == "user":
            lc_messages.append(HumanMessage(content=msg.content))
        elif msg.role == "ai":
            # Simplified: Assuming AI history messages don't contain complex structures like tool_calls
            # If they do, this conversion needs to be more sophisticated.
            lc_messages.append(AIMessage(content=msg.content))
        # Skipping 'tool' role conversion for simplicity, as done previously.
    return lc_messages


# --- API Endpoint Definition ---
@router.post("/chat")
@limiter.limit("20/minute")
async def api_chat_endpoint(
    chat_request: ChatRequest,
    request: Request,
    agent_service: AgentService = Depends(get_agent_service),  # Inject the service
):
    """
    Receives user query and history, uses AgentService to stream the response via SSE.

    Stream Event Types:
    - `ai_response_chunk`: AI text chunk.
    - `tool_call`: Agent intends to call a tool.
    - `tool_result`: Result from a tool execution.
    - `stream_end`: Indicates the end of the response stream.
    - `error`: Indicates an error occurred during streaming.
    """
    try:
        # Convert incoming API history to LangChain messages
        lc_history = convert_api_history_to_lc(chat_request.history)

        # Generate a unique conversation ID for this request (optional but good practice)
        conversation_id = str(uuid.uuid4())

        # Use the injected agent_service to get the streaming response
        async_gen = agent_service.stream_chat_response(
            query=chat_request.query,
            history=lc_history,
            conversation_id=conversation_id,
        )

        # Return a StreamingResponse that wraps the async generator from the service
        return StreamingResponse(
            async_gen,
            media_type="text/event-stream",
        )

    except Exception as e:
        print(f"Error in /chat endpoint before streaming: {e}")
        import traceback

        traceback.print_exc()
        raise HTTPException(
            status_code=500,
            detail=f"Internal server error: {str(e)}",
        )
