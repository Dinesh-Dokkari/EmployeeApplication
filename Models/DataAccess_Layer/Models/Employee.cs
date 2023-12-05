using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess_Layer.Models;

public partial class Employee
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EmployeeId { get; set; }
    public string Employee_Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public double Experience { get; set; }
    public double Annual_CTC { get; set; }

    public int LeadId { get; set; }
    public double Basic_Amount { get; set; }//50%
    public double HRA_Amount { get; set; }//40%
    public double LTA_Amount { get; set; }//10%
    public double PF_Money { get; set; }
    public double Gratuity { get; set; }//8%
    public double Professional_Tax { get; set; }
    public double Income_Tax { get; set; }
    public double Total_Deduction { get; set; }
    public double NetPay { get; set; }
    public double Monthly_CTC { get; set; }

}
