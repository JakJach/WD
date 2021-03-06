using System;

namespace WD.Data.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public float? Note { get; set; }
        public string Review { get; set; }
        public string Scope { get; set; }
        public string Goal { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool IsReviewed { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
    }
}
