# Sơ đồ lớp sơ bộ — EduHub

Vẽ bằng Mermaid (hiển thị trực tiếp trên GitHub) hoặc xuất ảnh từ draw.io rồi đặt cạnh file này.
Ghi rõ thuộc tính chính, khoá ngoại (FK) và bội số quan hệ (1, *, 0..1).

```mermaid
classDiagram
    class Club {
        +Guid Id
        +string Name
        +string Description
        +DateTime CreatedAt
        +IReadOnlyList~Member~ Members
        +AddMember(Member)
        +MemberCount() int
    }
    class Event {
        +Guid Id
        +Guid ClubId
         +string Title
        +DateTime Date
        +int Capacity
        +bool IsOnline
        +HasCapacity(int) bool
    }
     class Member {
        +Guid Id
        +string Name
        +string Email
        +string StudentCode
        +DateTime JoinedAt
        +MemberStatus Status
        +IsActive() bool
        +Deactivate()
    }
    class Registration {
        +Guid Id
        +Guid MemberId
        +Guid EventId
        +DateTime RegisteredAt
        +string Status
        +Confirm()
        +Cancel()
    }
    class CheckIn {
        +Guid Id
        +Guid RegistrationId
        +DateTime CheckedInAt
        +string Method
        +Summary() string
    }
    Club "1" --> "*" Event : tổ chức

    %% TODO: bổ sung Member, Registration, CheckIn, đủ thuộc tính, phương thức và các quan hệ còn lại
```
