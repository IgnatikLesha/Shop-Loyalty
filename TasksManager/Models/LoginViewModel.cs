using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksManager.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Invalid Email")]
        [StringLength(40, MinimumLength = 6)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        [StringLength(60, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}