using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Models
{
    public class EmployeeSalary
    {
        public int id { get; set; }

        public int EmployeeId { get; set; }

        //[NotMapped]
        public DateTime FromDate { get; set; }

        //[NotMapped]
        public DateTime ToDate { get; set; }

        public double New_CTC { get; set;}
    }
}
