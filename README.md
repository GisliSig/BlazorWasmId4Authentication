# Policy based authentication in Blazor Webassembly using Identity Server 4
This project shows how to use policy based authorization in a Blazor Webassembly project using Identity Server
## Solution setup
1. Identity Server - Identity server project that uses in memory configuration and users
2. Client - Blazor Webassembly client project that uses Identity Server for authentication
3. Server - Hosted project that is used both to host the Blazor client project and also used as a reverse proxy using a great library called ProxyKit ( you can see the repo for it here: https://github.com/ProxyKit/ProxyKit)
4) Service - Backend service that is also authenticated by the Identity Server

## Information
I have setup a solution that shows how you can use Identity Server to authenticate users in your Blazor Webassembly project. There are two users that are included in the template, alice and bob, and I have given alice a blazortestamin role so that user can access the secretagent page and it shows up for that user in the menu. That role is also in the jwt token sent to the backend service.

## How to use
If using Visual Studio, open the solution, then right click on it and select "Set Startup Projects", select "Multiple startup projects" and set Action Start to IdentityServer, BlazorWasmId4Authentication.Server and BlazorWasmId4Authentication.Service
