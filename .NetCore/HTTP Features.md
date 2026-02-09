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













