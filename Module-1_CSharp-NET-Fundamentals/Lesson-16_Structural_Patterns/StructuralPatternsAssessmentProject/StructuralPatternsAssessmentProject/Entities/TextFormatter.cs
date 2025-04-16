using StructuralPatternsAssessmentProject.Abstraction;

namespace StructuralPatternsAssessmentProject.Entities
{
    internal class TextFormatter
    {
        private string _baseText;
        private List<Func<IText, IText>> _decorators = new();

        public TextFormatter(string baseText)
        {
            _baseText = baseText;
        }

        public void AddDecorator(Func<IText, IText> decorator)
        {
            _decorators.Add(decorator);
        }

        public void RemoveDecorator<T>() where T : IText
        {
            _decorators.RemoveAll(decorator =>
            {
                var test = decorator(new BaseText("test"));
                return test is T;
            });
        }

        public string Format()
        {
            IText text = new BaseText(_baseText);
            foreach (var decorator in _decorators)
            {
                text = decorator(text);
            }
            return text.Format();
        }
    }
}
