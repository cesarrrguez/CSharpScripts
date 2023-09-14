#load "../../../packages.csx"

#load "ioc.csx"

var productService = IoC.Container.GetInstance<IProductService>();

var product = new Product
{
    Id = 21,
    Description = "Product description"
};

productService.RegisterNewProduct(product);
