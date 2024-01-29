// See https://aka.ms/new-console-template for more information

using System.Collections.Specialized;
using System.ComponentModel;
using ObservableCollections;

Console.WriteLine("Hello, Observable Collections!");

var observableCollectionFactory = new ObservableCollectionFactory<int>()
    .Create()
    .SetCollectionChangeNotificationDelegate(WhenCollectionChanges)
    .SetPropertyChangeNotificationDelegate(WhenPropertyChanges)
    .Add(1)
    .Add(2)
    .Add(3)
    .Add(4)
    .Add(5)
    .Add(6)
    .Remove(3)
    .Move(1, 2);

_ = observableCollectionFactory.Contains(3);

Console.WriteLine("fin.");
Console.ReadLine();

void WhenCollectionChanges(object? sender, NotifyCollectionChangedEventArgs e)
{
    var enumerable = (IEnumerable<int>) sender!;

    var allItems = enumerable.Select(x => $"{x}").ToArray();
    Console.WriteLine($"> Currently, the collection is {string.Join(',', allItems)}");

    Console.WriteLine($"> The operation is {e.Action}");

    var oldItems = e.OldItems as List<int>;

    var previousItems = oldItems?.Select(x => $"{x}").ToArray() ?? new[] {"<empty>"};
    Console.WriteLine($"> Before the operation it was {string.Join(',', previousItems)}");

    var newItems = e.NewItems as List<int>;

    var currentItems = newItems?.Select(x => $"{x}").ToArray() ?? new[] {"<empty>"};
    Console.WriteLine($"> Now, it is {string.Join(',', currentItems)}");
}

void WhenPropertyChanges(object? sender, PropertyChangedEventArgs e)
{
    var enumerable = (IEnumerable<int>) sender!;

    var allItems = enumerable.Select(x => $"{x}").ToArray();
    Console.WriteLine($"> Currently, the collection is {string.Join(',', allItems)}");
    Console.WriteLine($"> Property {e.PropertyName} has changed");
}