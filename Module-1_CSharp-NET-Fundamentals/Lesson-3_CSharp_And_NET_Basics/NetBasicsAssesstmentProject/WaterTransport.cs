using System.Reflection;

namespace NetBasicsAssessmentProject
{
    internal class WaterTransport : Transport
    {
        private int _displacement;
        public int Displacement
        {
            get => _displacement;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Displacement must be greater than zero.");
                }
                _displacement = value;
            }
        }
        public WaterTransport(Guid serialNumber, int year, string model, int displacement) : base(serialNumber, year, model)
        {
            _displacement = displacement;
        }
        public override void Move()
        {
            Console.WriteLine($"{Model} with a displacement of {Displacement} tons delivered the cargo across the ocean");
        }

        public override void DisplayTransportModel()
        {
            Console.WriteLine("This is Water Transport");
        }
    }
}
