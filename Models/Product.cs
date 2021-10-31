using e_organic.Data;
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
       public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public ProductCatagory ProductCatagory { get; set; }

        //Relationship 
        //vendor
        public  int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
    }
}
