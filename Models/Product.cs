using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace e_organic.Models
{
    public class Product


    {
        [Key]

        public int id { get; set; }
        [Display(Name = "name of the Product")]
        public String name { get; set; }
        [Display(Name = "Discription of The Product")]
        public String Discription { get; set; }
        [Display(Name = "price of the product")]
        public Double price { get; set; }
        [Display(Name = "Image of product")]
        public String imageUrl { get; set; }

        public ProductCategory ProductCategory { get; set; }

        //vendor
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
    }
  


}
