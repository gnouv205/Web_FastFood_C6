using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Web_Food_Shared.Dtos;

namespace Web_Food_Client.Pages.Admin.SanPhamAPI_Admin
{
	public partial class Delete
	{
		[Parameter] public int id { get; set; }

		private SanPhamCreateDto? sanPham;

		protected override async Task OnInitializedAsync()
		{
			sanPham = await Http.GetFromJsonAsync<SanPhamCreateDto>($"https://localhost:44373/api/admin/san-pham/{id}");
		}

		private async Task XacNhanXoa()
		{
			var response = await Http.DeleteAsync($"https://localhost:44373/api/admin/san-pham/{id}");
			if (response.IsSuccessStatusCode)
			{
				Navigation.NavigateTo("/admin/san-pham");
			}
		}

		private void QuayLai()
		{
			Navigation.NavigateTo("/admin/san-pham");
		}

		
	}
}
