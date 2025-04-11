using SOLIDAssessmentProject.Entities.Users;
using System.Xml.Linq;

namespace SOLIDAssessmentProject.Seed
{
    internal static class UserSeed
    {
        public static List<User> GetUsers()
        {
            var users = new List<User>();
            users.AddRange(
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Vasiliy",
                Email = "vasiliy@gmail.com",
                PhoneNumber = "1234567890",
            },

            new User
            {
                Id = Guid.NewGuid(),
                Name = "Viktor",
                Email = "viktor@gmail.com",
                PhoneNumber = "1234567890",
                IsNotificationEnable = true,
            },

            new User
            {
                Id = Guid.NewGuid(),
                Name = "Evgeniy",
                Email = "evgeniy@gmail.com",
                PhoneNumber = "1234567890",
            });

            return users;
        }
    }
}
