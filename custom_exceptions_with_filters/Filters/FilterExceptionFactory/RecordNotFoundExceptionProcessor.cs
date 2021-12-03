using custom_exceptions_with_filters.Exceptions;
using custom_exceptions_with_filters.Exceptions.Concrete;
using custom_exceptions_with_filters.Interfaces;
using custom_exceptions_with_filters.Models;
using System.Collections.Generic;

namespace custom_exceptions_with_filters.Filters.FilterExceptionFactory
{
    public class RecordNotFoundExceptionProcessor : IExceptionProcessor<List<CustomValidationError>>
    {
        public List<CustomValidationError> Process(CustomException exceptionContext)
        {
            var ex = exceptionContext as RecordNotFoundException;
            var errors = new List<CustomValidationError>
            {
                new CustomValidationError(ex.ErrorCode.ToString(), ex.Message)
            };

            // Log here or send to queue 
            return errors;
        }

    }

}
