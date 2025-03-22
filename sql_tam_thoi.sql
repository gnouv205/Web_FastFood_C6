CREATE DATABASE asm_c6_tamThoi;
GO

USE asm_c6_tamThoi;
GO

-- Bảng quản lý thông tin khách hàng
CREATE TABLE KhachHang (
    Id NVARCHAR(450) PRIMARY KEY, -- Mã khách hàng (UUID hoặc GUID)
    HoTen NVARCHAR(100) NOT NULL, -- Họ và tên khách hàng
    Hinh NVARCHAR(MAX) NOT NULL, -- Đường dẫn ảnh đại diện khách hàng
    DiaChi NVARCHAR(MAX) NOT NULL, -- Địa chỉ khách hàng
    TinhTrang NVARCHAR(50) NOT NULL DEFAULT 'Hoạt động' -- Trạng thái tài khoản (Hoạt động, Bị khóa, ...)
);

-- Bảng quản lý danh mục sản phẩm 
CREATE TABLE DanhMucSanPham (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY, -- Mã danh mục tự động tăng
    TenDanhMuc NVARCHAR(255) NOT NULL -- Tên danh mục
);

-- Bảng quản lý sản phẩm
CREATE TABLE SanPham (
    MaSanPham INT IDENTITY(1,1) PRIMARY KEY, -- Mã sản phẩm tự động tăng
    TenSanPham NVARCHAR(255) NOT NULL, -- Tên sản phẩm
    HinhAnh NVARCHAR(MAX) NOT NULL, -- Đường dẫn ảnh sản phẩm
    MoTa NVARCHAR(400) NOT NULL, -- Mô tả chi tiết sản phẩm
    Gia DECIMAL(18,2) NOT NULL CHECK (Gia >= 0), -- Giá sản phẩm (>= 0)
    SoLuong INT NOT NULL CHECK (SoLuong >= 0), -- Số lượng tồn kho
    DanhMuc INT NOT NULL, -- Mã danh mục (liên kết với DanhMucSanPham)
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo sản phẩm
    NgayCapNhat DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày cập nhật sản phẩm
    FOREIGN KEY (DanhMuc) REFERENCES DanhMucSanPham(MaDanhMuc) -- Liên kết với bảng DanhMucSanPham
);

-- Bảng lưu sản phẩm yêu thích của khách hàng
CREATE TABLE SanPhamYeuThich (
    MaYeuThich INT IDENTITY(1,1) PRIMARY KEY, -- Mã yêu thích tự động tăng
    Id NVARCHAR(450) NOT NULL, -- Mã khách hàng (liên kết với KhachHang)
    MaSanPham INT NOT NULL, -- Mã sản phẩm yêu thích
    FOREIGN KEY (Id) REFERENCES KhachHang(Id),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Bảng giỏ hàng, lưu các sản phẩm khách hàng thêm vào giỏ
CREATE TABLE GioHang (
    MaGioHang INT IDENTITY(1,1) PRIMARY KEY, -- Mã giỏ hàng tự động tăng
    Id NVARCHAR(450) NOT NULL, -- Mã khách hàng (liên kết với KhachHang)
    MaSanPham INT NOT NULL, -- Mã sản phẩm trong giỏ
    SoLuong INT NOT NULL CHECK (SoLuong > 0), -- Số lượng sản phẩm
    TongTien DECIMAL(18,2) NOT NULL, -- Tổng tiền của sản phẩm trong giỏ (SoLuong × Gia)
    FOREIGN KEY (Id) REFERENCES KhachHang(Id),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Bảng quản lý đơn đặt hàng của khách hàng
CREATE TABLE DonDatHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY, -- Mã đơn hàng tự động tăng
    Id NVARCHAR(450) NOT NULL, -- Mã khách hàng đặt hàng
    NgayDat DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày đặt hàng
    TrangThai NVARCHAR(50) NOT NULL DEFAULT 'Đang xử lý', -- Trạng thái đơn hàng (Đang xử lý, Đã thanh toán, Đã giao)
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0, -- Tổng tiền của đơn hàng
    FOREIGN KEY (Id) REFERENCES KhachHang(Id) -- Liên kết với KhachHang
);

-- Bảng chi tiết đơn hàng, chứa thông tin từng sản phẩm trong đơn hàng
CREATE TABLE ChiTietDonDatHang (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY, -- Mã chi tiết đơn hàng
    MaDonHang INT NOT NULL, -- Mã đơn hàng
    MaSanPham INT NOT NULL, -- Mã sản phẩm
    SoLuong INT NOT NULL CHECK (SoLuong > 0), -- Số lượng sản phẩm
    Gia DECIMAL(18,2) NOT NULL, -- Giá tại thời điểm đặt hàng (lưu lịch sử giá)
    NgayGiao DATETIME NULL, -- Ngày giao hàng (có thể NULL nếu chưa giao)
    NgayNhan DATETIME NULL, -- Ngày khách nhận hàng (có thể NULL)
    NgayThanhToan DATETIME NULL, -- Ngày thanh toán (có thể NULL nếu chưa thanh toán)
    TrangThai NVARCHAR(50) NOT NULL DEFAULT 'Đang xử lý', -- Trạng thái đơn hàng (Đang xử lý, Đang giao, Đã giao)
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0, -- Tổng tiền của sản phẩm trong đơn hàng
    FOREIGN KEY (MaDonHang) REFERENCES DonDatHang(MaDonHang),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Bảng quản lý thanh toán
CREATE TABLE ThanhToan (
    MaThanhToan INT IDENTITY(1,1) PRIMARY KEY, -- Mã thanh toán tự động tăng
    MaDonHang INT NOT NULL, -- Mã đơn hàng cần thanh toán
    SoTien DECIMAL(18,2) NOT NULL CHECK (SoTien >= 0), -- Số tiền thanh toán
    PhuongThuc NVARCHAR(100) NOT NULL DEFAULT 'MoMo', -- Phương thức thanh toán (MoMo, VNPay, Tiền mặt, ...)
    TrangThai NVARCHAR(50) NOT NULL DEFAULT 'Chưa thanh toán', -- Trạng thái thanh toán (Chưa thanh toán, Đã thanh toán)
    NgayThanhToan DATETIME NULL, -- Ngày thanh toán (có thể NULL nếu chưa thanh toán)
    FOREIGN KEY (MaDonHang) REFERENCES DonDatHang(MaDonHang),
    CHECK (
        (TrangThai = 'Chưa thanh toán' AND NgayThanhToan IS NULL) OR
        (TrangThai = 'Đã thanh toán' AND NgayThanhToan IS NOT NULL)
    ) -- Ràng buộc: Nếu chưa thanh toán thì NgayThanhToan phải NULL
);
