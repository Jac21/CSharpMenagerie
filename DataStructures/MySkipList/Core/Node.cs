using System.Diagnostics.CodeAnalysis;

namespace MySkipList.Core;

public class Node<T>
{
    public Node<T>[] Next { get; }

    public T Value { get; }

    public Node([DisallowNull] T value, int level)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));

        Next = new Node<T>[level];
    }
}