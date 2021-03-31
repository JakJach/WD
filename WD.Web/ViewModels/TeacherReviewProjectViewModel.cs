using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class TeacherReviewProjectViewModel
    {
        public string ClassesName { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        [RegularExpression(@"[0,2,3,4,5]")]
        public int Note { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public string FileName { get; set; }
        public IEnumerable<string> AttachmentNames { get; set; }
    }
}
