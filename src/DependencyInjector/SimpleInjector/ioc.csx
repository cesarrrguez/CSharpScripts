#load "data.csx"
#load "services.csx"

using SimpleInjector;

public static class IoC
{
    public static Container Container;

    static IoC()
    {
        Container = new Container();

        Container.Register<IProductService, ProductService>();
        Container.Register<IProductRepository, ProductRepository>();
    }
}
