# Worker Service Sample
This is a sample implementation for a worker service that checks the status of a change in records in a database and executes a call to a web service with that data.

The application runs as a Windows service and extracts records from a database using the repository pattern and using the Dapper library.

Likewise, the service configuration uses a combination of environment variables and App Settings files.

