using System.Collections.Generic;

namespace WD.Data.Models
{
    public partial class Student : User
    {
        public Student()
        {
            Classes = new HashSet<Class>();
        }

        public bool HasThesis { get; set; }

        public virtual Thesis Thesis { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
