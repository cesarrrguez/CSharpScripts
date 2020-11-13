#load "entities.csx"

public static class PersonUtil
{
    public delegate bool FilterDelegate(Person person);

    public static void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
    {
        WriteLine($"- {title}");

        foreach (Person person in people)
        {
            if (filter(person))
            {
                WriteLine($"  * {person}");
            }
        }

        WriteLine();
    }

    public static bool IsChild(Person person)
    {
        return person.Age < 18;
    }

    public static bool IsAdult(Person person)
    {
        return person.Age >= 18;
    }

    public static bool IsSenior(Person person)
    {
        return person.Age >= 65;
    }
}

// Extensions
// ------------------------------------------------------------

public static string ToYesNoString(this bool value)
{
    return value ? "Yes" : "No";
}
