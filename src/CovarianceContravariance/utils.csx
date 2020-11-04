#load "entities.csx"

public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person a, Person b)
    {
        if (a == null) return b == null ? 0 : -1;
        return b == null ? 1 : Compare(a, b);
    }
}
