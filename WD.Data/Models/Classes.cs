using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Data.Models
{
    public class Classes
    {
        public string Name { get; set; }
        [Key]
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public ICollection<int> StudentIDs { get; set; }
        public ICollection<int> ProjectIDs { get; set; }
    }
}
