using LinqAssessmentProject.Entities;

var citizens = new List<Citizen>
{
    new Citizen("Vasya", 19),
    new Citizen("Tudor", 43),
    new Citizen("Mihail", 26),
    new Citizen("Anastaisa", 15)
};

var citizens2 = new List<Citizen>
{
    new Citizen("Vasya", 19),
    new Citizen("Elon", 20),
    new Citizen("Mihail", 26),
    new Citizen("Volodya", 82),
    new Citizen("Mihail", 26),
};

var employees = new List<Employee>
{
    new Employee("Stanislav", 3),
    new Employee("Dmitriy", 1),
    new Employee("Alexei", 2),
    new Employee("Yana", 1)
};

var companies = new List<Company>
{
    new Company("Amdaris", employees.Take(2).ToList()),
    new Company("Endava", employees.Skip(2).Take(2).ToList())
};

var courses = new List<Course>
{
    new Course(".Net", 5),
    new Course("Sql", 3)
};

var students = new List<Student>
{
    new Student("Venya", ".Net"),
    new Student("Alla", "Sql"),
    new Student("Roman", "Sql"),
    new Student("Gennadiy", ".Net"),
    new Student("Afanasiy", "React"),
};

var people = new List<Person>();
people.AddRange(citizens);
people.AddRange(employees);


//Projections
//var citizenNames = citizens.Select(c => c.Name).ToList();
//citizenNames.ForEach(Console.WriteLine);
//Console.WriteLine();

//var selectedEmployees = companies.SelectMany(c => c.Team,
//                                    (c, e) => new { Name = e.Name, Company = c.Title }).ToList();
//selectedEmployees.ForEach(Console.WriteLine);
//Console.WriteLine();


////Filtration
//var selectedCitizens = citizens.Where(c => c.Age > 18).ToList();
//selectedCitizens.ForEach(Console.WriteLine);
//Console.WriteLine();

//var selectedPeople = people.OfType<Citizen>().ToList();
//selectedPeople.ForEach(Console.WriteLine);
//Console.WriteLine();

////Sorting
//var sortedEmployees = employees.OrderByDescending(e => e.Experience).ThenBy(e => e.Name).ToList();
//sortedEmployees.ForEach(Console.WriteLine);
//Console.WriteLine();

////Set operators 
//var ExceptedCitizens = citizens.Except(citizens2).ToList();
//ExceptedCitizens.ForEach(Console.WriteLine);
//Console.WriteLine();

//var IntersectedCitizens = citizens.Intersect(citizens2).ToList();
//IntersectedCitizens.ForEach(Console.WriteLine);
//Console.WriteLine();

//var DistinctCitizens = citizens.Distinct().ToList();
//DistinctCitizens.ForEach(Console.WriteLine);
//Console.WriteLine();

//var UnionCitizens = citizens.Union(citizens2).ToList();
//UnionCitizens.ForEach(Console.WriteLine);
//Console.WriteLine();

//var ConcatCitizens = citizens.Concat(citizens2).ToList();
//ConcatCitizens.ForEach(Console.WriteLine);
//Console.WriteLine();

////Aggregation
//var AggregateExpirience = employees.Select(e => e.Experience).Aggregate((x, y) => x + y);
//Console.WriteLine(AggregateExpirience);

//var CountEmployeesInCompany = companies.SelectMany(c => c.Team).Count();
//Console.WriteLine(CountEmployeesInCompany);

//var SumExpirience = employees.Select(e => e.Experience).Sum();
//Console.WriteLine(SumExpirience);

//var MinAge = citizens.Select(c => c.Age).Min();
//Console.WriteLine(MinAge);

//var MaxAge = citizens.Select(c => c.Age).Max();
//Console.WriteLine(MaxAge);

//var AverageAge = citizens.Select(c => c.Age).Average();
//Console.WriteLine(AverageAge);

////Grouping
//var expireinceGroups = employees
//    .GroupBy(e => e.Experience)
//    .OrderByDescending(g => g.Key);

//foreach (var expirience in expireinceGroups)
//{
//    Console.WriteLine($"Expirience: {expirience.Key} year - {expirience.Count()}");
//}

////Join
//var courseStudents = students.Join(courses,
//                               s => s.Course,
//                               c => c.Title,
//                               (s, c) => new { Name = s.Name, Course = c.Title, Lessons = c.Lessons });
//foreach (var student in courseStudents)
//{
//    Console.WriteLine($"{student.Name} - {student.Course} ({student.Lessons})");
//}
//Console.WriteLine();

//var courseStudentGroups = courses.GroupJoin(students,
//                               c => c.Title,
//                               s => s.Course,
//                               (c, studentList) => new { Title = c.Title, StudentList = studentList });

//foreach (var course in courseStudentGroups)
//{
//    Console.WriteLine($"{course.Title} Course Include");
//    foreach (var student in course.StudentList)
//    {
//        Console.WriteLine(student.Name);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine();

//var enrollments = courses.Zip(students);
//foreach (var enrollment in enrollments)
//{
//    Console.WriteLine($"{enrollment.First} - {enrollment.Second}");
//}
//Console.WriteLine();

////Quantifiers, Element operations
//Console.WriteLine(employees.Select(e => e.Experience).Contains(3));
//Console.WriteLine(employees.Select(e => e.Experience).Any(e => e > 2));
//Console.WriteLine(employees.Select(e => e.Experience).All(e => e < 3));
//Console.WriteLine(citizens.SequenceEqual(citizens2));
//Console.WriteLine();

//var first = employees.First();
//Console.WriteLine(first);
//Console.WriteLine(courses.FirstOrDefault(c => c.Title == ".Net"));
//Console.WriteLine();

//Console.WriteLine(employees.Last());
//Console.WriteLine(courses.FirstOrDefault(c => c.Title == "Sql"));
//Console.WriteLine();

//Console.WriteLine(citizens.Single(c => c.Age == 43));
//Console.WriteLine(citizens.SingleOrDefault(c => c.Age == 42));

//Console.WriteLine(citizens.ElementAt(3));
//Console.WriteLine(citizens.ElementAtOrDefault(6));

//var emptyList = new List<int>(5) { };
//var result = emptyList.DefaultIfEmpty(74).ToList();
//result.ForEach(Console.Write);


////Generation operators
//var emptySequence = Enumerable.Empty<string>();
//Console.WriteLine(emptySequence.Count());
//Console.WriteLine();

//var repeatedValues = Enumerable.Repeat("Hello", 3);
//foreach (var item in repeatedValues)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine();

//var numbers = Enumerable.Range(5, 4);
//foreach (var num in numbers)
//{
//    Console.Write(num + " ");
//}
//Console.WriteLine();

////Converstion methods
//List<object> strAndNums = new List<object> { 1, 4, 2 };
//var castedInts = strAndNums.Cast<int>().ToList();
//castedInts.ForEach(Console.Write);
//Console.WriteLine();

//var intArray = castedInts.ToArray();
//foreach (var num in intArray)
//{
//    Console.Write($" {num}");
//}
//Console.WriteLine();

//var coursesDictionary = courses.ToDictionary(c => c.Title, c => c.Lessons);
//foreach (var item in coursesDictionary)
//{
//    Console.WriteLine($"Course: {item.Key} has {item.Value} lessons");
//}
//Console.WriteLine();

//var filteredCitizens = citizens2
//    .Where(c => c.Age > 18)
//    .AsEnumerable()
//    .Where(c => c.Name.Contains("Mi"));

//foreach (var citizen in filteredCitizens)
//{
//    Console.WriteLine($"{citizen.Name} - {citizen.Age}");
//}

//Console.WriteLine();
//var citizensByName = citizens.ToLookup(c => c.Age >= 18);

//Console.WriteLine($"Mature citizens:");
//foreach (var citizen in citizensByName[true])
//{
//    Console.WriteLine($"  Name: {citizen.Name}");
//}

//Console.WriteLine();

//Console.WriteLine($"Child citizens:");
//foreach (var citizen in citizensByName[false])
//{
//    Console.WriteLine($"  Name: {citizen.Name}");
//}

//Console.WriteLine();

//var query = citizens.AsQueryable();
//var result2 = query
//    .Where(c => c.Age >= 20)
//    .OrderBy(c => c.Name);

//foreach (var citizen in result2)
//{
//    Console.WriteLine($"{citizen.Name} - {citizen.Age}");
//}