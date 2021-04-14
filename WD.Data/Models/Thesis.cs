using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Data.Models
{
    public class Thesis
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int StudentID { get; set; }
        public bool IsUploaded { get; set; }
        public int PromoterID { get; set; }
        public bool IsCheckedByPromoter { get; set; }
        public int ReviewerID { get; set; }
        public bool IsCheckedByReviewer { get; set; }
        public int PromoterNote { get; set; }
        public int ReviewerNote { get; set; }
        public string Review { get; set; }
        public string PromoterOpinion { get; set; }
        public string FileName { get; set; }
        public ICollection<string> AttachmentsName { get; set; }

    }
}
