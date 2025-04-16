using CreationalPatternsAssessmentProject.Models;

namespace CreationalPatternsAssessmentProject.Abstraction
{
    internal abstract class BaseCoffeeBuilder : ICoffeeBuilder
    {
        protected CoffeeBeverage _coffee;

        public BaseCoffeeBuilder()
        {
            _coffee = new CoffeeBeverage();
            BaseOptions();
        }

        public abstract void BaseOptions();

        public ICoffeeBuilder AddExtraMilk(MilkType milkType)
        {
            _coffee.Milks.Add(milkType.ToString());
            return this;
        }

        public ICoffeeBuilder AddExtraSugar(int extraSugar)
        {
            _coffee.ExtraSugar = extraSugar;
            return this;
        }

        public CoffeeBeverage GetCoffee()
        {
            var result = _coffee;
            Reset();
            return result;
        }

        protected void Reset()
        {
            _coffee = new CoffeeBeverage();
            BaseOptions();
        }

    }
}
