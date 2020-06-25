#load "interfaces.csx"

public class Company : IEntity
{
    public string Description { get; set; }

    public bool IsValid()
    {
        return true;
    }
}

public class Person : IEntity
{
    public string Description { get; set; }

    public bool IsValid()
    {
        return false;
    }
}
