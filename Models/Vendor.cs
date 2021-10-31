using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace e_organic.Models
{
    public class Vendor
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Profile Picture Url")]
       
        public String ImageUrl { get; set; }
  

        [Display(Name = "Full Name")]
        public String name { get; set; }
       
        [Display(Name = "Detail Descrition")]
        public String Discription { get; set; }
      

        [Display(Name = "correct Address")]
        public String Address { get; set; }

        public List<Product> Products { get; set; }

    }

}
