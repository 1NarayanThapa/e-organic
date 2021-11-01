using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Models
{
    public class ProductInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ItemOrigin { get; set; }
        public string ImageUrl { get; set; }
        
       //Relationship
      // public List<Products> Products { get; set; }
     
    }
}
