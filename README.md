# 🚀 Project Name

This project implements backend API endpoints to support an Angular front-end, enabling create, update, and delete operations on in-memory todo tasks. The data is transiently stored on the web server, making it lightweight and ideal for demonstration or testing purposes.

## Prerequisites

- .NET SDK
Can be downloaded here https://dotnet.microsoft.com/en-us/download

### Configuration
By default, the Web API application has been configured to run on http://localhost:5005/
The front-end Angular app has also been configured to consume Web APIs at the specified URL.

```bash
git clone this code repository
cd your-repo-name
dotnet restore
dotnet build
dotnet run
