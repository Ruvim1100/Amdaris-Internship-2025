using DisposalAssessmentProject;

Console.Write("Enter your email: ");
string userEmail = Console.ReadLine();

try
{
    using (var sender = new EmailSender())
    {
        sender.SendEmail(userEmail);
        Console.WriteLine("Thank you for subscribing!");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Something went wrong: " + ex.Message);
}

GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();