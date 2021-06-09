namespace WD.Data.Models
{
    public partial class StudentCourses
    {
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public float FinalNote { get; set; }
    }
}