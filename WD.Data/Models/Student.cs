using System.Collections.Generic;

namespace WD.Data.Models
{
    public partial class Student : User
    {
        public Student()
        {
            Classes = new HashSet<Class>();
            FinalNote = new HashSet<FinalNote>();
            Projects = new HashSet<Project>();
        }

        public Student(User user)
        {
            if(user != null)
            {
                UserID = user.UserID;
                Email = user.Email;
                Name = user.Name;
                Password = user.Password;
                Surname = user.Surname;
                HasThesis = false;
            }

            Classes = new HashSet<Class>();
            FinalNote = new HashSet<FinalNote>();
            Projects = new HashSet<Project>();
        }

        public bool HasThesis { get; set; }

        public virtual Thesis Thesis { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<FinalNote> FinalNote { get; set; }
    }
}
