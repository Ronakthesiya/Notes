## API Versioning

- API versioning is the practice of managing changes to your Web API without breaking existing clients.

## API Versioning Strategies

| Strategy                        | Example                           |
| ------------------------------- | --------------------------------- |
| URI versioning                  | `/api/v1/products`                |
| Query string versioning         | `/api/products?version=1`         |
| Header versioning               | `X-API-Version: 1`                |
| Media type versioning           | `application/vnd.company.v1+json` |

## URI Versioning

```cs
[RoutePrefix("api/v1/products")]
public class ProductsV1Controller : ApiController
{
    [HttpGet]
    [Route("")]
    public IHttpActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Name = "Laptop", Price = 1200 }
        });
    }
}


[RoutePrefix("api/v2/products")]
public class ProductsV2Controller : ApiController
{
    [HttpGet]
    [Route("")]
    public IHttpActionResult Get()
    {
        return Ok(new[]
        {
            new {
                Id = 1,
                Name = "Laptop",
                Pricing = new {
                    Amount = 1200,
                    Currency = "USD"
                }
            }
        });
    }
}
```

## Query String Versioning

```cs
public class ProductsController : ApiController
{
    [HttpGet]
    public IHttpActionResult Get(int version)
    {
        if (version == 1)
        {
            return Ok(new { Id = 1, Name = "Laptop", Price = 1200 });
        }
        else if (version == 2)
        {
            return Ok(new {
                Id = 1,
                Name = "Laptop",
                Pricing = new { Amount = 1200, Currency = "USD" }
            });
        }

        return BadRequest("Invalid API version");
    }
}
```

## Header Versioning

```cs
public class ProductsController : ApiController
{
    [HttpGet]
    public IHttpActionResult Get()
    {
        var version = Request.Headers.Contains("X-API-Version")
            ? Request.Headers.GetValues("X-API-Version").First()
            : "1";

        if (version == "1")
        {
            return Ok(new { Id = 1, Name = "Laptop", Price = 1200 });
        }
        else if (version == "2")
        {
            return Ok(new {
                Id = 1,
                Name = "Laptop",
                Pricing = new { Amount = 1200, Currency = "USD" }
            });
        }

        return BadRequest("Unsupported API version");
    }
}
```

## Media Type Versioning

```cs
public IHttpActionResult Get()
{
    var mediaType = Request.Headers.Accept.ToString();

    if (mediaType.Contains("vnd.mycompany.v2"))
    {
        return Ok(new { Id = 1, Name = "Laptop", Price = 1200, Currency = "USD" });
    }

    return Ok(new { Id = 1, Name = "Laptop", Price = 1200 });
}
```

## Using Microsoft API Versioning Package

### 1. Install (NuGet)
- Install-Package Microsoft.AspNet.WebApi.Versioning

### 2. WebApiConfig.cs

```cs
public static void Register(HttpConfiguration config)
{
    config.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
    });
}
```

### 3. Controller.cs

```cs
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ApiController
{
    [HttpGet]
    public IHttpActionResult GetV1()
    {
        return Ok(new { Name = "Laptop", Price = 1200 });
    }
}

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsV2Controller : ApiController
{
    [HttpGet]
    public IHttpActionResult GetV2()
    {
        return Ok(new { Name = "Laptop", Pricing = new { Amount = 1200, Currency = "USD" } });
    }
}
```

