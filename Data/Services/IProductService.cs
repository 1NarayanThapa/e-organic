using e_organic.Data.Base;
using e_organic.Data.ViewModels;
using e_organic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
   public interface IProductService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropDownVM> GetProductDropDownValue();

        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);

    }
}
