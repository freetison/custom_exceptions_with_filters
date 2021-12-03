using custom_exceptions_with_filters.Exceptions;
using custom_exceptions_with_filters.Interfaces;
using custom_exceptions_with_filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tx.Core.GenericFactory;

namespace custom_exceptions_with_filters.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly GenericFactory<int, IExceptionProcessor<List<CustomValidationError>>> _customExceptionProcesorFactory;
        public List<CustomValidationError> Errors { get; set; }


        public ApiExceptionFilter(GenericFactory<int, IExceptionProcessor<List<CustomValidationError>>> genericFactory)
        {
            _customExceptionProcesorFactory = genericFactory;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            List<CustomValidationError> details = new List<CustomValidationError>();
            if (context.Exception.GetType().BaseType == typeof(CustomException))
            {
                var ex = context.Exception as CustomException;
                details =  _customExceptionProcesorFactory.Get(ex.ErrorCode).Process(ex);
            }
            else
            {
                var ex = context.Exception;
                details = new List<CustomValidationError> { new("500", ex.Message) };
            }


            context.Result = new JsonResult(details);

            await base.OnExceptionAsync(context);
        }
    }
}
