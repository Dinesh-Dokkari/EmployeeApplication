using System.ComponentModel.DataAnnotations;

namespace DataAccess_Layer.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Employee_Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public double Experience { get; set; }

        [Required]
        public double Annual_CTC { get; set; }
        public double Basic_Amount { get; set; }//50%
        public double HRA_Amount { get; set; }//40%
        public double LTA_Amount { get; set; }//10%
        public double PF_Money { get; }
        public double Gratuity { get; set; }//8%
        public double Professional_Tax { get; }
        public double Income_Tax { get; set; }
        public double Total_Deduction { get; set; }
        public double NetPay { get; set; }
        public double Monthly_CTC { get; set; }

    }
}