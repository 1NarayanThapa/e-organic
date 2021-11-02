using e_organic.Data;
using e_organic.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Models
{
    public class Product
        :IEntityBase
    {
        [Key]
       public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Product Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        public ProductCatagory ProductCatagory { get; set; }

        //Relationship 
        //vendor
        public  int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
    }
}
