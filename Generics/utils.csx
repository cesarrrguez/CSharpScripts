#load "interfaces.csx"

static void TestGeneric<T>(T entity) where T : IEntity
{
    if (entity == null)
    {
        Console.WriteLine("Entity is null");
    }
    else
    {
        Console.WriteLine(entity.Name);

        if (entity.IsValid())
        {
            Console.WriteLine($"{entity.GetType().Name} is valid");
        }
        else
        {
            Console.WriteLine($"{entity.GetType().Name} is not valid");
        }
    }

    Console.WriteLine();
}
