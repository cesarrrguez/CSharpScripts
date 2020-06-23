#load "entities.csx"

public interface IProductRepository
{
    void Add(Product product);
}

public interface IProductService
{
    void RegisterNewProduct(Product product);
}
