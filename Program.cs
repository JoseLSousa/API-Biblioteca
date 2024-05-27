using APIBibliotecaCsharpNET.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}

// Adiciona o DbContext ao contêiner de injeção de dependência
var connectionString = builder.Configuration.GetConnectionString("MeuBD");
Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(connectionString));

// Adiciona controladores ao contêiner de injeção de dependência
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
