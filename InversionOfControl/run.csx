// IoC (Inversion of Control)
// ----------------------------------------------------------
// Is a software principle where rather than having the 
// application call the methods in a framework, the framework
// calls implementations provided by the application.
// ----------------------------------------------------------

#load "data.csx"
#load "services.csx"

IProductService productService = new ProductService(new ProductRepository());

var product = new Product
{
    Id = 21,
    Description = "Product description"
};

productService.RegisterNewProduct(product);
