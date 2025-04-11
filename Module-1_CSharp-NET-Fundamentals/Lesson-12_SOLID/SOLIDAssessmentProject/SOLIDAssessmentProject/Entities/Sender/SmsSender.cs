using SOLIDAssessmentProject.Abstractions;
using SOLIDAssessmentProject.Entities.Users;

namespace SOLIDAssessmentProject.Entities.Sender
{
    internal class SmsSender : INotificationSender
    {
        public void SendNotification(User user, string message)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.PhoneNumber))
                return;
            Console.WriteLine($"[SMS] To {user.Name} (With Phone Number {user.PhoneNumber}) || Message: \"{message}\"");
        }
    }
}
