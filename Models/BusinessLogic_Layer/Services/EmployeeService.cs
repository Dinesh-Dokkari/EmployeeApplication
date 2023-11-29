
using DataAccess_Layer.Models;
using DataAccess_Layer.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<int> Create(Employee emp)
        {
            return _repo.Create(emp);
        }

        public Task<int> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public Task<Employee> Get(int id)
        {
            return _repo.Get(id);
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<int> Update(Employee emp)
        {
            return _repo.Update(emp);
        }
    }
}
