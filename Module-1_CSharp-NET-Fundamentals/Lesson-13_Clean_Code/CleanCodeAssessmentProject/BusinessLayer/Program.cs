using BusinessLayer.Calculators;
using BusinessLayer.Models;
using BusinessLayer.Repository;
using BusinessLayer.Services;
using BusinessLayer.Validators;

namespace BusinessLayer
{
    internal class Program
    {

        static void Main(string[] args) 
        {
            Console.WriteLine("The App is started");

            var speaker = new Speaker
            {
                FirstName = "Vasiliy",
                LastName = "Goloborodko",
                Email = "vasiliy@gmail.com",
                Experience = 12,
                HasBlog = true,
                BlogURL = "DirtyCode.com",
                Browser = new WebBrowser("Chrome", 10),
                Certifications = new() {"1", "2", "3"},
                Employer = "Google",
                Sessions = new List<Session> { new Session("MVC4", "Web MVC4 Advanced"), new Session("Node.js", "Web Node.js Basics") }

            };

            var service = new SpeakerService(
                new SessionApprover(),
                new SpeakerValidator(),
                new InMemoryRepository(),
                new RegistrationCalculator()
                );

            Console.WriteLine(service.RegisterSpeaker(speaker));
        }
    }
}
