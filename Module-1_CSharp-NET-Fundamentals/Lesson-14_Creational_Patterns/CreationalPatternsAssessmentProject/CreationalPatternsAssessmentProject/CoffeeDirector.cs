using CreationalPatternsAssessmentProject.Builders;
using CreationalPatternsAssessmentProject.Models;

namespace CreationalPatternsAssessmentProject
{
    internal class CoffeeDirector
    {
        public CoffeeBeverage MakeFlatWhiteWithExtraMilk()
        {
            var builder = new FlatWhiteBuilder(MilkType.Regular);
            return builder
                .AddExtraMilk(MilkType.Regular)
                .GetCoffee();
        }

        public CoffeeBeverage MakeCappuccinoWithDoubleSugarAndOatMilk()
        {
            var builder = new CappuccinoBuilder(MilkType.Regular);
            return builder
                .AddExtraSugar(2)
                .AddExtraMilk(MilkType.Oat)
                .GetCoffee();
        }
    }
}
