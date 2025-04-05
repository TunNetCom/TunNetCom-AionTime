import os
from pathlib import Path
from dotenv import load_dotenv

# Load environment variables from .env file at the project root
# Determine the project root directory (assuming this file is in app/core)
APP_DIR = Path(__file__).parent.parent  # Points to the 'app' directory
PROJECT_ROOT = (
    APP_DIR.parent
)  # Points to the root directory containing 'app', '.env' etc.

# Construct the path to the .env file
ENV_PATH = PROJECT_ROOT / ".env"

# Load the .env file if it exists
if ENV_PATH.exists():
    load_dotenv(dotenv_path=ENV_PATH)
    print(f"Loaded environment variables from: {ENV_PATH}")
else:
    print(
        f"Warning: .env file not found at {ENV_PATH}. Environment variables may not be set."
    )

# Define path to the static directory relative to the app directory
STATIC_DIR = str(APP_DIR / "static")

# Optionally, load specific variables (example)
# OPENAI_API_KEY = os.getenv("OPENAI_API_KEY")
# if not OPENAI_API_KEY:
#     print("Warning: OPENAI_API_KEY not found in environment variables.")
