﻿using System.ComponentModel.DataAnnotations;

namespace Web_food_Asm.Models.ViewModel
{
    public class Login_ViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
