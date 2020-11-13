#load "entities.csx"

var entity = new ExternalEntity()
{
    Id = 1001,
    FirstName = "Dave",
    LastName = "Johnson"
};

WriteLine(entity);

//MyEntity convertedEntity = entity; // Error

var convertedEntity = (MyEntity)entity;
WriteLine(convertedEntity);
