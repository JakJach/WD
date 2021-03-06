using System.Collections.Generic;
using WD.Data.Models;
using WD.Data.Presentation;

namespace WD.Web.ViewModels
{
    public class TeacherViewModel
    {
        public IEnumerable<CourseProjectsList> Courses { get; set; }
        public IEnumerable<TeacherCourseFinal> Finals { get; set; }
        public IEnumerable<Thesis> PromotedTheses { get; set; }
        public IEnumerable<Thesis> ReviewedTheses { get; set; }
    }
}
