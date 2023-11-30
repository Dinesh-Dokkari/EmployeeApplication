using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer.Services
{
    public interface IEmployeeSalaryService
    {
        int Create(EmployeeSalary salUpdate);

        IEnumerable<EmployeeSalary> GetAll();



    }
}
