#load "data.csx"
#load "services.csx"

using Ninject;
using Ninject.Modules;

public class IoC : NinjectModule
{
    public override void Load()
    {
        Bind<IProductService>().To<ProductService>();
        Bind<IProductRepository>().To<ProductRepository>();
    }
}
