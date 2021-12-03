﻿namespace custom_exceptions_with_filters.Models
{
    public class CustomValidationError
    {
        public string Code { get; }

        public string Message { get; }

        public CustomValidationError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }

}
