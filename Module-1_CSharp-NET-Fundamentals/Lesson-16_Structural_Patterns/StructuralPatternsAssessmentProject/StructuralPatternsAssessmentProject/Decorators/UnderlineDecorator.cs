using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Decorators
{
    internal class UnderlineDecorator : BaseDecorator
    {
        public UnderlineDecorator(IText text) : base(text) { }

        public override string Format()
        {
            return $"[Underline] {_text.Format()} [/Underline]";
        }
    }
}
