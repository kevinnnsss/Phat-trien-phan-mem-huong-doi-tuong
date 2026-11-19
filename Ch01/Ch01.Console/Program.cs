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
var club = Club.Create("Tech Club", "Cau lac bo cong nghe: workshop, hackthon, chia se kien thuc.");
Console.WriteLine($"CLB: {club.Name} - {club.Description}");
//var club = Club.Create("Tech Club", "Câu lạc bộ công nghệ: workshop, hackathon, chia sẻ kiến thức.");
Step(2, "them thanh vien");
var members = new[]
{
    Member.Create("Nguyễn Văn An", "an.nv@student.dthu.edu.vn", "DH24001"),
    Member.Create("Trần Thị Bình", "binh.tt@student.dthu.edu.vn", "DH24002"),
    Member.Create("Lê Hoàng Cường", "cuong.lh@student.dthu.edu.vn", "DH24003"),
};
foreach (var member in members)
{
    club.AddMember(member);
    Console.WriteLine($"+ {member}<{member.Email}>");
}
Console.WriteLine($"Tổng thành viên: {club.MemberCount()}");
// TODO 2: Tạo 3 Member, thêm vào CLB                      → Member.Create(...), club.AddMember(...)
// TODO 3: Tạo sự kiện "Workshop AI", capacity = 50        → Event.Create(club.Id, ...)
Step(3, "Tao su kien");
var workshop = Event.Create(club.Id, "Workshop AI ", DateTime.Today.AddDays(7).AddHours(14), EventCapactity);
Console.WriteLine($"Su kien: {workshop.Title} - {workshop.Date:dd/MM/yyyy HH:mm} - suc chua {workshop.Capacity}");

// TODO 4: 2 Member đăng ký (kiểm tra HasCapacity) → Pending → gọi Confirm()
Step(4, "Dang ki tham du");
var registrations = new List<Registration>();
foreach (var member in members.Take(2))
{
    if(!workshop.HasCapacity(registrations.Count))
    {
        Console.WriteLine($"! het cho, khong nhan {member}");
        continue;
    }
    var registration = Registration.Create(member.Id, workshop.Id);
    registrations.Add( registration );
    Console.WriteLine($"{member} dang ky -> {registration.Status}");
}
Step(5, "Xác nhận đăng ký");
foreach (var registration in registrations)
{
    registration.Confirm();
    Console.WriteLine($"Phiếu {registration.Id.ToString()[..8]} → {registration.Status}");
}
Step(6, "check-in");
var checkIns = new List<CheckIn> { CheckIn.Create(registrations[0], CheckInMethod.QrCode) };
Console.WriteLine(checkIns[0].Summary());
// TODO 5: 1 Member check-in                               → CheckIn.Create(registration, ...)
Step(7, "Bao cao tham du");
Console.WriteLine($"so dang ky: {registrations.Count}/{workshop.Capacity}");
Console.WriteLine($"So check-in: {checkIns.Count}");
var memberById = members.ToDictionary(m => m.Id);
foreach (var registration in registrations)
{
    var attended = checkIns.Any(c => c.RegistrationId == registration.Id);
    Console.WriteLine($"-{memberById[registration.MemberId].Name}: {(attended ? "da check-in": "chua check-in")}");
}
// TODO 6: In báo cáo tham dự: số đăng ký, số check-in, danh sách tên
Step(8, "Kiem tra quy tat nghiep vu");
registrations[1].Cancel();
try { registrations[1].Confirm(); }
catch (InvalidOperationException ex) { Console.WriteLine($"dung nhu mong doi {ex.Message}"); }

Console.WriteLine("\n✅ Demo complete!");
