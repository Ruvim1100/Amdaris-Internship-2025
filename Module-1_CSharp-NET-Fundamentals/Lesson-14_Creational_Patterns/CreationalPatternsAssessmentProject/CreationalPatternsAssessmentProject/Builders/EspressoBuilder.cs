using CreationalPatternsAssessmentProject.Abstraction;
using CreationalPatternsAssessmentProject.Models;

namespace CreationalPatternsAssessmentProject.Builders
{
    internal class EspressoBuilder : BaseCoffeeBuilder
    {
        public override void BaseOptions()
        {
            _coffee.Name = CoffeeType.Espresso.ToString();
            _coffee.CoffeeShots = 1;
        }
    }
}
