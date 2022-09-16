public interface IUserController
{
    Task<string> GetAsync();
}

public interface IUserService
{
    Task<string> GetAsync();
}
