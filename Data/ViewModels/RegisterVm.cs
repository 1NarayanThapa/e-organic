using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.ViewModels
{
    public class RegisterVm
    {
        [Display(Name = "full name")]
        [Required(ErrorMessage = "Full Name is required")]
         public string FullName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage ="Email Address is required")]
        
        public String EmailAddress { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        public String Password  { get; set; }
        [Display(Name ="confirm Password")]
        [Required(ErrorMessage ="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password do not match")]
        public String ConfirmPassword { get; set; }
    }
}
