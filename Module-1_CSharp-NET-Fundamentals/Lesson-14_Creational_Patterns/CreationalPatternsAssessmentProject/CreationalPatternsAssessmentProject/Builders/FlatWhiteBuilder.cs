using CreationalPatternsAssessmentProject.Abstraction;
using CreationalPatternsAssessmentProject.Models;

namespace CreationalPatternsAssessmentProject.Builders
{
    internal class FlatWhiteBuilder : BaseCoffeeBuilder
    {
        public FlatWhiteBuilder(MilkType milkType)
        {
            _coffee.Milks.Add(milkType.ToString());
        }
        public override void BaseOptions()
        {
            _coffee.Name = CoffeeType.FlatWhite.ToString();
            _coffee.CoffeeShots = 2;
        }
    }        
}
