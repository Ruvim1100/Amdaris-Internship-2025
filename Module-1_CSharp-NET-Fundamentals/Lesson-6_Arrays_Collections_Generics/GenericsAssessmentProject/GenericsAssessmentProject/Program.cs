using GenericsAssessmentProject.Seed;
using GenericsAssessmentProject.Services;

var userRepository = DataSeeder.SeedUsers();
var lessonRepository = DataSeeder.SeedLessons();

var users = userRepository.GetAll().ToList();
var lessons = lessonRepository.GetAll().ToList();

var courseRepository = DataSeeder.SeedCourses(users, lessons);
var courseService = new CourseService(courseRepository);

courseService.PrintAllCourses(courseService.GetAll());

Console.WriteLine("\nGetById");
var courseById = courseService.GetById(new Guid("C5DB2AA8-5898-4B13-ACE9-026C1FEE3DDC"));
courseService.PrintCourse(courseById);


Console.WriteLine("\nAdd Course:");
Console.WriteLine($"Course {courseService.AddCourse(DataSeeder.CreateReactCourse(users, lessons))} added successfully");


Console.WriteLine("\nUpdate SqlCourse");
courseService.UpdateCourse(DataSeeder.CreateSqlCourse(users, lessons));

courseService.PrintAllCourses(courseService.GetAll());

Console.WriteLine("\nDelete Sql Course");
courseService.RemoveCourse(new Guid("2EA37F82-4E80-41E5-85EA-3F6C0DA6EA1D"));

courseService.PrintAllCourses(courseService.GetAll());