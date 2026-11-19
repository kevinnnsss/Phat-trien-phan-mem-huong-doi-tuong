using EduHub.Domain.Enums;

namespace EduHub.Domain.Entities;

public class Registration
{
    // 1. Các thuộc tính chỉ được sửa bên trong lớp (private set)
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public RegistrationStatus Status { get; private set; }

    // 2. Constructor private để bắt buộc khởi tạo qua Factory Method
    private Registration(Guid id, Guid memberId, Guid eventId, DateTime registeredAt, RegistrationStatus status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    // 3. Factory method Create
    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("MemberId cannot be empty.", nameof(memberId));

        if (eventId == Guid.Empty)
            throw new ArgumentException("EventId cannot be empty.", nameof(eventId));

        return new Registration(Guid.NewGuid(), memberId, eventId, DateTime.UtcNow, RegistrationStatus.Pending);
    }

    // 4. Phương thức Confirm: chỉ Pending mới được xác nhận
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException($"Cannot confirm registration with status '{Status}'. Only Pending registrations can be confirmed.");

        Status = RegistrationStatus.Confirmed;
    }

    // 5. Phương thức Cancel: Pending hoặc Confirmed đều huỷ được, đã huỷ thì không được huỷ lại
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException("Registration is already cancelled.");

        Status = RegistrationStatus.Cancelled;
    }
}