# User Stories — EduHub

Viết ít nhất 5 User Story, đủ 3 vai trò (Sinh viên, Ban CLB, Admin).
Mỗi story có ít nhất 2 tiêu chí nghiệm thu (Given/When/Then hoặc gạch đầu dòng).

## US-01 · Sinh viên: <việc cần làm>

Là [vai trò], tôi muốn [việc cần làm], để [lợi ích].

- Tiêu chí 1: Given ... When ... Then ...
- Tiêu chí 2: Given ... When ... Then ...

<!-- TODO: thêm US-02 đến US-05 (hoặc nhiều hơn) -->
##USER STORY CỬA HÀNG LAPTOP
Đối với người dùng
    US-01 Đăng nhập tài khoản
        Chưa có tài khoản -> đăng kí -> đã có tài khoản
        Có tài khoản -> dăng nhập -> vô giao diện chính
        Có tài khoản -> quên mật khẩu -> tạo mật khẩu mới -> đăng nhập
    US-02 Tìm kiếm sản phẩm
        Nhập tên sản phẩm -> có sản phẩm trong kho -> hiện thông tin sản phẩm
        Nhập tên sản phẩm -> không có sản phẩm -> hiện”không có sản phẩm”
    US-03 Mua hàng
        Chọn sản phẩm -> chọn số lượng -> chọn phương thức thanh toán -> nhấn mua hàng
        Chọn sản phẩm -> chọn số lượng -> đã hết hàng
Đối với nhân viên
    US-04 Thêm sản phẩm mới 
        Tạo sản phẩm mới -> ghi thông tin sản phẩm mới -> thêm thành công
        Tạo sản phẩm mới -> ghi thông tin sản phẩm mới -> đã có mã sp -> thêm thất bại
    US-05 Tư vấn khách hàng
        Check tin nhắn chờ/ trả lời tin nhắn cho khách
Đối với Admin
    US-06 Quản lý tài khoản người dùng
        Xóa tài khoản -> chọn tài khoản -> xóa tk thành công
        Xóa tài khoản -> chưa chọn tài khoản -> xóa thất bại
    US-07 Xem doanh thu
        Xem doanh thu theo ngày/tháng/ năm
        Xem doanh thu theo sản phẩm 
