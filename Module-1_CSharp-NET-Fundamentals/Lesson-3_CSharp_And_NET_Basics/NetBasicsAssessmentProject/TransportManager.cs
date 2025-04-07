using System.Collections;

namespace NetBasicsAssessmentProject
{
    internal class TransportManager : IEnumerable<Transport>
    {
        private readonly List<Transport> _transports = new List<Transport>();

        public void AddTransport(Transport transport)
        {
            if (transport == null)
            {
                throw new ArgumentNullException(nameof(transport), "Transport cannot be null");
            }
            _transports.Add(transport);
        }

        public void RemoveTransport(int index)
        {
            if (index < 0 || index >= _transports.Count)
            {
                Console.WriteLine("Wrong index, transport can not be deleted");
            }
            _transports.RemoveAt(index);
            Console.WriteLine("Transport deleted succesfully");
        }

        public IEnumerator<Transport> GetEnumerator()
        {
            return _transports.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
