namespace FileSystemAssessmentProject.Exceptions
{
    internal class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() : base() { }
        public EntityAlreadyExistsException(string message) : base(message) { }
        public EntityAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
    }
}
