using BusinessLayer.Abstraction;
using BusinessLayer.Models;

namespace BusinessLayer.Repository
{
    internal class InMemoryRepository : IRepository
    {
        private List<Speaker> _speakers = new();
        public int SaveSpeaker(Speaker speaker)
        {
            _speakers.Add(speaker);
            return _speakers.IndexOf(speaker);
        }
    }
}
