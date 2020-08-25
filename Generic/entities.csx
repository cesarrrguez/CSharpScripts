#load "interfaces.csx"

public class Company : IEntity
{
    public string Name { get; set; }

    public Company(string name) => Name = name;

    public bool IsValid() => true;

    public override string ToString() => $"{GetType().Name} ({Name})";
}

public class Person : IEntity
{
    public string Name { get; set; }

    public Person(string name) => Name = name;

    public bool IsValid() => false;

    public override string ToString() => $"{GetType().Name} ({Name})";
}

public class MyList<T> where T : IEntity
{
    public List<T> Items { get; private set; }
    public int Counter { get; set; }

    public MyList() => Items = new List<T>();

    public void AddItem(T item)
    {
        Items.Add(item);
        Counter++;
    }
}
