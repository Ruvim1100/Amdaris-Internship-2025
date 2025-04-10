namespace FileSystemAssessmentProject.Entities
{
    internal class Lesson : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
