using e_organic.Data.Base;
using e_organic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
    public class VendorService :EntityBaseRepository<Vendor>,IVendorService
    {
        
        public VendorService(ApplicationDbContext context) : base(context) { }
       

      


    }
}
