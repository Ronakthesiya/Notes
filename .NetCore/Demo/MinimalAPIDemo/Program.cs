using Microsoft.AspNetCore.RateLimiting;
using MinimalAPIDemo;
using MinimalAPIDemo.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddSingleton<ILog, Log>();


// Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", limiterOptions =>
    {
        limiterOptions.Window = TimeSpan.FromMinutes(1);
        limiterOptions.PermitLimit = 2;
        limiterOptions.QueueLimit = 0;
    });

    options.AddSlidingWindowLimiter("sliding", limiterOptions =>
    {
        limiterOptions.Window = TimeSpan.FromMinutes(1);
        limiterOptions.PermitLimit = 1;
        limiterOptions.SegmentsPerWindow = 1;
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseRateLimiter();

app.Use(async (context, next) =>
{
    Console.WriteLine("Request received");

    await next(); // call next middleware

    Console.WriteLine("Response sent");
});

app.UseHttpsRedirection();

// Route Group
var product = app.MapGroup("api/product/");

// get method with end point filter, ratelimiting
product.MapGet("", (ILog log) =>
{
    log.Log("get product by api.");
    return Results.Ok(Data.products);
})
.AddEndpointFilter(async (context, next) =>
{
    Console.WriteLine("Filter Executed");   
    return await next(context);
})
 .RequireRateLimiting("fixed");

// get by id
product.MapGet("/{id}", (ILog log,int id) =>
{
    if (id <= 0)
    {
        return Results.BadRequest("Id is not valid.");
    }

    try
    {
        log.Log("get product " + id + " by api.");
        return Results.Ok(Data.products.First(prod => prod.id == id));
    }
    catch (Exception e)
    {
        return Results.BadRequest(e.Message);
    }
}).RequireRateLimiting("sliding");

// post new product
product.MapPost("", (ILog log,Product product) =>
{
    if (product.id != 0)
    {
        return Results.BadRequest("id must be 0");
    }

    log.Log("create product by api.");
    product.id = Data.products.Last().id+1;
    Data.products.Add(product);

    return Results.Created($"/{product.id}",product);
});

// update product
product.MapPut("", (ILog log,Product product) =>
{
    if (product.id <= 0)
    {
        return Results.BadRequest("Id is not valid.");
    }

    log.Log("update product by api.");
    Product oldProduct = Data.products.FirstOrDefault(prod => prod.id == product.id);

    oldProduct.price = product.price;
    oldProduct.name = product.name;
    oldProduct.description = product.description;

    return Results.Ok(oldProduct);
});

// delete product
product.MapDelete("/{id}", (ILog log,int id) =>
{
    if (id <= 0)
    {
        return Results.BadRequest("Id is not valid.");
    }

    log.Log("delete product by api.");
    return Results.Ok(Data.products.RemoveAll(prod => prod.id == id));
});


app.Run();
