#load "entities.csx"

var entity = new ExternalEntity()
{
    Id = 1001,
    FirstName = "Dave",
    LastName = "Johnson"
};

Console.WriteLine(entity);

MyEntity convertedEntity = entity;
Console.WriteLine(convertedEntity);
