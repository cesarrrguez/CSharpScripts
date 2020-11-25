public interface IService<T>
{
    Task<T> Get(int id);
}

public interface IRepository<T>
{
    Task Save(string data);
}
