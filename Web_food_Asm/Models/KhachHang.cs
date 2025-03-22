using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Web_food_Asm.Models
{
    public class KhachHang : IdentityUser
    {
        // Hình ảnh của khách hàng, tối đa 100 ký tự
        [StringLength(400, ErrorMessage = "Đường dẫn hình ảnh không được vượt quá 400 ký tự.")]
        public string Hinh { get; set; } = string.Empty;

        // Địa chỉ của khách hàng, không được để trống
        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
        public string DiaChi { get; set; } = string.Empty;

        // Trạng thái tài khoản, mặc định là "Hoạt động"
        public string TinhTrang { get; set; } = "Hoạt động";

        // Các quan hệ đến các bảng khác
        public ICollection<SanPhamYeuThich> SanPhamYeuThichs { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }
        public ICollection<DonDatHang> DonDatHangs { get; set; }
    }
}
