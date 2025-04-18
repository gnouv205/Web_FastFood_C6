using System.Globalization;
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

		public async Task<List<UserDto>> GetAllUsersAsync()
		{
			return await _http.GetFromJsonAsync<List<UserDto>>("api/accounts/danh-sach");
		}
		public async Task<HttpResponseMessage> DeleteUserAsync(string id)
		{
			return await _http.DeleteAsync($"api/accounts/{id}");
		}
		public async Task<List<string>> GetAvailabelRolesAsync(string id)
		{
			return await _http.GetFromJsonAsync<List<string>>($"api/accounts/{id}/vai-tro-co-the-them");
		}
		public async Task<HttpResponseMessage> AddRolesAsync(string id, RoleViewModel userDto)
		{
			return await _http.PostAsJsonAsync($"api/accounts/{id}/them-vai-tro", userDto);
		}
		public async Task<HttpResponseMessage> RemoveRolesAsync(string id, RoleViewModel model)
		{
			var request = new HttpRequestMessage(HttpMethod.Delete, $"api/accounts/{id}/xoa-vai-tro")
			{
				Content = JsonContent.Create(model)
			};
			return await _http.SendAsync(request);
		}
	}
}
