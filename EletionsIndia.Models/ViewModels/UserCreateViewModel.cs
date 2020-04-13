using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EletionsIndia.Models.ViewModels
{
    public class UserCreateViewModel
    {
  
        [Required(ErrorMessage ="User Name required")][EmailAddress]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password required")][DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage="Confirm password deosn't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Address 1 is required")]
        [Display(Name="Address 1")]
        public string  Address1 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }
        [Required(ErrorMessage ="Pin Code or Zip Code is required")]
        [Display(Name= "Pin Code/Zip Code")]
        public int PinCode { get; set; }

        [Required(ErrorMessage ="Say about yourself is required")]
        [Display(Name ="Say About Yourself")]
        public string SayAboutYourself { get; set; }
    }
}
