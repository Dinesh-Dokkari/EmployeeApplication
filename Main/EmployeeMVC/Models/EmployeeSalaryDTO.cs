namespace EmployeeMVC.Models
{
    public class EmployeeSalaryDTO
    {
        public int id { get; set; }

        public int EmployeeId { get; set; }

        public DateOnly FromDate { get; set; }

        public DateOnly ToDate { get; set; }

        public double New_CTC { get; set; }
    }
}
