using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EmployeeService.Dtos;
using EmployeeService.Entities;
using EmployeeService.FunctionalExtensions;
using EmployeeService.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Properties.Data;
using Employee.Domain;

namespace EmployeeService.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const int TimeOut = 1600;
        private readonly ICommandHelper _sqlHelper;
        private readonly ILogger<EmployeeRepository> _logger;
        private static EmployeeContext context = new EmployeeContext();

        public EmployeeRepository(ILogger<EmployeeRepository> logger, ICommandHelper sqlHelper)
        {
            _logger = logger;
            _sqlHelper = sqlHelper;
        }


        /** Add the customer property to the SQL Server DB.
        **/
        public async Task<Result<Employees, ErrorResult>> AddEmployee(Employees employee)
        {
            try
            {
                employee.RecordState = State.Active;
                context.Employees.Add(employee);
                context.SaveChanges();
                await Task.Yield();
                return Result.Ok<Employee.Domain.Employees, ErrorResult>(new Employee.Domain.Employees());
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Error occured on AddEmployee with email: {templateName}.TimeOut in Seconds: {TimeOut}., \n Error: {Message}",
                    employee.Email,
                    TimeOut,
                    e.Message);
                return ResultGenerator.RepositoryError<Employee.Domain.Employees>();
            }
        }

        public async Task<Result<Employees, ErrorResult>> UpdateEmployee(Employees employee)
        {
            try
            {
                var myEmployee = context.Employees.FirstOrDefault(employee => employee.Id == employee.Id && employee.RecordState == State.Active);

                if (myEmployee != null)
                {
                    myEmployee.Age = employee.Age;
                    myEmployee.Address = employee.Address;
                    myEmployee.FirstName = employee.FirstName;
                    myEmployee.LastName = employee.LastName;
                    myEmployee.Email = employee.Email;
                }

                context.SaveChanges();
                await Task.Yield();
                return Result.Ok<Employee.Domain.Employees, ErrorResult>(new Employee.Domain.Employees());
            }
            catch (Exception e)
            {
                _logger.LogError(
                     "Error occured on update with email: {templateName}.TimeOut in Seconds: {TimeOut}., \n Error: {Message}",
                    employee.Email,
                    TimeOut,
                    e.Message);
                return ResultGenerator.RepositoryError<Employee.Domain.Employees>();
            }
        }

        public async Task<Result<Employees, ErrorResult>> DeleteEmployee(Employees myEmployee)
        {
            try
            {
                var value = context.Employees.First(employee => employee.FirstName == myEmployee.FirstName
                                                                    && employee.LastName == myEmployee.LastName
                                                                    && employee.Email == myEmployee.Email
                                                                    && employee.RecordState == State.Active);
                value.RecordState = State.Deleted;
                context.SaveChanges();
                await Task.Yield();
                return Result.Ok<Employee.Domain.Employees, ErrorResult>(new Employee.Domain.Employees());
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Error occured on DeleteEmployee with email: {templateName}.TimeOut in Seconds: {TimeOut}., \n Error: {Message}",
                    myEmployee.Email,
                    TimeOut,
                    e.Message);
                return ResultGenerator.RepositoryError<Employee.Domain.Employees>();
            }
        }

        public async Task<Result<List<Employee.Domain.Employees>, ErrorResult>> GetEmployees()
        {

            try
            {
                var res = context.Employees.Where(employee => employee.RecordState == State.Active).ToList();
                await Task.Yield();
                return Result.Ok<List<Employee.Domain.Employees>, ErrorResult>(res);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Error occured on GetProduct.TimeOut in Seconds: {TimeOut}. \n Error: {Message}", TimeOut,  e.Message);
                return ResultGenerator.RepositoryError<List<Employee.Domain.Employees>>();
            }
        }
    }
}
