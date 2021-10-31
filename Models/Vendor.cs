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
        
        public int VendorId { get; set; }
        [Display(Name = "Vendor name")]
        public string Name { get; set; }
        [Display(Name = "Vendor description")]
        public string Description { get; set; }

        [Display(Name = "Vendor picture url")]
        public string ImageUrl { get; set; }
        [Display(Name = "Vendor address")]
        public string Address { get; set; }

        //Relationship
        public List<Product> Products { get; set; }
        
    }
}
