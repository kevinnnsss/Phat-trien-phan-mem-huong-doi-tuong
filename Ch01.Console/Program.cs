using EduHub.Ch01.Domain;
using System.Text;
Console.OutputEncoding=Encoding.UTF8;
Console.InputEncoding=Encoding.UTF8;

// ═══════════════════════════════════════════════════════════════
//  EduHub Ch01 — Console demo (luồng nghiệp vụ đầy đủ)
    const string Separator = "============================= ";
    const int EventCapactity = 50;
//  Dùng hằng số cho separator, KHÔNG hardcode chuỗi lặp lại.
// ═══════════════════════════════════════════════════════════════
    
Console.WriteLine("=== EduHub — Club & Event Management ===");
static void Step(int number, string title) => Console.WriteLine($"\n{Separator}\n Bước {number}");

// TODO 1: Tạo CLB "Tech Club" với mô tả phù hợp         → Club.Create(...)
Step(1, "TẠO CÂU LẠC BỘ");
//var club = Club.Create("Tech Club", "Câu lạc bộ công nghệ: workshop, hackathon, chia sẻ kiến thức.");

// TODO 2: Tạo 3 Member, thêm vào CLB                      → Member.Create(...), club.AddMember(...)
// TODO 3: Tạo sự kiện "Workshop AI", capacity = 50        → Event.Create(club.Id, ...)
// TODO 4: 2 Member đăng ký (kiểm tra HasCapacity) → Pending → gọi Confirm()
// TODO 5: 1 Member check-in                               → CheckIn.Create(registration, ...)
// TODO 6: In báo cáo tham dự: số đăng ký, số check-in, danh sách tên

Console.WriteLine("\n✅ Demo complete!");
