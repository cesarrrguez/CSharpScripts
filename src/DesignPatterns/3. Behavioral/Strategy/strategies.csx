#load "interfaces.csx"

// Strategy A
public class QuickSort<T> : ISortStrategy<T>
{
    public void Sort(List<T> list)
    {
        list.Sort(); // Default is Quicksort
        WriteLine("QuickSort applied");
    }
}

// Strategy B
public class BubbleSort<T> : ISortStrategy<T>
{
    public void Sort(List<T> list)
    {
        //list.BubbleSort(); not-implemented
        WriteLine("BubbleSort applied");
    }
}

// Strategy C
public class MergeSort<T> : ISortStrategy<T>
{
    public void Sort(List<T> list)
    {
        //list.MergeSort(); not-implemented
        WriteLine("MergeSort applied");
    }
}
