﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teleperformance.repository.IGeneral
{
   public interface IGeneral<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> ADD(T addedItem);
        Task<T> Delete(int id);
        Task<T> Update(T UpdatedItem);

    }
}
