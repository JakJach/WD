﻿using System.ComponentModel.DataAnnotations;

namespace WD.Web.ViewModels
{
    public class HomeViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
