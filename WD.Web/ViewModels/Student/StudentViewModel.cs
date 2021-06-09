using System.Collections.Generic;
using WD.Data.Models;
using WD.Data.Presentation;

namespace WD.Web.ViewModels
{
    public class StudentViewModel
    {
        public IEnumerable<StudentFinalNote> FinalNotes { get; set; }
        public Thesis Thesis { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
