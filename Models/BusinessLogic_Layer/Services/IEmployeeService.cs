using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<int> Create(Employee emp);
        Task<int> Update(Employee emp);
        Task<int> Delete(int id);
    }
}
