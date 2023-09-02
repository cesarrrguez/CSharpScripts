#load "entities.csx"
#load "strategies.csx"

// Context
var sortedList = new SortedList<int>();
sortedList.Add(58);
sortedList.Add(42);
sortedList.Add(13);

// Quick Sort Strategy
sortedList.SetSortStrategy(new QuickSortStrategy<int>());
sortedList.Sort();

// Bubble Sort Strategy
sortedList.SetSortStrategy(new BubbleSortStrategy<int>());
sortedList.Sort();

// Merge Sort Strategy
sortedList.SetSortStrategy(new MergeSortStrategy<int>());
sortedList.Sort();
