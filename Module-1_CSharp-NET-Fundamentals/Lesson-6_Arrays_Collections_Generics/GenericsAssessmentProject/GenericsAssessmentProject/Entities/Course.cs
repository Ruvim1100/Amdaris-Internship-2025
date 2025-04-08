using GenericsAssessmentProject.Abstracions;

namespace GenericsAssessmentProject.Entities
{
    internal class Course : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<User> Students { get; set; } = new List<User>();
    }
}
