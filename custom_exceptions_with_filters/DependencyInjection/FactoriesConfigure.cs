using custom_exceptions_with_filters.Filters.FilterExceptionFactory;
using custom_exceptions_with_filters.Interfaces;
using custom_exceptions_with_filters.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Tx.Core.GenericFactory;
using static custom_exceptions_with_filters.Exceptions.ExceptionCodes;

namespace custom_exceptions_with_filters.DependencyInjection
{
    public static class FactoriesConfigure
    {
        public static IServiceCollection AddValidationExceptionFactory(this IServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var factory = new GenericFactory<int, IExceptionProcessor<List<CustomValidationError>>>();
                factory.Register((int)ErrorCodes.ModelValidationException, () => ActivatorUtilities.CreateInstance<ModelValidationExceptionProcessor>(sp));
                factory.Register((int)ErrorCodes.RecordNotFoundException, () => ActivatorUtilities.CreateInstance<RecordNotFoundExceptionProcessor>(sp));
                factory.Register((int)ErrorCodes.DbException, () => ActivatorUtilities.CreateInstance<DbExceptionProcessor>(sp));
                return factory;
            });

            return services;
        }

    }
}
