namespace GenericsAssessmentProject.Abstracions
{
    internal interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid Id);
        IList<T> GetAll();
        Guid Add(T entity);
        void Update(T entity);
        void Delete(Guid Id);
    }
}
