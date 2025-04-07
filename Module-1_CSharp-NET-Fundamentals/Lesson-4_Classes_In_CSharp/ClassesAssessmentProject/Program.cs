using ClassesAssessmentProject.Entities;

var printer = new Printer("HP Laser JT 1550");
var scanner = new Scanner("Canon 550");
MFP mfp = new MFP("Epson L3550");

List<OfficeEquipment> officeEquipments = new List<OfficeEquipment>() { printer, scanner, mfp };

Console.WriteLine("Using IS");

foreach (var equipment in officeEquipments)
{
	if (equipment is Printer)
	{
		Console.WriteLine($"Device {equipment.Model} is a Printer");
	}
}

Console.WriteLine();
Console.WriteLine("==================================================");

Console.WriteLine("Using AS");
Console.WriteLine();

OfficeEquipment device = new MFP("Brother 1220");
MFP mfpDevice = device as MFP;
mfpDevice?.TurnOn();
mfpDevice?.Print("Amdaris_Assessment_Report.Word");

Console.WriteLine();
Console.WriteLine("==================================================");

Console.WriteLine("Using optional parameters and use named arguments");
Console.WriteLine();

printer.Print("MaterialUI Documentation.pdf");
printer.Print(copies: 3, document: "Vite Documentation.pdf");
printer.SmartPrint("MaterialUI_Documentation.pdf", 2);

Console.WriteLine();
Console.WriteLine("==================================================");