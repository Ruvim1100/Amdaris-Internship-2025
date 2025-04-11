using SOLIDAssessmentProject.Abstractions;
using SOLIDAssessmentProject.Entities.Users;

namespace SOLIDAssessmentProject.Entities.Sender
{
    internal class EmailSender : INotificationSender
    {
        public void SendNotification(User user, string message)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email))
                return;
            Console.WriteLine($"[Email] To {user.Name} (with Email {user.Email}) || Message: \"{message}\"");
        }
    }
}
