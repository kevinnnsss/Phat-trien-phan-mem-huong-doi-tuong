namespace EduHub.Ch01.Domain;

/// <summary>Phiếu đăng ký của Member cho Event (bảng nối M:N).</summary>
public static class RegistrationStatus
{
    // TODO: Guid Id, Guid MemberId, Guid EventId, DateTime RegisteredAt, string Status (private set)
    // TODO: hằng số cho Status: "Pending" / "Confirmed" / "Cancelled" (static class hoặc const) — không dùng magic string
    public const string Pending = "Peding";
    public const string Confimed = "Confimed";
    public const string Cancelled = "Cancelled";
    // TODO: constructor PRIVATE + public static Registration Create(Guid memberId, Guid eventId)
    //       → Status khởi tạo = Pending

    // TODO: public void Confirm() — chỉ hợp lệ khi Pending, sai thì throw InvalidOperationException
    // TODO: public void Cancel()  — hợp lệ khi Pending/Confirmed; đã Cancelled thì throw
}
public class Registration
{
    public Guid Id { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAT { get; private set; }
    public string Status { get; private set; }

    private Registration(Guid memberId, Guid eventId)
    {
        Id = Guid.NewGuid();
        MemberId = memberId;
        RegisteredAT = DateTime.UtcNow;
        Status = RegistrationStatus.Pending;
    }
    public static Registration Create(Guid memberId, Guid evnetId)
    {
        if (memberId == Guid.Empty) throw new ArgumentException("thiếu memberId. ", nameof(memberId));
        if (eventId == Guid.Empty) throw new ArgumentException("Thiếu eventId.", nameof(EventId));
        return new Registration(memberId, evnetId);
    }
    public void Confim()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InsufficientExecutionStackException($"Khong the xac nhan trang thai {static}.");
        Status = RegistrationStatus.Confimed;
    }
    public void Canel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InsufficientExecutionStackException("Phieu da duocj huy truoc do.");
        Status = RegistrationStatus.Cancelled;
    }
}
