using System;
using System.Collections.Generic;

namespace WD.Data.Models
{
    public partial class Thesis
    {
        public Thesis()
        {
            Files = new HashSet<File>();
        }

        public int ThesisId { get; set; }
        public double? PromoterNote { get; set; }
        public double? ReviewerNote { get; set; }
        public string PromoterOpinion { get; set; }
        public string Review { get; set; }
        public string Title { get; set; }
        public bool IsTaken { get; set; }
        public DateTime? TakeDate { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? AcceptationDate { get; set; }
        public bool IsReviewed { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Scope { get; set; }
        public string Goal { get; set; }
        public string StudentQualifications { get; set; }
        public int? StudentId { get; set; }
        public int PromoterId { get; set; }
        public int? ReviewerId { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Promoter { get; set; }
        public virtual Teacher Reviewer { get; set; }
    }
}
