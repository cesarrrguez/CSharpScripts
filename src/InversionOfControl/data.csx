#load "interfaces.csx"

public class ProductRepository : IProductRepository
{
    public void Add(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        Console.WriteLine($"Adding product {product.Id} - {product.Description} into db");
    }
}
