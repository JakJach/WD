using System;
using System.Collections.Generic;

namespace WD.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            Files = new HashSet<File>();
        }

        public int ProjectId { get; set; }
        public double? Note { get; set; }
        public string Review { get; set; }
        public string Scope { get; set; }
        public string Goal { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool IsReviewed { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public int ClassId { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual Class Class { get; set; }
    }
}
