using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WD.Data;

namespace WD.Web.ViewModels
{
    public class ReviewThesisViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Student { get; set; }
        public string Promoter { get; set; }
        public string Reviewer { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public float Note { get; set; }
        public List<float> Options { get { return FinalNotes.Notes; } }
        public IEnumerable<string> Files { get; set; }
    }
}
