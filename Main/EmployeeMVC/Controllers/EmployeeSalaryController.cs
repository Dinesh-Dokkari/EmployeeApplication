using AutoMapper;
using BusinessLogic_Layer.Services;
using DataAccess_Layer.Models;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Spreadsheet;

namespace EmployeeMVC.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly IEmployeeSalaryService _service;
        private readonly IMapper _map;

        public EmployeeSalaryController(IEmployeeSalaryService service,IMapper map)
        {
            _service = service;
            _map = map;
        }
        public IActionResult Index()
        {
            var updateSalaries = _service.GetAll();
            return View(_map.Map<IEnumerable<SalaryUpdateDTO>>(updateSalaries));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SalaryUpdateDTO salUpdate)
        {
            if(salUpdate == null)
            {
                return View();
            }
            else
            {
                var result = _map.Map<EmployeeSalary>(salUpdate);
                _service.Create(result);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var empSal = _service.GetByName(u => u.EmployeeId == id);

            if (empSal == null)
            {
                return NotFound();
            }
            return View("Edit",_map.Map<SalaryUpdateDTO>(empSal));
        }

        [HttpPost]
        public IActionResult Edit(SalaryUpdateDTO empSal)
        {
            if (empSal == null)
            {
                return View();
            }
            else if(ModelState.IsValid)
            {
                _service.Update(_map.Map<EmployeeSalary>(empSal));
            }

            return RedirectToAction("Index");
        }
    }
}
