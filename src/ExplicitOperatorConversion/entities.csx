public class MyEntity
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public override string ToString() => $"MyEntity. Id: {Id}, FullName: {FullName}";
}

public class ExternalEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static explicit operator MyEntity(ExternalEntity externalEntity)
    {
        return new MyEntity()
        {
            Id = externalEntity.Id,
            FullName = externalEntity.FirstName + " " + externalEntity.LastName
        };
    }

    public override string ToString() => $"ExternalEntity. Id: {Id}, FirstName: {FirstName}, LastName: {LastName}";
}
