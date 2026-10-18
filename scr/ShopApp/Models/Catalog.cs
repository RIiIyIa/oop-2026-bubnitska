namespace ShopApp.Models;

public class Catalog<T> where T : Product
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public List<T> GetAll()
    {
        return new List<T>(_items);
    }

    public int Count => _items.Count;
}