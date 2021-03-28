using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teleperformance.Context;

namespace Teleperformance.repository.IGeneral
{
    public abstract class General<T> : IGeneral<T> where T : class

    {
        private readonly DBContext db;

        public General(DBContext _db)
        {
            db = _db;
        }
        public virtual async Task<T> ADD(T addedItem)
        {

            if (addedItem == null)
                return null;
            await db.AddAsync<T>(addedItem);
            await db.SaveChangesAsync();
            return addedItem;
        }

        public virtual async Task<T> Delete(int id)
        {
            T t = await GetById(id);
            if (t == null)
                return null;
            db.Set<T>().Remove(t);
            await db.SaveChangesAsync();
            return t;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Update(T UpdatedItem)
        {
            if (UpdatedItem == null)
                return null;
            db.Set<T>().Update(UpdatedItem);
            await db.SaveChangesAsync();
            return UpdatedItem;
        }
    }
}
