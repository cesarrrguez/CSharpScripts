using System.Collections.ObjectModel;
using System.Collections.Specialized;

var collection = new ObservableCollection<int>();

// Add handler
collection.CollectionChanged += Collection_CollectionChanged;

// Add
collection.Add(21);
collection.Add(7);

// Remove
collection.Remove(21);

static void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
{
    Write("{0} event. ", e.Action);

    // Add
    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        Write("New items: ");

        var sb = new StringBuilder();
        var separator = string.Empty;

        foreach (var item in e.NewItems)
        {
            sb.Append(separator).Append(item);
            separator = ", ";
        }

        Write(sb.ToString());
        WriteLine();
    }

    // Remove
    if (e.Action == NotifyCollectionChangedAction.Remove)
    {
        Write("Old items: ");

        var sb = new StringBuilder();
        var separator = string.Empty;

        foreach (var item in e.OldItems)
        {
            sb.Append(separator).Append(item);
            separator = ", ";
        }

        Write(sb.ToString());
        WriteLine();
    }
}
