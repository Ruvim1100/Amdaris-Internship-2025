using FileSystemAssessmentProject.Entities;

namespace FileSystemAssessmentProject.Abstractions
{
    internal interface IRepository<T> where T : BaseEntity
    {
        T? GetById(Guid Id);
        IList<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        Guid Delete(Guid Id);
    }
}
