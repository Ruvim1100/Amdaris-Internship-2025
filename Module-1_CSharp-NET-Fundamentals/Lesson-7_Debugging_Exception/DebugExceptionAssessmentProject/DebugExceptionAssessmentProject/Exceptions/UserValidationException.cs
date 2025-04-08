
namespace DebugExceptionAssessmentProject.Exceptions
{
    internal class UserValidationException : Exception
    {
        public UserValidationException() { }
        public UserValidationException(string message) : base(message) { }
        public UserValidationException(string message, Exception innerException) 
            : base (message, innerException){ }
    }
}