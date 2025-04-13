# AionTime: The AzureDevOps AI Agent

This project implements AionTime, an AI agent designed to help you understand and keep up with the latest work happening in your team's Azure DevOps work items. It uses [LangGraph](https://github.com/langchain-ai/langgraph) to orchestrate its reasoning and actions.

The agent takes your questions about Azure DevOps work items, reasons about them, potentially uses tools (like querying the Azure DevOps API or searching internal documentation - **Note: Specific Azure DevOps tools need to be implemented**) to find relevant information, and provides concise answers.

## Technology Stack

*   **Backend Framework:** FastAPI
*   **Web Server:** Uvicorn
*   **AI Agent Logic:** LangChain & LangGraph
*   **Language Models:** Compatible with OpenAI, Anthropic, Fireworks, and potentially OpenRouter models (configurable)
*   **Tools:** Tavily Search API (default)
*   **Data Validation:** Pydantic
*   **Package Management:** `uv` / `pip` with `pyproject.toml`

## Project Structure

```
.
├── .env.example           # Example environment variables
├── .gitignore             # Git ignore rules
├── LICENSE                # Project license
├── Makefile               # Optional: Build/run commands
├── pyproject.toml         # Project metadata and dependencies (for uv/pip)
├── uv.lock                # Lockfile for dependencies (if using uv)
├── README.md              # This file
├── src/                   # Main application source code directory
│   ├── __init__.py
│   ├── main.py            # FastAPI app entry point, mounts API routers
│   ├── core/              # Cross-cutting concerns (Config, Custom Exceptions)
│   │   ├── __init__.py
│   │   ├── config.py      # Application settings, environment variable loading.
│   │   ├── exceptions.py  # Optional: Custom application exceptions.
│   │   └── limiter.py     # Rate limiting configuration
│   ├── api/               # Presentation Layer (Handles HTTP requests/responses)
│   │   ├── __init__.py
│   │   ├── routers/       # FastAPI routers defining API endpoints.
│   │   │   ├── __init__.py
│   │   │   └── chat.py    # Chat endpoint router. Depends on `application.services`.
│   │   └── schemas.py     # Pydantic models for API request/response validation.
│   ├── application/       # Application Layer (Core business logic, use cases)
│   │   ├── __init__.py
│   │   ├── services/      # Orchestrates application use cases.
│   │   │   ├── __init__.py
│   │   │   └── agent_service.py # Service handling chat logic, using the agent graph.
│   │   ├── graph/         # Agent-specific graph logic (LangGraph).
│   │   │   ├── __init__.py
│   │   │   ├── definition.py  # LangGraph graph definition.
│   │   │   └── state.py       # Agent state definition.
│   │   ├── prompts.py       # Agent prompts.
│   │   └── interfaces/      # Abstract interfaces for infrastructure components.
│   │       ├── __init__.py
│   │       ├── i_llm.py     # Interface for language model operations.
│   │       └── i_tool.py    # Interface for agent tools.
│   ├── infrastructure/    # Infrastructure Layer (External concerns implementation)
│   │   ├── __init__.py
│   │   ├── llm/           # Concrete LLM clients and configuration.
│   │   │   ├── __init__.py
│   │   │   ├── configuration.py # LLM selection and API key setup.
│   │   │   └── clients.py     # Implementations for OpenAI, Anthropic etc.
│   │   ├── tools/         # Concrete tool implementations.
│   │   │   ├── __init__.py
│   │   │   ├── tavily.py    # Tavily search tool implementation.
│   │   │   └── devops.py    # Placeholder/Dummy Azure DevOps tool implementation.
│   │   └── caching/       # Optional: Caching mechanisms.
│   │       └── __init__.py
│   └── static/            # Static files (HTML, CSS, JS for simple UI)
│       └── index.html
├── tests/                 # Unit and integration tests
└── .venv/                 # Virtual environment created by `uv venv`
```

## Getting Started

### Prerequisites

*   Python 3.11+

### Setup

Follow these steps to set up the project environment using `uv`:

1.  **Install `uv` (if you haven't already):**
    `uv` is a fast Python package installer and resolver. Follow the official installation instructions for your operating system [here](https://github.com/astral-sh/uv#installation).
    A common method is using `curl` or `pip`:
    ```bash
    # Example using curl (check official docs for the latest)
    curl -LsSf https://astral.sh/uv/install.sh | sh 
    
    ```

2.  **Clone the repository and go the the ai agent folder:**
    ```bash
    git clone <repository-url>
    cd <repository-folder>

    cd src/AzureDevopsAgentService 
    ```

3.  **Create and populate `.env`:**
    Copy the example file and add your API keys.
```bash
cp .env.example .env
```
    Edit `.env` and add your keys:
    ```plaintext
    # Required for the default search tool
    TAVILY_API_KEY="your_tavily_api_key"

    # Required for the language model (choose one or more)
    OPENAI_API_KEY="your_openai_api_key"
    # or
    ANTHROPIC_API_KEY="your_anthropic_api_key"
    # or
    OPENROUTER_API_KEY="your_openrouter_api_key"

    # Optional: LangSmith tracing
    # LANGCHAIN_TRACING_V2="true"
    # LANGCHAIN_API_KEY="your_langsmith_api_key"
    # LANGCHAIN_PROJECT="your_project_name"
    ```
    *   Get a Tavily API key [here](https://app.tavily.com/).
    *   Get OpenAI/Anthropic keys from their respective platforms.

4.  **Create and Activate Virtual Environment:**
    ```bash
    # Create a virtual environment named '.venv' in the current directory.
    # This isolates project dependencies from your global Python installation.
    uv venv
    
    # Activate the virtual environment in your current shell session (Linux/macOS).
    # This makes the project's Python interpreter and installed packages available.
    source .venv/bin/activate 
    
    # On Windows PowerShell, use this command instead:
    # .\.venv\Scripts\Activate.ps1 
    ```
    *Note: You must activate the environment in each new terminal session where you want to work on the project.* 

5.  **Install Dependencies:**
    With the virtual environment activated, install the project dependencies:
    ```bash
    # Install all dependencies specified in pyproject.toml and locked in uv.lock
    # into the activated virtual environment. This ensures reproducible builds.
    uv sync
    ```

### Managing Dependencies with `uv`

Make sure your virtual environment is activated (`source .venv/bin/activate`) before running these commands.

*   **Adding a new dependency:**
    ```bash
    # Installs the package and adds it to your pyproject.toml
    uv pip install <package-name>
    # Example: uv pip install requests
    ```
    After adding, `uv` typically updates `pyproject.toml` automatically. If you modify `pyproject.toml` manually, run `uv sync` again.

*   **Removing a dependency:**
    ```bash
    # Uninstalls the package and removes it from your pyproject.toml
    uv pip uninstall <package-name>
    # Example: uv pip uninstall requests 
    ```
    Similar to adding, this should update `pyproject.toml`. Run `uv sync` if needed after manual edits.

### Running the API Server

Activate your virtual environment if you haven't already (`source .venv/bin/activate`).

Run the FastAPI application using Uvicorn:
```bash
# src.main refers to src/main.py, app refers to the FastAPI instance inside it.
uvicorn src.main:app --reload --host 0.0.0.0 --port 8000
```

The AionTime API will be available at `http://127.0.0.1:8000` (or your local network IP if accessing from another device). You can access the auto-generated API documentation at `http://127.0.0.1:8000/docs` and the simple chat UI at `http://127.0.0.1:8000/`.

## API Endpoint

*   `POST /api/chat`
    *   **Request Body:**
        ```json
        {
          "query": "Your question for the agent"
        }
        ```
    *   **Response Body:**
        ```json
        {
          "response": "The agent's final answer"
        }
        ```

You can test this endpoint using tools like `curl`, Postman, or the Swagger UI at `/docs`.

## Customization

*   **Agent Logic:** Modify the core reasoning graph in `src/application/graph/definition.py` and the state definition in `src/application/graph/state.py`. Agent interaction logic is primarily within `src/application/services/agent_service.py`.
*   **Tools:** This is crucial for AionTime. Implement tools in `src/infrastructure/tools/` (e.g., `devops.py`) to interact with the Azure DevOps API. Replace or supplement the default Tavily search tool (`tavily.py`). **Ensure the agent's prompt (`src/application/prompts.py`) is updated to know how to use these new Azure DevOps tools.**
*   **Model:** Change the default language model and other agent configurations in `src/infrastructure/llm/configuration.py`. Model loading logic is in `src/infrastructure/llm/clients.py`.
*   **Prompts:** Adjust the AionTime system prompt in `src/application/prompts.py`.
*   **Environment Loading:** Configuration loading (including `.env` handling) happens in `src/core/config.py`.
*   **API Endpoints:** Add new API endpoints if needed in `src/api/routers/` and include them in `src/main.py`.
*   **UI:** Modify the simple HTML UI in `src/static/index.html`.