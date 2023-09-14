#load "../../../packages.csx"

#load "ioc.csx"

using Ninject;

var kernel = new StandardKernel();
//kernel.Load(Assembly.GetExecutingAssembly());
kernel.Load(new[] { new IoC() });

var productService = kernel.Get<IProductService>();

var product = new Product
{
    Id = 21,
    Description = "Product description"
};

productService.RegisterNewProduct(product);
