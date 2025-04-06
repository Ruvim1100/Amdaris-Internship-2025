using ClassesAssessmentProject.Interfaces;

namespace ClassesAssessmentProject.Entities
{
    internal class MFP : OfficeEquipment, IPrint, IScan
    {
        public MFP(string model) : base(model)
        {
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine("MFP is ready to scan and print...");
        }
        public void Print(string document)
        {
            Console.WriteLine($"Printing document: {document}");
        }

        public void Print(string document, int copies)
        {
            for (int i = 1; i <= copies; i++)
            {
                Console.WriteLine($"Printing copy {i}: {document}");
            }
        }

        public void SmartPrint(string document, int copies = 1, bool color = true, bool highQuality = false)
        {
            Console.WriteLine($"{copies} copies of the {document} are printing with options: color format:{color}, high quality: {highQuality}");
        }

        public void Scan(string folder)
        {
            Console.WriteLine($"Scanning document to {folder}...");
        }
    }
}
