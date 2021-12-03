using custom_exceptions_with_filters.Exceptions;

namespace custom_exceptions_with_filters.Interfaces
{
    public interface IExceptionProcessor<T>
    {
        T Process(CustomException exceptionContext);
    }
}
