using SOLIDAssessmentProject.Abstractions;
using SOLIDAssessmentProject.Entities.Users;

namespace SOLIDAssessmentProject.Services
{
    internal class NotificationService(List<INotificationSender> senders)
    {
        private readonly List<INotificationSender> _senders = [..senders];

        public void Send(User user, string message) 
        {
            if (!user.IsNotificationEnable)
            {
                return;
            }

            foreach (var sendr in _senders)
            {
                sendr.SendNotification(user, message);
            }
        }

        public void Add(INotificationSender sender)
        {
            _senders.Add(sender);
        }

    }
}
