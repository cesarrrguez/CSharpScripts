#load "interfaces.csx"

// Concrete Subject
public class ProductService : ISubject
{
    private readonly List<IObserver> _observers;

    public ProductService()
    {
        _observers = new List<IObserver>();
    }

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void AddProduct(string name)
    {
        WriteLine($"Product {name} added");

        var subjectEvent = new SubjectEvent("ProductAdded", DateTime.Now);
        NotifyObservers(subjectEvent);
    }

    public void NotifyObservers(SubjectEvent subjectEvent)
    {
        WriteLine("Before notifying observers");

        _observers.ForEach(observer => observer.Update(subjectEvent));

        WriteLine("After notifying observers");
    }
}
