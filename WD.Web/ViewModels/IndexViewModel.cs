using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.ViewModels
{
    public class IndexViewModel
    {
        public IList<Class> Classes { get; set; }
        public IList<Project> Projects { get; set; }
        public IList<Thesis> Theses { get; set; }
        public IList<File> Files { get; set; }
    }
}
