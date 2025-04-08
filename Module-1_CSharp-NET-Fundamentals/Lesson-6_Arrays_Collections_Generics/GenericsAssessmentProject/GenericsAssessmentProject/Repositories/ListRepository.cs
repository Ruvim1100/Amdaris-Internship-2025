using GenericsAssessmentProject.Abstracions;

namespace GenericsAssessmentProject.Repositories
{
    internal class ListRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _inMemory = new List<T>(); // Use Singleton
        public T? GetById(Guid id) // Exception and TryById, result pattern
        {
            return _inMemory.Find(t => t.Id == id);
        }
        public IList<T> GetAll() => _inMemory.ToList();

        public Guid Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            if (_inMemory.Any(e => e.Id == entity.Id))
                throw new InvalidOperationException($"Entity with ID {entity.Id} already exists");

            _inMemory.Add(entity);
            return entity.Id;
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            int index = _inMemory.FindIndex(e => e.Id == entity.Id);
            if (index == -1)
                throw new Exception("Entity not found");

            _inMemory[index] = entity;
        }

        public void Delete(Guid Id)
        {
            int index = _inMemory.FindIndex(e => e.Id == Id); // NOT Found

            if (index >= 0)
            {
                _inMemory.RemoveAt(index);
            }
        }
    }
}
