#load "entities.csx"

public class VisitorService
{
    private readonly List<IVisitableElement> _cart;

    public VisitorService(List<IVisitableElement> items)
    {
        _cart = items;
    }

    public void RemoveItem(IVisitableElement item)
    {
        _cart.Remove(item);
    }

    public void ApplyVisitor(IVisitor visitor)
    {
        WriteLine($"\nApplying visitor {visitor.GetType().Name}");
        _cart.ForEach(item => item.Accept(visitor));
        visitor.Print();
    }
}
