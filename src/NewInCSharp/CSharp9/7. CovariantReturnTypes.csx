public class Person { }
public class Student : Person { }

public class A
{
    public virtual Person GetPerson()
    {
        return new Person();
    }
}

public class B : A
{
    // C# 8. You can return the child class, but it still returns a Person
    // public override Person GetPerson()
    // {
    //     return new Student();
    // }

    // C# 9. You can return the more specific type
    public override Student GetPerson()
    {
        return new Student();
    }
}
