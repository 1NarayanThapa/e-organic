using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.ViewModels
{
    public class LoginVm
    {
        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Requried")]
        public string EmailAddress { get; set; }
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "required")]
        public string Password { get; set; }
    }
}
