public interface IService<T>
{
    Task<T> GetAsync(int id);
}

public interface IRepository<T>
{
    Task SaveAsync(string data);
}
