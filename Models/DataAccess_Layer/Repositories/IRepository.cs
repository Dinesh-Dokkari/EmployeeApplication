using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        int Create(T entity);

        T Get(int? id);
        T GetByName(Expression<Func<T, bool>> expression = null);

        int Delete(int? id);

        int SaveDetails();

        int Update(T entity);

    }
}
