using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class HomeViewModel
    {
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public string Email { get; set; }
        [Display(Name = "ID")]
        public string UserId { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
