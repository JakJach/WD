using System.ComponentModel.DataAnnotations;

namespace WD.Web.Models
{
    public class HomeViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
