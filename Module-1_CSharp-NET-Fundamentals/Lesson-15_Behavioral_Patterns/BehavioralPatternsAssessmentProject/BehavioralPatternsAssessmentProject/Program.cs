using BehavioralPatternsAssessmentProject.Models;
using BehavioralPatternsAssessmentProject;
using BehavioralPatternsAssessmentProject.Services;

var emailService = new EmailNotificationSender();
var smsService = new SmsNotificationSender();

var notificationObserver = new OrderNotificationObserver(new()
{
    { ChannelType.Email, emailService },
    { ChannelType.Sms, smsService }
});

var order = new Order("Behavioral Design Patterns");
order.Attach(notificationObserver);

var customer = new Customer("Vasiliy", null, "068934551");
var staff1 = new Staff("Igor", "igor@gmail.com", null);
var staff2 = new Staff("Vlada", "vlada@gmail.com", "067942317");

order.AddCustomer(customer);
order.AddStaff(staff1);
order.AddStaff(staff2);

order.UpdateStatus(OrderStatus.ReadyToShip);

order.RemoveStaff(staff2);
order.UpdateStatus(OrderStatus.Shipped);