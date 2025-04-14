using BusinessLayer.Abstraction;

namespace BusinessLayer.Calculators
{
    internal class RegistrationCalculator : ICalculator
    {
        public int Calculate(int? experience)
        {
            if (experience <= 1) return 500;
            else if (experience <= 3) return 250;
            else if (experience <= 5) return 100;
            else if (experience <= 9) return 50;
            else return 0;
        }
    }
}
