using e_organic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
    public interface IVendorService
    {
       Task< IEnumerable<Vendor> >GetAllAsync();
        Task<Vendor> GetByIdAsync(int id);
        Task AddAsync(Vendor vendor);

        Task<Vendor> UpdateAsync(int id, Vendor newVendor);
        void delete(int id);
    }
}
