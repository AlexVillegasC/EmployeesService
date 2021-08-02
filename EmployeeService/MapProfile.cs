using AutoMapper;
using Employee.Domain;
using EmployeeService.Dtos;
using EmployeeService.Entities;

namespace EmployeeService
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // get
            CreateMap<Employees, EmployeeDto>();
            CreateMap<EmployeeDto, Employees>();
            CreateMap<DeleteEmployeeDto, Employees>();            
        }
    }
}