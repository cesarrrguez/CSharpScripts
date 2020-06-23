#load "interfaces.csx"

public class UserRepository : IUserRepository
{
    public void Add(User user)
    {
        Console.WriteLine($"User registered\n-----------------\nEmail: {user.Email}\nPassword: {user.Password})\n");
    }
}
