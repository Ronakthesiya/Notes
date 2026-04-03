## Built-in Middleware

### 1. UseRouting()

- This middleware enables routing, which maps HTTP requests to appropriate route handlers
- This must be added to the pipeline before any authorization or endpoint mapping middleware, so that requests are routed properly before further processing.

### 2. UseAuthorization()

- This middleware is responsible for handling authorization. It checks whether the user has the necessary permissions to access a resource after authentication has been performed.

### 3. UseAuthentication()

- This middleware is responsible for handling user authentication. It ensures that the request contains a valid user identity (like a JWT token or cookie-based authentication).

### 4. UseStaticFiles()

- This middleware serves static files such as images, CSS, JavaScript, and fonts from the wwwroot folder. It allows your application to serve static content without needing to pass it through the request pipeline.

### 5. UseDeveloperExceptionPage()

- This middleware shows detailed error pages for unhandled exceptions during development. It's useful for debugging during the development process.

### 6. UseExceptionHandler()

- This middleware catches unhandled exceptions and provides a way to handle them globally

### 7. UseHttpsRedirection()

- Redirects HTTP requests to HTTPS, ensuring secure communication between the client and server.

### 8. UseCors()

- This middleware allows you to configure Cross-Origin Resource Sharing (CORS) policies, enabling or restricting requests from different domains.

### 9. UseCookiePolicy()

- Configures cookies and manages their settings, such as making them HttpOnly, Secure, SameSite, etc.

## Custom Middleware

> #### 1. Create a class that implements the middleware logic.
> #### 2. Implement the middleware by creating a method that processes the request and either passes control to the next middleware or terminates the request.
> #### 3. Register the middleware in the application's request pipeline.
> #### . 

### 1. Create a Custom Middleware Class

- A middleware class typically has a constructor that takes a RequestDelegate as a parameter.
- The RequestDelegate represents the next middleware in the pipeline, and it’s called to pass control to the next middleware.

```cs
public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomMiddleware> _logger;

    // Constructor
    public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    // Invoke method where the request processing logic happens
    public async Task InvokeAsync(HttpContext context)
    {
        // Custom logic before calling the next middleware
        _logger.LogInformation("Request incoming: " + context.Request.Path);

        // Call the next middleware in the pipeline
        await _next(context);

        // Custom logic after the next middleware has been called
        _logger.LogInformation("Request processed: " + context.Request.Path);
    }
}
```

- Constructor: Takes a RequestDelegate and other dependencies (like a logger).

- InvokeAsync: The InvokeAsync method contains the logic of the middleware. It can inspect or modify the request, call the next middleware (await _next(context)), and optionally modify the response afterward.

### 2. Register the Custom Middleware in the Pipeline

- Once you have your custom middleware class, you need to register it in the application's request pipeline using the UseMiddleware extension method in the Program.cs

```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Register custom middleware
app.UseMiddleware<CustomMiddleware>();

// Define your other middlewares
app.MapGet("/", () => "Hello, World!");

app.Run();
```

- UseMiddleware<CustomMiddleware>() registers the CustomMiddleware class in the pipeline.
- Any HTTP request that passes through this pipeline will invoke the InvokeAsync method in the CustomMiddleware class.


### Adding Parameters to Middleware

```cs
public class CustomLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _message;

    public CustomLoggingMiddleware(RequestDelegate next, string message)
    {
        _next = next;
        _message = message;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Custom logic before passing to the next middleware
        Console.WriteLine($"Custom message: {_message}");
        
        await _next(context);  // Call the next middleware

        // Custom logic after passing to the next middleware
    }
}
```

```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<CustomLoggingMiddleware>("This is a custom message");

app.MapGet("/", () => "Hello, World!");

app.Run();
```

### Middleware That Short-circuits the Pipeline

```cs
public class ShortCircuitMiddleware
{
    private readonly RequestDelegate _next;

    public ShortCircuitMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Short-circuit logic: If a request path is "/blocked", return a custom response
        if (context.Request.Path.StartsWithSegments("/blocked"))
        {
            context.Response.StatusCode = 403;  // Forbidden
            await context.Response.WriteAsync("This path is blocked.");
            return;  // Stop further processing
        }

        // Call the next middleware
        await _next(context);
    }
}
```