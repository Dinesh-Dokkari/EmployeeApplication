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
        }
    }
}
