using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //iki constructor da çalışabilir
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        //overload
        public Result(bool success)
        {
            Success = success;
        }

        //Consturctor dışında set edilemez çünkü get read only özelliği barındırır
        public bool Success { get; }

        public string Message { get; }
    }
}
