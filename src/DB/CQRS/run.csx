#load "data.csx"
#load "services.csx"

// Register new Product
var productWriteService = new ProductWriteService(new ProductWriteRepository());

var product = new Product
{
    Id = 21,
    Description = "Product description"
};

productWriteService.CreateProduct(product);

WriteLine();

// Read all Products
var productReadService = new ProductReadService(new ProductReadRepository());

var products = productReadService.GetAllProducts();
foreach (var product in products)
{
    WriteLine(product);
}
