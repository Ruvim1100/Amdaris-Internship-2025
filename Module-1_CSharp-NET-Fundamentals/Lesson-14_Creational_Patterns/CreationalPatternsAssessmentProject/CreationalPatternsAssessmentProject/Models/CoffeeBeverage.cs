namespace CreationalPatternsAssessmentProject.Models
{
    internal class CoffeeBeverage
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Milks { get; set; } = new();
        public int CoffeeShots { get; set; }
        public int ExtraSugar { get; set; }

        public void Display()
        {
            Console.WriteLine($"Your {Name} with: " +
                $"\nBlackCoffee Shots: {CoffeeShots} " +
                $"\nmilks: {string.Join(", ", Milks)} \nsugars: {ExtraSugar} " +
                $"\nIS READY.");
        }
    }
}