import os
from langchain_openai import ChatOpenAI
from langchain.chat_models import init_chat_model
from langchain_core.language_models import BaseChatModel

from src.application.interfaces.i_llm import ILLMClient


class LLMClient(ILLMClient):
    """Concrete implementation for loading LLM clients."""

    def load_chat_model(self, fully_specified_name: str) -> BaseChatModel:
        """Load a chat model from a fully specified name.

        Handles standard LangChain providers and adds specific handling for OpenRouter
        using the ChatOpenAI interface.

        Args:
            fully_specified_name (str): String in the format 'provider/model' (e.g., 'openai/gpt-4o', 'openrouter/google/gemini-flash-1.5').
        """
        provider, model = fully_specified_name.split("/", maxsplit=1)

        if provider == "openrouter":
            api_key = os.environ.get("OPENROUTER_API_KEY")
            if not api_key:
                raise ValueError(
                    "Provider is 'openrouter' but OPENROUTER_API_KEY environment variable is not set."
                )
            print(f"Using OpenRouter model: {model}")
            # Use ChatOpenAI client configured for OpenRouter
            return ChatOpenAI(
                model=model,  # Pass the specific OpenRouter model identifier
                openai_api_key=api_key,
                openai_api_base="https://openrouter.ai/api/v1",
                # temperature=0.7, # Example
            )
        else:
            # Default behavior for other providers (openai, anthropic, fireworks, etc.)
            print(f"Using LangChain standard provider: {provider}, model: {model}")
            return init_chat_model(model, model_provider=provider)
