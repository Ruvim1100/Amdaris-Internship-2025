using SOLIDAssessmentProject.Entities.Users;

namespace SOLIDAssessmentProject.Abstractions
{
    internal interface INotificationSender
    {
        public void SendNotification(User user, string message);
    }
}
