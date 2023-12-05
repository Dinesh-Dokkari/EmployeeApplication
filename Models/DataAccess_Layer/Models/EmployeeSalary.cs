using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]

        public DateTime FromDate { get; set; }

        //[NotMapped]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]

        public DateTime ToDate { get; set; }

        public double New_CTC { get; set;}
    }
}
