import os
import uvicorn
from fastapi import FastAPI, HTTPException, Request, Response
from fastapi.staticfiles import StaticFiles
from fastapi.responses import FileResponse

# Imports for Rate Limiting
from slowapi import _rate_limit_exceeded_handler
from slowapi.errors import RateLimitExceeded
from slowapi.middleware import SlowAPIMiddleware

from src.core.limiter import limiter

from src.core.config import STATIC_DIR
from src.api.routers import chat as chat_router


# --- Initialize FastAPI app ---
app = FastAPI(
    title="AionTime - Azure DevOps AI Agent API",
    description="API endpoint and simple UI to interact with the AionTime agent for Azure DevOps.",
    version="0.3.0",
)

# --- Add Rate Limiter State and Middleware/Handler ---
app.state.limiter = limiter
app.add_exception_handler(RateLimitExceeded, _rate_limit_exceeded_handler)
app.add_middleware(
    SlowAPIMiddleware
)  # IMPORTANT: Add middleware AFTER exception handler


# --- Mount Static Files ---
# Serve static files (like index.html, css, js) from the 'app/static' directory
if os.path.exists(STATIC_DIR) and os.path.isdir(STATIC_DIR):
    app.mount("/static", StaticFiles(directory=STATIC_DIR), name="static")
    print(f"Successfully mounted static files from: {STATIC_DIR}")
else:
    print(
        f"Warning: Static directory not found or is not a directory at {STATIC_DIR}. UI may not load correctly."
    )


# --- Include API Routers ---
app.include_router(chat_router.router, prefix="/api", tags=["chat"])


# --- Root Endpoint for HTML UI ---
@app.get("/", include_in_schema=False)  # Exclude from OpenAPI docs
async def read_root():
    """Serves the main HTML chat interface."""
    html_file_path = os.path.join(STATIC_DIR, "index.html")
    print(f"Attempting to serve index.html from: {html_file_path}")  # Debugging path
    if os.path.exists(html_file_path):
        return FileResponse(html_file_path)
    else:
        # Provide a fallback message if index.html is missing
        print(f"Error: index.html not found at {html_file_path}")
        raise HTTPException(
            status_code=404, detail="index.html not found in static directory"
        )


# --- Simple Test Endpoint --- (Optional)
@app.get("/api/ping", tags=["test"])
@limiter.limit("1/second")  # Use the imported limiter
async def ping(request: Request):  # Endpoint needs request parameter for limiter
    """Simple health check endpoint."""
    return {"message": "pong"}


# --- Main execution block ---
if __name__ == "__main__":
    print("Starting Uvicorn server...")
    # Run using the application string 'src.main:app'
    # Host 0.0.0.0 makes it accessible on the network
    # Reload=True is great for development
    uvicorn.run("src.main:app", host="0.0.0.0", port=8000, reload=True)
