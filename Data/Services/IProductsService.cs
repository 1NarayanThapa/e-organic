using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Data.Base;
using e_organic.Data.ViewModels;
using e_organic.Models;

namespace e_organic.Data.Services
{
  public  interface IProductsService: IEntityBaseReposistory<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownValues();

    }
}
