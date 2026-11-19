using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Domain.Entities;
using Moq;

namespace EduHub.Tests;

public class EventServiceTests
{
    // TODO (Câu 3c):
    // Viết một unit test cho EventService, dùng Moq giả lập IEventRepository và INotificationService:
    // - Mock IEventRepository và INotificationService (cùng INotificationFactory)
    // - Gọi eventService.CreateEvent(...) với dữ liệu hợp lệ
    // - Kiểm tra repo.Add(...) và notifier.Send(...) đều được gọi đúng một lần (Times.Once)
}
