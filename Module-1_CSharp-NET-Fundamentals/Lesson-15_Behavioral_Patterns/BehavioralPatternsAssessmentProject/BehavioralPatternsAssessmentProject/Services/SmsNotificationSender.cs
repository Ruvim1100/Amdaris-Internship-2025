using BehavioralPatternsAssessmentProject.Abstraction;
using BehavioralPatternsAssessmentProject.Models;

namespace BehavioralPatternsAssessmentProject.Services
{
    internal class SmsNotificationSender : INotificationSender
    {
        public void Send(string recipient, string content)
        {
            Console.WriteLine($"[Sms] \nTo: {recipient} \nMessage: {content}\n");
        }
    }
}
