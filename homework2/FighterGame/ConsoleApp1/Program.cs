public class Person
{
    private int _age;
    public string Name;

    public Person( int age )
    {
        _age = age;
    }

    public Person( string name, int age ) 
    { 
        Name = name;    
        _age = age;
    }
}

public class Program
{
    public static void Main()
    {
        var child = new Person(10);

        var adult = new Person(30)
        {
            Name = "Jane"
        };

        var anotherAdult = new Person("Viktor", 20);
    }
}