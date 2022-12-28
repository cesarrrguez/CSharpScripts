#load "interfaces.csx"

public class UserService : IUserService
{
    public async Task<string> GetAsync()
    {
        await Task.FromResult(0);
        return "César Rodríguez";
    }
}
