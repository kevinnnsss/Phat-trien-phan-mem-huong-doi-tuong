using EduHub.Application.Interfaces;

namespace EduHub.Infrastructure.Notifications;

public class SmsNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"[SMS SENT]: {message}");
    }
}
