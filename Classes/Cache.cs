namespace SignalRMessages.Classes;

public class Cache<T>
{
    private readonly List<T> _data = [];

    public void Add(T item)
    {
        _data.Add(item);
    }

    public List<T> Get()
    {
        return _data;
    }
    
    public void Delete(T item)
    {
        _data.Remove(item);
    }
}