using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.BlazorApp.Data
{
    public class Error
    {
        public int Identifier { get; set; }

        public ExceptionType ExceptionType { get; set; }

        public string Message { get; set; }

        public Error(string errorMessage, ExceptionType? exceptionType = null, int? identifier = null)
        {
            Message = errorMessage;
            Identifier = identifier ?? int.MinValue;
            ExceptionType = exceptionType ?? ExceptionType.Exception;
        }
    }
}
