using DelegatesAssessmentProject.Entities;

namespace DelegatesAssessmentProject.Functions
{
    internal static class DelegateFunctions
    {

        public static bool IsAdult(User user)
        {
            return user.Age > 17;
        }
        public static List<User> FilterUsers(List<User> users, Func<User, bool> predicate)
        {
            var result = new List<User>();

            foreach ( var user in users )
            {
                if (predicate(user))
                {
                    result.Add(user);
                }
            }

            return result;
        }
    }
}
