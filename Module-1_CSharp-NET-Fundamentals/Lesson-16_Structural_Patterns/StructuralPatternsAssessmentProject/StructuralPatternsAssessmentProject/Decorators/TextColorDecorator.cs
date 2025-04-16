using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Decorators
{
    internal class TextColorDecorator : BaseDecorator
    {
        ConsoleColor _foregroundColor;
        public TextColorDecorator(IText text, ConsoleColor foregroundColor) : base(text)
        {
            _foregroundColor = foregroundColor;
        }
        public override string Format()
        {
            Console.ForegroundColor = _foregroundColor;
            return _text.Format();
        }
    }
}
