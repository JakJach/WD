using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class CreateThesisViewModel
    {
        [Required]
        public string Title { get; set; }
        public List<SelectListItem> Students { get; set; }
        public string SelectedStudent { get; set; }
        public List<SelectListItem> Reviewers { get; set; }
        [Required]
        public string SelectedReviewer { get; set; }
        [Required]
        public string Goal { get; set; }
        [Required]
        public string Scope { get; set; }
        [Required]
        public string StudentQualifications { get; set; }
    }
}
