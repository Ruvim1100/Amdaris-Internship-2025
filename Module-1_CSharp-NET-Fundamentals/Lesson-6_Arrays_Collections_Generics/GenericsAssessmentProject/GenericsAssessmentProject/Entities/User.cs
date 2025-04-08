using GenericsAssessmentProject.Abstracions;

namespace GenericsAssessmentProject.Entities
{
    internal class User : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public DateOnly BirthDay { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
