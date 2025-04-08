namespace LinqAssessmentProject.Entities
{
    internal record class Citizen(string Name, int Age) : Person(Name);
}
