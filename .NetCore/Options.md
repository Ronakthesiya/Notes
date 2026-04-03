## Options Pattern

- In ASP.NET Core, configuration settings (like app settings from appsettings.json, environment variables, or command-line arguments) are usually stored as key-value pairs.
- Accessing them directly using Configuration["SomeKey"] works, but it’s error-prone and lacks type safety.

- The Options pattern solves this by:
    - Mapping configuration sections to strongly typed classes.
    - Providing a clean way to inject configuration wherever you need it.
    - Supporting validation and change monitoring.

```cs

public class MySettings
{
    public string ConnectionString { get; set; }
    public int RetryCount { get; set; }
}

services.Configure<MySettings>(Configuration.GetSection("MySettings"));
```

## Options Pattern Types

### 1. Simple Options (`IOptions<T>`)

- Read-only snapshot of configuration at app startup.
- Inject `IOptions<T>` wherever needed.

```cs
// 1. Define settings class
public class MySettings
{
    public string AppName { get; set; }
}

// 2. Register options
services.Configure<MySettings>(Configuration.GetSection("MySettings"));

// 3. Inject into services or controllers
public class HomeController : Controller
{
    private readonly MySettings _settings;

    public HomeController(IOptions<MySettings> options)
    {
        _settings = options.Value;
    }

    public IActionResult Index()
    {
        return Content($"App: {_settings.AppName}");
    }
}
```

### 2. Monitor Options (`IOptionsMonitor<T>`)

- Supports change notifications when configuration is updated (useful with reloadOnChange: true in appsettings.json).
- Inject `IOptionsMonitor<T>` to get live updates.

```cs
public class MyService
{
    private readonly IOptionsMonitor<MySettings> _monitor;

    public MyService(IOptionsMonitor<MySettings> monitor)
    {
        _monitor = monitor;
        _monitor.OnChange(OnSettingsChanged);
    }

    private void OnSettingsChanged(MySettings settings)
    {
        Console.WriteLine($"AppName changed to: {settings.AppName}");
    }
}
```

### 3. Snapshot Options (`IOptionsSnapshot<T>`)


- Similar to IOptions<T>, but creates a fresh instance per request in scoped services (like in web apps).
- Useful when configuration could vary per request (e.g., per tenant in a multi-tenant app).

```cs
public class MyController : Controller
{
    private readonly MySettings _settings;

    public MyController(IOptionsSnapshot<MySettings> options)
    {
        _settings = options.Value;
    }
}
```


## Binding Configuration with Options

```json
"MySettings": {
  "AppName": "MyCoolApp",
  "RetryCount": 5
}
```

```cs
services.Configure<MySettings>(Configuration.GetSection("MySettings"));
```

## Validating Options

```cs
public class MySettings
{
    [Required]
    public string AppName { get; set; }

    [Range(1, 10)]
    public int RetryCount { get; set; }
}

// In Program.cs
services.AddOptions<MySettings>()
        .Bind(Configuration.GetSection("MySettings"))
        .ValidateDataAnnotations()
        .Validate(settings => settings.RetryCount % 2 == 0, "RetryCount must be even");
        
```



| **Feature**              | **`IOptions<T>`**                                                  | **`IOptionsSnapshot<T>`**                                             | **`IOptionsMonitor<T>`**                                                    |
| ------------------------ | ------------------------------------------------------------------ | --------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| **Lifetime**             | Singleton                                                          | Scoped (per request)                                                  | Singleton (but monitors changes)                                            |
| **Usage**                | Configuration values read at startup                               | Configuration values that may change per request                      | Configuration values that change during app lifetime                        |
| **When to Use**          | Static, unchanging configuration                                   | Per-request configuration that can change                             | Dynamic configuration that needs to be monitored                            |
| **Configuration Change** | Does not detect runtime changes                                    | Reflects configuration changes **per request**                        | Automatically detects and reacts to runtime changes                         |
| **Scope**                | Global to the entire application                                   | Per HTTP request (or per scope in DI)                                 | Global to the application but reacts to changes                             |
| **Example Use Case**     | Static values like database connection string or app-wide settings | Tenant-specific settings or feature flags that may change per request | Dynamic feature flags, caching policies, or settings that change at runtime |
