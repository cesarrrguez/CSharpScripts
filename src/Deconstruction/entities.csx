public class Person
{
    public string FullName { get; init; } = default!;
    public DateTime DateOfBirth { get; init; }

    public void Deconstruct(out string fullName, out DateTime dateOfBirth)
    {
        fullName = FullName;
        dateOfBirth = DateOfBirth;
    }
}
