using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
