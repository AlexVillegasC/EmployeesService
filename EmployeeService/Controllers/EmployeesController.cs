
using System.Threading.Tasks;
using EmployeeService.Dtos;
using EmployeeService.FunctionalExtensions;
using EmployeeService.Helpers;
using EmployeeService.Impersonation;
using EmployeeService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Employee.Domain;
using System.Collections.Generic;

namespace EmployeeService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/employees")]
    [ApiController]

    // [Authorize(Roles = Roles.Gdlusers)]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesModel _productModel;
        private readonly IImpersonation _impersonation;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeesModel employeeModel, IImpersonation impersonation)
        {
            _logger = logger;
            _productModel = employeeModel;
            _impersonation = impersonation;
        }

        /// <summary>
        /// Get all property repo.
        /// </summary>
        /// <returns>Products name list.</returns>
        [HttpGet("GetEmployees", Name = "GetEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            if (!ModelState.IsValid)
            {
                return ModelState.CreateValidationError();
            }

            // Impersonation.
            var result =
            await _impersonation.Run(
                async () =>
                {
                    var productType = await _productModel.GetEmployees();
                    return productType.ToActionResult(this);
                }, LogonType.LOGON32_LOGON_NEW_CREDENTIALS,
                LogonProvider.LOGON32_PROVIDER_DEFAULT);

            return result.Result;
        }

        /// <summary>
        /// Test.
        /// </summary>
        /// <returns>Template.</returns>
        [HttpPost("AddEmployee", Name = "AddEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto property)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.CreateValidationError();
            }

            // Impersonation.
            var result =
            await _impersonation.Run(
                async () =>
                {
                    var productType = await _productModel.AddEmployee(property);
                    return productType.ToActionResult(this);
                }, LogonType.LOGON32_LOGON_NEW_CREDENTIALS,
                LogonProvider.LOGON32_PROVIDER_DEFAULT);

            return result.Result;
        }

        /// <summary>
        /// Test.
        /// </summary>
        /// <returns>Template.</returns>
        [HttpPut("UpdateEmployee", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.CreateValidationError();
            }

            // Impersonation.
            var result =
            await _impersonation.Run(
                async () =>
                {
                    var productType = await _productModel.UpdateEmployee(employee);
                    return productType.ToActionResult(this);
                }, LogonType.LOGON32_LOGON_NEW_CREDENTIALS,
                LogonProvider.LOGON32_PROVIDER_DEFAULT);

            return result.Result;
        }

        /// <summary>
        /// Test.
        /// </summary>
        /// <returns>Template.</returns>
        [HttpDelete("DeleteEmployee", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(DeleteEmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.CreateValidationError();
            }

            // Impersonation.
            var result =
            await _impersonation.Run(
                async () =>
                {
                    var productType = await _productModel.DeleteEmployee(employee);
                    return productType.ToActionResult(this);
                }, LogonType.LOGON32_LOGON_NEW_CREDENTIALS,
                LogonProvider.LOGON32_PROVIDER_DEFAULT);

            return result.Result;
        }

    }
}