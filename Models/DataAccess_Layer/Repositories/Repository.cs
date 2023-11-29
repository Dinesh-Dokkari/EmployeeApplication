using DataAccess_Layer.Data;
using DataAccess_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
        public int Create(T entity)
        {
             _db.Set<T>().Add(entity);
            return SaveDetails();

        }

        public int Delete(int? id)
        {
            var entityRecord = _db.Set<T>().Find(id);

            if (entityRecord != null)
            {
                _db.Set<T>().Remove(entityRecord);
            }
            int result = SaveDetails();
            return result;
        }


        public T Get(int? id)
        {
            var entityRecord =  _db.Set<T>().Find(id);
            if(entityRecord != null)
            {
                return entityRecord;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            var records = _db.Set<T>().ToList();
            return records;
        }


        public int Update(T entity)
        {
            _db.Set<T>().Update(entity);
            return  SaveDetails();
        }

        public int SaveDetails()
        {
            return  _db.SaveChanges();
        }

        public T GetByName(Expression<Func<T,bool>> expression = null)
        {
            var entityRecord =  _db.Set<T>().FirstOrDefault(expression);
            if (entityRecord != null)
            {
                return entityRecord;
            }
            else
            {
                return null;
            }
        }
    }
}
