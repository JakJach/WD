using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class TeacherViewModel
    {
        public Teacher LoggedInTeacher { get; set; }
        public IEnumerable<Classes> TeacherClasses { get; set; }
        public IEnumerable<Project> TeacherProjects { get; set; }
        public IEnumerable<Student> TeacherStudents { get; set; }
        public IEnumerable<Thesis> TeacherPromotingTheses { get; set; }
        public IEnumerable<Thesis> TeacherReviewingTheses { get; set; }
        public IEnumerable<StudentFinalNote> StudentFinalNotes { get; set; }
    }
}
