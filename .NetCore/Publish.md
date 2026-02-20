## What is IIS?

- Internet Information Services (IIS) is Microsoft’s web server software that runs on Windows.


## Publish on IIS

### Publish Using Visual Studio (Easiest)

- Right-click project
- Click Publish
- Choose: Folder
- Choose location: C:\Publish\MyWebsite
- Click Publish

- After publishing, go to: C:\Publish\MyWebsite

- You will see:
    - web.config
    - .dll files
    - wwwroot folder
    - etc.

- These files are what IIS needs.

### Create Website in IIS

- Open IIS Manager
- Right click Sites
- Click Add Website

| Field         | Value                |
| ------------- | -------------------- |
| Site name     | MyWebsite            |
| Physical path | C:\Publish\MyWebsite |
| Port          | 8080                 |

- Click OK.

### Configure Application Pool

- Click Application Pools
- Find your site pool (MyWebsite)
- Right click → Advanced Settings

| Setting               | Value           |
| --------------------- | --------------- |
| .NET CLR Version      | No Managed Code |
| Managed Pipeline Mode | Integrated      |

### What Is an Application Pool?

- Each website in IIS runs inside its own separate worker process.
- That worker process is called: w3wp.exe
- Application Pool = A container that runs and manages that process.

### What Happens Behind the Scenes?

- When a request comes:
- Browser → IIS → Application Pool → Worker Process (w3wp.exe) → Your Website

- Each Application Pool:
    - Has its own memory
    - Has its own process
    - Has its own security identity

### Important Settings Inside Application Pool

#### 1. .NET CLR Version

- You will see:
    - .NET CLR Version v4.0
    - No Managed Code

- Old ASP.NET apps → use: .NET CLR Version v4.0
- ASP.NET Core (.NET Core / .NET 6/7/8) → use: No Managed Code

> Why?
>
> Because:
> - ASP.NET Core runs using Kestrel server internally.
> - IIS only forwards requests.
> - So for .NET Core: Always choose No Managed Code


#### 2. Managed Pipeline Mode

- Integrated
- Classic


### Recycling (Automatic Restart)

- Application Pools can restart automatically:
    - After certain memory usage
    - After certain time
    - After number of requests

- To prevent memory leaks and keep server healthy.

### What is w3wp.exe?

- World Wide Web Worker Process
- It is the actual Windows process that runs your website code inside Internet Information Services (IIS).

- Browser → IIS → w3wp.exe → Your Code Executes → Response sent back

- Every Application Pool creates its own w3wp.exe process.


