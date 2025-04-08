namespace DebugExceptionAssessmentProject.Exceptions
{
    internal class InvalidUsernameException : UserValidationException
    {
        public InvalidUsernameException() { }
        public InvalidUsernameException(string message) : base(message) { }
        public InvalidUsernameException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
