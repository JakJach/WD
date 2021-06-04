using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class IndexViewModel
    {
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
