using e_organic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.ViewModels
{
    public class NewProductDropDownVM
    {

        public NewProductDropDownVM()
        {
            Vendors = new List<Vendor>();
        }

        public List<Vendor> Vendors { get; set; }
    }
}
