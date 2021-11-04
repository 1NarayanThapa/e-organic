using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Data.Base;
using e_organic.Models;

namespace e_organic.Data.Services
{
    public class VendorsService:EntityBaseRepository<Vendor>,IVendorsService
    {
        public VendorsService(AppDbContext context):base(context)
        {

        }
    }
}
