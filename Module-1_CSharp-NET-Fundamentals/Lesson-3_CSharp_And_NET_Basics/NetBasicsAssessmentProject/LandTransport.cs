namespace NetBasicsAssessmentProject
{
    internal class LandTransport : Transport
    {
        public LandTransport(Guid serialNumber, int year, string model) : base(serialNumber, year, model)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{Model} : {SerialNumber} delivered the cargo along the country's main highways");
        }

        public override void DisplayTransportModel()
        {
            Console.WriteLine("This is Land Transport");
        }
    }
}
