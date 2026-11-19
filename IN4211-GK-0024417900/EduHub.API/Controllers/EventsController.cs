using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.API.Controllers;

[ApiController]
public class EventsController : ControllerBase
{
    // TODO (Câu 5c):
    // 1. Inject IEventRepository và EventService qua constructor
    // 2. Viết 4 endpoints theo yêu cầu:
    //    - GET /api/clubs/{clubId}/events : Lấy danh sách sự kiện của CLB (200 OK)
    //    - GET /api/events/{id}           : Xem một sự kiện theo Id (200 OK hoặc 404 Not Found)
    //    - POST /api/clubs/{clubId}/events: Tạo sự kiện mới cho CLB (201 Created hoặc 400 Bad Request)
    //    - DELETE /api/events/{id}        : Xoá một sự kiện (204 NoContent hoặc 404 Not Found)
    private readonly IEventRepository _eventRepository;
    private readonly EventService _eventService;
    public EventsController(IEventRepository eventRepository, EventService eventService)
    {
        _eventRepository = eventRepository;
        _eventService = eventService;
    }
    // 1. GET /api/clubs/{clubId}/events : Lấy danh sách sự kiện của CLB
    [HttpGet("api/clubs/{clubId:guid}/events")]
    public IActionResult GetEventsByClub(Guid clubId)
    {
        var events = _eventRepository.GetByClubId(clubId);
        return Ok(events);
    }
    // 2. GET /api/events/{id} : Xem một sự kiện theo Id
    [HttpGet("api/events/{id:guid}", Name = "GetEventById")]
    public IActionResult GetEventById(Guid id)
    {
        var ev = _eventRepository.GetById(id);
        if (ev == null)
            return NotFound(new { message = $"Event with id {id} not found." });
        return Ok(ev);
    }
    // Model nhận dữ liệu tạo sự kiện
    public record CreateEventRequest(string Title, DateTime Date, int Capacity, string Channel);
    // 3. POST /api/clubs/{clubId}/events : Tạo sự kiện mới cho CLB
    [HttpPost("api/clubs/{clubId:guid}/events")]
    public IActionResult CreateEvent(Guid clubId, [FromBody] CreateEventRequest request)
    {
        try
        {
            var createdEvent = _eventService.CreateEvent(
                clubId,
                request.Title,
                request.Date,
                request.Capacity,
                request.Channel
            );
            return CreatedAtRoute("GetEventById", new { id = createdEvent.Id }, createdEvent);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    // 4. DELETE /api/events/{id} : Xoá một sự kiện
    [HttpDelete("api/events/{id:guid}")]
    public IActionResult DeleteEvent(Guid id)
    {
        var deleted = _eventRepository.Delete(id);
        if (!deleted)
            return NotFound(new { message = $"Event with id {id} not found." });
        return NoContent();
    }
}
