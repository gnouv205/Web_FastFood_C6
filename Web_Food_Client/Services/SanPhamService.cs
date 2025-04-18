using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Web_Food_Shared.Dtos;
using Web_Food_Shared.Models;



namespace Web_Food_Client.Services
{
	public class SanPhamService
	{
		private readonly HttpClient _http;

		public SanPhamService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<SanPhamDtos>> GetAllSanPhams()
		{
			try
			{
				var response = await _http.GetAsync("api/admin/san-pham");
				//Console.WriteLine($"API Status: {response.StatusCode}");

				var responseContent = await response.Content.ReadAsStringAsync();
				//Console.WriteLine($"API Response: {responseContent}"); 

				if (response.IsSuccessStatusCode)
				{
					return JsonSerializer.Deserialize<List<SanPhamDtos>>(responseContent) ?? new();
				}
				return new();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Lỗi service: {ex}");
				throw;
			}
		}
		public async Task<List<DanhMucDto>> GetDanhMucDropdownAsync()
		{
			return await _http.GetFromJsonAsync<List<DanhMucDto>>("api/admin/san-pham/categories-dropdown");
		}

		public async Task<HttpResponseMessage> CreateSanPhamAsync(SanPhamCreateDto dto, IBrowserFile imageFile)
		{
			var content = new MultipartFormDataContent();

			content.Add(new StringContent(dto.TenSanPham), "TenSanPham");
			content.Add(new StringContent(dto.Gia.ToString()), "Gia");
			content.Add(new StringContent(dto.SoLuong.ToString()), "SoLuong");
			content.Add(new StringContent(dto.MaDanhMuc.ToString()), "MaDanhMuc");
			content.Add(new StringContent(dto.MoTa), "MoTa");

			if (imageFile != null)
			{
				var stream = imageFile.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); // giới hạn 10MB
				content.Add(new StreamContent(stream), "ImageFile", imageFile.Name);
			}

			return await _http.PostAsync("api/admin/san-pham", content);
		}
		// Lấy sản phẩm theo ID
		public async Task<SanPhamDtos> GetSanPhamById(int id)
		{
			return await _http.GetFromJsonAsync<SanPhamDtos>($"api/admin/san-pham/{id}");
		}

		// Cập nhật sản phẩm
		public async Task<HttpResponseMessage> UpdateSanPhamAsync(int id, MultipartFormDataContent content)
		{
			return await _http.PutAsync($"api/admin/san-pham/{id}", content);
		}

		// Xóa sản phẩm
		public async Task<bool> DeleteSanPham(int id)
		{
			var response = await _http.DeleteAsync($"api/admin/san-pham/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
