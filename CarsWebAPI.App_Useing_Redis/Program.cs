using CarsWebAPI.App_Useing_Redis.Caching;
using CarsWebAPI.App_Useing_Redis.CarService;
using CarsWebAPI.App_Useing_Redis.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");

var redisConnection = builder.Configuration.GetConnectionString("Redis");


builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var config = ConfigurationOptions.Parse(redisConnection!);
    config.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(config);
});

builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
