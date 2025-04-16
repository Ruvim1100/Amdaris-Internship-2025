using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Entities
{
    internal class BaseText : IText
    {
        public string Text { get; set; } = string.Empty;

        public BaseText(string text)
        {
            Text = text;
        }

        public string Format()
        {
            return Text;
        }
    }
}
