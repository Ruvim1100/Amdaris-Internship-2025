using GenericsAssessmentProject.Entities;
using GenericsAssessmentProject.Repositories;

namespace GenericsAssessmentProject.Seed
{
    internal static class DataSeeder
    {
        public static ListRepository<User> SeedUsers()
        {
            var repository = new ListRepository<User>();

            var users = new List<User>
            {
                new User { FullName = "Bozaji Ruvim", Email = "ruvim-bozaji@gmail.com", BirthDay = new DateOnly(1999, 5, 9), PhotoUrl = "https://filemanager.com/photo.png" },
                new User { FullName = "Vasiliy Clone", Email = "vasiliy.clone@example.com", BirthDay = new DateOnly(2001, 10, 15), PhotoUrl = "https://filemanager.com/vasiliy.png" },
                new User { FullName = "Just User", Email = "user@example.com", BirthDay = new DateOnly(1990, 3, 22), PhotoUrl = "https://filemanager.com/user.png" }
            };

            foreach (var user in users)
                repository.Add(user);

            return repository;
        }


        public static ListRepository<Lesson> SeedLessons()
        {
            var repository = new ListRepository<Lesson>();

            var lessons = new List<Lesson>
            {
                new Lesson { Title = ".Net Basics", Description = "Learn C#", Text = "Intro text..." },
                new Lesson { Title = "Collections", Description = "Work with lists", Text = "Something about you" },
                new Lesson { Title = "ASP.NET", Description = "Web dev", Text = "Don't read this text" }
            };

            foreach (var lesson in lessons)
                repository.Add(lesson);

            return repository;
        }

        public static ListRepository<Course> SeedCourses(List<User> users, List<Lesson> lessons)
        {
            var repository = new ListRepository<Course>();
            
            var courses = new List<Course>
            {
                new Course
                { 
                    Id = new Guid("C5DB2AA8-5898-4B13-ACE9-026C1FEE3DDC"), 
                    Title = ".NetCourse", 
                    Description = "It is Course for Beginners. Start your journey in It with .Net basics", 
                    Lessons = lessons, 
                    Students = users 
                },
            
                new Course
                {
                    Id = new Guid("2EA37F82-4E80-41E5-85EA-3F6C0DA6EA1D"),
                    Title = "Sql course",
                    Description = "It is Course for Beginners. Start your journey in It with .Net basics",
                    Lessons = lessons,
                    Students = users
                }
            };

            foreach (var course in courses)
                repository.Add(course);

            return repository;
        }
    }
}