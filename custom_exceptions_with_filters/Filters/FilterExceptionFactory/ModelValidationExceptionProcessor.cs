using custom_exceptions_with_filters.Exceptions;
using custom_exceptions_with_filters.Exceptions.Concrete;
using custom_exceptions_with_filters.Interfaces;
using custom_exceptions_with_filters.Models;
using System.Collections.Generic;
using Tx.Core.Extentions.String;

namespace custom_exceptions_with_filters.Filters.FilterExceptionFactory
{
    public class ModelValidationExceptionProcessor : IExceptionProcessor<List<CustomValidationError>>
    {
        public List<CustomValidationError> Process(CustomException exceptionContext)
        {
            var ex = exceptionContext as ValidationException<List<CustomValidationError>>;
            List<CustomValidationError> errors = ex.Payload;

            // Log here or send to queue 
            return errors;
        }
    }

}
