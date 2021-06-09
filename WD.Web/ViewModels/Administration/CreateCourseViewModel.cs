using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class CreateCourseViewModel
    {
        [Required]
        public string Name { get; set; }

        public List<SelectListItem> Teachers { get; set; }
        public string SelectedTeacher { get; set; }
    }
}
