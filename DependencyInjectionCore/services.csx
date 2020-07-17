#load "interfaces.csx"

public class UserService : IUserService
{
    public string GetName()
    {
        return "César Rodríguez";
    }
}
