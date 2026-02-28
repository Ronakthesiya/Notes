## All Types of Filters

- Authorization Filters
- Resource Filters
- Action Filters
- Result Filters
- Exception Filters

## Where Filters Execute in Request Pipeline

### Order of execution:

1. Middleware
2. Routing
3. **Authorization Filters**
4. **Resource Filters**
5. Model Binding
6. **Action Filters**
7. Action Method
8. **Result Filters**
9. Response
10. **Exception Filters** (if exception occurs)

## Authorization Filters

- Runs early in the MVC filter pipeline
- Verifies authentication + authorization
- Short-circuits the request if authorization fails
- Prevents the action method from executing

- It works with:
    - [Authorize]
    - [AllowAnonymous]
    - Custom authorization logic
    - Policy-based authorization

### AuthorizationFilterContext

1. HttpContext

| Property          | Description         |
| ----------------- | ------------------- |
| `User`            | ClaimsPrincipal     |
| `Request`         | HttpRequest         |
| `Response`        | HttpResponse        |
| `Items`           | Per-request storage |
| `Session`         | Session state       |
| `RequestServices` | DI container        |

2. Result

```cs
context.Result = new ForbidResult();
```

- → MVC pipeline STOPS
- → Action will NOT execute

- Common results:
    - UnauthorizedResult() → 401
    - ForbidResult() → 403
    - RedirectResult()
    - JsonResult()
    - StatusCodeResult()

3. ActionDescriptor

- Controller name
- Action name
- Parameters
- Endpoint metadata

4. Filters = List of all filters applied.

5. ModelState = Although model binding hasn't happened yet.

### Synchronous Example

```cs
public class CustomAuthFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!user.IsInRole("Admin"))
        {
            context.Result = new ForbidResult();
        }
    }
}
```

apply : 
```cs
[TypeFilter(typeof(CustomAuthFilter))]
```

### Async Example

```cs
public class CustomAsyncAuthFilter : IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // Async DB check
        await Task.Delay(10);
    }
}
```

### add Global Authorization Filter

```cs
services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});
```

## Resource Filter

- Resource Filters are part of the MVC filter pipeline and execute after Authorization filters but before model binding and action execution.

```cs
Authorization Filters
↓
Resource Filters      ← (YOU ARE HERE)
↓
Model Binding
↓
Action Filters
↓
Action Method
↓
Result Filters
↓
Result Execution
```

### ResourceExecutingContext

1. HttpContext
2. Result
3. ActionDescriptor
4. ValueProviderFactories 
- Used for model binding customization.
- Advanced usage only.

### ResourceExecutedContext

| Property           | Description                          |
| ------------------ | ------------------------------------ |
| `Result`           | Final result                         |
| `Exception`        | Exception thrown                     |
| `ExceptionHandled` | Boolean                              |
| `Canceled`         | Whether pipeline was short-circuited |


### Example

```cs
public class TransactionResourceFilter : IResourceFilter
{
    private readonly AppDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public TransactionResourceFilter(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        if (context.Exception == null)
        {
            _transaction.Commit();
        }
        else
        {
            _transaction.Rollback();
        }

        _transaction.Dispose();
    }
}
```

## Action Filter

- They allow you to execute logic:
    - ✅ Before an action method runs
    - ✅ After an action method runs
    - ❌ But NOT before model binding

```cs
public interface IActionFilter : IFilterMetadata
{
    void OnActionExecuting(ActionExecutingContext context);
    void OnActionExecuted(ActionExecutedContext context);
}


public interface IAsyncActionFilter : IFilterMetadata
{
    Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next);
}
```


### ActionExecutingContext

1. ActionArguments
```cs
context.ActionArguments["id"]
context.ActionArguments["name"] = "Modified Name";
```

2. HttpContext

3. Controller

4. Result

### ActionExecutedContext

| Property           | Description             |
| ------------------ | ----------------------- |
| `Result`           | Action result           |
| `Exception`        | Exception thrown        |
| `ExceptionHandled` | Mark true to suppress   |
| `Canceled`         | Whether short-circuited |


### Basic Logging Filter

```cs
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

public class LoggingActionFilter : IActionFilter
{
    private Stopwatch _stopwatch;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
        Console.WriteLine("Action executing...");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        Console.WriteLine($"Action executed in {_stopwatch.ElapsedMilliseconds} ms");

        if (context.Exception != null)
        {
            Console.WriteLine("Exception: " + context.Exception.Message);
        }
    }
}
```

### Async Action Filter

```cs
public class AsyncLoggingFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        Console.WriteLine("Before action");

        var executedContext = await next();

        Console.WriteLine("After action");

        if (executedContext.Exception != null)
        {
            Console.WriteLine("Exception occurred");
        }
    }
}
```

### Applying Action Filters

- Attribute
```cs
[LoggingActionFilter]
public IActionResult Index()
```

- Global Registration
```cs
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LoggingActionFilter>();
});
```

### Built-in Action Filter: ActionFilterAttribute

```cs
public class MyFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
```

## ServiceFilter

```cs
[ServiceFilter(typeof(LoggingFilter))]
```

- Must register in DI:

```cs
builder.Services.AddScoped<LoggingFilter>();
```

## TypeFilter

```cs
[TypeFilter(typeof(LoggingFilter))]
```

## Exception Filter

```cs
Authorization Filters
↓
Resource Filters
↓
Model Binding
↓
Action Filters
↓
Action Method
↓
Exception Filters   ← YOU ARE HERE only if exception occurs
↓
Result Filters
↓
Result Execution
```

### Interfaces for Exception Filters

```cs
public interface IExceptionFilter : IFilterMetadata
{
    void OnException(ExceptionContext context);
}

public interface IAsyncExceptionFilter : IFilterMetadata
{
    Task OnExceptionAsync(ExceptionContext context);
}
```

### ExceptionContext

1. Exception = Actual exception object

2. ExceptionHandled
- If set to true:
    - MVC stops propagating exception
    - No further exception filters run
    - Request continues normally

3. Result

4. HttpContext

### Example 

```cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        context.Result = new ObjectResult(new
        {
            Message = "Something went wrong",
            Details = exception.Message
        })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
```

## Result Filter

```cs
Authorization Filters
↓
Resource Filters
↓
Model Binding
↓
Action Filters
↓
Action Method
↓
Exception Filters if exception occurs
↓
Result Filters       ← YOU ARE HERE
↓
Result Execution
```

### Interfaces for Result Filters

```cs
public interface IResultFilter : IFilterMetadata
{
    void OnResultExecuting(ResultExecutingContext context);
    void OnResultExecuted(ResultExecutedContext context);
}


public interface IAsyncResultFilter : IFilterMetadata
{
    Task OnResultExecutionAsync(
        ResultExecutingContext context,
        ResultExecutionDelegate next);
}
```

### ResultExecutingContext

1. Result
2. HttpContext
3. Cancel

### ResultExecutedContext

| Property           | Description                       |
| ------------------ | --------------------------------- |
| `Result`           | Final result                      |
| `Exception`        | Exception during result execution |
| `ExceptionHandled` | Handle exception                  |
| `Canceled`         | Whether execution was canceled    |

### Exaple 

```cs
using Microsoft.AspNetCore.Mvc.Filters;

public class AddHeaderResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Add("X-Custom-Header", "MyValue");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine("Response has been sent");
    }
}
```
