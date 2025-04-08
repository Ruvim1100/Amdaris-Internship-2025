using DebugExceptionAssessmentProject.Entities;
using DebugExceptionAssessmentProject.Exceptions;
using DebugExceptionAssessmentProject.Services;

var user1 = new User
{
    Id = Guid.NewGuid(),
    Username = "Ruvim",
    Age = 25
};
var user2 = new User
{
    Id = Guid.NewGuid(),
    Username = "Ru",
    Age = 25
};
var user3 = new User
{
	Id = Guid.NewGuid(),
	Username = "Ruvim",
	Age = -5
};
User user4 = null;


#if DEBUG
Console.WriteLine("Debug mode enabled. Extra validations will run.");
#endif

try
{
	var service = new UserService();

	//service.ValidateUser(user4);

    //throw new UserValidationException("Basic UserValidationException");
    //throw new Exception("Basic Exception");

    Console.WriteLine("Congrats, you entered valid data");
}
catch (InvalidUsernameException ex)
{
	Console.WriteLine($"Username is wrong: {ex.Message}");
}
catch (InvalidAgeException ex)
{
    Console.WriteLine($"Age is wrong: {ex.Message}");
}
catch (UserValidationException ex)
{
    Console.WriteLine($"Somethig wrong with user data: {ex.Message}");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Argument null: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
	throw;
}
finally
{
#if DEBUG
    Console.WriteLine("Program completed (debug mode).");
#else
    Console.WriteLine("Program completed.");
#endif
    Console.ReadLine();
}