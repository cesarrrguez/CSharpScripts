#load "interfaces.csx"

public class ProductWriteRepository : IProductWriteRepository
{
    public void Add(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        WriteLine($"Adding product {product.Id} - {product.Description} into db");
    }
}

public class ProductReadRepository : IProductReadRepository
{
    public IEnumerable<Product> GetAll()
    {
        WriteLine("Getting all products from db");

        return new List<Product>()
        {
            new Product{
                Id = 1,
                Description="Product 1"
            }
            ,
            new Product{
                Id = 2,
                Description="Product 2"
            }
        };
    }
}
