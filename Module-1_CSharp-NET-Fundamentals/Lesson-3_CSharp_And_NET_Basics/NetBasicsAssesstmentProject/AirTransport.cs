namespace NetBasicsAssessmentProject
{
    internal class AirTransport : Transport
    {
        public AirTransport(Guid serialNumber, int year, string model) : base(serialNumber, year, model)
        {
        }

        public override void Move()
        {
            Console.WriteLine($"{Model} delivered the cargo through the country's airspace");
        }

        public override void DisplayTransportModel()
        {
            Console.WriteLine("This is Air Transport");
        }
    }
}
