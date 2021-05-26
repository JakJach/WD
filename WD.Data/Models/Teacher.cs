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

        public Teacher(User user)
        {
            UserID = user.UserID;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Password = user.Password;
            CanBePromoter = true;
            CanBeReviewer = true;
        }

        public string Title { get; set; }
        public bool CanBePromoter { get; set; }
        public bool CanBeReviewer { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Thesis> PromotedTheses { get; set; }
        public virtual ICollection<Thesis> ReviewedTheses { get; set; }
    }
}
