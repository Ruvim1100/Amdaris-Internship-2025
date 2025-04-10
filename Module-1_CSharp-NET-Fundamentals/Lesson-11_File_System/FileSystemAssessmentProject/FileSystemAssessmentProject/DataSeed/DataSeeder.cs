using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Repositories;

namespace FileSystemAssessmentProject.DataSeed
{
    internal static class DataSeeder
    {
        public static InMemoryRepository<Participant> SeedParticipants()
        {
            var repository = new InMemoryRepository<Participant>();

            var users = new List<Participant>
            {
                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Vasiliy",
                        Email = "vasiliy@gmail.com"
                    },

                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Victor",
                        Email = "victor@gmail.com"
                    },

                      new Participant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Galina",
                        Email = "galina@gmail.com"
                    }
            };

            foreach (var user in users)
                repository.Add(user);

            return repository;
        }

        public static InMemoryRepository<Lesson> SeedLessons()
        {
            var repository = new InMemoryRepository<Lesson>();

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

        public static InMemoryRepository<Course> SeedCourses(List<Participant> participants, List<Lesson> lessons)
        {
            var repository = new InMemoryRepository<Course>();

            var courses = new List<Course>
            {
                new Course
                {
                    Id = new Guid("C5DB2AA8-5898-4B13-ACE9-026C1FEE3DDC"),
                    Title = ".NetCourse",
                    Description = "It is Course for Beginners. Start your journey in It with .Net basics",
                    Lessons = lessons,
                    Participants = participants
                },

                new Course
                {
                    Id = new Guid("2EA37F82-4E80-41E5-85EA-3F6C0DA6EA1D"),
                    Title = "Sql course",
                    Description = "It is Course for Beginners. Start your journey in It with .Net basics",
                    Lessons = lessons,
                    Participants = participants
                }
            };

            foreach (var course in courses)
                repository.Add(course);

            return repository;
        }

        public static Course CreateReactCourse(List<Participant> users, List<Lesson> lessons)
        {
            return new Course
            {
                Id = Guid.NewGuid(),
                Title = "React",
                Description = "It is a course for Beginners. Start your journey in IT with React basics",
                Lessons = lessons,
                Participants = users
            };
        }

        public static Course CreateSqlCourse(List<Participant> users, List<Lesson> lessons)
        {
            return new Course
            {
                Id = new Guid("2EA37F82-4E80-41E5-85EA-3F6C0DA6EA1D"),
                Title = "Sql course",
                Description = "It is a course for Beginners. Start your journey in IT with .SQL basics",
                Participants = users
            };
        }
    }
}
