using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Logging;
using FileSystemAssessmentProject.Repositories;
using FileSystemAssessmentProject.Services;

var courseRepository = new InMemoryRepository<Course>();
var courseService = new CourseService(courseRepository);

var courseId = new Guid("126A00E6-E012-4B97-9032-F6C586CC618C");

var course = new Course()
{
    Id = Guid.NewGuid(),
    Title = "React",
    Description = "It is a course for Beginners. Start your journey in IT with React basics"
};
var lesson = new Lesson()
{
    Id = Guid.NewGuid(),
    Title = "Hooks",
    Description = "Start with hooks",
    Text = "Hooks let you use different React features from your components. You can either use the built-in Hooks or combine them to build your own. This page lists all built-in Hooks in React."
};
var participant = new Participant()
{
    Id = Guid.NewGuid(),
    Name = "Vasiliy",
    Email = "vasiliy@gmail.com"
};
var course2 = new Course()
{
    Id = courseId,
    Title = "React",
    Description = "It is a course for Beginners. Start your journey in IT with React basics",
    Lessons = new List<Lesson> { lesson },
    Participants = new List<Participant> { participant }
};
var course3 = new Course()
{
    Id = new Guid("126A00E6-E012-4B97-9032-F6C586CC618C"),
    Title = "React",
    Description = "It is a course for Beginners. Start your journey in IT with React basics",
    Lessons = new List<Lesson> { lesson },
};


await courseService.AddAsync(course);
await courseService.AddAsync(course2);
var courses = await courseService.GetAllAsync();
courseService.PrintAllCourses(courses);

await courseService.UpdateAsync(course3);
courses = await courseService.GetAllAsync();
courseService.PrintAllCourses(courses);


//await courseService.UpdateAsync(null);
//courses = await courseService.GetAllAsync();
//courseService.PrintAllCourses(courses);


var logReader = new LogReader();
string tmp = await logReader.ReadLogAsync($"{DateTime.Now:yyyy-MM-dd}.txt");
Console.WriteLine(tmp);