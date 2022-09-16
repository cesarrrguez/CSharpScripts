#load "interfaces.csx"

public class UserService : IUserService
{
    public async Task<string> GetAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        return "César Rodríguez";
    }
}
