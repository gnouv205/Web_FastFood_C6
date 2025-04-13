using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_food_Asm.Data;
using Web_Food_Shared.Dtos;
using Web_Food_Shared.Models;

namespace Web_food_Asm.Controllers
{
    [Route("api/admin/san-pham")]
    [ApiController]
    public class SanPhamAdminApiController : ControllerBase
    {
        private readonly ConnectStr _connectStr;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ConnectStr _context;

        public SanPhamAdminApiController(ConnectStr connectStr, IWebHostEnvironment webHostEnvironment)
        {
            _connectStr = connectStr;
            _webHostEnvironment = webHostEnvironment;
            _context = connectStr;
        }

        #region Danh Sách Sản Phẩm
        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm, có thể lọc theo danh mục, từ khóa tìm kiếm và trạng thái còn hàng.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(string? searchTerm = "", int? CategoryId = null, bool showOutOfStock = false, string? sort = "asc")
        {
            var products = await _connectStr.SanPhams
                .Include(sp => sp.DanhMucSanPham)
                .Where(sp =>
                    (!CategoryId.HasValue || sp.MaDanhMuc == CategoryId) &&
                    (showOutOfStock ? sp.SoLuong == 0 : sp.SoLuong > 0) &&
                    (string.IsNullOrEmpty(searchTerm) || sp.TenSanPham.Contains(searchTerm))
                )
                .Select(sp => new
                {
                    sp.MaSanPham,
                    sp.TenSanPham,
                    sp.HinhAnh,
                    sp.MoTa,
                    sp.Gia,
                    sp.SoLuong,
                    sp.MaDanhMuc, // Chỉ lấy mã danh mục, không lấy thông tin của danh mục
                    sp.NgayTao,
                    sp.NgayCapNhat,
                })
                .ToListAsync();

            if (sort == "asc")
                products = products.OrderBy(sp => sp.Gia).ToList();
            else if (sort == "desc")
                products = products.OrderByDescending(sp => sp.Gia).ToList();

            return Ok(products);
        }
		#endregion

		#region Thêm Sản Phẩm Mới
		/// <summary>
		/// Thêm sản phẩm mới.
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> CreateProduct([FromForm] SanPhamCreateDto sanPhamDto, IFormFile? ImageFile)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var danhMuc = await _context.DanhMucSanPhams.FindAsync(sanPhamDto.MaDanhMuc);
			if (danhMuc == null)
			{
				return BadRequest("Danh mục không tồn tại.");
			}

			var existingProduct = await _context.SanPhams
				.FirstOrDefaultAsync(sp => sp.TenSanPham.ToLower() == sanPhamDto.TenSanPham!.ToLower() && sp.MaDanhMuc == sanPhamDto.MaDanhMuc);

			if (existingProduct != null)
			{
				existingProduct.SoLuong += sanPhamDto.SoLuong;
				existingProduct.Gia = sanPhamDto.Gia;
				existingProduct.MoTa = sanPhamDto.MoTa;
				existingProduct.NgayCapNhat = DateTime.Now;
				if (ImageFile != null)
					existingProduct.HinhAnh = await SaveUserImage(ImageFile);

				_context.SanPhams.Update(existingProduct);
			}
			else
			{
				var newSanPham = new SanPham
				{
					TenSanPham = sanPhamDto.TenSanPham,
					Gia = sanPhamDto.Gia,
					SoLuong = sanPhamDto.SoLuong,
					MaDanhMuc = sanPhamDto.MaDanhMuc,
					MoTa = sanPhamDto.MoTa,
					HinhAnh = ImageFile != null ? await SaveUserImage(ImageFile) : "/images/default.png",
					NgayTao = DateTime.Now,
					NgayCapNhat = DateTime.Now
				};

				await _context.SanPhams.AddAsync(newSanPham);
			}

			await _context.SaveChangesAsync();
			return Ok();
		}


		#endregion

		#region Lấy Danh Sách Danh Mục
		/// <summary>
		/// Lấy danh sách danh mục sản phẩm để hiển thị khi thêm sản phẩm.
		/// </summary>
		[HttpGet("categories-dropdown")]
        public async Task<IActionResult> GetCategoriesForDropdown()
        {
            var categories = await _context.DanhMucSanPhams
                .Select(dm => new { dm.MaDanhMuc, dm.TenDanhMuc })
                .ToListAsync();

            return Ok(categories);
        }
        #endregion

        #region Chi Tiết Theo ID
        /// <summary>
        /// Lấy thông tin chi tiết sản phẩm theo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _connectStr.SanPhams.FindAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        #endregion

        #region Chỉnh Sửa Sản Phẩm
        /// <summary>
        /// Cập nhật thông tin sản phẩm theo ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] SanPham sanPham, IFormFile? ImageFile)
        {
            var product = await _connectStr.SanPhams.FindAsync(id);
            if (product == null)
                return NotFound(new { message = "Sản phẩm không tồn tại!" });

            var danhMuc = await _connectStr.DanhMucSanPhams.FindAsync(sanPham.MaDanhMuc);
            if (danhMuc == null)
                return BadRequest(new { message = $"Mã danh mục ({sanPham.MaDanhMuc}) không hợp lệ!" });

            product.TenSanPham = sanPham.TenSanPham;
            product.Gia = sanPham.Gia;
            product.SoLuong = sanPham.SoLuong;
            product.MaDanhMuc = sanPham.MaDanhMuc;
            product.MoTa = sanPham.MoTa;
            product.NgayCapNhat = DateTime.Now;

            if (ImageFile != null)
                product.HinhAnh = await SaveUserImage(ImageFile);

            await _connectStr.SaveChangesAsync();
            return Ok(new { message = "Cập nhật sản phẩm thành công!" });
        }
        #endregion

        #region Xóa Sản Phẩm
        /// <summary>
        /// Xóa sản phẩm theo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _connectStr.SanPhams.Include(sp => sp.DanhMucSanPham).FirstOrDefaultAsync(sp => sp.MaSanPham == id);
            if (product == null) return NotFound(new { message = "Không tìm thấy sản phẩm để xóa!" });

            _connectStr.SanPhams.Remove(product);
            await _connectStr.SaveChangesAsync();
            return Ok(new { message = "Xóa sản phẩm thành công!" });
        }
        #endregion

        #region Lưu Vào Thư Mục
        /// <summary>
        /// Lưu hình ảnh sản phẩm vào thư mục.
        /// </summary>
        private async Task<string> SaveUserImage(IFormFile imageFile)
        {
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "newfood");
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(directoryPath, uniqueFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
                await imageFile.CopyToAsync(stream);

            return "/images/newfood/" + uniqueFileName;
        }
        #endregion
    }
}