namespace MySkipList.Core;

public class SkipList
{
    private readonly Node<int> _head = new(0, 33);
    private readonly Random _random = new();
    private int _levels = 1;

    public void Insert(int value)
    {
        // Determine the level of the new node. Generate a random number R. The number of
        // 1-bits before we encounter the first 0-bit is the level of the node. Since R is
        // 32-bit, the level can be at most 32.
        var level = 0;

        for (var r = _random.Next(); (r & 1) == 1; r >>= 1)
        {
            level += 1;

            if (level == _levels)
            {
                _levels += 1;
                break;
            }
        }

        var newNode = new Node<int>(value, level + 1);
        var current = _head;

        for (var i = _levels - 1; i >= 0; i--)
        {
            for (; current.Next[i] != null; current = current.Next[i])
            {
                if (current.Next[i].Value > value) break;
            }

            if (i <= level)
            {
                newNode.Next[i] = current.Next[i];
                current.Next[i] = newNode;
            }
        }
    }

    public bool Contains(int value)
    {
        var cur = _head;
        for (var i = _levels - 1; i >= 0; i--)
        {
            for (; cur.Next[i] != null; cur = cur.Next[i])
            {
                if (cur.Next[i].Value > value) break;
                if (cur.Next[i].Value == value) return true;
            }
        }

        return false;
    }

    public bool Remove(int value)
    {
        var cur = _head;

        var found = false;
        for (var i = _levels - 1; i >= 0; i--)
        {
            for (; cur.Next[i] != null; cur = cur.Next[i])
            {
                if (cur.Next[i].Value == value)
                {
                    found = true;
                    cur.Next[i] = cur.Next[i].Next[i];
                    break;
                }

                if (cur.Next[i].Value > value) break;
            }
        }

        return found;
    }

    public IEnumerable<int> Enumerate()
    {
        var current = _head.Next[0];

        while (current != null)
        {
            yield return current.Value;
            current = current.Next[0];
        }
    }
}