using CreationalPatternsAssessmentProject;
using CreationalPatternsAssessmentProject.Builders;
using CreationalPatternsAssessmentProject.Models;

var director = new CoffeeDirector();
var flatWhite = director.MakeFlatWhiteWithExtraMilk();
var cappuccino = director.MakeCappuccinoWithDoubleSugarAndOatMilk();

flatWhite.Display();
Console.WriteLine();

cappuccino.Display();
Console.WriteLine();

var espresso = new EspressoBuilder()
    .AddExtraMilk(MilkType.Oat)
    .AddExtraSugar(2)
    .GetCoffee();

espresso.Display();