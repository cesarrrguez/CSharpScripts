#load "entities.csx"
#load "structs.csx"

using OneOf;

public interface IUserService
{
    OneOf<User, InvalidEmail, EmailAlreadyExists> CreateUser(User user);
    User GetUserByID(Guid userId);
}
