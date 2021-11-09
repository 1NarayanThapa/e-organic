using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.ViewModels
{
    public class RegisterVm
    {

        [Display(Name = " Full name")]
        [Required(ErrorMessage = "name is required  Requried")]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Requried")]



        public string EmailAddress { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "required")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "confirm password is required")]
        [Compare("Password", ErrorMessage = "password donot match")]
        public string ConfirmPassword { get; set; }
    }
}
