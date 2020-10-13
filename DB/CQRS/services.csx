#load "interfaces.csx"

public class ProductWriteService : IProductWriteService
{
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductWriteService(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository ?? throw new ArgumentNullException(nameof(productWriteRepository));
    }

    public void CreateProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        _productWriteRepository.Add(product);
    }
}

public class ProductReadService : IProductReadService
{
    private readonly IProductReadRepository _productReadRepository;

    public ProductReadService(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository ?? throw new ArgumentNullException(nameof(productReadRepository));
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productReadRepository.GetAll();
    }
}
