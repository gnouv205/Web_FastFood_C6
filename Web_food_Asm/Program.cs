using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Web_food_Asm.Data;
using Web_Food_Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConnectStr>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectStr"));
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
		policy =>
		{
			policy.WithOrigins(
					"https://localhost:7218", 
					"https://localhost:7104")
			   .AllowAnyHeader()
			   .AllowAnyMethod()
			   .AllowCredentials();
		});
});


builder.Services.AddSingleton<SendMail>();
builder.Services.AddSingleton<FileImgUpload>();



// Đăng ký Identity
builder.Services.AddIdentity<KhachHang, IdentityRole>()
    .AddEntityFrameworkStores<ConnectStr>()
    .AddDefaultTokenProviders();

// Sử dụng cấu hình EmailSettings từ appsettings.json
//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Tạo tài liệu RESTful API
builder.Services.AddSwaggerGen(c =>
{
    // Tự động lấy XML file mà không cần chỉ rõ đường dẫn
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Thêm dịch vụ điều khiển (Controllers)
builder.Services.AddControllers();

// Cấu hình Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors(MyAllowSpecificOrigins);

// Gọi hàm tạo tài khoản mặc địnhz
using (var scope = app.Services.CreateScope())
{
    await DataSeeder.SeedRolesAndUsers(
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(),
        scope.ServiceProvider.GetRequiredService<UserManager<KhachHang>>()
    );
}

// Cấu hình HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(); // Cho phép sử dụng wwwroot


app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
	RequestPath = "/images/newfood"
});


app.UseSession();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
