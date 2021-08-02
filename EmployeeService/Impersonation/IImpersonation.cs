using System;
using System.Threading.Tasks;

namespace EmployeeService.Impersonation
{
    public interface IImpersonation
    {
        void Run(Action action);

        Task<T> Run<T>(Func<T> func);

        Task<T> Run<T>(Func<T> func, LogonType logonType, LogonProvider logonProvider);
    }
}