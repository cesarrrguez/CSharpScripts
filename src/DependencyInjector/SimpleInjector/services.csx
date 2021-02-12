#load "interfaces.csx"

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public void RegisterNewProduct(Product product)
    {
        _productRepository.Add(product);
    }
}
