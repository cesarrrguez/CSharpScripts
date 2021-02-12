#load "interfaces.csx"

public class ProductRepository : IProductRepository
{
    public void Add(Product product)
    {
        Console.WriteLine($"Adding product {product.Id} - {product.Description} into db");
    }
}
