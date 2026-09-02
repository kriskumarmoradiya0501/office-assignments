namespace Program1;

public class Storage<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }
    public void RemoveItem(T item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);        
        }    
    }

    public void DisplayItems()
    {
        foreach(T item in items)
        {
            Console.WriteLine(item);
        }
    }

    public T this[int index]
    {
        get
        {
            return items[index];
        }
    }
}
