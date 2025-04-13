using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Food_Shared.Dtos
{
    public class UserDto
    {
		public string Id { get; set; }
		public string Email { get; set; }
		public string HoTen { get; set; }
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }
		public string TinhTrang { get; set; }
		public string DiaChi { get; set; }
		public string Hinh { get; set; }
		[Required]
		public string Password { get; set; } = string.Empty;
		public List<string> Roles { get; set; }
	}
}
