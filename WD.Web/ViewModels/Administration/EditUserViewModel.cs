using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }

        public EditUserViewModel()
        {
            Roles = new List<string>();
            Claims = new List<string>();
        }
    }
}
