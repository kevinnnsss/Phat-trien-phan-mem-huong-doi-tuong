using EduHub.Application.Interfaces;
using EduHub.Domain.Entities;

namespace EduHub.Application.Services;

public class EventService
{
    // TODO (Câu 3b):
    // 1. Khai báo các dependency: IEventRepository, INotificationFactory
    // 2. Nhận các phụ thuộc qua constructor (Dependency Injection), không còn new lớp cụ thể
    // 3. Viết phương thức CreateEvent(Guid clubId, string title, DateTime date, int capacity, string channel):
    //    - Tạo entity Event qua Event.Create(...)
    //    - Lưu qua repo.Add(newEvent)
    //    - Lấy notifier từ factory theo channel và gọi notifier.Send(...)
    private readonly IEventRepository _eventRepository;
    private readonly INotificationFactory _notificationFactory;
    // Tiêm các phụ thuộc (Dependency Injection)
    public EventService(IEventRepository eventRepository, INotificationFactory notificationFactory)
    {
        _eventRepository = eventRepository;
        _notificationFactory = notificationFactory;
    }
    public Event CreateEvent(Guid clubId, string title, DateTime date, int capacity, string channel)
    {
        // 1. Tạo entity bằng factory method (tự động kiểm tra hợp lệ)
        var newEvent = Event.Create(clubId, title, date, capacity);
        // 2. Lưu vào repository
        _eventRepository.Add(newEvent);
        // 3. Gửi thông báo thông qua Factory chọn kênh
        var notifier = _notificationFactory.GetService(channel);
        notifier.Send($"Sự kiện mới: {title}");
        return newEvent;
    }
}
