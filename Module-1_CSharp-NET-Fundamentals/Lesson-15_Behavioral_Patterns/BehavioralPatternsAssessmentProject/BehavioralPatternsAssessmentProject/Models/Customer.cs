using BehavioralPatternsAssessmentProject.Abstraction;

namespace BehavioralPatternsAssessmentProject.Models
{
    internal class Customer : Person
    {
        public Customer(string name, string? email, string? phoneNumber)
            : base(name, email, phoneNumber) { }
    }
}
