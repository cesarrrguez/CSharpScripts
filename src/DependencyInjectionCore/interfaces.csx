public interface IUserController
{
    Task GetAsync();
}

public interface IUserService
{
    Task<string> GetAsync();
}
