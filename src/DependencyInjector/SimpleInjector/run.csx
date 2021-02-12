#load "ioc.csx"

#r "nuget: SimpleInjector, 5.2.1"

var productService = IoC.Container.GetInstance<IProductService>();

var product = new Product
{
    Id = 21,
    Description = "Product description"
};

productService.RegisterNewProduct(product);
