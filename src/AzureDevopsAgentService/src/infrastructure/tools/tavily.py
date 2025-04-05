from typing import Any, cast, Optional
from langchain_community.tools.tavily_search import TavilySearchResults
from langchain_core.tools import tool

# Configuration might be injected or handled differently in the new structure
# For now, assuming a simple default or needing explicit passing
DEFAULT_MAX_SEARCH_RESULTS = 3

@tool
async def tavily_search_tool(query: str, max_results: int = DEFAULT_MAX_SEARCH_RESULTS) -> Optional[list[dict[str, Any]]]:
    """Search for general web results using Tavily.

    Use this tool to find information about current events or general knowledge.

    Args:
        query: The search query string.
        max_results: The maximum number of search results to return.
    """
    print(f"Executing Tavily search for: '{query}' with max_results={max_results}")
    # In a real app, Tavily API key would be needed, likely from config/env
    wrapped = TavilySearchResults(max_results=max_results)
    try:
        result = await wrapped.ainvoke({"query": query})
        # The result from TavilySearchResults is already a list of dicts
        return cast(list[dict[str, Any]], result)
    except Exception as e:
        print(f"Error during Tavily search: {e}")
        # Depending on requirements, could return None, empty list, or raise error
        return []

# Note: The original search function took a 'config' argument.
# This has been simplified here. In a full implementation, configuration
# (like API keys, max_results default) would likely be managed centrally
# (e.g., in `app.core.config`) and injected where needed, perhaps during
# tool initialization or via the service layer.
