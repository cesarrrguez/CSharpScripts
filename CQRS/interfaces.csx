#load "entities.csx"

public interface IProductWriteRepository
{
    void Add(Product product);
}

public interface IProductReadRepository
{
    IEnumerable<Product> GetAll();
}

public interface IProductWriteService
{
    void CreateProduct(Product product);
}

public interface IProductReadService
{
    IEnumerable<Product> GetAllProducts();
}


