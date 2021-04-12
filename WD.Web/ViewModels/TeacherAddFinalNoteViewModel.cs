using System.ComponentModel.DataAnnotations;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class TeacherAddFinalNoteViewModel
    {
        public string ClassesName { get; set; }
        [RegularExpression(@"[0,2,3,4,5]")]
        public int Note { get; set; }
        public Student Student { get; set; }
    }
}
