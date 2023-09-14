#load "../../../packages.csx"

#load "entities.csx"
#load "dtos.csx"

using Mapster;

// Create mapper config
var config = new TypeAdapterConfig();
config.NewConfig<User, UserDto>()
    .Map(x => x.Name, src => src.FirstName + ' ' + src.LastName)
    .Map(x => x.Street, src => src.Address.Street)
    .Map(x => x.City, src => src.Address.City);

// Create model object
var user = new User("James", "Wilson");
user.AddAddress("My Street", "My City");

// Print model object
WriteLine(user);

// Mapping object model to DTO
var userMap = user.Adapt<UserDto>(config);

// Print DTO
WriteLine();
WriteLine(userMap);
