using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Logging;
using FileSystemAssessmentProject.Repositories;

namespace FileSystemAssessmentProject.Services
{
    internal class LessonService(InMemoryRepository<Lesson> lessonRepository)
    {
        private readonly Logger<LessonService> logger = new();

        public void PrintCourse(Lesson lesson)
        {
            ConsoleLogLesson(lesson);
        }

        public void PrintAllCourses(List<Lesson> lessons)
        {
            foreach (var lesson in lessons)
            {
                ConsoleLogLesson(lesson);
            }
        }

        private void ConsoleLogLesson(Lesson lesson)
        {
            Console.WriteLine($"Lesson: {lesson.Title}, Description: {lesson.Description}, Text: {lesson.Text}");
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            try
            {
                var result = lessonRepository.GetAll().ToList();
                await logger.LogInfoAsync("Lessons downloaded successfully");
                return result;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Lessons are not downloaded");
                throw;
            }
        }

        public async Task<Lesson> GetByIdAsync(Guid id)
        {
            try
            {
                var result = lessonRepository.GetById(id);
                await logger.LogInfoAsync("Lesson downloaded successfully");
                return result;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Lesson didn't download");
                throw;
            }
        }

        public async Task<Lesson> AddAsync(Lesson course)
        {
            try
            {
                var result = lessonRepository.Add(course);
                await logger.LogInfoAsync("Lesson Added Successfully");
                return course;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Lesson cannot be added");
                throw;
            }
        }

        public async Task<Lesson> UpdateAsync(Lesson course)
        {
            try
            {
                var result = lessonRepository.Update(course);
                await logger.LogInfoAsync("Lesson Udated Successfully");
                return course;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Lesson cannot be updated");
                throw;
            }
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                var result = lessonRepository.Delete(id);
                await logger.LogInfoAsync("Lesson Deleted Successfully");
                return id;
            }
            catch (Exception)
            {
                await logger.LogErrorAsync("Method finished with error, Lesson cannot be deleted");
                throw;
            }
        }

    }
}
