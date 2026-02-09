## Minimal API

- Minimal APIs are a lightweight way to build HTTP APIs in ASP.NET Core without controllers and without MVC overhead.

- Instead of this 👇 (MVC):

```cs
[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }
}
```

- You write this 👇:
```cs
var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/products/{id}", (int id) =>
{
    return Results.Ok();
});

app.Run();
```
- No controllers. No attributes. Just endpoints.

## Program.cs

```cs
var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World");

app.Run();
```
| Line               | Purpose                              |
| ------------------ | ------------------------------------ |
| `CreateBuilder`    | Configures host, logging, config, DI |
| `builder.Services` | Dependency injection                 |
| `app.Use...`       | Middleware                           |
| `app.Map...`       | Endpoint mapping                     |
| `app.Run()`        | Starts server                        |

## Mapping Endpoints

```cs
app.MapGet("/items", () => { });
app.MapPost("/items", () => { });
app.MapPut("/items/{id}", () => { });
app.MapDelete("/items/{id}", () => { });
app.MapPatch("/items/{id}", () => { });
```

## Route Parameters

```cs
app.MapGet("/users/{id}", (int id) =>
{
    return $"User ID: {id}";
});
```
- Names must match
- Type conversion is automatic
- Invalid values → 400 Bad Request

- Optional parameters:

```cs
app.MapGet("/users/{id?}", (int? id) =>
{
    return id is null ? "All users" : $"User {id}";
});
```

## Dependency Injection (DI)

```cs
builder.Services.AddSingleton<IClock, SystemClock>();

app.MapGet("/time", (IClock clock) =>
{
    return clock.Now;
});
```

## Accessing HttpContext

```cs
app.MapGet("/context", (HttpContext context) =>
{
    return context.Request.Path;
});
```

```cs
app.MapGet("/headers", (HttpRequest request) =>
{
    return request.Headers["User-Agent"].ToString();
});
```

## Returning Responses

### 1. Simple types

```cs
return "Hello";
```

### 2. POCOs (auto-JSON)

```cs
return new Product(1, "Pen", 1.5m);
```

### 3. IResult (recommended)

```cs
return Results.Ok(product);
return Results.NotFound();
return Results.BadRequest();
```

#### Common Results

| Method           | HTTP |
| ---------------- | ---- |
| `Ok()`           | 200  |
| `Created()`      | 201  |
| `NoContent()`    | 204  |
| `BadRequest()`   | 400  |
| `Unauthorized()` | 401  |
| `Forbidden()`    | 403  |
| `NotFound()`     | 404  |


## Validation

- Minimal APIs do not automatically validate models like [ApiController].

### 1. Manual validation

```cs
app.MapPost("/users", (User user) =>
{
    if (string.IsNullOrWhiteSpace(user.Email))
        return Results.BadRequest("Email required");

    return Results.Ok(user);
});
```

### 2. FluentValidation (recommended)

```cs
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

app.MapPost("/users", async (User user, IValidator<User> validator) =>
{
    var result = await validator.ValidateAsync(user);
    if (!result.IsValid)
        return Results.ValidationProblem(result.ToDictionary());

    return Results.Ok(user);
});
```

## Filters (Endpoint Filters)

- Filters are like middleware for endpoints.

### Inline endpoint filters

```cs
app.MapPost("/orders", (Order order) =>
{
    return Results.Ok();
})
.AddEndpointFilter(async (context, next) =>
{
    if (!context.HttpContext.Request.Headers.ContainsKey("X-API-KEY"))
        return Results.Unauthorized();

    return await next(context);
});
```

### DI in filter

```cs
public class AuditFilter(ILogger<AuditFilter> logger) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        logger.LogInformation("Request started");
        return await next(context);
    }
}

var group = app.MapGroup("/api")
    .AddEndpointFilter<AuditFilter>();
```

| Feature                | Middleware | Endpoint Filter |
| ---------------------- | ---------- | --------------- |
| Scope                  | Global     | Endpoint/group  |
| Runs before routing    | Yes        | No              |
| Access to bound params | ❌          | ✅               |
| Typed arguments        | ❌          | ✅               |
| Short-circuit          | Yes        | Yes             |


## Authorization & Authentication

```cs
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer();


app.UseAuthentication();
app.UseAuthorization();


app.MapGet("/secure", () => "Secret")
   .RequireAuthorization();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
});

app.MapGet("/admin", () => "Admin")
   .RequireAuthorization("AdminOnly");
```


## Grouping Endpoints

- Endpoint groups help structure large APIs.

```cs
var users = app.MapGroup("/users");

users.MapGet("/", GetUsers);
users.MapGet("/{id}", GetUser);
users.MapPost("/", CreateUser);

users.RequireAuthorization();
```

## API Versioning

- Minimal APIs don’t include versioning by default.

- Common approaches:
    - URL versioning: /v1/products
    - Header versioning
    - Query versioning

```cs
var v1 = app.MapGroup("/api/v1");
v1.MapGet("/products", () => "v1");

var v2 = app.MapGroup("/api/v2");
v2.MapGet("/products", () => "v2");
```

## Error Handling

### Global exception handling

```cs
app.UseExceptionHandler(app =>
{
    app.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Something went wrong");
    });
});
```


