#load "entities.csx"
#load "services.csx"

#r "nuget: OneOf, 3.0.216"

var userToCreate = new User
{
    Id = Guid.NewGuid(),
    Email = "cesar.rrguez",
    FullName = "César Rodríguez",
};
CreateUser(userToCreate);

userToCreate.Email = "cesar.rrguez@gmail.com";
CreateUser(userToCreate);

userToCreate.Email = "cesar@gmail.com";
CreateUser(userToCreate);

public void CreateUser(User userToCreate)
{
    var userService = new UserService();
    var userOneOf = userService.CreateUser(userToCreate);

    userOneOf.Switch(
            user => WriteLine($"User {user.Id} has been successfully created."),
            _ => WriteLine("Sorry, that email is not valid."),
            _ => WriteLine("Sorry, that email is already in use.")
        );
}
