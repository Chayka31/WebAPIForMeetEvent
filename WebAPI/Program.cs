using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ПОЛУЧАЕМ СТРОКУ ПОДКЛЮЧЕНИЯ ИЗ APPSETTINGS
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ЛОГИРУЕМ ДЛЯ ПРОВЕРКИ (временно)
Console.WriteLine($"🔌 Строка подключения: {connectionString}");

// Добавляем DbContext с MySQL
builder.Services.AddDbContext<MeetEventDBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    // Для отладки - видеть SQL запросы в консоли
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddScoped<IMeetEventService, MeetEventService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS для MAUI
builder.Services.AddCors(options =>
{
    options.AddPolicy("MauiApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// СОЗДАЕМ БАЗУ ДАННЫХ АВТОМАТИЧЕСКИ
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<MeetEventDBContext>();

        // Проверяем подключение
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("✅ Подключение к MySQL успешно!");

            // Создаем базу если её нет
            dbContext.Database.EnsureCreated();
            Console.WriteLine("✅ База данных проверена/создана");
        }
        else
        {
            Console.WriteLine("❌ Не удалось подключиться к MySQL");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Ошибка при инициализации БД: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MauiApp");
app.UseAuthorization();
app.MapControllers();

app.Run();