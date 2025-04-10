using FileSystemAssessmentProject.Abstractions;
using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Exceptions;

namespace FileSystemAssessmentProject.Repositories
{
    internal class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _inMemory = new();

        public T Add(T entity)
        {
            if (entity == null)
            {
                 throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            if (_inMemory.Any(e => e.Id == entity.Id))
                throw new EntityAlreadyExistsException($" This Entity already exists.");

            _inMemory.Add(entity);
            return entity;
        }

        public Guid Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.", nameof(id));

            var entity = _inMemory.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                throw new EntityNotFoundException($"Entity {id} not found.");

            _inMemory.Remove(entity);
            return id;
        }

        public IList<T> GetAll() => _inMemory.ToList();

        public T? GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty.", nameof(id));

            return _inMemory.FirstOrDefault(e => e.Id == id);
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var index = _inMemory.FindIndex(e => e.Id == entity.Id);
            if (index == -1)
                throw new EntityNotFoundException($"Entity {entity.Id} not found.");

            _inMemory[index] = entity;
            return entity;
        }
    }
}
