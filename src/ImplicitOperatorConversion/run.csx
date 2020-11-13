#load "entities.csx"

var entity = new ExternalEntity()
{
    Id = 1001,
    FirstName = "Dave",
    LastName = "Johnson"
};

WriteLine(entity);

MyEntity convertedEntity = entity;
WriteLine(convertedEntity);
