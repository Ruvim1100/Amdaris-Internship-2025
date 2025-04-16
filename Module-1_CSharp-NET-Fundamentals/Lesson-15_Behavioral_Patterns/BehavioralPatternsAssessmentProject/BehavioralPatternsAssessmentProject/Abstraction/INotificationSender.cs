namespace BehavioralPatternsAssessmentProject.Abstraction
{
    internal interface INotificationSender
    {
        void Send(string recipient, string content);
    }
}
