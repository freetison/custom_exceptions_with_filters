using static custom_exceptions_with_filters.Exceptions.ExceptionCodes;

namespace custom_exceptions_with_filters.Exceptions.Concrete
{
    public sealed class ValidationException<T> : CustomException where T : class
    {
        private const int ERROR_CODE = (int)ErrorCodes.ModelValidationException;

        public override string ExceptionType { get; set; } = "Validation";
        public override int ErrorCode { get; set; } = ERROR_CODE;

        public T Payload;
        public T Errors { get; set; }

        private ValidationException(T payload) : base(ERROR_CODE, "Domain Validation Error")
        {
            HResult = ERROR_CODE;
            Payload = payload;
        }

        private ValidationException(string message, T payload) : base(ERROR_CODE, message)
        {
            HResult = ERROR_CODE;
            Payload = payload;
        }

        public static ValidationException<T> Apply(string message, T payload) => new ValidationException<T>(message, payload);
        public static ValidationException<T> Create(T payload) => new ValidationException<T>(payload);
    }

}
