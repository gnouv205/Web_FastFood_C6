using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_Food_Shared.Models
{
    public class DanhMucSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDanhMuc { get; set; }

        [Required]
<<<<<<< HEAD:Web_food_Asm/Models/DanhMucSanPham.cs
        public string TenDanhMuc { get; set; }
=======
        public string? TenDanhMuc { get; set; }
>>>>>>> 7b1c485 (Update View Blazor):Web_Food_Shared/Models/DanhMucSanPham.cs

        [JsonIgnore] // Ngăn lỗi vòng lặp JSON
        public ICollection<SanPham>? SanPhams { get; set; } = new List<SanPham>(); // Khởi tạo mặc định
    }
}
