#load "data.csx"
#load "services.csx"

IProductService productService = new ProductService(new ProductRepository());

var product = new Product
{
    Id = 21,
    Description = "Product description"
};

productService.RegisterNewProduct(product);
