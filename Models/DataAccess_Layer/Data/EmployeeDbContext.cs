using DataAccess_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
