using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Infrastructure.Notifications;
using EduHub.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO (Câu 5d):
// Đăng ký Dependency Injection:
// - IEventRepository -> InMemoryEventRepository (Lưu ý: đăng ký Singleton theo Câu 5d để tránh mất dữ liệu)
// - INotificationFactory -> NotificationFactory
// - EventService -> AddScoped
// Đăng ký Singleton để không bị mất dữ liệu in-memory giữa các request (Câu 5d)
builder.Services.AddSingleton<IEventRepository, InMemoryEventRepository>();
builder.Services.AddSingleton<INotificationFactory, NotificationFactory>();
builder.Services.AddScoped<EventService>();

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
