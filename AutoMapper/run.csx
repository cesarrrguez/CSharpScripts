#load "entities.csx"
#load "DTO.csx"

#r "nuget: AutoMapper, 10.0.0"

using AutoMapper;

// Create mapper config
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>()
    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FirstName + ' ' + x.LastName))
    .ForMember(x => x.Street, opt => opt.MapFrom(x => x.Address.Street))
    .ForMember(x => x.City, opt => opt.MapFrom(x => x.Address.City));
});

// Create mapper
var mapper = config.CreateMapper();

// Create model object
var user = new User("James", "Wilson");
user.AddAddress("My Street", "My City");

// Print model object
Console.WriteLine(user);

// Mapping object model to DTO
var userMap = mapper.Map<User, UserDTO>(user);

// Print DTO
Console.WriteLine();
Console.WriteLine(userMap);
