using StructuralPatternsAssessmentProject.Abstraction;
using StructuralPatternsAssessmentProject.Decorators;
using StructuralPatternsAssessmentProject.Entities;

IText simpleText = new BaseText("Amdaris is the best way to start grow as a .net developer");
simpleText = new BoldDecorator(simpleText);
simpleText = new ItalicDecorator(new UnderlineDecorator(simpleText));
simpleText = new TextColorDecorator(simpleText, ConsoleColor.Blue);
simpleText = new BackgroundColorDecorator(simpleText, ConsoleColor.Gray);
Console.WriteLine(simpleText.Format());
Console.WriteLine();


var formatter = new TextFormatter("Amdaris is the best way to start grow as a .net developer\"");

formatter.AddDecorator(text => new BoldDecorator(text));
formatter.AddDecorator(text => new ItalicDecorator(text));
formatter.AddDecorator(text => new UnderlineDecorator(text));
Console.WriteLine(formatter.Format());
Console.WriteLine();

formatter.RemoveDecorator<ItalicDecorator>();
Console.WriteLine(formatter.Format());
Console.WriteLine();