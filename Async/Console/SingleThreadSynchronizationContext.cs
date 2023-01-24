using System.Collections.Concurrent;

namespace Async;

internal sealed class SingleThreadSynchronizationContext : SynchronizationContext
{

    private readonly BlockingCollection<KeyValuePair<SendOrPostCallback, object>> m_queue = new();
    
    public override void Post(SendOrPostCallback d, object state)
    {
        m_queue.Add(new KeyValuePair<SendOrPostCallback, object>(d, state));
    }
    public void RunOnCurrentThread()
    {
        KeyValuePair<SendOrPostCallback, object> workItem;
        while (m_queue.TryTake(out workItem, Timeout.Infinite))
            workItem.Key(workItem.Value);
    }

    public void Complete()
    {
        m_queue.CompleteAdding();
    }
}