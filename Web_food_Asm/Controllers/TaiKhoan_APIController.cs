using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_food_Asm.Data;
using Web_food_Asm.Models;
using Web_food_Asm.Models.ViewModel;

namespace Web_food_Asm.Controllers
{
    [ApiController]
    [Route("api/taikhoan")]
    public class TaiKhoan_APIController : ControllerBase
    {
        private readonly UserManager<KhachHang> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SendMail _sendMail;
        private readonly FileImgUpload _fileImgUpload;
        public TaiKhoan_APIController(UserManager<KhachHang> userManager, RoleManager<IdentityRole> roleManager, SendMail sendMail, FileImgUpload fileImgUpload)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sendMail = sendMail;
            _fileImgUpload = fileImgUpload;
        }

        #region Danh Sách Tài khoản
        /// <summary>
        /// Lấy danh sách tài khoản kèm theo vai trò
        /// </summary>
        [HttpGet("danhsach")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new
                {
                    user.Id,
                    user.Email,
                    user.UserName,
                    user.Hinh,
                    user.PasswordHash,
                    user.PhoneNumber,
                    user.TinhTrang,
                    user.DiaChi,
                    Roles = roles
                });
            }

            return Ok(userList);
        }
        #endregion

        #region Thông tin tài khoản
        /// <summary>
        /// Xem thông tin tài khoản theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "ID không hợp lệ" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Error = "Tài khoản không tồn tại" });

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.Hinh,
                user.PasswordHash,
                user.PhoneNumber,
                user.TinhTrang,
                user.DiaChi,
                Roles = roles
            });
        }
        #endregion

        #region Xóa Tài khoản
        /// <summary>
        /// Xóa tài khoản theo ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "ID không hợp lệ" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Error = "Tài khoản không tồn tại" });

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(new { Error = "Xóa tài khoản thất bại", Details = result.Errors });

            return Ok(new { Message = "Xóa tài khoản thành công!" });
        }
        #endregion

        #region Đổi mật khẩu
        /// <summary>
        /// Đổi mật khẩu tài khoản theo ID
        /// </summary>
        [HttpPost("{id}/doimatkhau")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] DoiMatKhau_ViewModel model)
        {
            if (string.IsNullOrEmpty(id) || model == null)
                return BadRequest(new { Error = "Dữ liệu không hợp lệ" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Error = "Tài khoản không tồn tại" });

            // Đổi mật khẩu
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                if (result.Errors.Any(e => e.Code == "PasswordMismatch"))
                    return BadRequest(new { Error = "Mật khẩu cũ không đúng." });

                return BadRequest(new { Error = "Đổi mật khẩu thất bại", Details = result.Errors });
            }

            // Gửi thông báo qua email
            if (!string.IsNullOrEmpty(user.Email))
            {
                string subject = "Thông báo: Bạn đã đổi mật khẩu thành công!";
                string body = "Mật khẩu của bạn đã được thay đổi thành công. Nếu không phải bạn thực hiện, vui lòng liên hệ hỗ trợ ngay lập tức.";

                try
                {
                    _sendMail.SendEmail(user.Email, subject, body);
                }
                catch
                {
                    // Bỏ qua lỗi nếu không gửi được email
                }
            }

            return Ok(new { Message = "Đổi mật khẩu thành công!" });
        }
        #endregion

        #region Sửa thông tin tài khoản
        /// <summary>
        /// Cập nhật thông tin tài khoản theo ID
        /// </summary>
        [HttpPut("{id}/capnhat")]
        public async Task<IActionResult> UpdateUser(string id, [FromForm] TaiKhoan_ViewModel model) 
        {
            if (string.IsNullOrEmpty(id) || model == null)
                return BadRequest(new { Error = "Dữ liệu không hợp lệ" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Error = "Tài khoản không tồn tại" });

            // Kiểm tra xem Email có thay đổi không
            if (!string.Equals(user.Email, model.Email, StringComparison.OrdinalIgnoreCase))
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null && existingUser.Id != user.Id)
                    return BadRequest(new { Error = "Email này đã được sử dụng" });
            }

            // Cập nhật thông tin tài khoản
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;  
            user.DiaChi = model.DiaChi;  
            user.TinhTrang = model.TinhTrang ?? user.TinhTrang;  // Cập nhật tình trạng nếu có thay đổi

            // Nếu có hình ảnh mới
            if (model.HinhFile != null)
            {
                user.Hinh = await _fileImgUpload.UploadFileAsync(model.HinhFile);
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(new { Error = "Cập nhật thông tin thất bại", Details = result.Errors });

            return Ok(new { Message = "Cập nhật thông tin thành công!" });
        }
        #endregion

    }
}
