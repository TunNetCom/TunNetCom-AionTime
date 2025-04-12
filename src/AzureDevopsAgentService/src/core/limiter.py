from slowapi import Limiter
from slowapi.util import get_remote_address

# Initialize Rate Limiter
# Default limit applied globally unless overridden at the endpoint level.
limiter = Limiter(key_func=get_remote_address, default_limits=["100/minute"])
