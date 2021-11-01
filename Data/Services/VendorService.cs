using e_organic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
    public class VendorService : IVendorService
    {
        private readonly ApplicationDbContext _context;
        public VendorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
           await  _context.SaveChangesAsync();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            var vendorData = await  _context.Vendors.ToListAsync();
            return vendorData;
        }

     

        public async Task<Vendor> GetByIdAsync(int id)
        {
            var vendorData =  await _context.Vendors.FirstOrDefaultAsync(n => n.VendorId == id);
            return vendorData;
           
        }

        public async Task<Vendor> UpdateAsync(int id,Vendor newVendor)
        {
            _context.Update(newVendor);
            await _context.SaveChangesAsync();
            return newVendor;
        }

      


    }
}
