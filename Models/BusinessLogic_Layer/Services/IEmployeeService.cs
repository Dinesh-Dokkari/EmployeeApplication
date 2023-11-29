using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);

        Employee GetByName(Expression<Func<Employee, bool>> expression = null);
        int Create(Employee emp);
        int Update(Employee emp);
        int Delete(int id);

        int SaveChanges();
    }
}
