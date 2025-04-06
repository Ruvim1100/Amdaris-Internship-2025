namespace ClassesAssessmentProject.Entities
{
    internal class OfficeEquipment
    {
        public string Model { get; set; }
        public bool IsOn { get; private set; }

        public OfficeEquipment(string model)
        {
            Model = model;
            IsOn = false;
        }

        public virtual void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Model} is now ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Model} is now OFF.");
        }
    }
}
