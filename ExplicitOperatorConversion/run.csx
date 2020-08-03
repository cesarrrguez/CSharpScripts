#load "entities.csx"

var entity = new ExternalEntity()
{
    Id = 1001,
    FirstName = "Dave",
    LastName = "Johnson"
};

Console.WriteLine(entity);

var convertedEntity = (MyEntity)entity;
Console.WriteLine(convertedEntity);
