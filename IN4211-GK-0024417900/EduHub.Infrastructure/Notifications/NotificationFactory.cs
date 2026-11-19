using EduHub.Application.Interfaces;

namespace EduHub.Infrastructure.Notifications;

public class NotificationFactory : INotificationFactory
{
    // TODO (Câu 3b):
    // Cài đặt GetService(string channel):
    // - channel "email" -> trả về new EmailNotificationService()
    // - channel "sms"   -> trả về new SmsNotificationService()
    // - khác            -> ném ArgumentException
    public INotificationService GetService(string channel)
    {
        return channel.ToLower() switch
        {
            "email" => new EmailNotificationService(),
            "sms" => new SmsNotificationService(),
            _ => throw new ArgumentException($"Channel '{channel}' is not supported.")
        };
    }
}
