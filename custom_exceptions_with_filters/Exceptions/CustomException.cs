using System;

namespace custom_exceptions_with_filters.Exceptions
{
    public abstract class CustomException : Exception
    {
        public abstract string ExceptionType { get; set; }
        public abstract int ErrorCode { get; set; }
        
        protected CustomException(int eRROR_CODE)
        { 
        }

        protected CustomException(int code, string message) : base(message) => HResult = code;
        protected CustomException(int code, string message, Exception inner) : base(message, inner) => HResult = code;
    }
}
