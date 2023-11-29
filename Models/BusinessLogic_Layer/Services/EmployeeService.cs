
using DataAccess_Layer.Models;
using DataAccess_Layer.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repo;

        public EmployeeService(IRepository<Employee> repo)
        {
            _repo = repo;   
        }

        public int Create(Employee emp)
        {
            return  _repo.Create(emp);
        }

        public int Delete(int id)
        {
            return  _repo.Delete(id);
        }

        public Employee Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repo.GetAll();
        }

        public Employee GetByName(Expression<Func<Employee, bool>> expression = null)
        {
            return _repo.GetByName(expression);
        }

        public int SaveChanges()
        {
            return _repo.SaveDetails();
        }

        public int Update(Employee emp)
        {
            return _repo.Update(emp);
        }

        
    }
}
