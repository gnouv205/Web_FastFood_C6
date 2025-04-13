using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Web_Food_Shared.Dtos;
using Web_Food_Shared.Models;

namespace Web_Food_Client.Pages.Admin.SanPhamAPI_Admin
{
	public partial class Edit
	{
		[Parameter] public int id { get; set; }

		private SanPhamCreateDto? sanPham;
		private List<DanhMucSanPham> danhMucList = new();
		private IBrowserFile? selectedImage;

		protected override async Task OnInitializedAsync()
		{
			sanPham = await Http.GetFromJsonAsync<SanPhamCreateDto>($"https://localhost:44373/api/SanPhamAdminApi/{id}");
			danhMucList = await Http.GetFromJsonAsync<List<DanhMucSanPham>>("https://localhost:44373/api/admin/san-pham/categories-dropdown");
		}

		private async Task OnImageChange(InputFileChangeEventArgs e)
		{
			selectedImage = e.File;

			using var stream = selectedImage.OpenReadStream(maxAllowedSize: 10_000_000);
			var buffer = new byte[selectedImage.Size];
			await stream.ReadAsync(buffer);

			var base64 = Convert.ToBase64String(buffer);
			sanPham!.HinhAnh = $"data:{selectedImage.ContentType};base64,{base64}";
		}

		private async Task HandleValidSubmit()
		{
			var response = await Http.PutAsJsonAsync($"https://localhost:44373/api/admin/san-pham/{id}", sanPham);
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
