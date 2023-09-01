public class Person
{
    public string FullName { get; init; } = default!;
    public DateOnly DateOfBirth { get; init; }

    public void Deconstruct(out string fullName, out DateOnly dateOfBirth)
    {
        fullName = FullName;
        dateOfBirth = DateOfBirth;
    }
}
