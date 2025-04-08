using GenericsAssessmentProject.Entities;
using GenericsAssessmentProject.Repositories;

namespace GenericsAssessmentProject.Services
{
    internal class CourseService
    {
        private readonly ListRepository<Course> _courseRepository;

        public CourseService(ListRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;   
        }

        public void PrintCourse(Course course)
        {
            Console.WriteLine($"Console.WriteLine($\"Course: {course.Title}, Students Count: {course.Students.Count}, Lessons Count: {course.Lessons.Count}");
        }

        public void PrintAllCourses(List<Course> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Title}, Students Count: {course.Students.Count}, Lessons Count: {course.Lessons.Count}");
            }
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAll().ToList();
        }

        public Course GetById(Guid id)
        {
            return _courseRepository.GetById(id);
        }

        public Guid AddCourse(Course course)
        {
            return _courseRepository.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void RemoveCourse(Guid id)
        {
            _courseRepository.Delete(id);
        }

    }
}
