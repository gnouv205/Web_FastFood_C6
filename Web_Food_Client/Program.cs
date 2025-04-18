using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web_Food_Client;
using Web_Food_Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri("https://localhost:7104")
});
// Dang ky services
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<SanPhamService>();
builder.Services.AddScoped<DanhMucService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<RoleServices>();


builder.Services.AddBlazoredToast();


await builder.Build().RunAsync();
