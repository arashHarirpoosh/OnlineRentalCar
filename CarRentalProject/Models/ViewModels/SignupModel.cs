using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Models.ViewModels
{
    public class SignupModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Username")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public bool AcceptPrivacyPolicy { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
