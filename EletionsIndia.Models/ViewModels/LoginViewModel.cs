using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EletionsIndia.Models.ViewModels
{
   public class LoginViewModel
    {
     [Required(ErrorMessage ="User Name required")]
     [Display(Name = "User Name")]
     [EmailAddress]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
