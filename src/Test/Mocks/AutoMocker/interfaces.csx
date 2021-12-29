public interface IUserService
{
    void Print();
}

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
}
