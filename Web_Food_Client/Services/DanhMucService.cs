using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using Web_Food_Shared.Models;

namespace Web_Food_Client.Services
{
	public class DanhMucService
	{
		private readonly HttpClient _http;

		public DanhMucService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<DanhMucSanPham>?> GetAllCategories()
		{
			return await _http.GetFromJsonAsync<List<DanhMucSanPham>>("api/admin/danh-muc");
		}
		public async Task<DanhMucSanPham?> GetCategoryById(int id)
		{
			return await _http.GetFromJsonAsync<DanhMucSanPham>($"api/admin/danh-muc/{id}");
		}
		public async Task<HttpResponseMessage> CreateCategory(DanhMucSanPham danhmuc)
		{
			return await _http.PostAsJsonAsync("api/admin/danh-muc", danhmuc);
		}
		public async Task<HttpResponseMessage> UpdateCategory (DanhMucSanPham danhmuc, int id)
		{
			return await _http.PutAsJsonAsync($"api/admin/danh-muc/{id}", danhmuc);
		}
		public async Task<bool> DeleteCategoryAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/admin/danh-muc/{id}");
			return response.IsSuccessStatusCode;
		}

	}
}
