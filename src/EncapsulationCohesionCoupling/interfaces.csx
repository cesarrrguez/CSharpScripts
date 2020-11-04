public interface IDataContext
{
    void AddRow(string table, object value);
    void DeleteRow(string table, Guid value);
}

public interface IRepository<T>
{
    void Add(T entity);
    void Delete(Guid id);
}
