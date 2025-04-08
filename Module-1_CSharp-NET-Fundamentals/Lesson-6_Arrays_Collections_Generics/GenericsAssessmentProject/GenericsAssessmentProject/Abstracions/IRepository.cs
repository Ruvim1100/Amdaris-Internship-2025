namespace GenericsAssessmentProject.Abstracions
{
    internal interface IRepository<T> where T : BaseEntity
    {
        T? GetById(Guid Id);
        IList<T> GetAll();
        Guid Add(T entity); // return entity
        void Update(T entity); // return bool or entity
        void Delete(Guid Id);
    }
}
