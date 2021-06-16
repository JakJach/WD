using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WD.Web.ViewModels
{
    public class SubmitThesisViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Student { get; set; }
        public string Promoter { get; set; }
        public string Reviever { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
