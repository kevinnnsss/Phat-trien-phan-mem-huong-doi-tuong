namespace EduHub.Ch01.Domain;

/// <summary>Câu lạc bộ sinh viên.</summary>
public class Club
{
    // TODO: Guid Id, string Name, string Description, DateTime CreatedAt  (private set)
    private readonly List<Member> _members = [];

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<Member> Members => _members;

    private Club(string name, string descriptio)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = descriptio;
        CreatedAt = DateTime.UtcNow;
    }
     public static Club Create(String name, string descriptio)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Teen CLB không được để trống. ", nameof(name));

        return new Club(name.Trim(), descriptio?.Trim() ?? string.Empty);
    }
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);
        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException($"{member} đã là thành viên của {Name}");

        _members.Add(member);
    }
    // TODO: danh sách thành viên: field private List<Member> + property IReadOnlyList<Member> Members
    //       (bên ngoài không được .Add() trực tiếp — phải đi qua AddMember)
    public int MemberCount() => _members.Count;

    // TODO: constructor PRIVATE + public static Club Create(string name, string description)
    // TODO: public void AddMember(Member member) — chặn null và thành viên trùng
    // TODO: public int MemberCount()
}
