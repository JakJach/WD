using System.Collections.Generic;

namespace WD.Data.Presentation
{
    public class CourseProjectsList
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<ProjectPresentation> Projects { get; set; }
    }
}
