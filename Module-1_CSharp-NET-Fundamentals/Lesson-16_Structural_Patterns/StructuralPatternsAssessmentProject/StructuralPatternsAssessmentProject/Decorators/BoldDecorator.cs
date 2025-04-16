using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Decorators
{
    internal class BoldDecorator : BaseDecorator
    {
        public BoldDecorator(IText text) : base(text) { }

        public override string Format()
        {
            return $"[Bold] {_text.Format()} [/Bold]";
        }
    }
}
