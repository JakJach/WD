using System.Collections.Generic;
using WD.Data.Enums;

namespace WD.Data.Models
{
    public class Teacher : User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> Classes { get; set; }
        public EScienceTitles Title { get; set; }
    }
}
