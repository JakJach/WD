using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.ViewModels
{
    public class TeacherViewModel
    {
        public Teacher LoggedInTeacher { get; set; }
        public IEnumerable<Class> TeacherClasses { get; set; }
        public IEnumerable<Project> TeacherProjects { get; set; }
        public IEnumerable<Student> TeacherStudents { get; set; }
        public IEnumerable<Thesis> TeacherPromotingTheses { get; set; }
        public IEnumerable<Thesis> TeacherReviewingTheses { get; set; }
        public IEnumerable<FinalNote> StudentFinalNotes { get; set; }
    }
}
