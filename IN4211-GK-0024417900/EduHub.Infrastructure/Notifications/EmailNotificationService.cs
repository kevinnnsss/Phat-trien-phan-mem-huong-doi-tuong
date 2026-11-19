using EduHub.Application.Interfaces;

namespace EduHub.Infrastructure.Notifications;

public class EmailNotificationService : INotificationService
{
    // TODO (Câu 3b):
    // Hiện thực Send(string message): in ra Console (Console.WriteLine)
    public void Send(string message)
    {
        Console.WriteLine($"[EMAIL SENT]: {message}");
    }
}
