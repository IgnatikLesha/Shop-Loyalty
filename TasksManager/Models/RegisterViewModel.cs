using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TasksManager.Models
{
    public class RegisterViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Incorrect name")]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Incorrect Email")]
        [Display(Name = "Email address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Incorrect password")]
        [StringLength(30, MinimumLength = 6)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}