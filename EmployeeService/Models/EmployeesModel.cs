using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using EmployeeService.Dtos;
using EmployeeService.Entities;
using EmployeeService.FunctionalExtensions;
using EmployeeService.Helpers;
using EmployeeService.Services;
using Microsoft.Extensions.Logging;
using Employee.Domain;

namespace EmployeeService.Models
{
    public class EmployeesModel : IEmployeesModel
    {
        private readonly ILogger<EmployeesModel> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeesRepository;        

        public EmployeesModel(ILogger<EmployeesModel> logger, IMapper mapper, IEmployeeRepository propertiesRepository)
        {
            // Injecting dependencies.
            _logger = logger;
            _mapper = mapper;
            _employeesRepository = propertiesRepository;
        }

        public async Task<Result<EmployeeDto, ErrorResult>> AddEmployee(EmployeeDto employee)
        {
            // Saving in the Properties repository, i.e. SQL Server DB which contains saved Properties.
            var myEmployee = _mapper.Map<Employees>(employee);
            var res = await _employeesRepository.AddEmployee(myEmployee);
            if (res.IsFailure)
            {
                _logger.LogError(
                    "Failed to insert Employee with name: {name} {lastname}, Email: {email} from repository. {Error}",
                    employee.FirstName, employee.LastName, employee.Email,
                    res.Error);
                return ResultGenerator.RepositoryError<EmployeeDto>();
            }

            var employeeResult = res.Value;
            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeResult);
            return Result.Ok<EmployeeDto, ErrorResult>(employeeToReturn);
        }

        public async Task<Result<EmployeeDto, ErrorResult>> UpdateEmployee(EmployeeDto employee)
        {
            // Saving in the Properties repository, i.e. SQL Server DB which contains saved Properties.
            var myEmployee = _mapper.Map<Employees>(employee);
            var res = await _employeesRepository.UpdateEmployee(myEmployee);
            if (res.IsFailure)
            {
                _logger.LogError(
                    "Failed to update Employee with name: {name} {lastname}, Email: {email} from repository. {Error}",
                    employee.FirstName, employee.LastName, employee.Email,
                    res.Error);
                return ResultGenerator.RepositoryError<EmployeeDto>();
            }

            var employeeResult = res.Value;
            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeResult);
            return Result.Ok<EmployeeDto, ErrorResult>(employeeToReturn);
        }
        public async Task<Result<EmployeeDto, ErrorResult>> DeleteEmployee(DeleteEmployeeDto employee)
        {
            // Saving in the Properties repository, i.e. SQL Server DB which contains saved Properties.
            var myEmployee = _mapper.Map<Employees>(employee);
            var res = await _employeesRepository.DeleteEmployee(myEmployee);
            if (res.IsFailure)
            {
                _logger.LogError(
                    "Failed to get product with id: {productName} from repository. {Error}",
                    employee,
                    res.Error);
                return ResultGenerator.RepositoryError<EmployeeDto>();
            }

            var employeeResult = res.Value;
            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeResult);
            return Result.Ok<EmployeeDto, ErrorResult>(employeeToReturn);
        }

        public async Task<Result<List<EmployeeDto>, ErrorResult>> GetEmployees()
        {
            // Get Properties from repository, i.e. SQL Server DB which contains saved Properties.
            var employees = await _employeesRepository.GetEmployees();
            if (employees.IsFailure)
            {
                _logger.LogError(
                    "Failed to get products  from repository. {Error}",
                    employees.Error);
                return ResultGenerator.RepositoryError<List<EmployeeDto>>();
            }

            // Automapper is a great Lib to Map between data types.
            // The goal here is to separe backend logic with API output data.
            var productsToReturn = _mapper.Map<List<EmployeeDto>>(employees.Value);

            // Return either sucessfull result or error status.
            return Result.Ok<List<EmployeeDto>, ErrorResult>(productsToReturn);
        }
    }
}
