using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WD.Web.Models
{
    public class StudentAddProjectViewModel
    {
        public string ClassesName { get; set; }
        public string Title { get; set; }
        public IFormFile File { get; set; }
        public IEnumerable<IFormFile> Attachments { get; set; }
    }
}
