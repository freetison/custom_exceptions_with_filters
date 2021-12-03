using static custom_exceptions_with_filters.Exceptions.ExceptionCodes;

namespace custom_exceptions_with_filters.Exceptions.Concrete
{
    public sealed class RecordNotFoundException : CustomException
    {
        private const int ERROR_CODE = (int)ErrorCodes.RecordNotFoundException;

        public override string ExceptionType { get; set; } = "DataBase";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        

        public RecordNotFoundException() : base(ERROR_CODE, "Record Not Found") => HResult = ERROR_CODE;

        public RecordNotFoundException(string message) : base(ERROR_CODE, message) => HResult = ERROR_CODE;
    }
}
