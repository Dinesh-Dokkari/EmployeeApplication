using AutoMapper;
using BusinessLogic_Layer.Services;
using DataAccess_Layer.Models;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Dml;
using NPOI.OpenXmlFormats.Spreadsheet;
using OfficeOpenXml;
using System.Collections.Generic;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _map;

        public EmployeeController(IEmployeeService service,IMapper map)
        {
            _service = service;
            _map = map;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> DownLoadAll()
        {
            var Employees = await _service.GetAll();
            foreach (var employee in Employees)
            {
                Employee(employee.EmployeeId);

            }
            return View();
        }

        public async Task<IActionResult> GetList()
        {

            string file = @"C:\Users\DDOKKARI\Downloads\EmployeeData (3).xlsx";
            using (ExcelPackage package = new ExcelPackage(new FileInfo(file)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var sheet = package.Workbook.Worksheets["Sheet1"];
                var columnInfo = Enumerable.Range(1, sheet.Dimension.Columns).ToList().Select(n => new { Index = n, ColumnName = sheet.Cells[1, n].Value.ToString() });

                for (int row = 2; row <= sheet.Dimension.Rows; row++)
                {
                    EmployeeDTO employee = (EmployeeDTO)Activator.CreateInstance(typeof(EmployeeDTO));//generic object
                    foreach (var prop in typeof(EmployeeDTO).GetProperties())
                    {
                        if (!string.IsNullOrWhiteSpace(prop.Name))
                        {
                            var col = columnInfo.SingleOrDefault(c => c.ColumnName == prop.Name);
                            if (col != null)
                            {
                                var column = col.Index;
                                var val = sheet.Cells[row, column].Value;
                                var propType = prop.PropertyType;
                                prop.SetValue(employee, Convert.ChangeType(val, propType));
                            }

                        }
                    }
                    if (employee != null)
                    {
                        EmployeeAllDetailsDTO employeeAllDetails = new EmployeeAllDetailsDTO();
                        employeeAllDetails.SetDetails(employee.Employee_Name,employee.PhoneNumber,employee.Experience,employee.Annual_CTC);
                        var employeedb = _map.Map<Employee>(employeeAllDetails);
                        await _service.Create(employeedb);
                        
                    }
                }
            }
            var results = _map.Map<IEnumerable<EmployeeAllDetailsDTO>>(await _service.GetAll());
            return View("PaySlip", results);
        }

        public async void Employee(int id)
        {
            var employee = await _service.Get(id);

            //EmployeeAllDetailsDTO employeeAllDetails = new EmployeeAllDetailsDTO();



            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderHtmlAsPdf($"    <h1>Basic Employee PaySlip</h1>" +
                $"   <p>---------------------------------------------------------</p>" +
                $"    <h3>Employee Name : {employee.Employee_Name}</h3>" +
                $"    <h3>Employee ID : {employee.EmployeeId}</h3>" +
                $"    <h3>PhoneNumber : {employee.PhoneNumber}</h3>" +
                $"   <h3>Experience : {employee.Experience}</h3>" +
                $"   <h3>Annual CTC : {employee.Annual_CTC}</h3>" +
                $"   <h3>Basic Amount(50%) : {employee.Basic_Amount}</h3>" +
                $"    <h3>HRA Amount(40%) : {employee.HRA_Amount}</h3>" +
                $"   <h3>LTA Amount(10%) : {employee.LTA_Amount}</h3>" +
                $"    <h3>PF Amount : {employee.PF_Money}</h3>" +
                $"   <h3>Gratuity :{employee.Gratuity}</h3>" +
                $"  <h3>Professional Tax : {employee.Professional_Tax}</h3>" +
                $"    <h3>Income Tax: {employee.Income_Tax}</h3>" +
                $"   <h3>Professional Tax : {employee.Professional_Tax}</h3>" +
                $"   <h3>Total Deduction : {employee.Total_Deduction}</h3>" +
                $"   <h3>NetPay : {employee.NetPay}</h3>");

            pdf.SaveAs(@"C:\Users\DDOKKARI\Documents\November Projects\EmployeesApplication\EmployeeApplication\Main\EmployeeMVC\EmployeePaySlips\" + employee.Employee_Name + ".pdf");
        }
    }
}
