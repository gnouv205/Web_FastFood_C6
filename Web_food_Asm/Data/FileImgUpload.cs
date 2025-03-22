namespace Web_food_Asm.Data
{
    public class FileImgUpload
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileImgUpload(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var uploadDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            // Kiểm tra loại file (chỉ cho phép ảnh)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
                throw new Exception("Chỉ cho phép tải lên hình ảnh (jpg, jpeg, png, gif).");

            // Kiểm tra kích thước file (giới hạn 5MB)
            if (file.Length > 5 * 1024 * 1024)
                throw new Exception("Kích thước file quá lớn. Vui lòng tải lên file dưới 5MB.");

            // Tạo tên file mới để tránh ghi đè
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var newFileName = $"{fileName}_{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadDirectory, newFileName);

            // Lưu file vào thư mục
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newFileName;
        }
    }

}
