#load "../../packages.csx"

#load "entities.csx"

using System.Security.AccessControl;

using ErrorOr;

PrintResult(GetUser()); // Id is required
PrintResult(GetUser(Guid.NewGuid())); // John Doe

void PrintResult(ErrorOr<User> errorOrUser)
{
    errorOrUser.SwitchFirst(
        user => WriteLine(user.Name),
        error => WriteLine(error.Description));
}

ErrorOr<User> GetUser(Guid id = default)
{
    if (id == default)
    {
        return Error.Validation("User.IdRequired", "User Id is required");
    }

    return new User { Name = "John Doe" };
}
