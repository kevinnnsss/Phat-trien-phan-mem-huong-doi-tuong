using EduHub.Domain.Entities;
using EduHub.Domain.Enums;

namespace EduHub.Tests;

public class RegistrationTests
{
    // TODO (Câu 2c):
    // Viết ít nhất ba unit test cho Registration:
    // 1. Test tạo mới Registration thành công với trạng thái Pending.
    // 2. Test Confirm() khi đang Pending chuyển sang Confirmed thành công.
    // 3. Test BẮT BUỘC theo đề bài:
    //    var r = Registration.Create(memberId, eventId);
    //    r.Cancel();
    //    r.Confirm(); // kiểm tra ném InvalidOperationException và r.Status vẫn là Cancelled.
     [Fact]
    public void Create_ValidParameters_ShouldHavePendingStatus()
    {
        // 1. Arrange (Chuẩn bị dữ liệu)
        var memberId = Guid.NewGuid();
        var eventId = Guid.NewGuid();
        // 2. Act (Thực hiện hành động)
        var registration = Registration.Create(memberId, eventId);
        // 3. Assert (Khẳng định kết quả)
        Assert.NotNull(registration);
        Assert.Equal(memberId, registration.MemberId);
        Assert.Equal(eventId, registration.EventId);
        Assert.Equal(RegistrationStatus.Pending, registration.Status);
    }
    // =========================================================================
    // TEST 2: Kiểm tra khi đang Pending, gọi Confirm() thì chuyển sang Confirmed
    // =========================================================================
    [Fact]
    public void Confirm_WhenStatusIsPending_ShouldChangeToConfirmed()
    {
        // 1. Arrange
        var registration = Registration.Create(Guid.NewGuid(), Guid.NewGuid());
        // 2. Act
        registration.Confirm();
        // 3. Assert
        Assert.Equal(RegistrationStatus.Confirmed, registration.Status);
    }
    // =========================================================================
    // TEST 3 (BẮT BUỘC THEO ĐỀ BÀI):
    // Đã huỷ (Cancel) mà cố xác nhận (Confirm) thì phải ném lỗi và giữ nguyên Cancelled
    // =========================================================================
    [Fact]
    public void Confirm_WhenStatusIsCancelled_ShouldThrowInvalidOperationExceptionAndRemainCancelled()
    {
        // 1. Arrange
        var memberId = Guid.NewGuid();
        var eventId = Guid.NewGuid();
        // Dòng 1: Tạo phiếu mới
        var r = Registration.Create(memberId, eventId);
        // Dòng 2: Huỷ phiếu -> Trạng thái thành Cancelled
        r.Cancel();
        // 2 & 3. Act & Assert:
        // Kiểm tra Dòng 3: r.Confirm() phải ném ra ngoại lệ InvalidOperationException
        Assert.Throws<InvalidOperationException>(() => r.Confirm());
        // Kiểm tra sau khi ném lỗi, r.Status vẫn phải là Cancelled (không bị thay đổi bậy)
        Assert.Equal(RegistrationStatus.Cancelled, r.Status);
    }

}
