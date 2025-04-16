using CreationalPatternsAssessmentProject.Models;

namespace CreationalPatternsAssessmentProject.Abstraction
{
    internal interface ICoffeeBuilder
    {
        ICoffeeBuilder AddExtraMilk(MilkType milkType);
        ICoffeeBuilder AddExtraSugar(int extraSugar);
        CoffeeBeverage GetCoffee();
    }
}
