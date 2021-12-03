using static custom_exceptions_with_filters.Exceptions.ExceptionCodes;

namespace custom_exceptions_with_filters.Exceptions.Concrete
{
    public sealed class DbException : CustomException
    {
        private const int ERROR_CODE = (int)ErrorCodes.DbException;

        public override string ExceptionType { get; set; } = "DataBase";
        public override int ErrorCode { get; set; } = ERROR_CODE;


        public DbException() : base(ERROR_CODE, "Database Error") => HResult = ERROR_CODE;

        public DbException(string message) : base(ERROR_CODE, message) => HResult = ERROR_CODE;
    }
}
