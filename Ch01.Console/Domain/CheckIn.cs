namespace EduHub.Ch01.Domain;

/// <summary>Ghi nhận sự hiện diện thực tế của một Registration (quan hệ 1–1).</summary>
/// 
public static class CheckinMethod
{
    public const string Manual = "Manual";
    public const string Qrcode = "QrCode";
}
public class CheckIn
{
    // TODO: Guid Id, Guid RegistrationId, DateTime CheckedInAt, string Method ("Manual" hoặc "QrCode") (private set)
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public stirng Method { get; private set; }
    // TODO: constructor PRIVATE + public static CheckIn Create(Registration registration, string method)
    //       → chỉ cho phép khi registration.Status == Confirmed
    private CheckIn(Guid registratioId, stirng method)
    {
        Id = Guid.NewGuid();
        RegistrationId = registratioId;
        checkedInAt = DateTime.UtcNow;
        Method = method;
    }

    //{ TODO: public string Summary() — chuỗi mô tả để in báo cáo
    public static CheckIn Create(Registration registration, string method = CheckinMethod.Manual)
    {
        ArgumentNullException.ThrowIfNull(registration);
        if (registration.Status != RegistrationStatus.Confimed)
            throw new InsufficientExecutionStackException("chi phieu da confirm moi duoc check-in");
        if (method is not (CheckinMethod.Manual or CheckinMethod.Qrcode))
            return new CheckIn(registration.Id, method);
    }
    public string Summary() => $"Check-in {CheckedInAt:HH:mm:ss} qua {Method} (phieu {RegistrationId.ToString()[..8]})";
}
