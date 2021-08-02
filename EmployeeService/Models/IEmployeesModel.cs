using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EmployeeService.Dtos;
using EmployeeService.FunctionalExtensions;

namespace EmployeeService.Models
{
    public interface IEmployeesModel
    {
        Task<Result<EmployeeDto, ErrorResult>> AddEmployee(EmployeeDto property);        
        Task<Result<EmployeeDto, ErrorResult>> UpdateEmployee(EmployeeDto property);        
        Task<Result<EmployeeDto, ErrorResult>> DeleteEmployee(DeleteEmployeeDto property);        

        public Task<Result<List<EmployeeDto>, ErrorResult>> GetEmployees();
        
    }
}
