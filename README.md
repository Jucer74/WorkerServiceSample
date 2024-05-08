# Worker Service Sample
This is a sample implementation for a worker service that checks the status of a change in records in a database and executes a call to a web service with that data.

The application runs as a Windows service and extracts records from a database using the repository pattern and using the Dapper library.

Likewise, the service configuration uses a combination of environment variables and App Settings files.

# Projects
The current solution include the following projects:

- **WorkerService.App**: Contains the Main entry Point
- **WorkerService.Application**: Implements the Service Logic
- **WorkerService.Domain**: Defines the Entities and business models
- **WorkerService.Infrastructure**: Implements the database or external connections


# Steps
Here we describe the steps to implement this Service.

1. Adding Logging
2. Configuration and Environment
3. Schedule Execution
4. Health Check
5. Data Sources
6. Consume Web Services


## Adding Logging
## Configuration and Environment
## Schedule Execution
## Health Check
## Data Sources
## Consume Web Services


