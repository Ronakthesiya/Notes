## Service Lifetimes

| **Service Lifetime** | **Instance Creation**       | **Usage**                                        | **Typical Use Cases**                                  |
| -------------------- | --------------------------- | ------------------------------------------------ | ------------------------------------------------------ |
| **Transient**        | Created each time requested | Lightweight, stateless services                  | Logging, temporary objects, calculations               |
| **Scoped**           | Created once per request    | Shared within a single HTTP request or scope     | Database contexts, unit of work, request-specific data |
| **Singleton**        | Created once for entire app | Shared throughout the entire application runtime | Caching, configuration, logging services               |



## Options Pattern

- The Options Pattern is a design pattern in ASP.NET Core used for managing and binding configuration settings into strongly typed objects.
- This pattern allows for a clean and centralized way to read and access configuration values, especially when dealing with complex or large configuration structures

### 1. `IOptions<T>` Interface

- It allows you to bind a configuration section (or a set of related configuration values) to a POCO (Plain Old CLR Object) class.
- provided by the Dependency Injection (DI) container and can be injected into controllers or services.

### 2. `IOptionsSnapshot<T>` Interface

- per request scoped

### 3. `IOptionsMonitor<T>` Interface

- dynamically monitor and react to configuration changes.

### Emplementation

#### 1. Define a Configuration POCO

```cs
public class MyAppSettings
{
    public string ConnectionString { get; set; }
    public int MaxItems { get; set; }
    public bool IsFeatureEnabled { get; set; }
}
```

#### 2. Configure the Options in appsettings.json

```cs
{
  "MyAppSettings": {
    "ConnectionString": "Server=myserver;Database=mydb;User=myuser;Password=mypassword;",
    "MaxItems": 50,
    "IsFeatureEnabled": true
  }
}
```

#### 3. Register the Configuration with DI Container

```cs
public var builder = WebApplication.CreateBuilder(args);

// Registering MyAppSettings as options
builder.Services.Configure<MyAppSettings>(builder.Configuration.GetSection("MyAppSettings"));

var app = builder.Build();
```

#### 4. Injecting Options into Controllers or Services

> Using `IOptions<T>`:

```cs
public class HomeController : Controller
{
    private readonly MyAppSettings _appSettings;

    public HomeController(IOptions<MyAppSettings> options)
    {
        _appSettings = options.Value;
    }

    public IActionResult Index()
    {
        var connectionString = _appSettings.ConnectionString;
        var maxItems = _appSettings.MaxItems;
        var isFeatureEnabled = _appSettings.IsFeatureEnabled;

        return Content($"ConnectionString: {connectionString}, MaxItems: {maxItems}, Feature Enabled: {isFeatureEnabled}");
    }
}
```

> Using `IOptionsSnapshot<T>`

```cs
public class MyService
{
    private readonly IOptionsSnapshot<MyAppSettings> _appSettingsSnapshot;

    public MyService(IOptionsSnapshot<MyAppSettings> appSettingsSnapshot)
    {
        _appSettingsSnapshot = appSettingsSnapshot;
    }

    public string GetFeatureStatus()
    {
        return _appSettingsSnapshot.Value.IsFeatureEnabled ? "Feature is enabled" : "Feature is disabled";
    }
}
```

> Using `IOptionsMonitor<T>`

```cs
public class ConfigListener
{
    private readonly IOptionsMonitor<MyAppSettings> _optionsMonitor;

    public ConfigListener(IOptionsMonitor<MyAppSettings> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;
        _optionsMonitor.OnChange(OnConfigChanged);
    }

    private void OnConfigChanged(MyAppSettings newSettings)
    {
        // React to configuration changes
        Console.WriteLine($"Configuration changed: MaxItems = {newSettings.MaxItems}");
    }

    public string GetConnectionString()
    {
        return _optionsMonitor.CurrentValue.ConnectionString;
    }
}
```

| **Feature**              | **`IOptions<T>`**                                                  | **`IOptionsSnapshot<T>`**                                             | **`IOptionsMonitor<T>`**                                                    |
| ------------------------ | ------------------------------------------------------------------ | --------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| **Lifetime**             | Singleton                                                          | Scoped (per request)                                                  | Singleton (but monitors changes)                                            |
| **Usage**                | Configuration values read at startup                               | Configuration values that may change per request                      | Configuration values that change during app lifetime                        |
| **When to Use**          | Static, unchanging configuration                                   | Per-request configuration that can change                             | Dynamic configuration that needs to be monitored                            |
| **Configuration Change** | Does not detect runtime changes                                    | Reflects configuration changes **per request**                        | Automatically detects and reacts to runtime changes                         |
| **Scope**                | Global to the entire application                                   | Per HTTP request (or per scope in DI)                                 | Global to the application but reacts to changes                             |
| **Example Use Case**     | Static values like database connection string or app-wide settings | Tenant-specific settings or feature flags that may change per request | Dynamic feature flags, caching policies, or settings that change at runtime |
