using GenericsAssessmentProject.Abstracions;

namespace GenericsAssessmentProject.Entities
{
    internal class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDay { get; set; }
        public string PhotoUrl { get; set; }
    }
}
