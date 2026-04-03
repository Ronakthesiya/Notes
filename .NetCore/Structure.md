## Program.cs

- This is the entry point of a .NET Core application.
- It typically contains the Main method and can include configuration for the application.
- In ASP.NET Core apps, it also configures services and middleware by building the application pipeline.

## Startup.cs

- This file is used to configure the application's services and the request handling pipeline. In .NET Core applications (pre .NET 6), Startup.cs contains methods such as:
    - ConfigureServices: Adds services to the DI container (Dependency Injection).
    - Configure: Defines the HTTP request pipeline by adding middleware components like MVC, authentication, static file serving

## wwwroot Folder

- This folder contains all the static files of your application, such as:
    - CSS files
    - JavaScript files
    - Images
    - Fonts
    - Client-side libraries (e.g., jQuery, Bootstrap)

- Files inside wwwroot are publicly accessible and are served directly by the web server.

## Properties Folder

### launchSettings.json
- Contains settings related to how the application should behave during development.
- It can define things like which port to use, whether to use IIS Express, or whether the application should be run with specific environment variables.


## Controllers Folder (For MVC/WebAPI Projects)
- Contains the controller classes that handle the HTTP requests from clients.
- Each controller is responsible for one or more actions (HTTP methods) such as GET, POST, PUT, DELETE.


## Models Folder
- This folder contains the data models that define the structure of data that the application uses.

## Views Folder
- This folder contains the Razor views used to render the HTML responses

## Services Folder
- This folder contains service classes that define the business logic of the application.
- These services can be injected into controllers to keep them clean and focused on HTTP request handling.

## appsettings.json

- Contains configuration settings used by the application. These can include things like:
    - Connection strings
    - Logging settings
    - Environment-specific settings (can be overridden by appsettings.Development.json or other environment-specific files)

## appsettings.Development.json

- These files are used for overriding settings from appsettings.json based on the environment (Development, Production, etc.). The environment can be set via the ASPNETCORE_ENVIRONMENT environment variable.

## minimal hosting model

- In the minimal hosting model, the typical Program.cs and Startup.cs files are merged into a single file (Program.cs), simplifying the app initialization process.

## Request Pipeline

1. Request Comes In: An HTTP request is made to the server (e.g., a GET request to /home/index).

2. Middleware Execution: The middleware components are executed in the order they are configured in the Program.cs (or Startup.cs) file.

3. Response is Generated: After processing the request, the response is generated and sent back through the same middleware components in reverse order.

4. Response Sent Out: Finally, the response is returned to the client.

### Common Middleware in the Request Pipeline

1. UseDeveloperExceptionPage()
2. UseExceptionHandler()
3. UseHttpsRedirection()
4. UseStaticFiles()
5. UseRouting()
6. UseAuthentication()
7. UseAuthorization()
8. MapControllerRoute() or MapRazorPages()
9. UseEndpoints()

