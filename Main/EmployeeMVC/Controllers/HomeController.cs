//using EmployeeMVC.Models;
//using Microsoft.AspNetCore.Components.RenderTree;
//using Microsoft.AspNetCore.Mvc;
//using NPOI.SS.Formula.Functions;
//using NPOI.SS.UserModel;
//using OfficeOpenXml;
//using System.IO;
//using System.Text;
//using Rotativa;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Diagnostics;
//using IronPdf;
//using Microsoft.AspNetCore.Components.Web;
//using Elfie.Serialization;
//using HandlebarsDotNet;
//using System.Xml.Linq;

//namespace EmployeeMVC.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        //static List<Employee> Employees = new List<Employee>();


//        public IActionResult Index()
//        {

//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }


//        public IActionResult GetList()
//        {
//            string file = @"C:\Users\DDOKKARI\Downloads\EmployeeData (2).xlsx";
//            using (ExcelPackage package = new ExcelPackage(new FileInfo(file)))
//            {
//                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//                var sheet = package.Workbook.Worksheets["Sheet1"];
//                var columnInfo = Enumerable.Range(1, sheet.Dimension.Columns).ToList().Select(n => new { Index = n, ColumnName = sheet.Cells[1, n].Value.ToString() });

//                for (int row = 2; row <= sheet.Dimension.Rows; row++)
//                {
//                    Employee employee = (Employee)Activator.CreateInstance(typeof(Employee));//generic object
//                    foreach (var prop in typeof(Employee).GetProperties())
//                    {
//                        if (!string.IsNullOrWhiteSpace(prop.Name))
//                        {
//                            var col = columnInfo.SingleOrDefault(c => c.ColumnName == prop.Name);
//                            if (col != null)
//                            {
//                                var column = col.Index;
//                                var val = sheet.Cells[row, column].Value;
//                                var propType = prop.PropertyType;
//                                prop.SetValue(employee, Convert.ChangeType(val, propType));
//                            }

//                        }
//                    }
//                    if (employee != null)
//                    {
//                        Employees.Add(employee);
//                    }
//                }
//            }
//            return View("PaySlip", Employees);
//        }



//        public static void Employee(int id)
//        {
//            var employee = Employees.Where(a => a.EmployeeId == id).FirstOrDefault();

//            EmployeeAllDetailsDTO employeeAllDetails = new EmployeeAllDetails(employee.EmployeeId,employee.Employee_Name,employee.PhoneNumber,employee.Experience,employee.Annual_CTC);



//            var renderer = new ChromePdfRenderer();
//            var pdf = renderer.RenderHtmlAsPdf($"    <h1>Basic Employee PaySlip</h1>" +
//                $"   <p>---------------------------------------------------------</p>" +
//                $"    <h3>Employee Name : {employeeAllDetails.Employee_Name}</h3>" +
//                $"    <h3>Employee ID : {employeeAllDetails.EmployeeId}</h3>" +
//                $"    <h3>PhoneNumber : {employeeAllDetails.PhoneNumber}</h3>" +
//                $"   <h3>Experience : {employeeAllDetails.Experience}</h3>" +
//                $"   <h3>Annual CTC : {employeeAllDetails.Annual_CTC}</h3>" +
//                $"   <h3>Basic Amount(50%) : {employeeAllDetails.Basic_Amount}</h3>" +
//                $"    <h3>HRA Amount(40%) : {employeeAllDetails.HRA_Amount}</h3>" +
//                $"   <h3>LTA Amount(10%) : {employeeAllDetails.LTA_Amount}</h3>" +
//                $"    <h3>PF Amount : {employeeAllDetails.PF_Money}</h3>" +
//                $"   <h3>Gratuity :{employeeAllDetails.Gratuity}</h3>" +
//                $"  <h3>Professional Tax : {employeeAllDetails.Professional_Tax}</h3>" +
//                $"    <h3>Income Tax: {employeeAllDetails.Income_Tax}</h3>" +
//                $"   <h3>Professional Tax : {employeeAllDetails.Professional_Tax}</h3>" +
//                $"   <h3>Total Deduction : {employeeAllDetails.Total_Deduction}</h3>" +
//                $"   <h3>NetPay : {employeeAllDetails.NetPay}</h3>");

//            pdf.SaveAs(@"C:\Users\DDOKKARI\Documents\November Projects\EmployeesApplication\EmployeeApplication\Main\EmployeeMVC\EmployeePaySlips\" +employee.Employee_Name +".pdf");
//        }

//        public IActionResult DownLoadAll()
//        {
//            foreach(var employee in Employees)
//            {
//                Employee(employee.EmployeeId);

//            }
//            return View();
//        }



//    }
//}
