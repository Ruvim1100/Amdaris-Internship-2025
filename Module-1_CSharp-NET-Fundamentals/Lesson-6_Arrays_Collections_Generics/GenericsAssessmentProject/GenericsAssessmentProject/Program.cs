using GenericsAssessmentProject.Entities;
using GenericsAssessmentProject.Seed;

var userRepository = DataSeeder.SeedUsers();
var lessonRepository = DataSeeder.SeedLessons();
var courseRepository = DataSeeder.SeedCourses(userRepository.GetAll().ToList(), lessonRepository.GetAll().ToList());


Console.WriteLine("Get All Courses:");
foreach (var course in courseRepository.GetAll())
{
    Console.WriteLine($"Course: {course.Title}, Students Count: {course.Students.Count}, Lessons Count: {course.Lessons.Count}");
}

Console.WriteLine("\nGetById");
var courseById = courseRepository.GetById(new Guid("C5DB2AA8-5898-4B13-ACE9-026C1FEE3DDC"));
Console.WriteLine($"Console.WriteLine($\"Course: {courseById.Title}, Students Count: {courseById.Students.Count}, Lessons Count: {courseById.Lessons.Count}");

var newCourse = new Course
{
    Title = "Sql course",
    Description = "It is Course for Beginners. Start your journey in It with .Net basics",
    Lessons = lessonRepository.GetAll().ToList(),
    Students = userRepository.GetAll().ToList()
};

Console.WriteLine("\nAdd Course:");
Console.WriteLine($"Course {courseRepository.Add(newCourse)} added successfully");


Console.WriteLine("\nUpdate .NetCourse");
courseRepository.Update(new Course
{
    Id = new Guid("C5DB2AA8-5898-4B13-ACE9-026C1FEE3DDC"),
    Title = ".NetCourse",
    Description = "It is Course for Beginners. Start your journey in It with .Net basics",
    Students = userRepository.GetAll().ToList()
});

Console.WriteLine("Get All Courses:");
foreach (var course in courseRepository.GetAll())
{
    Console.WriteLine($"Course: {course.Title}, Students Count: {course.Students.Count}, Lessons Count: {course.Lessons.Count}");
}

Console.WriteLine("\nDelete Sql Course");
courseRepository.Delete(new Guid("2EA37F82-4E80-41E5-85EA-3F6C0DA6EA1D"));

Console.WriteLine("Get All Courses:");
foreach (var course in courseRepository.GetAll())
{
    Console.WriteLine($"Course: {course.Title}, Students Count: {course.Students.Count}, Lessons Count: {course.Lessons.Count}");
}