#nullable enable
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite("Data Source=products.db"));

// Исправление: добавляем порт клиента (5284) и его HTTPS-версию (7243)
builder.Services.AddCors(opt => opt.AddPolicy("AllowWasm", p => 
    p.WithOrigins("http://localhost:5284", "https://localhost:7243")
     .AllowAnyHeader()
     .AllowAnyMethod()));

var app = builder.Build();

app.UseCors("AllowWasm"); // Строго перед MapControllers
// app.UseHttpsRedirection(); // Отключено для локальной разработки (HTTP -> HTTP)
app.MapControllers();
app.Run();