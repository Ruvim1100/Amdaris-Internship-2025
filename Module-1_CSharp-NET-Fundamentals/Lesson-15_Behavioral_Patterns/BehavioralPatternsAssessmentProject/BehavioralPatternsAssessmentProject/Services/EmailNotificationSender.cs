using BehavioralPatternsAssessmentProject.Abstraction;
using BehavioralPatternsAssessmentProject.Models;

namespace BehavioralPatternsAssessmentProject.Services
{
    internal class EmailNotificationSender : INotificationSender
    {
        public void Send(string recipient, string content)
        {
            Console.WriteLine($"[Email] \nTo: {recipient} \nMessage: {content}\n");
        }
    }
}
