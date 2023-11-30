namespace EmployeeMVC.Models
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Employee_Name { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Experience { get; set; }
        public double Annual_CTC { get; set; }
    }
}
