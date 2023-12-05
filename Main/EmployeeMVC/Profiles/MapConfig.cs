using AutoMapper;
using DataAccess_Layer.Models;
using EmployeeMVC.Models;

namespace EmployeeMVC.Profiles
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<EmployeeAllDetailsDTO, Employee>().ReverseMap();
            CreateMap<EmployeeAllDetailsDTO, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<EmployeeSalary, SalaryUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
