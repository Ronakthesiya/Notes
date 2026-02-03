## Caching 
- is the process of storing copies of data so that future requests can be served faster without re-processing or re-fetching the data.


## Types of Caching

### 1. Client-Side (HTTP) Caching

- Stored in browser or client
- Controlled using HTTP headers
- No server code needed after first response

### 2. Proxy / CDN Caching

- Stored in intermediate servers
- Used by multiple users
- Requires public cache control

### 3. Server-Side Caching

- Stored in application memory or distributed cache
- Implemented manually (MemoryCache, Redis)
- Still requires HTTP request

## HTTP Caching

### Cache-Control
| Directive    | Meaning                        |
| ------------ | ------------------------------ |
| `public`     | Cacheable by browser & proxies |
| `private`    | Cacheable only by browser      |
| `no-cache`   | Must revalidate before use     |
| `no-store`   | Do not cache at all            |
| `max-age=60` | Cache valid for 60 seconds     |

```cs
response.Headers.CacheControl = new CacheControlHeaderValue
{
    Public = true,
    MaxAge = TimeSpan.FromSeconds(60)
};
```

## Server-Side Caching

> In-memory cache = data stored in RAM of the API process
- Lives inside **IIS worker process**
- Extremely fast (nanoseconds)
- Lost when app restarts

```cs
var cache = MemoryCache.Default;

cache.Set(
    "greeting",
    "Hello World",
    DateTimeOffset.UtcNow.AddMinutes(1)
);

varvalue = cache.Get("greeting");
```

```cs
MemoryCache.Default.Set("products", data, DateTimeOffset.Now.AddMinutes(5));
```

