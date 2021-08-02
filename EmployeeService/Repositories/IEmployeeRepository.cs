using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Employee.Domain;
using EmployeeService.Dtos;
using EmployeeService.Entities;
using EmployeeService.FunctionalExtensions;

namespace EmployeeService.Services
{
    public interface IEmployeeRepository
    {

        Task<Result<List<Employee.Domain.Employees>, ErrorResult>> GetEmployees();

        Task<Result<Employee.Domain.Employees, ErrorResult>> AddEmployee(Employees employee);
        Task<Result<Employee.Domain.Employees, ErrorResult>> UpdateEmployee(Employees employee);
        Task<Result<Employee.Domain.Employees, ErrorResult>> DeleteEmployee(Employees employee);

    }
}
