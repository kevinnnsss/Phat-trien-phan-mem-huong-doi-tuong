using EduHub.Domain.Entities;

namespace EduHub.Application.Interfaces;

public interface IEventRepository
{
    // TODO (Câu 3b):
    // Khai báo các phương thức:
    // void Add(Event ev);
    // Event? GetById(Guid id);
    // IEnumerable<Event> GetByClubId(Guid clubId);
    // bool Delete(Guid id);
    void Add(Event ev);
    Event? GetById(Guid id);
    IEnumerable<Event> GetByClubId(Guid clubId);
    bool Delete(Guid id);
}
