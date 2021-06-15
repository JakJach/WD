using System.Collections.Generic;
using WD.Data;

namespace WD.Web.ViewModels
{
    public class AddFinalNoteViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }
        public string StudentId { get; set; }
        public string Student { get; set; }
        public float Note { get; set; }
        public List<float> Options { get { return FinalNotes.Notes; } }
    }
}
