public class CustomList<T>
{
    /// <value>Get the amount of items in the array.</value>
    public int Count { get {return _count;}}

    public T this[int index]
    {
        get
        {
            if((uint)(index) >= (uint)(_capacity))
            {
                return default!;
            }
            //Check if index is to high or to low
            return _items[index];
        }
        set
        {
            if((uint)(index) < (uint)(_capacity))
            {
                _items[index] = value;    
            }
        }
    }

    private T[] _items;
    private int _capacity;
    private int _count;

    public CustomList()
    {
        _capacity = 4;
        _items = new T[_capacity];
        _count = 0;
    }

    public void Add(T item)
    {
        _count += 1;
        if(_count > _capacity)
        {
            IncreaseArray();
        }
        _items[_count-1] = item;
    }

    public void Remove(T item)
    {
        if(item == null) return;
        for(int i = 0; i < _count; i++)
        {
            if (item.Equals(_items[i]))
            {
                RemoveAt(i);
                return;
            }
        }
    }
    /// <summary>
    /// Removes a item at the position of the given index.
    /// </summary>
    /// <param name="index">Index of the item that needs to be removed.</param>
    public void RemoveAt(int index)
    {
        if(index < 0) return;
        for(int i = index; i + 1 < _count; i++)
        {
            _items[i] = _items[i + 1];
        }
        _count -= 1;
        _items[_count] = default!;
    }

    public int IndexOf(T item)
    {
        if(item == null) return -1;
        for (int i = 0; i < _count; i++)
        {
            if (item.Equals(_items[i]))
            {
                return i;
            }
        }
        return -1;
    }

    private void IncreaseArray()
    {
        var newCapacity = _capacity * 2;
        var newItems = new T[newCapacity];
        for(int i = 0; i < _capacity; i++)
        {
            newItems[i] = _items[i];
        }
        _capacity = newCapacity;
        _items = newItems;
    }
}