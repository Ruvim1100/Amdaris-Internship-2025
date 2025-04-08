using DelegatesAssessmentProject.Entities;
using DelegatesAssessmentProject.Functions;

namespace DelegatesAssessmentProject.Extensions
{
    internal static class CollectionExtensions
    {
        public static void PrintUsers(this List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name, 8}, Age: {user.Age} ");
            }
        }

        public static List<User> GetAdults(this List<User> users)
        {
            return DelegateFunctions.FilterUsers(users, user => user.Age > 17);
            //return users.Where(u => u.Age > 17).ToList();
        }
    }
}
