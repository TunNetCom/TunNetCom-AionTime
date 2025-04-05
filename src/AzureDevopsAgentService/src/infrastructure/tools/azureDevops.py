from typing import List, Optional
import datetime
from pydantic import BaseModel, Field
from langchain_core.tools import tool

# --- Work Item Schema (Moved from old tools.py) ---
class WorkItem(BaseModel):
    """Represents an Azure DevOps work item."""

    id: int
    type: str
    title: str
    status: str
    assigned_to: str
    created_date: str
    description: Optional[str] = None
    tags: List[str] = []
    url: Optional[str] = None

# --- Dummy Data (Extracted and centralized from old tools) ---
# This simulates a simple in-memory DB or cache for the dummy tools
# In a real app, these tools would interact with the Azure DevOps API
DUMMY_WORK_ITEMS_DB = {
    201: {
        "id": 201, "type": "User Story", "title": "User Profile Page Refactor", "status": "Active",
        "assigned_to": "Alice Johnson", "created_date": "2025-02-08", "tags": ["frontend", "refactor", "ui"],
        "description": "Refactor the user profile page using the new design system.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/201",
    },
    202: {
        "id": 202, "type": "Bug", "title": "Login redirect loop on Safari", "status": "Resolved",
        "assigned_to": "Bob Williams", "created_date": "2025-02-15", "tags": ["bug", "login", "safari"],
        "description": "Users on Safari are stuck in a redirect loop after login.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/202",
    },
    203: {
        "id": 203, "type": "Task", "title": "Update API Documentation for v2", "status": "Active",
        "assigned_to": "Charlie Brown", "created_date": "2025-02-20", "tags": ["api", "docs", "v2"],
        "description": "Ensure all new v2 endpoints are documented with examples.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/203",
    },
    204: {
        "id": 204, "type": "Feature", "title": "Implement Two-Factor Authentication", "status": "New",
        "assigned_to": "Alice Johnson", "created_date": "2025-03-01", "tags": ["security", "auth", "backend"],
        "description": "Add support for TOTP-based two-factor authentication.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/204",
    },
    205: {
        "id": 205, "type": "Bug", "title": "Data export fails for large datasets", "status": "Active",
        "assigned_to": "David Lee", "created_date": "2025-03-10", "tags": ["bug", "export", "backend", "performance"],
        "description": "Export process times out or fails for users with >10k records.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/205",
    },
    206: {
        "id": 206, "type": "Task", "title": "Configure Staging Environment Monitoring", "status": "Closed",
        "assigned_to": "Eve Davis", "created_date": "2025-03-15", "tags": ["devops", "monitoring", "staging"],
        "description": "Setup Datadog monitoring for the staging k8s cluster.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/206",
    },
    207: {
        "id": 207, "type": "User Story", "title": "Allow users to customize dashboard widgets", "status": "New",
        "assigned_to": "Alice Johnson", "created_date": "2025-03-22", "tags": ["frontend", "dashboard", "feature"],
        "description": "Users should be able to add, remove, and rearrange widgets on their dashboard.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/207",
    },
    208: {
        "id": 208, "type": "Bug", "title": "Incorrect calculation in monthly report", "status": "New",
        "assigned_to": "Bob Williams", "created_date": "2025-04-01", "tags": ["bug", "reporting", "backend"],
        "description": "The summary calculation for MRR is off by 2% for subscriptions started mid-month.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/208",
    },
    209: {
        "id": 209, "type": "Task", "title": "Perform Security Audit on Dependencies", "status": "Active",
        "assigned_to": "Eve Davis", "created_date": "2025-04-03", "tags": ["security", "audit", "dependencies"],
        "description": "Use Snyk/Dependabot to audit project dependencies for vulnerabilities.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/209",
    },
    210: {
        "id": 210, "type": "Feature", "title": "Integrate with Slack for notifications", "status": "New",
        "assigned_to": "Charlie Brown", "created_date": "2025-04-05", "tags": ["integration", "notifications", "feature", "backend"],
        "description": "Send notifications to a configured Slack channel when new bugs are created.",
        "url": "https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/210",
    },
}


# --- Tool: listWorkItems ---
class ListWorkItemsArgs(BaseModel):
    """Input schema for listWorkItems tool."""
    start_date: Optional[str] = Field(None, description="Filter work items created or updated after this date (YYYY-MM-DD).")
    end_date: Optional[str] = Field(None, description="Filter work items created or updated before this date (YYYY-MM-DD).")
    item_type: Optional[str] = Field(None, description="Filter by work item type (e.g., 'Bug', 'User Story', 'Task').")
    status: Optional[str] = Field(None, description="Filter by work item status (e.g., 'New', 'Active', 'Resolved', 'Closed').")
    tags: Optional[List[str]] = Field(None, description="Filter by tags associated with the work item.")
    assigned_to: Optional[str] = Field(None, description="Filter by the person the work item is assigned to (email or name).")

@tool(args_schema=ListWorkItemsArgs)
async def listWorkItems(
    start_date: Optional[str] = None,
    end_date: Optional[str] = None,
    item_type: Optional[str] = None,
    status: Optional[str] = None,
    tags: Optional[List[str]] = None,
    assigned_to: Optional[str] = None,
) -> List[WorkItem]:
    """
    Lists Azure DevOps work items based on provided filters. Returns dummy data.
    Use this tool to find work items matching specific criteria like dates, type, status, tags, or assignee.
    """
    print(f"Tool 'listWorkItems' called with filters: start_date={start_date}, end_date={end_date}, item_type={item_type}, status={status}, tags={tags}, assigned_to={assigned_to}")

    # Convert DB dict values to WorkItem objects for initial list
    all_items = [WorkItem(**data) for data in DUMMY_WORK_ITEMS_DB.values()]
    filtered_items = all_items

    # Apply filters
    if start_date:
        try:
            start_dt = datetime.datetime.strptime(start_date, "%Y-%m-%d").date()
            filtered_items = [item for item in filtered_items if datetime.datetime.strptime(item.created_date, "%Y-%m-%d").date() >= start_dt]
        except ValueError:
            print(f"Warning: Invalid start_date format: {start_date}. Should be YYYY-MM-DD.")
    if end_date:
        try:
            end_dt = datetime.datetime.strptime(end_date, "%Y-%m-%d").date()
            filtered_items = [item for item in filtered_items if datetime.datetime.strptime(item.created_date, "%Y-%m-%d").date() <= end_dt]
        except ValueError:
            print(f"Warning: Invalid end_date format: {end_date}. Should be YYYY-MM-DD.")
    if item_type:
        filtered_items = [item for item in filtered_items if item.type.lower() == item_type.lower()]
    if status:
        filtered_items = [item for item in filtered_items if item.status.lower() == status.lower()]
    if assigned_to:
        filtered_items = [item for item in filtered_items if assigned_to.lower() in item.assigned_to.lower()]
    if tags:
        lower_tags = [tag.lower() for tag in tags]
        filtered_items = [item for item in filtered_items if any(tag.lower() in lower_tags for tag in item.tags)]

    print(f"Returning {len(filtered_items)} filtered dummy work items.")
    return filtered_items


# --- Tool: getWorkItemById ---
class GetWorkItemByIdArgs(BaseModel):
    """Input schema for getWorkItemById tool."""
    work_item_id: int = Field(..., description="The unique ID of the Azure DevOps work item to retrieve.")

@tool(args_schema=GetWorkItemByIdArgs)
async def getWorkItemById(work_item_id: int) -> WorkItem:
    """
    Retrieves details for a specific Azure DevOps work item by its ID. Returns dummy data.
    Use this tool when you know the ID of the work item you need information about.
    """
    print(f"Tool 'getWorkItemById' called with ID: {work_item_id}")
    item_data = DUMMY_WORK_ITEMS_DB.get(work_item_id)
    if item_data:
        print(f"Returning dummy data for work item {work_item_id}.")
        return WorkItem(**item_data)
    else:
        # Provide a consistent not-found response
        print(f"Work item {work_item_id} not found in dummy data.")
        # Consider raising an exception or returning a specific error object
        # For now, returning a placeholder - this might need adjustment based on agent expectations
        return WorkItem(
            id=work_item_id, type="Unknown", title=f"Work Item {work_item_id} Not Found",
            status="NotFound", assigned_to="N/A", created_date="N/A",
            description="This work item was not found in the dummy data.", tags=[],
            url=f"https://dev.azure.com/dummyorg/dummyproject/_workitems/edit/{work_item_id}"
        )

# --- Placeholder Tools (as mentioned in refactor plan, add if needed) ---
# @tool
# async def updateWorkItem(...) -> WorkItem: ...

# @tool
# async def createWorkItem(...) -> WorkItem: ...

# List of tools provided by this module
azure_devops_tools = [listWorkItems, getWorkItemById]
