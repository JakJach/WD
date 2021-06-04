using System.Collections.Generic;

namespace WD.Data.Models
{
    public partial class Class
    {
        public Class()
        {
            Projects = new HashSet<Project>();
            FinalNote = new HashSet<FinalNote>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<FinalNote> FinalNote { get; set; }
    }
}
