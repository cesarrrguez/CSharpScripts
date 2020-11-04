#load "interfaces.csx"

public class UserRepository : IUserRepository
{
    public void Add(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        Console.WriteLine($"User registered\n-----------------\nEmail: {user.Email}\nPassword: {user.Password})\n");
    }
}
