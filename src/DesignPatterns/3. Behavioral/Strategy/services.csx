#load "interfaces.csx"

// Context
public class SortedList<T>
{
    private readonly List<T> _list = new List<T>();
    private ISortStrategy<T> _strategy;

    public void SetSortStrategy(ISortStrategy<T> strategy)
    {
        _strategy = strategy);
    }

    public void Add(T element)
    {
        _list.Add(element);
    }

    public void Sort()
    {
        _strategy.Sort(_list);
        WriteLine($"Sorted List: {string.Join(", ", _list)}\n");
    }
}
