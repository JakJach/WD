using System;

namespace WD.Data.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
