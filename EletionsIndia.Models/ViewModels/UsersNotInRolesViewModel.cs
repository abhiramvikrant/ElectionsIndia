using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
    public class UsersNotInRolesViewModel
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }
        [Display(Name="Is In Role")]
        public bool IsInRole { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
