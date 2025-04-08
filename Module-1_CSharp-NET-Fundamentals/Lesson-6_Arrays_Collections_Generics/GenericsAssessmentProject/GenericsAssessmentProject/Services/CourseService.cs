using GenericsAssessmentProject.Entities;
using GenericsAssessmentProject.Repositories;

namespace GenericsAssessmentProject.Services
{
    internal class CourseService(ListRepository<Course> courseRepository)
    {
        public void PrintCourse(Course course)
        {
            ConsoleLogCourse(course);
        }

        public void PrintAllCourses(List<Course> courses)
        {
            foreach (var course in courses)
            {
                ConsoleLogCourse(course);
            }
        }

        private void ConsoleLogCourse(Course course)
        {
            Console.WriteLine($"Course: {course.Title}, Students Count: {course.Students.Count}, Lessons Count: {course.Lessons.Count}");
        }

        public List<Course> GetAll()
        {
            return courseRepository.GetAll().ToList();
        }

        public Course GetById(Guid id)
        {
            return courseRepository.GetById(id);
        }

        public Guid AddCourse(Course course)
        {
            return courseRepository.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.Update(course);
        }

        public void RemoveCourse(Guid id)
        {
            courseRepository.Delete(id);
        }

    }
}
