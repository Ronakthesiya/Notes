using MinimalAPIDemo;
using MinimalAPIDemo.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILog, Log>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var product = app.MapGroup("api/product/");


product.MapGet("", (ILog log) =>
{
    log.Log("get product by api.");
    return Results.Ok(Data.products);
})
.AddEndpointFilter(async (context, next) =>
{
    Console.WriteLine("Filter Executed");   
    return await next(context);
}); 


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
});


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
