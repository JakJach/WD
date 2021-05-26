using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WD.Data.Models;

namespace WD.Web.ViewModels
{
    public class RegisterViewModel : User
    {
        public bool IsStudent { get; set; }
        public bool IsTeacher { get; set; }
    }
}
