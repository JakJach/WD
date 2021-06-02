using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WD.Web.Utilities;

namespace WD.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidEmailDomain("agh.edu.pl", "student.agh.edu.pl",
            ErrorMessage = "Email domain must be agh.edu.pl or student.agh.edu.pl")]
        public string Email { get; set; }
    }
}
