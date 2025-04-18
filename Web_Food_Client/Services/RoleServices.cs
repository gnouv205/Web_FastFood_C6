using System.Net.Http.Json;

namespace Web_Food_Client.Services
{
	public class RoleServices
	{
		private readonly HttpClient _http;

		public RoleServices(HttpClient http)
		{
			_http = http;
		}
		public async Task<List<RoleDto>?> GetAllRolesAsync()
		{
			return await _http.GetFromJsonAsync<List<RoleDto>>("api/roles/danh-sach");
		}
		public async Task<RoleDetailDto> GetRoleByIdAsync(string id)
		{
			return await _http.GetFromJsonAsync<RoleDetailDto>($"api/roles/{id}");
		}
		public async Task<HttpResponseMessage> CreateRole(string roleName)
		{
			return await _http.PostAsJsonAsync("api/roles/them-quyen", roleName);
		}
		public async Task<HttpResponseMessage> UpdateRole(string id, string newName)
		{

			return await _http.PutAsJsonAsync($"api/roles/cap-nhat-quyen/{id}", newName);
		}
		public async Task<HttpResponseMessage> DeleteRole(string id)
		{
			return await _http.DeleteAsync($"api/roles/{id}");
		}

	}
	public class RoleDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}

	public class RoleDetailDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int TotalAccounts { get; set; }
		public List<UserInRoleDto> Users { get; set; }
	}

	public class UserInRoleDto
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string DiaChi { get; set; }
		public string TinhTrang { get; set; }
		public string Hinh { get; set; }
	}
}
