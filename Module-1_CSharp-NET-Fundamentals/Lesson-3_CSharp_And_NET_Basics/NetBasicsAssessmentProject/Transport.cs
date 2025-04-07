namespace NetBasicsAssessmentProject
{
    internal abstract class Transport : ICloneable
    {
        public Guid SerialNumber { get; set; }
        public string Model { get; set; }

        private int _year;
        public int Year
        {
            get => _year;
            set 
            {
                if (value <= 1900)
                {
                    throw new ArgumentException("Year must be greater than 1900.");
                }
                _year = value;
            }
        }

        public Transport(Guid serialNumber, int year, string model)
        {
            SerialNumber = serialNumber;
            _year = year;
            Model = model;
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Model} : {SerialNumber} Delivered the cargo");
        }

        public void Move(int quantity)
        {
            Console.WriteLine($"{Model} delivered {quantity} parcels.");
        }

        public abstract void DisplayTransportModel();

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
