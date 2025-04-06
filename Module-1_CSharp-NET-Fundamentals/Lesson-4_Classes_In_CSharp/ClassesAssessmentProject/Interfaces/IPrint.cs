namespace ClassesAssessmentProject.Interfaces
{
    internal interface IPrint
    {
        public void Print(string document);
        public void Print(string document, int copies);
        public void SmartPrint(string document, int copies, bool color, bool highQuality);
    }
}
