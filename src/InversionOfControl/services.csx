#load "interfaces.csx"

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void RegisterNewProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        _productRepository.Add(product);
    }
}
