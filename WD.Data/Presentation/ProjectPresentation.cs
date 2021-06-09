using System;
using System.Collections.Generic;

namespace WD.Data.Presentation
{
    public class ProjectPresentation
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Review { get; set; }
        public string Scope { get; set; }
        public string Goal { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public List<string> Students { get; set; }
        public float? Note { get; set; }
    }
}
