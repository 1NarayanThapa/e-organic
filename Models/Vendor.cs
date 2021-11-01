using e_organic.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Models
{
    public class Vendor: IEntityBase
    {

        [Key]
        
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage="name is required")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="name must be between 4 to 20 character")]
        public string Name { get; set; }

        [StringLength(1000, MinimumLength = 10, ErrorMessage = "name must be between 1000 to 10 character")]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Vendor Image")]
        [Required(ErrorMessage = "image is required")]
        public string ImageUrl { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "address is required")]
        public string Address { get; set; }

        //Relationship
        public List<Product> Products { get; set; }
        
    }
}
