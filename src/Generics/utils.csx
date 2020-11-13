#load "interfaces.csx"

static void TestGeneric<T>(T entity) where T : IEntity
{
    if (entity == null)
    {
        WriteLine("Entity is null");
    }
    else
    {
        WriteLine(entity.Name);

        if (entity.IsValid())
        {
            WriteLine($"{entity.GetType().Name} is valid");
        }
        else
        {
            WriteLine($"{entity.GetType().Name} is not valid");
        }
    }

    WriteLine();
}
