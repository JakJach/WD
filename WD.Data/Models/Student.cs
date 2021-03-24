using System.Collections.Generic;

namespace WD.Data.Models
{
    public class Student : User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> Classes { get; set; }
        public int ThesisID { get; set; }
        public List<int> FinalNotes { get; set; }
    }
}
