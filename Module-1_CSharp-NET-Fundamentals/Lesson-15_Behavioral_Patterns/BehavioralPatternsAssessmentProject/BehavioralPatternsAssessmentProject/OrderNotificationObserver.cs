using BehavioralPatternsAssessmentProject.Abstraction;
using BehavioralPatternsAssessmentProject.Models;

namespace BehavioralPatternsAssessmentProject
{
    internal class OrderNotificationObserver : IObserver
    {
        private readonly Dictionary<ChannelType, INotificationSender> notificationSenders;

        public OrderNotificationObserver(Dictionary<ChannelType, INotificationSender> senders)
        {
            notificationSenders = senders;
        }

        public void Update(ISubject subject)
        {
            if (subject is not Order order)
                return;

            NotifyRecipients(order.Customers.Cast<Person>(), order);
            NotifyRecipients(order.StaffMembers.Cast<Person>(), order, isStaff: true);
        }

        private void NotifyRecipients(IEnumerable<Person> recipients, Order order, bool isStaff = false)
        {
            foreach (var person in recipients)
            {
                foreach (var channel in person.ContactChannels)
                {
                    if (!notificationSenders.TryGetValue(channel.ChannelType, out var service))
                    {
                        throw new Exception($"No service for {channel.ChannelType}");
                    }

                    var message = isStaff
                        ? $"Hi Staff [{person.Name}], the order \"{order.Book}\" is \"{order.Status}\""
                        : $"Hi Customer [{person.Name}], your order \"{order.Book}\" is \"{order.Status}\"";

                    service.Send(channel.Identifier, message);
                }
            }
        }
    }
}
