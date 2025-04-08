using DebugExceptionAssessmentProject.Entities;
using DebugExceptionAssessmentProject.Exceptions;

namespace DebugExceptionAssessmentProject.Services
{
    internal class UserService
    {
        public void ValidateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot ve null");
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new InvalidUsernameException("Username cannot be empty");
            }

            if (user.Username.Length < 3)
            {
                throw new InvalidUsernameException("Username must be longer then 2 characters");
            }

            if (user.Age < 0)
            {
                throw new InvalidAgeException("Age must greater then 0");
            }

            if (user.Age > 150)
            {
                throw new InvalidAgeException("You cannot be 150 and more yers old");
            }
        }
    }
}
