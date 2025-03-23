using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Web_food_Asm.Data;
using Web_food_Asm.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SendMail>();
builder.Services.AddSingleton<FileImgUpload>();

// Đăng ký DbContext với DI container, cấu hình sử dụng SQL Server với chuỗi kết nối từ appsettings.json
builder.Services.AddDbContext<ConnectStr>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectStr")));

builder.Services.AddIdentity<KhachHang, IdentityRole>()
    .AddEntityFrameworkStores<ConnectStr>()
    .AddDefaultTokenProviders();

//Tạo tài liệu RESTful API
builder.Services.AddSwaggerGen(c =>
{
    //Tự động lấy XML file mà không cần chỉ rõ đường dẫn
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Gọi hàm tạo tài khoản mặc định
using (var scope = app.Services.CreateScope())
{
    await DataSeeder.SeedRolesAndUsers(
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(),
        scope.ServiceProvider.GetRequiredService<UserManager<KhachHang>>()
    );
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
