using System.ComponentModel.DataAnnotations;
using WD.Data.Models;

namespace WD.Web.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            UserID = user.UserID;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
        }

        [Key]
        public int UserID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
