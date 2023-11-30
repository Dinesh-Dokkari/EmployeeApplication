using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class SalaryUpdateDTO
    {
        public int id { get; set; }

        public int EmployeeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ToDate { get; set; }

        public double New_CTC { get; set; }
    }
}
