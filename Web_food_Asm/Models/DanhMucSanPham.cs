using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_food_Asm.Models
{
    public class DanhMucSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDanhMuc { get; set; }

        [Required]
        public string TenDanhMuc { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
