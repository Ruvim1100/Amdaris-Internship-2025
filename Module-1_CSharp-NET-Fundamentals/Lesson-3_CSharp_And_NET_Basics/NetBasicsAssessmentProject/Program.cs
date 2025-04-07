using NetBasicsAssessmentProject;

Transport landTransport = new LandTransport(new Guid("D8A2503B-E5B6-4260-A721-0F1EF6FF6377"), 2005, "Truck");
Transport waterTransport = new WaterTransport(new Guid("0BC24DD9-27E2-4FA9-BFE6-E9C45583D4B6"), 2010, "Cargo Ship", 50000);
Transport airTransport = new AirTransport(new Guid("3806EF64-20EE-4A05-8335-C5959C21FF98"), 2018, "Cargo Plane");

TransportManager transportManager = new TransportManager();
transportManager.AddTransport(landTransport);
transportManager.AddTransport(waterTransport);
transportManager.AddTransport(airTransport);

foreach (Transport transport in transportManager)
{
    transport.DisplayTransportModel();
    transport.Move();
    transport.Move(10);
    Console.WriteLine();
}

Transport clonedTransport = (Transport)landTransport.Clone();
Console.WriteLine("Cloned transport:");
clonedTransport.DisplayTransportModel();
clonedTransport.Move();