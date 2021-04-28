using System.Collections.Generic;

namespace WD.Data.Models
{
    public partial class Teacher : User
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            PromotedTheses = new HashSet<Thesis>();
            ReviewedTheses = new HashSet<Thesis>();
        }

        public string Title { get; set; }
        public bool CanBePromoter { get; set; }
        public bool CanBeReviewer { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Thesis> PromotedTheses { get; set; }
        public virtual ICollection<Thesis> ReviewedTheses { get; set; }
    }
}
