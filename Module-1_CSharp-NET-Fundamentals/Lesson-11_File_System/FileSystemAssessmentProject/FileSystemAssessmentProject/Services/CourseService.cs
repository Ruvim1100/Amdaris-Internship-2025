using FileSystemAssessmentProject.Constants;
using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Logging;
using FileSystemAssessmentProject.Repositories;

namespace FileSystemAssessmentProject.Services
{   
    internal class CourseService(InMemoryRepository<Course> courseRepository)
    {
        private readonly Logger<CourseService> logger = new();

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
            Console.WriteLine($"Course: {course.Title}, Participants Count: {course.Participants.Count()}, Lessons Count: {course.Lessons.Count()}");
        }

        public async Task<List<Course>> GetAllAsync()
        {
            try
            {
                var result = courseRepository.GetAll().ToList();
                await logger.LogInfoAsync("Courses downloaded successfully");
                return result;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Courses are not downloaded");
            }
            return new();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            try
            {
                var result = courseRepository.GetById(id);
                await logger.LogInfoAsync("Course downloaded successfully");
                return result;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Course didn't download");
                throw;
            }
        }

        public async Task<Course> AddAsync(Course course)
        {
            try
            {
                var result = courseRepository.Add(course);
                await logger.LogInfoAsync("Course Added Successfully");
                return course;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Course cannot be added");
                throw;
            }
        }

        public async Task<Course> UpdateAsync(Course course)
        {
            try
            {
                var result = courseRepository.Update(course);
                await logger.LogInfoAsync("Course Udated Successfully");
                return course;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Course cannot be updated");
                throw;
            }
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                var result = courseRepository.Delete(id);
                await logger.LogInfoAsync("Course Deleted Successfully");
                return id;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Course cannot be deleted");
                throw;
            }
        }
    }
}
