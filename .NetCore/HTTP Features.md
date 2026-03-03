## Http Context

| Feature                | ASP.NET Framework   | ASP.NET Core    |
| ---------------------- | ------------------- | --------------- |
| Access                 | HttpContext.Current | Injected via DI |
| Thread-bound           | Yes                 | No              |
| Static access          | Yes                 | No              |
| Testability            | Harder              | Easier          |
| SynchronizationContext | Yes                 | No              |


### HttpContext in .Net Framework

| Property      | Description                |
| ------------- | -------------------------- |
| `Request`     | Incoming request data      |
| `Response`    | Outgoing response          |
| `Session`     | Per-user session storage   |
| `Application` | Global application storage |
| `Server`      | Utility methods            |
| `User`        | Authenticated user         |
| `Items`       | Per-request storage        |
| `Cache`       | Application-wide cache     |


#### HttpContext.Items (Per-Request Storage)

- Store data during request lifecycle
- Share data between modules, filters, handlers

```cs
// BeginRequest
HttpContext.Current.Items["Start"] = DateTime.Now;

// EndRequest
var start = (DateTime)HttpContext.Current.Items["Start"];
var duration = DateTime.Now - start;
```

#### HttpContext.Session (Per-user storage)

- Stored:
    - In memory
    - SQL Server
    - State server

- Real-world:
    - Shopping cart
    - User preferences

```cs
HttpContext.Session["Cart"] = cart;
```

#### HttpContext.Application (Global app-level storage)

- Shared across all users.

```cs
HttpContext.Application["TotalUsers"] = 100;
```

- Requires manual locking

```cs
Application.Lock();
Application["Counter"] = count;
Application.UnLock();
```

#### HttpContext.Cache (Global caching)

- Better alternative than Application.

```cs
HttpContext.Cache.Insert("Products", products);
```

#### HttpContext.User

```cs
var username = HttpContext.User.Identity.Name;
```
- Used in:
    - Role-based access
    - Claims
    - Identity system


### HttpContext in ASP.NET Core

#### Accessing HttpContext

- In Controllers = Controller base class provides it.
- In Minimal APIs = Injected automatically.
- In Services = ASP.NET Core uses DI.

#### HttpContext Core Properties

1. Request

```cs
var path = HttpContext.Request.Path;
var headers = HttpContext.Request.Headers;
var body = HttpContext.Request.Body;
```

2. Response

```cs
HttpContext.Response.StatusCode = 404;
await HttpContext.Response.WriteAsync("Not Found");
```

3. User (Authentication)

```cs
var username = HttpContext.User.Identity.Name;
```

4. Items (Per-Request Storage)

```cs
HttpContext.Items["StartTime"] = DateTime.UtcNow;
```

- Logging duration
- Sharing data between middleware
- Correlation IDs

5. Session (Optional)

```cs
> program.cs

builder.Services.AddSession();
app.UseSession();

> Controller

HttpContext.Session.SetString("Cart", "123");

```

6. Connection

```cs
var ip = HttpContext.Connection.RemoteIpAddress;
```

- Logging
- Security
- Rate limiting



## HTTP Request & Response Handling

### HttpRequest

- Represents the incoming request.

- Common properties:
    - Request.Method → GET, POST, PUT, DELETE
    - Request.Headers
    - Request.Query
    - Request.RouteValues
    - Request.Body
    
### HttpResponse

- Represents the outgoing response.

- Common properties:
    - Response.StatusCode
    - Response.Headers
    - Response.Body

## HTTP Status Codes

- 200 OK
- 201 Created
- 204 NoContent
- 400 BadRequest
- 401 Unauthorized
- 403 Forbidden
- 404 NotFound
- 500 InternalServerError

## HTTP Caching

- Improve performance using headers:
    - Cache-Control
    - ETag

```cs
[ResponseCache(Duration = 60)]
public IActionResult Get()
{
    return Ok();
}
```

## Rate Limiting in ASP.NET Core Web API

- Rate limiting controls how many HTTP requests a client can make within a given time window.
- Allow 100 requests per minute per user

- ASP.NET Core provides native rate limiting middleware in **System.Threading.RateLimiting**

### How Rate Limiting Works Internally

1. Request comes in

2. Rate limiter checks:
    - Who is calling (IP, user, API key)
    - How many requests already made

3. If limit exceeded:
    - Request is rejected (HTTP 429)

4. Otherwise:
    - Request proceeds normally

### Common Rate Limiting Algorithms

#### 1. Fixed Window

- Requests counted in fixed time blocks
- Simple but can cause traffic spikes

#### 2. Sliding Window

- Smooths request counting
- More accurate than fixed window

#### 3. Token Bucket (Most Popular)

- Tokens refill over time
- Allows bursts

#### 4. Concurrency Limiter
- Limits number of concurrent requests
- Useful for expensive operations

### Enabling Rate Limiting

#### Step 1: Add Rate Limiting Services

```cs
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", limiterOptions =>
    {
        limiterOptions.Window = TimeSpan.FromMinutes(1);
        limiterOptions.PermitLimit = 100;
        limiterOptions.QueueLimit = 0;
    });
});
```

#### Step 2: Add Middleware

```cs
app.UseRateLimiter();
```

#### Step 3: Apply Rate Limiting to Endpoints

- Controller

```cs
[EnableRateLimiting("fixed")]
[HttpGet]
public IActionResult GetData()
{
    return Ok("Success");
}
```

- Minimal API
```cs
app.MapGet("/data", () => "Hello")
   .RequireRateLimiting("fixed");
```













