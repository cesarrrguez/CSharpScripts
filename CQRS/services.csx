#load "interfaces.csx"

public class ProductWriteService : IProductWriteService
{
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductWriteService(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public void CreateProduct(Product product)
    {
        _productWriteRepository.Add(product);
    }
}

public class ProductReadService : IProductReadService
{
    private readonly IProductReadRepository _productReadRepository;

    public ProductReadService(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productReadRepository.GetAll();
    }
}
