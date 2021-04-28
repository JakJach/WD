using System;

namespace WD.Data.Models
{
    public partial class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
        public int? ThesisId { get; set; }
        public int? ProjectId { get; set; }

        public virtual Thesis Thesis { get; set; }
        public virtual Project Project { get; set; }
    }
}
