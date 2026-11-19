namespace EduHub.Application.Interfaces;

public interface INotificationFactory
{
    // TODO (Câu 3b):
    // Khai báo phương thức:
    // INotificationService GetService(string channel);
    INotificationService GetService(string channel);
}
