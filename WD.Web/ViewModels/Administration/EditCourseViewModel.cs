using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class EditCourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public List<SelectListItem> Teachers { get; set; }
        public string SelectedTeacherId { get; set; }
        public string SelectedTeacher { get; set; }

        public List<string> Students { get; set; }

        public EditCourseViewModel()
        {
            Students = new List<string>();
            Teachers = new List<SelectListItem>();
        }
    }
}
