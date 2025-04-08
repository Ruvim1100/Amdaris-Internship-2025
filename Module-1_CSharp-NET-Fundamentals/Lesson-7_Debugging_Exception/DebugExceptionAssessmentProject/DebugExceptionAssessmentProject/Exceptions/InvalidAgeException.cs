namespace DebugExceptionAssessmentProject.Exceptions
{
    internal class InvalidAgeException : UserValidationException
    {
        public InvalidAgeException() { }
        public InvalidAgeException(string message) : base(message) { }
        public InvalidAgeException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
