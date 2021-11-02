using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Data.Base;

namespace e_organic.Data.ViewModels
{
    public class NewProductVM


    {
        public int id { get; set; }

        [Display(Name  = "name of the Product")]
        [Required(ErrorMessage ="name required")]
        public String name { get; set; }
        [Display(Name  = "Vendor Description")]
        [Required(ErrorMessage = "Dessctiption required")]
        public String Discription { get; set; }
        [Display(Name = "price in $ ")]
        [Required(ErrorMessage = "name required")]
        public Double price { get; set; }
        [Display(Name = "Vendor's Image ")]
        [Required(ErrorMessage = "image required")]
        public String imageUrl { get; set; }
        [Display(Name = "choose a category")]
        [Required(ErrorMessage = "you must choose one ")]
        public ProductCategory ProductCategory { get; set; }

        //vendor

     
        [Display(Name = "select a Vendor")]
        [Required(ErrorMessage = "you must choose Vendor")]
        public int VendorId { get; set; }
    
    }
  


}
