#load "interfaces.csx"
#load "utils.csx"

using OneOf;

public class UserService : IUserService
{
    private readonly IDictionary<Guid, User> _users = new Dictionary<Guid, User>
    {
        { Guid.Parse("00000000-1111-2222-3333-000000000000"), new User
          {
              Id = Guid.Parse("00000000-1111-2222-3333-000000000000"),
              Email = "cesar.rrguez@gmail.com",
              FullName = "César Rodríguez"
          }}
    };

    public OneOf<User, InvalidEmail, EmailAlreadyExists> CreateUser(User user)
    {
        if (!RegexUtilities.IsValidEmail(user.Email))
        {
            return new InvalidEmail();
        }

        var existingEmails = _users.Values.Select(x => x.Email.Normalize());

        if (existingEmails.Contains(user.Email.Normalize()))
        {
            return new EmailAlreadyExists();
        }

        _users.TryAdd(user.Id, user);
        return user;
    }

    public User GetUserByID(Guid userId)
    {
        throw new NotImplementedException();
    }
}
