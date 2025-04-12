from pydantic import BaseModel, Field
from typing import List, Dict, Literal


# Define a model for a single message in the history
class ChatMessage(BaseModel):
    role: Literal["user", "ai", "tool"]
    content: str = Field(..., min_length=1, max_length=10000)


# Define API request models
class ChatRequest(BaseModel):
    query: str = Field(..., min_length=1, max_length=2000)
    history: List[ChatMessage] = Field(default=[], max_items=50)


# Define API response models
class ChatResponse(BaseModel):
    response: str
    history: List[ChatMessage]
