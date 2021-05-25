using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WD.Data.Models;

namespace WD.Web.ViewModels
{
    public class TeacherReviewProjectViewModel
    {
        public string ClassesName { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        [RegularExpression(@"[2.0,3.0,3.5,4.0,4.5,5.0]")]
        public float Note { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<string> Files { get; set; }
    }
}
