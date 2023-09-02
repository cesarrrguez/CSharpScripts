#load "interfaces.csx"

// Strategy A
public class QuickSortStrategy<T> : ISortStrategy<T>
{
    public void Sort(List<T> list)
    {
        list.Sort(); // Default is Quicksort
        WriteLine("QuickSort applied");
    }
}

// Strategy B
public class BubbleSortStrategy<T> : ISortStrategy<T>
{
    public void Sort(List<T> list)
    {
        //list.BubbleSort(); not-implemented
        WriteLine("BubbleSort applied");
    }
}

// Strategy C
public class MergeSortStrategy<T> : ISortStrategy<T>
{
    public void Sort(List<T> list)
    {
        //list.MergeSort(); not-implemented
        WriteLine("MergeSort applied");
    }
}
