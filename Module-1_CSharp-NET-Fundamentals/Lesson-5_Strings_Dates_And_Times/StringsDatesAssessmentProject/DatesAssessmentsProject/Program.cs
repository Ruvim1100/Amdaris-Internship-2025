using System.Globalization;

string str = "       Hello, World! ";
string modifiedString = str.Trim().Replace("World", "Amdaris");
Console.WriteLine($"Modified string: {modifiedString}");
Console.WriteLine($"===================================================================");

string str2 = "Hi, will you drink a coffee? Latte, Cappuccino, Espresso";
string[] words = str2.Substring(28).Split(' ');
string joined = string.Join(" | ", words);
Console.WriteLine($"Coffee types: {joined}");
Console.WriteLine($"===================================================================");

DateTime birthDate = new DateTime(1999, 5, 9);
Console.WriteLine($"I was born {birthDate.ToString("d")}");
TimeSpan myHours = DateTime.Now - birthDate;
Console.WriteLine($"I live here about: {(int)myHours.TotalHours} hours");
TimeSpan duration = TimeSpan.FromDays(10);
myHours = DateTime.Now - birthDate - duration;
Console.WriteLine($"Trying to be younger) I live here about: {myHours.TotalHours - 5} hours");
Console.WriteLine($"===================================================================");

TimeSpan difference = DateTime.Now - DateTime.UtcNow;
Console.WriteLine($"The difference between zones is {difference.Hours}");
Console.WriteLine($"===================================================================");


DateTimeOffset currentDateTimeOffset = DateTimeOffset.Now;
Console.WriteLine("Current time with offset: " + currentDateTimeOffset);
DateTimeOffset utcDateTimeOffset = DateTimeOffset.UtcNow;
Console.WriteLine("Current time UTC " + utcDateTimeOffset);
Console.WriteLine($"===================================================================");

var timeZones = TimeZoneInfo.GetSystemTimeZones();

//foreach (var item in timeZones)
//{
//    Console.WriteLine(item);
//}
TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
Console.WriteLine("The Local Time Zone is: "+ localTimeZone);
Console.WriteLine($"Is daylight saving time? " + localTimeZone.IsDaylightSavingTime(DateTime.Now));

TimeZoneInfo AZone = TimeZoneInfo.FindSystemTimeZoneById("CAT");
DateTime nyTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, AZone);
Console.WriteLine($"Time in Central Afrika is: {nyTime}");
Console.WriteLine($"===================================================================");

Console.WriteLine(CultureInfo.CurrentCulture.Name);

DateTime dateTime = DateTime.Now;
double mySalaryInAmdaris = 10_000;

CultureInfo USAculture = new CultureInfo("en-US"); // Английский (США)
CultureInfo FRculture = new CultureInfo("fr-FR"); // Французский (Франция)
CultureInfo RUculture = new CultureInfo("ru-RU"); // Русский (Россия)
CultureInfo MDculture = new CultureInfo("ro-MD"); // Румынский (Молдова)

Console.WriteLine(dateTime.ToString(USAculture));
Console.WriteLine(dateTime.ToString(FRculture));
Console.WriteLine(dateTime.ToString(RUculture));
Console.WriteLine(dateTime.ToString(MDculture));

Console.WriteLine();

Console.WriteLine(mySalaryInAmdaris.ToString("C", USAculture));
Console.WriteLine(mySalaryInAmdaris.ToString("C", FRculture));
Console.WriteLine(mySalaryInAmdaris.ToString("C", RUculture));
Console.WriteLine(mySalaryInAmdaris.ToString("C", MDculture));
