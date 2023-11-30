using DataAccess_Layer.Models;
using DataAccess_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IRepository<EmployeeSalary> _repo;

        public EmployeeSalaryService(IRepository<EmployeeSalary> repo)
        {
            _repo = repo;
            
        }
        public int Create(EmployeeSalary salUpdate)
        {
            return _repo.Create(salUpdate);
        }

        public IEnumerable<EmployeeSalary> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
