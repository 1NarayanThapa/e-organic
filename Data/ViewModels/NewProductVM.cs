using e_organic.Data;
using System.ComponentModel.DataAnnotations;

namespace e_organic.Data.ViewModels
{
    public class NewProductVM
    {
        [Required(ErrorMessage ="name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Product Image")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Catagory is required")]
        [Display(Name = "Product Catagory")]
        public ProductCatagory ProductCatagory { get; set; }

        //Relationship 
        //vendor
        [Required(ErrorMessage = "Vendor is required")]
        [Display(Name = "Select a Vendor")]
        public  int VendorId { get; set; }
      
    }
}
