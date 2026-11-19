using EduHub.Application.Interfaces;
using EduHub.Domain.Entities;

namespace EduHub.Infrastructure.Repositories;

public class InMemoryEventRepository : IEventRepository
{
    // TODO (Câu 3b & Câu 5d):
    // 1. Khai báo danh sách lưu trữ trong bộ nhớ: private readonly List<Event> _events = new();
    // 2. Hiện thực 4 phương thức của IEventRepository:
    //    - Add(Event ev)
    //    - GetById(Guid id)
    //    - GetByClubId(Guid clubId)
    //    - Delete(Guid id)
    private readonly List<Event> _events = new();
    public void Add(Event ev)
    {
        _events.Add(ev);
    }
    public Event? GetById(Guid id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }
    public IEnumerable<Event> GetByClubId(Guid clubId)
    {
        return _events.Where(e => e.ClubId == clubId).ToList();
    }
    public bool Delete(Guid id)
    {
        var ev = GetById(id);
        if (ev == null) return false;
        return _events.Remove(ev);
    }
}
