namespace StructuralPatternsAssessmentProject.Abstraction
{
    internal abstract class BaseDecorator : IText
    {
        protected IText _text;

        protected BaseDecorator(IText text)
        {
            _text = text;
        }

        public abstract string Format();
    }
}
