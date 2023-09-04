namespace WeakEventPattern.Events;

public class WeakEvent<TEventArgs>
{
    /// <summary>
    /// List of WeakReference objects
    /// </summary>
    private readonly List<WeakReference> _listeners = new();

    /// <summary>
    /// Adds a new listener to the list
    /// </summary>
    /// <param name="handler"></param>
    public void AddListener(EventHandler<TEventArgs> handler)
    {
        _listeners.Add(new WeakReference(handler));
    }

    /// <summary>
    /// Removes a listener to the list where references are not alive (i.e., garbage collected)
    /// </summary>
    /// <param name="handler"></param>
    public void RemoveListener(EventHandler<TEventArgs> handler)
    {
        _listeners.RemoveAll(wr => !wr.IsAlive ||
                                   wr.Target!.Equals(handler));
    }

    /// <summary>
    /// Raises the event handler by calling each listener in the list, removes dead entries
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void Raise(object sender, TEventArgs args)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            var weakReference = _listeners[i];

            if (weakReference.IsAlive)
            {
                ((EventHandler<TEventArgs>) weakReference.Target!)?.Invoke(sender, args);
            }
            else
            {
                _listeners.RemoveAt(i);
            }
        }
    }
}