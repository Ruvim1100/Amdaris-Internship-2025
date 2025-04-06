using ClassesAssessmentProject.Interfaces;

namespace ClassesAssessmentProject.Entities
{
    internal class Scanner : OfficeEquipment, IScan
    {
        public Scanner(string model) : base(model)
        {
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine("Scanner is waiting command...");
        }

        public void Scan(string folder)
        {
            Console.WriteLine($"Scanning document to {folder}...");
        }

    }
}
