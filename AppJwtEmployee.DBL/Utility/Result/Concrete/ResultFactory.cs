using AppJwtEmployee.DBL.Utility.Result.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJwtEmployee.DBL.Utility.Result.Concrete
{
    public class ResultFactory<TResult> : IResultFactory<TResult>
    {
        public string Message { get; set; }
        public TResult? Data { get; set; }
        public bool? Status { get; set; }
        public int StatusCode { get; set; }
        public ResultFactory()
        {

        }
        public ResultFactory(string message, bool? status ,int statusCode )
        {
            Message = message;
            Status = status;
            StatusCode = statusCode;
        }


        public ResultFactory(string message,TResult data ,bool? status, int statusCode)
        {
            Message = message;
            Status = status;
            StatusCode = statusCode;
            Data = data;
        }
    }
}
