using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WD.Web.ViewModels
{
    public class StudentAddProjectViewModel
    {
        public string ClassesName { get; set; }
        public string Title { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
}
