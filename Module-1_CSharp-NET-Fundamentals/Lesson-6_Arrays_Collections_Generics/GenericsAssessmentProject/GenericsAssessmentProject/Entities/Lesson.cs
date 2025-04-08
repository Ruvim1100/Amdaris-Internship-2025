﻿using GenericsAssessmentProject.Abstracions;

namespace GenericsAssessmentProject.Entities
{
    internal class Lesson : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Text { get; set; }
    }
}
