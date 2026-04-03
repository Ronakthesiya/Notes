## Routing

- Routing in ASP.NET Core is a key part of the framework’s request-processing pipeline that directs incoming HTTP requests to the appropriate controller and action.

## Types of Routing in ASP.NET Core

### 1. Conventional Routing

- It relies on defining route templates in the Startup.cs or Program.cs file, where you specify the patterns that match the URL structure.

```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

### 2. Attribute Routing

- Attribute Routing allows you to define routes directly on actions and controllers using attributes.

```cs
[Route("home")]
public class HomeController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return Content("Home Index");
    }

    [Route("about")]
    public IActionResult About()
    {
        return Content("About Us");
    }

    [Route("contact/{id}")]
    public IActionResult Contact(int id)
    {
        return Content($"Contact ID: {id}");
    }
}
```

## Routing with Route Parameters

### 1. Optional Parameters
- You can define optional route parameters by appending a ? to the parameter name.

```cs
[Route("home/{id?}")]
public IActionResult Index(int? id)
{
    if (id.HasValue)
    {
        return Content($"ID: {id.Value}");
    }
    return Content("No ID");
}
```

### 2. Custom Constraints
- You can apply constraints to route parameters to enforce valid values.

```cs
[Route("home/{id:int}")]
public IActionResult Index(int id)
{
    return Content($"ID: {id}");
}
```

### 3. Route Parameter Mapping

```cs
[Route("home/{controller}/{action}/{id}")]
public IActionResult Show(string controller, string action, int id)
{
    return Content($"Controller: {controller}, Action: {action}, ID: {id}");
}
```

## Route Constraints

- You can add constraints to routes to restrict the values of route parameters, improving route matching and validation.

```cs
[Route("home/{id:int}")]
public IActionResult Show(int id)
{
    return Content($"ID: {id}");
}
```


