using EmployeeService.Helpers;
using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService
{
    internal static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeesModel, EmployeesModel>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpContextTokenFetcher, HttpContextTokenFetcher>();
            services.AddTransient<ICommandHelper, CommandHelper>();

            return services;
        }
    }
}