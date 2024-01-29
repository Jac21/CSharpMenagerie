using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ObservableCollections;

public class ObservableCollectionFactory<T> where T : struct
{
    private ObservableCollection<T> _collection;

    public ObservableCollectionFactory<T> Create(IEnumerable<T>? items = null!)
    {
        _collection = items != null ? new ObservableCollection<T>(items) : new ObservableCollection<T>();

        return this;
    }

    public ObservableCollectionFactory<T> Add(T item)
    {
        _collection.Add(item);

        return this;
    }

    public ObservableCollectionFactory<T> Remove(T item)
    {
        _collection.Remove(item);

        return this;
    }

    public bool Contains(T item)
    {
        return _collection.Contains(item);
    }

    public ObservableCollectionFactory<T> Move(int oldIndex, int newIndex)
    {
        _collection.Move(oldIndex, newIndex);

        return this;
    }

    public ObservableCollectionFactory<T> SetCollectionChangeNotificationDelegate(
        NotifyCollectionChangedEventHandler handler)
    {
        _collection.CollectionChanged += handler;

        return this;
    }

    public ObservableCollectionFactory<T> SetPropertyChangeNotificationDelegate(PropertyChangedEventHandler handler)
    {
        (_collection as INotifyPropertyChanged).PropertyChanged += handler;

        return this;
    }
}