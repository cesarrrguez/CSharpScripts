#load "../../../packages.csx"

#load "entities.csx"
#load "dtos.csx"

using AutoMapper;

// Create mapper config
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDto>()
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
WriteLine(user);

// Mapping object model to DTO
var userMap = mapper.Map<User, UserDto>(user);

// Print DTO
WriteLine();
WriteLine(userMap);
