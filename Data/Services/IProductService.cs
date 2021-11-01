using e_organic.Data.Base;
using e_organic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
   public interface IProductService:IEntityBaseRepository<NewProductVM>
    {
        Task<NewProductVM> GetProductByIdAsync(int id);
     
    }
}
