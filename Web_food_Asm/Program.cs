using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Microsoft.Extensions.Configuration;
=======
using Microsoft.Extensions.FileProviders;
>>>>>>> 7b1c485 (Update View Blazor)
using Microsoft.OpenApi.Models;
using System.Reflection;
using Web_food_Asm.Data;
using Web_Food_Shared.Models;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// Đăng ký các dịch vụ
=======
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7218")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

>>>>>>> 7b1c485 (Update View Blazor)
builder.Services.AddSingleton<SendMail>();
builder.Services.AddSingleton<FileImgUpload>();

// Đăng ký DbContext với DI container, cấu hình sử dụng SQL Server với chuỗi kết nối từ appsettings.json
builder.Services.AddDbContext<ConnectStr>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectStr")));

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

<<<<<<< HEAD
// Đăng ký dịch vụ Session
=======
// đăng ký dịch vụ Session
>>>>>>> 7b1c485 (Update View Blazor)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
<<<<<<< HEAD
=======

>>>>>>> 7b1c485 (Update View Blazor)

// Thêm dịch vụ điều khiển (Controllers)
builder.Services.AddControllers();

// Cấu hình Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

<<<<<<< HEAD
// Gọi hàm tạo tài khoản mặc định
=======
app.UseCors(MyAllowSpecificOrigins);

// Gọi hàm tạo tài khoản mặc địnhz
>>>>>>> 7b1c485 (Update View Blazor)
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

<<<<<<< HEAD
=======
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
	RequestPath = "/images"
});

>>>>>>> 7b1c485 (Update View Blazor)
app.UseSession();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
