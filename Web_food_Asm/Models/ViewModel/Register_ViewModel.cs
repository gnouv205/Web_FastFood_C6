using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_food_Asm.Models.ViewModel
{
    public class Register_ViewModel
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Tên người dùng chỉ chứa chữ và số, không có khoảng trắng hoặc ký tự đặc biệt")]
        public string UserName { get; set; }


        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(255, ErrorMessage = "Địa chỉ không được quá 255 ký tự")]
        public string DiaChi { get; set; }
    }
}
