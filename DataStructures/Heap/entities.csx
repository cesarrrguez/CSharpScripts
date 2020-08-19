// Heap
// ---------------
// Priority queue.
// ----------------

public class Heap<T>
{
    public int Capacity { get; private set; }
    public int Size { get; private set; }
    public T[] Elements { get; private set; }

    public Heap(int capacity)
    {
        Capacity = capacity;
        Elements = new T[capacity + 1];
    }

    public void Add(T value)
    {
        // Full Heap
        if (Size >= Capacity) return;

        var i = 0;
        for (i = Size + 1; Comparer<T>.Default.Compare(Elements[i / 2], value) > 0; i /= 2)
        {
            Elements[i] = Elements[i / 2];
        }
        Elements[i] = value;
        Size++;
    }

    public T RemoveMin()
    {
        var index = 0;
        int sonIndex = 0;
        T minElement = default(T);
        T lastElement = default(T);

        if (Size <= 0) return default(T);

        minElement = Elements[1];
        lastElement = Elements[Size--];

        for (index = 1; index * 2 <= Size; index = sonIndex)
        {
            sonIndex = index * 2;
            if (sonIndex != Size && Comparer<T>.Default.Compare(Elements[sonIndex + 1], Elements[sonIndex]) < 0)
            {
                sonIndex++;
            }

            if (Comparer<T>.Default.Compare(lastElement, Elements[sonIndex]) > 0)
            {
                Elements[index] = Elements[sonIndex];
            }
            else
            {
                break;
            }
        }

        Elements[index] = lastElement;

        return minElement;
    }

    public void Print()
    {
        for (var i = 0; i <= Size; i++)
            Console.Write($"{Elements[i]}, ");

        Console.WriteLine();
    }
}
