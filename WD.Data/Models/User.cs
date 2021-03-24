using System.ComponentModel.DataAnnotations;
using WD.Data.Services;

namespace WD.Data.Models
{
    public class User : IUser
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public bool IsStudent { get; set; }
    }
}
