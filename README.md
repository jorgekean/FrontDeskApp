# FrontDeskApp

This repository contains two projects: one for the service (ASP.NET Core API) and a client (console app) that consumes the API.

The FrontDeskAppService project contains an ASP.NET Core Web API built with EF Core to allow storage facility employees to manage customer information, check storage area availability, and record box storage status. The client project, FrontDeskAppConsoleClient, allows employees to interact with the API by creating new customers, checking storage area availability, and recording box storage status.

To use this application, you will need to run both projects. In the FrontDeskAppService project, you may need to adjust the ApiUrl value to match your API port number. You can then run the API project and start sending requests to it using the console client.

This application is built on top of .NET Core and makes use of HttpClientFactory to handle API requests.

Thank you for checking out this project!
