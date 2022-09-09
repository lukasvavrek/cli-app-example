namespace ConsoleApp;

public class Person
{
    private Person(string name, string surname, int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }
    
    public string Name { get; }
    public string Surname { get; }
    public int Age { get; }

    public static Person CreatePerson(string name, string surname, int age)
    {
        return new Person(name, surname, age);
    }
    
    public static IEnumerable<Person> ExampleData =>
        new List<Person>
        {
            CreatePerson("Janko", "Hrasko", 3),
            CreatePerson("John", "Doe", 42),
            CreatePerson("Yuval", "Harari", 46)
        };
}