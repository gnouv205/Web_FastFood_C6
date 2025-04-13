using System.Net.Http;
using System.Net.Http.Json;
using Web_Food_Shared.Dtos;
using Web_Food_Shared.Models;

namespace Web_Food_Client.Services
{
	public class AccountService
	{
		private readonly HttpClient _http;

		public AccountService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<UserDto>> GetAllAsync()
		{
			var result = await _http.GetFromJsonAsync<List<UserDto>>("api/accounts/danh-sach");
			return result ?? new List<UserDto>();
		}
		public async Task<string?> CreateUserAsync(UserDto model)
		{
			var content = new MultipartFormDataContent
	{
		{ new StringContent(model.UserName), "UserName" },
		{ new StringContent(model.HoTen), "HoTen" },
		{ new StringContent(model.Email), "Email" },
		{ new StringContent(model.PhoneNumber), "PhoneNumber" },
		{ new StringContent(model.DiaChi), "DiaChi" },
		{ new StringContent(model.Password), "Password" },
		{ new StringContent(model.TinhTrang ?? "Hoạt Động"), "TinhTrang" }
	};

			// Gửi danh sách vai trò
			if (model.Roles != null)
			{
				foreach (var role in model.Roles)
				{
					content.Add(new StringContent(role), "RoleNames");
				}
			}

			var response = await _http.PostAsync("api/accounts/tao-moi", content);

			if (response.IsSuccessStatusCode)
			{
				return "Tạo tài khoản thành công!";
			}
			else
			{
				var error = await response.Content.ReadAsStringAsync();
				return $"Thất bại: {error}";
			}
		}


		public async Task<bool> UpdateAsync(string id, KhachHang user)
		{
			var res = await _http.PutAsJsonAsync($"api/accounts/sua/{id}", user);
			return res.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteAsync(string id)
		{
			var res = await _http.DeleteAsync($"api/accounts/xoa/{id}");
			return res.IsSuccessStatusCode;
		}
	}
}
