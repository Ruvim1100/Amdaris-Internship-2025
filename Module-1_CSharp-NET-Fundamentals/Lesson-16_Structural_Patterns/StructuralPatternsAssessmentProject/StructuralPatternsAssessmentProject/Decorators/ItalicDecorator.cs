using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Decorators
{
    internal class ItalicDecorator : BaseDecorator
    {
        public ItalicDecorator(IText text) : base(text) {}

        public override string Format()
        {
            return $"[Italic] {_text.Format()} [/Italic]";
        }
    }
}
