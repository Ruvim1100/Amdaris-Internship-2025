using CreationalPatternsAssessmentProject.Abstraction;
using CreationalPatternsAssessmentProject.Models;

namespace CreationalPatternsAssessmentProject.Builders
{
    internal class CappuccinoBuilder : BaseCoffeeBuilder
    {
        public CappuccinoBuilder(MilkType milkType) 
        {
            _coffee.Milks.Add(milkType.ToString());
        }
        public override void BaseOptions()
        {
            _coffee.Name = CoffeeType.Cappuccino.ToString();
            _coffee.CoffeeShots = 1;
        }
    }
}
