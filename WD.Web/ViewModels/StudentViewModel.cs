using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class StudentViewModel
    {
        public Student LoggedInStudent { get; set; }
        public IEnumerable<Classes> StudentClasses { get; set; }
        public IEnumerable<Project> StudentProjects { get; set; }
        public Thesis StudentThesis { get; set; }
    }
}
