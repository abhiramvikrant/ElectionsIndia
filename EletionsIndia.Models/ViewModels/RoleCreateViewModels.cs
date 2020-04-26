using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionsIndia.Models.ViewModels
{
   public class RoleCreateViewModels
    {
        public string RoleName { get; set; }
        public List<IdentityRole> RoleList { get; set; }
    }
}
