using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Utility.Result.Abstract
{
    public interface IResultFactory<TResult>
    {
        string Message { get; set; }
        bool? Status { get; set; }
        int StatusCode { get; set; }
        TResult? Data { get; set; }


       
    }
}
