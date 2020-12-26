#load "services.csx"
#load "strategies.csx"

// Context
var sortedList = new SortedList<int>();
sortedList.Add(58);
sortedList.Add(42);
sortedList.Add(13);

// Quick Sort Strategy
sortedList.SetSortStrategy(new QuickSort<int>());
sortedList.Sort();

// Bubble Sort Strategy
sortedList.SetSortStrategy(new BubbleSort<int>());
sortedList.Sort();

// Merge Sort Strategy
sortedList.SetSortStrategy(new MergeSort<int>());
sortedList.Sort();
