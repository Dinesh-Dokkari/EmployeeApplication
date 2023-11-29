using DataAccess_Layer.Data;
using DataAccess_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _db;

        public Repository(EmployeeDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return await SaveDetails();

        }

        public async Task<int> Delete(int? id)
        {
            var entityRecord = await _db.Set<T>().FindAsync(id);

            if (entityRecord != null)
            {
                _db.Set<T>().Remove(entityRecord);
            }
            int result = await SaveDetails();
            return result;
        }

        public Task<int> Edit(int? id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(int? id)
        {
            var entityRecord = await _db.Set<T>().FindAsync(id);
            if(entityRecord != null)
            {
                return entityRecord;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var records = await _db.Set<T>().ToListAsync();
            return records;
        }


        public async Task<int> Update(T entity)
        {
            _db.Set<T>().Update(entity);
            return await SaveDetails();
        }

        public async Task<int> SaveDetails()
        {
            return await _db.SaveChangesAsync();
        }


    }
}
