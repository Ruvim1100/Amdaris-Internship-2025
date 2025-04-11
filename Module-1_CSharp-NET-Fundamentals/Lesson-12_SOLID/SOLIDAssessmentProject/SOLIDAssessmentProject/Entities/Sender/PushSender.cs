using SOLIDAssessmentProject.Abstractions;
using SOLIDAssessmentProject.Entities.Users;

namespace SOLIDAssessmentProject.Entities.Sender
{
    internal class PushSender : INotificationSender
    {
        public void SendNotification(User user, string message)
        {
            Console.WriteLine($"[Push Notification] To ({user.Name} With Id {user.Id}) || Message: \"{message}\"");
        }
    }
}
