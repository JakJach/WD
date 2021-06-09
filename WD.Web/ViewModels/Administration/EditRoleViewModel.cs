using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class EditRoleViewModel
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }

        public List<string> Users { get; set; }

        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
    }
}
