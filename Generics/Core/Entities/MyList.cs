using Core.Interfaces;

namespace Core.Entities;

public class MyList<T, K>
    //where T : class, K, IEntity, new()
    //where T : class, IEntity, new()
    //where T : struct, IEntity
    //where T : K
    //where T : new()
    //where T : IEntity
    //where T : class
    //where T : struct
{
    private T[] items;

    public MyList()
    {
        items = new T[0];
    }

    public void Add(T item)
    {
        Array.Resize(ref items, items.Length + 1);
        items[items.Length - 1] = item;
    }

    public void GetAll()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;    
    }
}