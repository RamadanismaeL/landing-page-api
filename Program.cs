using landing_page_api.src.configs;
using landing_page_api.src.data;
using landing_page_api.src.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var username = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER is not set");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD is not set");
var port = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new InvalidOperationException("DB_PORT is not set");
var server = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new InvalidOperationException("DB_SERVER is not set");
Console.WriteLine($"user: {username}\npassword: {password}\nport: {port}\nserver: {server}");
string? connect = $"server={server}; port={port}; database=dbLandingPage; user={username}; password={password}; Persist Security Info=false; Connect Timeout=300";

builder.Services.AddDbContextPool<Contextdb>(ram => ram.UseMySql(connect, ServerVersion.AutoDetect(connect)));
builder.Services.AddScoped<IClientConfig, ClientConfig>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();