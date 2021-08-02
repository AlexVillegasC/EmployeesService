using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace EmployeeService.Helpers
{
    public interface IHttpContextTokenFetcher
    {
        Task<Result<string>> GetToken();
    }
}