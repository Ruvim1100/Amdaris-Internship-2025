using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Decorators
{
    internal class BackgroundColorDecorator : BaseDecorator
    {
        ConsoleColor _backgroundColor;
        public BackgroundColorDecorator(IText text, ConsoleColor backgroundColor) : base(text)
        {
            _backgroundColor = backgroundColor;
        }

        public override string Format()
        {
            Console.BackgroundColor = _backgroundColor;
            return _text.Format();       
        }
    }
}
