using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Pract02_GutierrezNina.Application.UseCases.Clients;
using Pract02_GutierrezNina.Application.UseCases.OrderDetails;
using Pract02_GutierrezNina.Application.UseCases.Orders;
using Pract02_GutierrezNina.Application.UseCases.Products;
using Pract02_GutierrezNina.Models;
using Pract02_GutierrezNina.Repositories.Implements;
using Pract02_GutierrezNina.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Db")
    ?? throw new InvalidOperationException("No se configuró ConnectionStrings:Db.");

builder.Services.AddDbContext<StoreLinQDB>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<GetAllClientsUseCase>();
builder.Services.AddScoped<GetClientByIdUseCase>();
builder.Services.AddScoped<GetClientsByNameUseCase>();
builder.Services.AddScoped<GetClientsByProductUseCase>();
builder.Services.AddScoped<GetClientsWithProductCountUseCase>();
builder.Services.AddScoped<InsertClientUseCase>();
builder.Services.AddScoped<UpdateClientUseCase>();
builder.Services.AddScoped<DeleteClientUseCase>();

builder.Services.AddScoped<GetAllOrdersUseCase>();
builder.Services.AddScoped<GetOrderByIdUseCase>();
builder.Services.AddScoped<GetOrdersAfterDateUseCase>();
builder.Services.AddScoped<GetOrderTotalQuantityUseCase>();
builder.Services.AddScoped<GetClientWithMostOrdersUseCase>();
builder.Services.AddScoped<GetOrdersWithProductsUseCase>();
builder.Services.AddScoped<GetClientsWithOrdersUseCase>();
builder.Services.AddScoped<GetSalesByClientUseCase>();
builder.Services.AddScoped<InsertOrderUseCase>();
builder.Services.AddScoped<UpdateOrderUseCase>();
builder.Services.AddScoped<DeleteOrderUseCase>();

builder.Services.AddScoped<GetAllOrderDetailsUseCase>();
builder.Services.AddScoped<GetOrderDetailByIdUseCase>();
builder.Services.AddScoped<GetOrderDetailsByOrderUseCase>();
builder.Services.AddScoped<GetOrderWithDetailsUseCase>();
builder.Services.AddScoped<InsertOrderDetailUseCase>();
builder.Services.AddScoped<UpdateOrderDetailUseCase>();
builder.Services.AddScoped<DeleteOrderDetailUseCase>();

builder.Services.AddScoped<GetAllProductsUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<GetProductsByMinimumPriceUseCase>();
builder.Services.AddScoped<GetMostExpensiveProductUseCase>();
builder.Services.AddScoped<GetAverageProductPriceUseCase>();
builder.Services.AddScoped<GetProductsWithoutDescriptionUseCase>();
builder.Services.AddScoped<GetProductsByOrderUseCase>();
builder.Services.AddScoped<GetProductsSoldToClientUseCase>();
builder.Services.AddScoped<InsertProductUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
