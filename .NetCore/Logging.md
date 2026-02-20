## ILogger Interface

- ILogger is the central logging interface in ASP.NET Core. It's part of the Microsoft.Extensions.Logging namespace. All logging in ASP.NET Core flows through this interface.
- Inject logger into any service using Dependency Injection (DI).
- Severity Levels


| Level       | Use Case                                  |
| ----------- | ----------------------------------------- |
| Trace       | Very detailed, mostly for developers      |
| Debug       | Debugging info, internal state            |
| Information | General app flow, important events        |
| Warning     | Potential issues, non-critical failures   |
| Error       | Recoverable errors                        |
| Critical    | Application failure, unhandled exceptions |


| Level           | Example Code                                                                                |
| --------------- | ------------------------------------------------------------------------------------------- |
| **Trace**       | `_logger.LogTrace("Processing item {ProductId} with qty {Qty}", item.Id, item.Qty);`        |
| **Debug**       | `_logger.LogDebug("Calculated discount for User {UserId}: {Discount}", user.Id, discount);` |
| **Information** | `_logger.LogInformation("Order {OrderId} created successfully", order.Id);`                 |
| **Warning**     | `_logger.LogWarning("Retry attempt {RetryCount} for Order {OrderId}", retry, order.Id);`    |
| **Error**       | `_logger.LogError(ex, "Error saving Order {OrderId}", order.Id);`                           |
| **Critical**    | `_logger.LogCritical(ex, "Database unavailable. System cannot continue.");`                 |


## Logging Providers

- a logging provider is a component that determines where logs are written.

### Built-in Logging Providers

#### 1. Console Provider

- What It Does :
    - Writes logs to the terminal/console window.

- When It’s Used :
    - Local development
    - Docker containers
    - Linux servers
    - Kubernetes pods

- How To Enable

```cs
builder.Logging.AddConsole();
```

#### 2. Debug Provider

- What It Does
    - Writes logs to Visual Studio Output window.

- When It’s Used
    - Only during local development.

```cs
builder.Logging.AddDebug();
```

#### 3. EventLog Provider

- What It Does
    - Writes logs to Windows Event Viewer.

```cs
builder.Logging.AddEventLog();
```

### Third-Party Logging Providers

Serilog, NLog, Seq, Application Insights

### NLog

- NLog is a powerful, flexible logging framework for .NET applications.
- It allows you to:
    - Write logs to files
    - Write logs to databases
    - Send logs to email
    - Write to Windows Event Log
    - Send logs to external systems
    - Perform log archiving & rotation
    - Use structured logging
    - Configure everything via XML

- How NLog Works (Architecture):
    - ILogger  →  NLog Provider  →  Targets  →  Destination

| Component | Description                     |
| --------- | ------------------------------- |
| Logger    | Object used to log messages     |
| Target    | Where logs go (file, DB, email) |
| Layout    | Format of log message           |
| Rule      | Determines which logs go where  |

### NLog Implementation in ASP.NET Core

#### 1. Install Required Packages

```bash
dotnet add package NLog.Web.AspNetCore
```

#### 2. Create nlog.config File

- Add this to project root:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      autoReload="true"
      internalLogLevel="Warn">

  <targets>
    
    <!-- File Target -->
    <target name="file"
            xsi:type="File"
            fileName="logs/app-${shortdate}.log"
            layout="${longdate} | ${level:uppercase=true} | ${logger} | ${message} ${exception}" />

    <!-- Console Target -->
    <target name="console"
            xsi:type="Console"
            layout="${longdate} | ${level} | ${message}" />

  </targets>

  <rules>
    <logger name="*" minlevel="Info" writeTo="file,console" />
  </rules>

</nlog>
```

#### 3. Configure in Program.cs

```cs
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
                       .LoadConfigurationFromFile("nlog.config")
                       .GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders(); // Remove default providers
    builder.Host.UseNLog(); // Use NLog

    var app = builder.Build();

    app.MapGet("/", (ILogger<Program> log) =>
    {
        log.LogInformation("Application started successfully");
        return "Hello NLog!";
    });

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application stopped due to exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
```

#### Structured Logging in NLog

```cs
_logger.LogInformation("Order {OrderId} created for user {UserId}",
    order.Id, user.Id);
```

#### Database Logging with NLog

```xml
<target xsi:type="Database"
        name="database"
        connectionString="Server=.;Database=LogsDb;Trusted_Connection=True;"
        commandText="INSERT INTO Logs(Level, Message, Exception, CreatedOn)
                     VALUES(@level, @message, @exception, @time)">
  
  <parameter name="@level" layout="${level}" />
  <parameter name="@message" layout="${message}" />
  <parameter name="@exception" layout="${exception}" />
  <parameter name="@time" layout="${longdate}" />

</target>

<logger name="*" minlevel="Error" writeTo="database" />

```

#### Email Alerts for Critical Logs

```cs
<target xsi:type="Mail"
        name="mail"
        smtpServer="smtp.gmail.com"
        smtpPort="587"
        enableSsl="true"
        smtpUserName="your@email.com"
        smtpPassword="password"
        from="your@email.com"
        to="admin@email.com"
        subject="Critical Error!"
        body="${message} ${exception}" />

<logger name="*" minlevel="Critical" writeTo="mail" />

```

#### Log Rotation & Archiving

```xml
<target xsi:type="File"
        name="file"
        fileName="logs/app.log"
        archiveFileName="logs/archive/app.{#}.log"
        archiveEvery="Day"
        archiveNumbering="Rolling"
        maxArchiveFiles="7"
        layout="${longdate} | ${level} | ${message}" />
```


#### Async Logging

```xml
<targets async="true">
```

```xml
<target xsi:type="AsyncWrapper" name="asyncFile">
    <target xsi:type="File" ... />
</target>
```


| Feature            | Built-in | NLog     |
| ------------------ | -------- | -------- |
| File logging       | No       | Yes      |
| Database logging   | No       | Yes      |
| Email alerts       | No       | Yes      |
| Log rotation       | Basic    | Advanced |
| XML config         | No       | Yes      |
| Enterprise support | Basic    | Strong   |


## Structured Logging in ASP.NET Core

- Structured logging means logging named properties (key-value pairs) instead of plain text messages.

- Instead of this:


```cs
_logger.LogInformation("User 123 logged in from 10.0.0.1");
```

- You log this:

```cs
_logger.LogInformation("User {UserId} logged in from {IP}", userId, ip);
```

- Now your log system stores:

```json
{
  "message": "User 123 logged in from 10.0.0.1",
  "UserId": 123,
  "IP": "10.0.0.1"
}
```

- This allows:
    - Searching by UserId
    - Filtering by IP
    - Better analytics in log systems


## Correlation IDs in ASP.NET Core

- A Correlation ID is a unique identifier attached to a request that:
    - Travels through the entire system
    - Appears in all logs for that request
    - Helps track request flow across services

### Implementing Correlation ID in ASP.NET Core

#### Step 1: Create Middleware

```cs
public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private const string HeaderName = "X-Correlation-ID";

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ILogger<CorrelationIdMiddleware> logger)
    {
        string correlationId;

        if (context.Request.Headers.ContainsKey(HeaderName))
        {
            correlationId = context.Request.Headers[HeaderName];
        }
        else
        {
            correlationId = Guid.NewGuid().ToString();
            context.Request.Headers[HeaderName] = correlationId;
        }

        context.Response.Headers[HeaderName] = correlationId;

        using (logger.BeginScope(new Dictionary<string, object>
        {
            ["CorrelationId"] = correlationId
        }))
        {
            await _next(context);
        }
    }
}
```


#### Step 2: Register Middleware

```cs
app.UseMiddleware<CorrelationIdMiddleware>();
```

### How Correlation ID Works with Structured Logging

```cs
_logger.LogInformation("Processing payment {PaymentId}", paymentId);
```

```json
{
  "message": "Processing payment 123",
  "PaymentId": 123,
  "CorrelationId": "8f0c2e4b-93a3-4f1a-a9c8-d78b1e91c001"
}
```

