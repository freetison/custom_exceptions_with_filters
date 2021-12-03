using custom_exceptions_with_filters.Exceptions.Concrete;
using custom_exceptions_with_filters.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace custom_exceptions_with_filters.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public List<CustomValidationError> Errors { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Errors = context.ModelState.Keys
                    .SelectMany(key => context.ModelState[key].Errors.Select(x => new CustomValidationError(key, x.ErrorMessage)))
                    .ToList();


                throw ValidationException<List<CustomValidationError>>.Create(Errors);

            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
