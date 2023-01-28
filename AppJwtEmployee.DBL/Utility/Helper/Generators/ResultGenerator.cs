using AppJwtEmployee.DBL.Utility.Helper.FileOperations;
using AppJwtEmployee.DBL.Utility.Result.Abstract;
using AppJwtEmployee.DBL.Utility.Result.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Utility.Helper.Generators
{
    public static class ResultGenerator
    {
        private static IResultFactory<TResult> Generate<TResult>(TResult value, string message, bool? status, int statusCode)
               => new ResultFactory<TResult>
               {
                   Status = status,
                   Message = ResponseMessageManager
                       .GetResponseMessageByMessageCode(message),
                   Data = value,
                   StatusCode = statusCode
               };


        internal static IResultFactory<TResult> Generate<TResult>(IResultFactory<TResult> result)
            => Generate<TResult>(result.Data, result.Message, result.Status, result.StatusCode);


    }
}
