#load "interfaces.csx"
#load "entities.csx"

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public void Print()
    {
        var users = _userRepository.GetAll();

        foreach (var employee in users)
        {
            WriteLine(employee.Name);
        }
    }
}
