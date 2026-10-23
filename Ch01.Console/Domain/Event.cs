namespace EduHub.Ch01.Domain;

/// <summary>Sự kiện do câu lạc bộ tổ chức.</summary>
public class Event
{
    // TODO: Guid Id, Guid ClubId, string Title, DateTime Date, int Capacity, bool IsOnline (private set)
    public Guid Id { get; private set; }

    public Guid ClubId { get; private set; }

    public string Title { get; private set; }

    public DateTime Date { get; private set; }

    public int Capacity { get; private set; }

    public bool IsOnline { get; private set; }
    // TODO: constructor PRIVATE + public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isOnline = false)
    //       → validate: title không trống, capacity > 0
    private Event(Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        Id = Guid.NewGuid();
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }
    ///<summary>Tạo sự kiện mới.</summary>
       ///<exception cref="ArgmentException">Tiêu đề trống hoặc sức chứa không dương,</exception>
    public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isOnl = false)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentNullException("Sự kiện phải thuộc một CLB.", nameof(clubId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("tiêu đề không được để trống", nameof(title));
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "sức chứa phải lớn hơn 0");
        return new Event(clubId, title.Trim(), date, capacity, isOnl);
    }
    // TODO: public bool HasCapacity(int registeredCount) — true nếu registeredCount < Capacity
    public bool HasCapacity(int registeredCount) => registeredCount < Capacity;
}
