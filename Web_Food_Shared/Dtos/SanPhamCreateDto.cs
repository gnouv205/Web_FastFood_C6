namespace Web_Food_Shared.Dtos
{
	public class SanPhamCreateDto
	{
		public int MaSanPham { get; set; }             
		public string? TenSanPham { get; set; }
		public decimal Gia { get; set; }
		public int SoLuong { get; set; }
		public int MaDanhMuc { get; set; }
		public string TenDanhMuc { get; set; } = string.Empty;
		public string? MoTa { get; set; }
		public DateTime NgayTao { get; set; }
		public DateTime NgayCapNhat { get; set; }
		public string? HinhAnh { get; set; }
	}
}
