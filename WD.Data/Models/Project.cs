using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Data.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassesID { get; set; }
        public List<int> StudentIDs { get; set; }
        public bool IsUploaded { get; set; }
        public int ReviewerID { get; set; }
        public bool IsReviewed { get; set; }
        public int ReviewerNote { get; set; }
        public string Review { get; set; }
        public string FileName { get; set; }
        public List<string> AttachmentsName { get; set; }

    }
}
