using System.Text.Json;
using Example.MondayCom.Webhooks.App.DbContexts;
using kr.bbon.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var apiVersion = new ApiVersion(1, 0);

var builder = WebApplication.CreateBuilder(args);

var defaultConnectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.ConfigureAppOptions();
builder.Services.AddOptions<JsonSerializerOptions>()
    .Configure(options =>
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services
    .AddDbContext<AppDbContext>(builder =>
    {
        builder.UseSqlServer(defaultConnectionString, options =>
        {
            options.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
        });
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningAndSwaggerGen(apiVersion);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwaggerUIWithApiVersioning();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
