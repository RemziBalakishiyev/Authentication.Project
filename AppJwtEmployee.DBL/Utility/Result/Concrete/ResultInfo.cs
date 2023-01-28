using AppJwtEmployee.DBL.Utility.Result.Abstract;
using Microsoft.AspNetCore.Http;

namespace AppJwtEmployee.DBL.Utility.Result.Concrete
{
    public class ResultInfo<TResult>
    {

       
        public static IResultFactory<TResult> NotFound(string message)
        {
            return new ResultFactory<TResult>
            {
                Status = false,
                Message = message,
                StatusCode = StatusCodes.Status404NotFound
            };

        }

        public static IResultFactory<TResult> Failure(string message, TResult value)
            => new ResultFactory<TResult>(message,value,false,StatusCodes.Status500InternalServerError);

        public static IResultFactory<TResult> BadRequest(string message)
           => new ResultFactory<TResult>(message, false, StatusCodes.Status400BadRequest);

        public static IResultFactory<TResult> Success(string message)
        {
            return new ResultFactory<TResult>
            {
                Status = true,
                Message = message,
                StatusCode= StatusCodes.Status200OK
            };
        }

        public static IResultFactory<TResult> Success(string message, TResult value)
        {
            return new ResultFactory<TResult>
            {
                Status = true,
                Message = message,
                Data = value,
                StatusCode= StatusCodes.Status200OK
                
            };
        }

        public static IResultFactory<TResult> Unauthorize(string message, TResult value)
        {
            return new ResultFactory<TResult>
            {
                Status = true,
                Message = message,
                StatusCode = StatusCodes.Status401Unauthorized

            };
        }
    }
}
