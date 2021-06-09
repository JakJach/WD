using System.Collections.Generic;
using WD.Data.Models;
using WD.Data.Presentation;

namespace WD.Web.ViewModels
{
    public class TeacherViewModel
    {
        public IEnumerable<CourseProjectsList> Courses { get; set; }
        public IEnumerable<TeacherFinalNote> FinalNotes { get; set; }
        public IEnumerable<Thesis> Theses { get; set; }
    }
}
