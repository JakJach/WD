using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class AddFinalNoteViewModel
    {
        public string ClassesName { get; set; }
        [RegularExpression(@"[2.0,3.0,3.5,4.0,4.5,5.0]")]
        public float Note { get; set; }
    }
}
