namespace EduHub.Domain.Entities;

// Đoạn mã 1 ban đầu trong đề (chưa đóng gói):
// public class Member
// {
//     public Guid Id { get; set; }
//     public string Email { get; set; }
//     public Member() { }

// }

public class Member
{
    // TODO (Câu 1b):
    // 1. Viết lại các thuộc tính Id và Email được đóng gói (không cho phép gán đè từ bên ngoài)
    // 2. Constructor private
    // 3. Factory method public static Member Create(string email) kiểm tra email không rỗng và có ký tự @
   
        public Guid Id { get; private set; }
        public string Email { get; private set; }

        private Member(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
        public static Member Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            if (!email.Contains('@'))
                throw new ArgumentException("Email must contain '@'.", nameof(email));
            return new Member(Guid.NewGuid(), email);
        }
 }


