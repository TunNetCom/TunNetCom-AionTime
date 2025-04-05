from abc import ABC, abstractmethod
from langchain_core.language_models import BaseChatModel

class ILLMClient(ABC):
    """Interface for language model clients."""

    @abstractmethod
    def load_chat_model(self, fully_specified_name: str) -> BaseChatModel:
        """Load or get a chat model instance."""
        pass
