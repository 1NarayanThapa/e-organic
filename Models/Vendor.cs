using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Data.Base;

namespace e_organic.Models
{
    public class Vendor:IEntityBase
    {
        [Key] 
        public int id { get; set; }

        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "profiel pictre required")]

        public String ImageUrl { get; set; }
  

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = " vendor name  required")]
        public String name { get; set; }
       
        [Display(Name = "Detail Descrition")]
        [Required(ErrorMessage = " vendor Descriptoin  required")]
        public String Discription { get; set; }

        [Display(Name = " Address")]
/*        [Required(ErrorMessage = " vendor address  required")]*/
        public String Address { get; set; }


        public List<Product> Products { get; set; }

    }

}
