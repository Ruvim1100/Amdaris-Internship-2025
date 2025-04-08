using DelegatesAssessmentProject.Entities;
using DelegatesAssessmentProject.Extensions;
using DelegatesAssessmentProject.Functions;

var users = new List<User>
{
            new User { Id = 1, Name = "Vasiliy", Age = 25 },
            new User { Id = 2, Name = "Egor", Age = 30 },
            new User { Id = 3, Name = "Diana", Age = 22 },
            new User { Id = 4, Name = "Carolina", Age = 15 }
};

users.PrintUsers();

Console.WriteLine("\nPrint only adult users (using delegates)");
var adultusers = DelegateFunctions.FilterUsers(users, DelegateFunctions.IsAdult);
adultusers.PrintUsers();

Console.WriteLine("\nPrint only adult users (using anonymus method)");
adultusers = DelegateFunctions.FilterUsers(users, delegate (User u) { return u.Age > 17; });
adultusers.PrintUsers();

Console.WriteLine("\nPrint only adult users (using Lambda)");
adultusers = DelegateFunctions.FilterUsers(users, user => user.Age > 17);
adultusers.PrintUsers();

Console.WriteLine("\nPrint only adult users (using extensions)");
adultusers = users.GetAdults();
adultusers.PrintUsers();

Console.WriteLine("\nPrint only adult users (using linq)");
adultusers = users.Where(u => u.Age > 17).ToList();
adultusers.PrintUsers();
