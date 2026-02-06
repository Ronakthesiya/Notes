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


app.MapGet("api/product", (ILog log) =>
{
    log.Log("get product by api.");
    return Results.Ok(Data.products);
});


app.MapGet("api/product/{id}", (ILog log,int id) =>
{
    log.Log("get product "+id+" by api.");
    return Results.Ok(Data.products.FirstOrDefault(prod => prod.id==id));
});


app.MapPost("api/product", (ILog log,Product product) =>
{
    log.Log("create product by api.");

    product.id = Data.products.Last().id+1;
    Data.products.Add(product);

    return Results.Created($"api/product/{product.id}",product);
});


app.MapPut("api/product", (ILog log,Product product) =>
{
    log.Log("update product by api.");

    Product oldProduct = Data.products.FirstOrDefault(prod => prod.id == product.id);

    oldProduct.price = product.price;
    oldProduct.name = product.name;
    oldProduct.description = product.description;

    return Results.Ok(oldProduct);
});


app.MapDelete("api/product/{id}", (ILog log,int id) =>
{
    log.Log("delete product by api.");

    return Results.Ok(Data.products.RemoveAll(prod => prod.id == id));
});


app.Run();
