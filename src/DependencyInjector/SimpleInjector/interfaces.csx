#load "entities.csx"

public interface IProductService
{
    void RegisterNewProduct(Product product);
}

public interface IProductRepository
{
    void Add(Product product);
}
