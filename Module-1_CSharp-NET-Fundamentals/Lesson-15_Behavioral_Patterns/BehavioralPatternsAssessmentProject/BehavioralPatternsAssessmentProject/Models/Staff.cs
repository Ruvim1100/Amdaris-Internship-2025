using BehavioralPatternsAssessmentProject.Abstraction;

namespace BehavioralPatternsAssessmentProject.Models
{
    internal class Staff : Person
    {
        public Staff(string name, string? email, string? phoneNumber) 
            : base(name, email, phoneNumber){}
    }
}
