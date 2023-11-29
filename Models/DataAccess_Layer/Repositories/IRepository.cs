using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<int> Create(T entity);

        Task<T> Get(int? id);

        Task<int> Edit(int? id, T entity);

        Task<int> Delete(int? id);

        Task<int> SaveDetails();

        Task<int> Update(T entity);

    }
}
