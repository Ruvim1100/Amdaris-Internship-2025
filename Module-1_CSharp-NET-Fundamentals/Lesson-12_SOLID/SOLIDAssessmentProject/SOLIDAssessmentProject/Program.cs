using SOLIDAssessmentProject.Abstractions;
using SOLIDAssessmentProject.Entities.Sender;
using SOLIDAssessmentProject.Seed;
using SOLIDAssessmentProject.Services;

var users = UserSeed.GetUsers();
var senders = new List<INotificationSender>{new EmailSender(), new SmsSender()};
var notificationService = new NotificationService(senders);

notificationService.Send(users[1], "I will find you");
Console.WriteLine();

notificationService.Add(new PushSender());
notificationService.Send(users[2], "I aware you, be careful");
Console.WriteLine();

foreach (var user in users)
{
    notificationService.Send(user, "Just do It, Do it just");
    Console.WriteLine();
}