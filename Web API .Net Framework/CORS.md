## SOP

- Same-Origin Policy
- blocks cross-origin browser requests by default

## CORS

- (Cross-Origin Resource Sharing)
- CORS is a controlled relaxation of Same-Origin Policy.

- CORS IS:
    - a browser-enforced rule
    - based on HTTP headers
    - meant to protect users, not servers

- If a request does NOT come from a browser, CORS does not apply.

- **The API works in Postman but not in the browser!**

- API still executes
- API still returns data
- BUT the browser blocks JavaScript from reading the response
- CORS Is a Browser Security Feature (Not a Server One)
- The browser acts like a security guard for the user, not for your server.

## CORS Request Types

| Type                    | Description                   |
| ----------------------- | ----------------------------- |
| **Simple Request**      | Sent directly                 |
| **Preflighted Request** | Browser asks permission first |

- Preflighted requests use an OPTIONS call.

### Simple Requests (Low-Risk Requests)

- A request is simple if all of these conditions are met
    - Allowed HTTP methods
        - GET
        - POST
        - HEAD
    - Allowed request headers
        - Accept
        - Accept-Language
        - Content-Language
        - Content-Type (with restrictions)
    - Allowed Content-Type values
        - text/plain
        - application/x-www-form-urlencoded
        - multipart/form-data
        - **❌ application/json is NOT allowed**

### Non-Simple Requests (Preflight Required)

- If any rule is broken, the request becomes preflighted.

- A preflight request is:
    - Sent by the browser
    - Uses HTTP OPTIONS
    - Sent before the real request
    - Asks permission

## CORS Headers

### 1. Access-Control-Allow-Origin
- Tells the browser which origin is allowed to read the response.

- Access-Control-Allow-Origin: https://app.example.com
- Only JavaScript from https://app.example.com may access this response.

- Access-Control-Allow-Origin: *
- Any origin may access this response.

### 2. Access-Control-Allow-Methods
- Lists HTTP methods the browser is allowed to use.

- Access-Control-Allow-Methods: GET, POST, PUT, DELETE

### 3. Access-Control-Allow-Headers
- Lists custom request headers JavaScript is allowed to send.

- Access-Control-Allow-Headers: Authorization, Content-Type

### 4. Access-Control-Allow-Credentials
- Allows the browser to:
    - send cookies
    - send client certificates
    - use Authorization headers in certain contexts

- Access-Control-Allow-Credentials: true

### 5. Access-Control-Expose-Headers
- Allows JavaScript to read certain response headers.

- By default, JS can only read:
    - Cache-Control
    - Content-Language
    - Content-Type
    - Expires
    - Last-Modified
    - Pragma

- Access-Control-Expose-Headers: X-Total-Count, X-Request-Id
- Now JavaScript can:
- response.headers.get("X-Total-Count");


### 6. Access-Control-Max-Age

- Tells the browser how long it can cache the preflight response.

- Access-Control-Max-Age: 3600
- For the next 1 hour, don’t ask again.

- Reduces OPTIONS traffic
- Improves performance
- Reduces latency

## CORS Flow Lifecycle

### 1. Browser Detects Cross-Origin

- Browser asks:

- “Is this request going to a different origin than my page?”
- Compares protocol + host + port

- If same → no CORS, normal request
- If different → apply CORS rules

### 2. Determine Request Type

- Simple request → low-risk → send immediately
- Preflighted request → risky → send OPTIONS first

### 3. Preflight Request (If Needed)

- Browser sends OPTIONS request to API:
```js
OPTIONS /orders HTTP/1.1
Origin: http://localhost:4200
Access-Control-Request-Method: POST
Access-Control-Request-Headers: Authorization, Content-Type
```

### 4. Server Responds to Preflight

- Server must respond with CORS headers:

```js
HTTP/1.1 200 OK
Access-Control-Allow-Origin: http://localhost:4200
Access-Control-Allow-Methods: POST, GET
Access-Control-Allow-Headers: Authorization, Content-Type
Access-Control-Allow-Credentials: true
Access-Control-Max-Age: 3600
```

### 5. Actual Request

- If preflight passes (or it was a simple request):
- Browser sends actual request

```js
POST /orders
Origin: http://localhost:4200
Authorization: Bearer token123
Content-Type: application/json

{ "item": "book", "qty": 2 }
```

- Browser includes cookies or auth headers only if Allow-Credentials: true was set


### 6. Server Responds

- Server sends response + CORS headers

## Enabling CORS in ASP.NET Web API (.NET Framework)

- global, controller-level, and action-level CORS.

### 1. Install NuGet Package
- **Microsoft.AspNet.WebApi.Cors**

- Why this is needed
    - Adds CORS middleware to ASP.NET Web API pipeline
    - Provides [EnableCors] attributes for controllers/actions
    - Handles both simple and preflight requests automatically

### 2. Enable Global CORS

- WebApiConfig.cs

```c#
// Enable CORS globally
var cors = new EnableCorsAttribute(
    origins: "http://localhost:4200", // allowed origin
    headers: "*",                     // allowed headers
    methods: "*");                    // allowed methods
cors.SupportsCredentials = true;      // allow credentials if needed

config.EnableCors(cors);
```

### 3. Enable CORS at Controller Level

```c#
[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*", SupportsCredentials = true)]
public class OrdersController : ApiController
{
}
```
### 4. Enable CORS at Action Level

```c#
[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "GET")]
public IHttpActionResult Get()
{
    return Ok(new { message = "Action-level CORS works" });
}
```

