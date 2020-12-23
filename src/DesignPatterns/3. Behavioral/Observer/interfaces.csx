#load "entities.csx"

// Observer
public interface IObserver
{
    void Update(SubjectEvent subjectEvent);
}

// Subject
public interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void NotifyObservers(SubjectEvent subjectEvent);
}
