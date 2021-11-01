﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;

namespace e_organic.Data.Base
{
   public  interface IEntityBaseReposistory<T> where T:class,IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
         Task DeleteAsync(int id);
    }
}
