using System.ComponentModel.DataAnnotations;

namespace Web_food_Asm.Models.ViewModel
{
    public class ForgotPassword_ViewModel
    {
        [Required]
        public string Email { get; set; } 
    }
}
