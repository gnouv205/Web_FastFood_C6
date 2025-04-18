using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Food_Shared.Dtos
{
	public class SanPhamDtos
	{
		public int maSanPham { get; set; }  // Phải viết thường giống JSON
		public string tenSanPham { get; set; }
		public string hinhAnh { get; set; }  // Viết thường
		public string moTa { get; set; }
		public decimal gia { get; set; }
		public int soLuong { get; set; }
		public int maDanhMuc { get; set; }
		public DateTime ngayTao { get; set; }
		public DateTime ngayCapNhat { get; set; }
	}
}
