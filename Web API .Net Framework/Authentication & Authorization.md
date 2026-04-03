## Authentication

- Who are you?
- Verifies user identity
- Happens when user logs in
- Example: username + password → valid user

## Authorization

- What are you allowed to do?
- Happens after authentication
- Checks roles/permissions
- Example: Admin can delete users, normal user can’t

## JWT (JSON Web Token)

- JWT is a self-contained token that proves:
    - the user is authenticated
    - what the user is allowed to do

- Why JWT?
    - Stateless (no server session)
    - Fast & scalable
    - Works great for APIs

- A JWT has 3 parts:
- HEADER.PAYLOAD(Claims).SIGNATURE(Created using secret key,Prevents token tampering)

### JWT Flow 

Client → Login (username/password)
Server → Validate user
Server → Generate JWT
Client → Store JWT
Client → Send JWT in Authorization header
Server → Validate JWT
Server → Allow or deny access


## How to Implement

### 1. Install NuGet (JWT only)

Install-Package System.IdentityModel.Tokens.Jwt

### 2. Create Models

```cs
public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
```

### 3. User Repository

```cs
public static class UserRepository
{
    public static List<(string Username, string Password, string Role)> Users =
        new List<(string, string, string)>
        {
            ("admin", "123", "Admin"),
            ("user", "123", "User")
        };

    public static (string Username, string Role)? ValidateUser(string username, string password)
    {
        var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (string.IsNullOrEmpty(user.Username)) return null;
        return (user.Username, user.Role);
    }
}

```

### 4. Create JWT Token Generator (inside AuthController)

```cs

[RoutePrefix("api/auth")]
public class AuthController : ApiController
{
    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public IHttpActionResult Login(LoginModel model)
    {
        var user = UserRepository.ValidateUser(model.Username, model.Password);
        if (user == null)
            return Unauthorized();

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Value.Username),
            new Claim(ClaimTypes.Role, user.Value.Role)
        };

        var key = Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_12345");

        var token = new JwtSecurityToken(
            issuer: "JwtAuthNoOwin",
            audience: "JwtUsers",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { token = tokenString, role = user.Value.Role });
    }
}
```

### 5. Create Custom Authorization Filter
JwtAuthorizeAttribute.cs

```cs

public class JwtAuthorizeAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        var authHeader = actionContext.Request.Headers.Authorization;

        if (authHeader == null || authHeader.Scheme != "Bearer")
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Missing token");
            return;
        }

        var token = authHeader.Parameter;
        var key = Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_12345");

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = "JwtAuthNoOwin",
                ValidAudience = "JwtUsers",
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            // Attach user to request
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
                HttpContext.Current.User = principal;

            // Role check
            if (!string.IsNullOrEmpty(Roles))
            {
                var roles = Roles.Split(',');
                var hasRole = roles.Any(r => principal.IsInRole(r.Trim()));
                if (!hasRole)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden: Role mismatch");
                    return;
                }
            }
        }
        catch
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token");
            return;
        }

        base.OnAuthorization(actionContext);
    }
}

```

### 6. Protect API with JwtAuthorize
ValuesController.cs

```cs

[RoutePrefix("api/values")]
public class ValuesController : ApiController
{
    // Any authenticated user
    [JwtAuthorize]
    [HttpGet]
    [Route("user")]
    public IHttpActionResult UserData()
    {
        var username = User.Identity.Name;
        return Ok($"Hello {username}, you are logged in");
    }

    // Only Admin
    [JwtAuthorize(Roles = "Admin")]
    [HttpGet]
    [Route("admin")]
    public IHttpActionResult AdminData()
    {
        var username = User.Identity.Name;
        return Ok($"Hello {username}, only admins can see this");
    }
}
```
