namespace EduHub.Domain.Entities;

public class Event
{
    // TODO (Câu 3b):
    // 1. Các thuộc tính Id, ClubId, Title, Date, Capacity (chỉ gán bên trong lớp)
    // 2. Constructor private
    // 3. Factory method Event.Create(Guid clubId, string title, DateTime date, int capacity):
    //    - Kiểm tra tiêu đề không rỗng (ném ArgumentException)
    //    - Kiểm tra sức chứa lớn hơn 0 (ném ArgumentException)
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }

    private Event(Guid id, Guid clubId, string title, DateTime date, int capacity)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
    }
    // Factory method kiểm tra tiêu đề không rỗng và sức chứa > 0
    public static Event Create(Guid clubId, string title, DateTime date, int capacity)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than 0.", nameof(capacity));
        return new Event(Guid.NewGuid(), clubId, title, date, capacity);
    }

}
