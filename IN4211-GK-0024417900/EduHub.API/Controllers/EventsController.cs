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
}
