using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;

namespace e_organic.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Vendors = new List<Vendor>();
        }

        public List<Vendor> Vendors { get; set; }
    }

}
