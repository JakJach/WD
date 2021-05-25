using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WD.Data.Models;

namespace WD.Web.ViewModels
{
    public class StudentAddThesisViewModel
    {
        public string StudentName { get; set; }
        public string PromoterName { get; set; }
        public string RevieverName { get; set; }
        public Thesis Thesis { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
