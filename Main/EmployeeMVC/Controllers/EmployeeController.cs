using AutoMapper;
using BusinessLogic_Layer.Services;
using DataAccess_Layer.Models;
using EmployeeMVC.Models;
using MathNet.Numerics.Distributions;
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
        private readonly IEmployeeSalaryService _salservice;
        private readonly IMapper _map;

        public EmployeeController(IEmployeeService service,IMapper map,IEmployeeSalaryService salservice)
        {
            _service = service;
            _salservice = salservice;
            _map = map;
        }


        public IActionResult Index()
        {
            var results = _map.Map<IEnumerable<EmployeeAllDetailsDTO>>(_service.GetAll());
            return View("EmployeePaySlip", results);
        }

        public IActionResult ExcelFileReader()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExcelFileReader(IFormFile file)
        {
            string filePath = null;


            if (file != null && file.Length > 0)
            {
                var uploadDirectory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";
                string uniqueName = Guid.NewGuid().ToString() + "_" + file.FileName;

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                var extension = Path.GetExtension(file.FileName);


                if (extension.ToLower().Equals(".xls") || extension.ToLower().Equals(".xlsx"))
                {
                    filePath = Path.Combine(uploadDirectory, uniqueName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                }
                else
                {
                    ViewBag.File = "Please Upload .xls,.xlsx Excel formats only!!";
                    return View();

                }


            }

            if (filePath != null)
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
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
                            var today = DateTime.Now;
                            var UpdateSalary = _salservice.GetAll().FirstOrDefault(e => e.EmployeeId == employee.EmployeeId  && e.ToDate < today);
                            if (UpdateSalary != null)
                            {
                                employee.Annual_CTC = UpdateSalary.New_CTC;
                            }


                            EmployeeAllDetailsDTO employeeAllDetails = new EmployeeAllDetailsDTO();
                            employeeAllDetails.SetDetails(employee.EmployeeId, employee.Employee_Name,employee.Email, employee.PhoneNumber, employee.Experience, employee.Annual_CTC);
                            var employeedb = _map.Map<Employee>(employeeAllDetails);

                            var searchEmployee = _service.GetByName(s => s.EmployeeId == employee.EmployeeId);
                            if (searchEmployee != null)
                            {
                                _service.Update(employeedb);
                            }
                            else
                            {
                                _service.Create(employeedb);
                            }

                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult DownLoadAll()
        {
            var Employees =  _service.GetAll();
            foreach (var employee in Employees)
            {
                PaySlipDownload(employee.EmployeeId);

            }
            return View();
        }

        public void PaySlipDownload(int id)
        {
            var employee = _service.Get(id);

            //EmployeeAllDetailsDTO employeeAllDetails = new EmployeeAllDetailsDTO();



            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderHtmlAsPdf($"<h1>Basic Employee PaySlip(Monthly)</h1>" +
                $"   <p>-------------------------------------------------------------------------</p>" +
                $"   <h3>Employee Name :     {employee.Employee_Name}</h3>" +
                $"   <h3>Employee ID :       {employee.EmployeeId}</h3>" +
                $"   <h3>Employee Email :    {employee.Email}</h3>" +
                $"   <h3>PhoneNumber :       {employee.PhoneNumber}</h3>" +
                $"   <h3>Experience :        {employee.Experience} Years</h3>" +
                $"   <h3>Annual CTC :        {employee.Annual_CTC} Lakhs</h3>" +
                $"   <h3>Basic Amount(50%) : {employee.Basic_Amount} Rupees</h3>" +
                $"   <h3>HRA Amount(40%) :   {employee.HRA_Amount} Rupees</h3>" +
                $"   <h3>LTA Amount(10%) :   {employee.LTA_Amount} Rupees</h3>" +
                $"   <h3>PF Amount :         {employee.PF_Money} Rupees</h3>" +
                $"   <h3>Gratuity :          {employee.Gratuity} Rupees</h3>" +
                $"   <h3>Professional Tax :  {employee.Professional_Tax} Rupees</h3>" +
                $"   <h3>Income Tax:         {employee.Income_Tax} Rupees</h3>" +
                $"   <h3>Professional Tax :  {employee.Professional_Tax} Rupees</h3>" +
                $"   <h3>Total Deduction :   {employee.Total_Deduction} Rupees</h3>" +
                $"   <h3>NetPay :            {employee.NetPay} Rupees</h3>");

            pdf.SaveAs(@"C:\Users\DDOKKARI\Documents\November Projects\EmployeesApplication\EmployeeApplication\Main\EmployeeMVC\PaySlips\" + employee.Employee_Name + ".pdf");
        }
    }
}
