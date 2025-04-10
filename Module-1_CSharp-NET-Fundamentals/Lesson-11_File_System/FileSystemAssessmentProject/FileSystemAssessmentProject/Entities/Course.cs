namespace FileSystemAssessmentProject.Entities
{
    internal class Course : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
