namespace custom_exceptions_with_filters.Exceptions
{
    public static class ExceptionCodes
    {
        public enum ErrorCodes
        {
            RecordNotFoundException = 404,
            ModelValidationException = 605,
            ExternalHttpException = 606,
            DbException = 607
        }
    }

}
