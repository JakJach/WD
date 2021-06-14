using System.Collections.Generic;

namespace WD.Data.Presentation
{
    public class TeacherCourseFinal
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<TeacherFinalNote> FinalNotes { get; set; }

        public TeacherCourseFinal()
        {
            FinalNotes = new List<TeacherFinalNote>();
        }
    }
}
