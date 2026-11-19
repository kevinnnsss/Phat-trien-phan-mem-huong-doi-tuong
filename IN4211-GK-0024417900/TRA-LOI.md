# BÀI LÀM LÝ THUYẾT ĐỀ SỐ 02

## Câu 1a
<!-- Nêu tên và giải thích ngắn gọn bốn trụ cột của lập trình hướng đối tượng. Với mỗi trụ cột, chỉ ra một chỗ trong code bài làm của em minh hoạ cho trụ cột đó (tên tệp và tên lớp) -->
1. **Tính đóng gói (Encapsulation):**
   - *Giải thích:* Che giấu dữ liệu nội bộ và các chi tiết cài đặt của đối tượng, chỉ cho phép truy cập và sửa đổi trạng thái thông qua các phương thức công khai hợp lệ.
   - *Minh hoạ trong code:* Lớp `Member` trong tệp `Member.cs` (Project `EduHub.Domain`) đóng gói các thuộc tính với `private set`, ẩn constructor mặc định và chỉ cho phép khởi tạo qua factory method `Create(...)`.
2. **Tính trừu tượng (Abstraction):**
   - *Giải thích:* Tập trung vào những đặc tính và hành vi cốt lõi của đối tượng cần thiết cho hệ thống, ẩn đi các chi tiết triển khai phức tạp bên dưới.
   - *Minh hoạ trong code:* Interface `IEventRepository` trong tệp `IEventRepository.cs` (Project `EduHub.Application`) định nghĩa các thao tác lưu trữ sự kiện mà không cần quan tâm dữ liệu được lưu trong bộ nhớ, SQL hay NoSQL.
3. **Tính kế thừa (Inheritance):**
   - *Giải thích:* Cho phép một lớp con tái sử dụng hoặc mở rộng các thuộc tính và phương thức từ một lớp cha (hoặc hiện thực hoá giao diện).
   - *Minh hoạ trong code:* Lớp `InMemoryEventRepository` kế thừa và hiện thực giao diện `IEventRepository` trong tệp `InMemoryEventRepository.cs` (Project `EduHub.Infrastructure`).
4. **Tính đa hình (Polymorphism):**
   - *Giải thích:* Khả năng các đối tượng khác nhau có thể phản hồi cùng một thông điệp (gọi cùng phương thức) theo những cách khác nhau tùy thuộc vào kiểu thực tế của đối tượng lúc thực thi.
   - *Minh hoạ trong code:* Cùng giao diện `INotificationService`, khi gọi phương thức `Send(...)`, `EmailNotificationService` và `SmsNotificationService` xử lý theo cách riêng (Project `EduHub.Infrastructure`).

## Câu 1b
<!-- Ghi hai vấn đề về tính đóng gói của lớp Member ban đầu vào đây -->
Có 2 vấn đề của lớp Meber chưa đóng gói:**
1 Thuộc tính Id, Email có setter public (dòng 3,4), nên bên ngoài gán m.Email = "abc" dòng 9 được mà khong bị kiểm tra, làm dữ liệu sai hợp lệ hóa
2 Constructor public khong làm tham số dòng 5 cho phép tạo member ở trạng thái không hợp lệ (Email == null, Id = Guid.Empty), bỏ qua luaatj nghiệp vụ 
Cách khắc phục: setter private, constructor private, và tạo đối tượng qua factory method Member.Create(email) có kiểm tra email khong rỗng và chứa "@"

## Câu 2a
<!-- Vẽ sơ đồ trạng thái của Registration bằng Mermaid (stateDiagram-v2), ghi rõ tên phương thức trên mỗi mũi tên chuyển trạng thái -->

```mermaid
stateDiagram-v2
    [*] --> Pending : Create() "phiếu mới tạo là Pending"
    Pending --> Confirmed : Confirm() "chờ xác nhận "
    Pending --> Cancelled : Cancel() "nếu Pending hủy được"
    Confirmed --> Cancelled : Cancel() "confirmed hủy được"
    Cancelled --> [*] " đã hủy thì không đổi nữa"
```

## Câu 3a
<!-- Chỉ ra ba nguyên lý SOLID mà lớp EventService vi phạm. Với mỗi nguyên lý, ghi số dòng vi phạm và giải thích ngắn -->
1. S - Single Responsibility Principle (SRP - Nguyên lý đơn trách nhiệm)
số dòng vi phạm: Dòng 6-14
giải thích: Lớp EventService ôm quá nhiều trách nhiệm: vừa kiểm tra dữ liệu nghiệp vụ, vừa trực tiếp kết nối cơ sở dữ liệu qua sqlConnection, vừa ghi file log hệ thống, vừa phụ trahs logic gửi gmail và SMS. Một lớp chỉ nen có một lý do duy nhất để thay đổi.
2. O - Open/Closed Principle (OCP - Nguyên lý Đóng/Mở):
số dòng vi phạm: dòng 11-14
giải thích: sử dụng if (channel == "email")... else if (channer == "SMS")... gắn cứng. khi hệ thống muốn mở rộng thêm kênh thông báo mới (như Zalo, Telegram, Push Notification), ta bắt buộc phải sửa trực tiếp mã nguồn của lớp EventService, vi phạm nguyên tắc "đóng với việc sửa đổi, mở với việc mở rộng".
3. D - Dependency Inversion Principle (DIP - Nguyên lý đảo ngược phụ thuộc):
Số dòng vi phạm: Dòng 8, 12, 14.
Giải thích: Lớp cấp cao (EventService) phụ thuộc trực tiếp vào các lớp cụ thể cấp thấp (SqlConnection, EmailSender, SmsSender) qua từ khoá new, thay vì phụ thuộc vào các Abstraction (interface).
## Câu 4b
<!-- Phân biệt git merge và git rebase. Khi nào không nên dùng rebase? -->


## Câu 5a
<!-- Thiết lập tham chiếu giữa các project theo đúng chiều phụ thuộc của Clean Architecture bằng dotnet add reference.
Vẽ sơ đồ bốn lớp và chiều phụ thuộc, ghi rõ lớp nào chứa Event, IEventRepository, EventService, InMemoryEventRepository, EventsController -->


## Câu 5b
<!-- Giải thích vì sao project EduHub.Domain không được tham chiếu tới EduHub.Infrastructure -->


## Câu 5d
<!-- Nếu đăng ký InMemoryEventRepository bằng AddScoped và bên trong lưu dữ liệu vào một List<Event> thông thường (không static), thì gọi POST thành công nhưng ngay sau đó gọi GET lại nhận danh sách rỗng.
Giải thích nguyên nhân và ghi cách em đã đăng ký để tránh lỗi này -->

