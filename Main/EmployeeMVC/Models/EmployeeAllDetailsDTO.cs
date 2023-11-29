using NPOI.SS.Formula.Functions;

namespace EmployeeMVC.Models
{
    public class EmployeeAllDetailsDTO
    {
        public int EmployeeId { get; set; }
        public string Employee_Name { get; set; }
        public string PhoneNumber { get; set; }
        public double Experience { get; set; }
        public double Annual_CTC { get; set; }
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


        public void SetDetails(int id,string name,string number,double experience,double anuual)
        {
            this.EmployeeId = id;
            this.Employee_Name = name;
            this.PhoneNumber = number;
            this.Experience = experience;
            this.Annual_CTC = anuual;

            Monthly_CTC = Math.Round((Annual_CTC * 100000) / 12.0,2);


            if (Experience<=3 && Experience >= 0)
            {
                this.PF_Money = Math.Round(Monthly_CTC * (3.0 / 100),2);
            }
            else if(Experience<=10 && Experience >3) 
            {
                this.PF_Money = Math.Round(Monthly_CTC * (6.0 / 100),2);
            }
            else
            {
                this.PF_Money = Math.Round(Monthly_CTC * (9.0 / 100),2);
            }

            if(Annual_CTC<=8 && Annual_CTC >= 0)
            {
                this.Income_Tax = 0;
            }
            else if(Annual_CTC > 8 && Annual_CTC <= 15)
            {
                this.Income_Tax = Math.Round(Monthly_CTC * (0.1),2);
            }
            else
            {
                this.Income_Tax = Math.Round(Monthly_CTC * (0.2),2);
            }

            Professional_Tax = Math.Round(Monthly_CTC * (0.8 / 100), 2);

            Basic_Amount = Math.Round(Monthly_CTC * (1.0 / 2),2);

            HRA_Amount = Math.Round(Monthly_CTC * (2.0 / 5),2);

            LTA_Amount = Math.Round(Monthly_CTC * (0.1),2);

            Gratuity = Math.Round(Monthly_CTC * (2.0 / 25),2);

            Total_Deduction = Math.Round(Gratuity + PF_Money + Professional_Tax + Income_Tax,2);

            NetPay = Math.Round(Monthly_CTC - Total_Deduction,2);

        }
        //public void SetMonthlyCTC()
        //{
        //    Monthly_CTC = (Annual_CTC * 100000) / 12.0;
        //}

        //public double GetBasic()
        //{

        //    Basic_Amount = Monthly_CTC * (1.0 / 2);

        //    return Basic_Amount;

        //}

        //public double GetHRA()
        //{
        //    HRA_Amount = Monthly_CTC * (2.0 / 5);

        //    return HRA_Amount;

        //}

        //public double GetLTA()
        //{
        //    LTA_Amount = Monthly_CTC * (0.1);
        //    return LTA_Amount;

        //}

        //public double GetGratuity()
        //{
        //    Gratuity = Monthly_CTC * (2.0 / 25);
        //    return Gratuity;
        //}

        //public double GetTotalDeduction()
        //{
        //    Total_Deduction = Gratuity + PF_Money + Professional_Tax + Income_Tax;
        //    return Total_Deduction;
        //}

        //public double GetNetPay()
        //{
        //    NetPay = Monthly_CTC - Total_Deduction;
        //    return Total_Deduction;
        //}

    }
}
