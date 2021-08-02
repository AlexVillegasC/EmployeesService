using EmployeeService.FunctionalExtensions;

namespace EmployeeService.Helpers
{
    using CSharpFunctionalExtensions;
    using EmployeeService.FunctionalExtensions;

    public class ResultGenerator
    {
        public static Result<T, ErrorResult> RepositoryError<T>()
        {
            return Result.Fail<T>(ErrorResult.DefaultError).ToRepositoryErrorResult();
        }

        public static Result<T, ErrorResult> NotFoundError<T>()
        {
            return Result.Fail<T>(ErrorResult.DefaultError).ToNotFoundErrorResult();
        }

        public static Result<T, ErrorResult> ValidationError<T>(string errorMessage)
        {
            return Result.Fail<T>(ErrorResult.DefaultError).ToValidationFailedErrorResult(errorMessage);
        }

        public static Result<T, ErrorResult> BadRequestError<T>(string errorMessage)
        {
            return Result.Fail<T>(ErrorResult.DefaultError).ToBadRequestErrorResult(errorMessage);
        }
    }
}