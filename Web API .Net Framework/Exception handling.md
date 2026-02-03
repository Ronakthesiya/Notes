## 1. Try-Catch in Controller Actions

- This is the simplest method. You wrap your code in a try-catch block.

```cs
public class ProductsController : ApiController
{
    private readonly MyDbContext db = new MyDbContext();

    [HttpGet]
    [Route("api/products/{id}")]
    public IHttpActionResult GetProduct(int id)
    {
        try
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound(); // 404
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            // Log the exception here
            return InternalServerError(ex); // 500
        }
    }
}
```

## 2. Using ExceptionFilterAttribute

- Web API supports filters, which are classes that intercept requests/responses. 
- ExceptionFilterAttribute is specifically for handling exceptions at the action or controller level.

### Step 1: Create a custom exception filter

```cs
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext context)
    {
        // Log the exception
        var errorMessage = context.Exception.Message;

        // Customize the response
        context.Response = context.Request.CreateResponse(
            HttpStatusCode.InternalServerError,
            new { Message = "An unexpected error occurred.", Details = errorMessage }
        );
    }
}

```

### Step 2: Apply it to controller or globally

#### a) Apply to a single controller:

```cs
[GlobalExceptionFilter]
public class ProductsController : ApiController
{
    public IHttpActionResult Get(int id)
    {
        var product = db.Products.Find(id); // No try-catch needed
        return Ok(product);
    }
}
```

#### b) Apply globally (for all controllers):

- In WebApiConfig.cs:

```cs
config.Filters.Add(new GlobalExceptionFilter());
```

## 3. Overriding ExceptionHandler (Global Exception Handling)

- ASP.NET Web API 2 introduced ExceptionHandler for global exception handling.
- It allows centralized handling for all unhandled exceptions, similar to middleware.

### Step 1: Create a custom exception handler

```cs
public class GlobalExceptionHandler : ExceptionHandler
{
    public override void Handle(ExceptionHandlerContext context)
    {
        // Log the exception
        var message = context.Exception.Message;

        // Create a custom response
        context.Result = new InternalServerErrorResult(context.Request, message);
    }
}

// Helper class
public class InternalServerErrorResult : IHttpActionResult
{
    private readonly HttpRequestMessage _request;
    private readonly string _message;

    public InternalServerErrorResult(HttpRequestMessage request, string message)
    {
        _request = request;
        _message = message;
    }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = _request.CreateResponse(HttpStatusCode.InternalServerError, new
        {
            Message = "Something went wrong on the server.",
            Details = _message
        });
        return Task.FromResult(response);
    }
}
```

### Step 2: Register the handler globally

- In WebApiConfig.cs:

```cs
config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
```

## 4. Using HttpResponseException

- ASP.NET Web API has a built-in HttpResponseException class that allows you to throw an exception with a specific HTTP response.

```cs
public IHttpActionResult GetProduct(int id)
{
    var product = db.Products.Find(id);
    if (product == null)
    {
        throw new HttpResponseException(HttpStatusCode.NotFound); // 404
    }
    return Ok(product);
}

```
