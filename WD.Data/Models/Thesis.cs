using System;

namespace WD.Data.Models
{
    public partial class Thesis
    {
        public int ThesisId { get; set; }
        public float? PromoterNote { get; set; }
        public float? ReviewerNote { get; set; }
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
        public string StudentId { get; set; }
        public string PromoterId { get; set; }
        public string ReviewerId { get; set; }
    }
}
