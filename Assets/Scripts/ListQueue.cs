using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListQueue<T> : List<T>
{
    public void Enqueue(T item)
    {
        base.Add(item);
    }

    public T Dequeue()
    {
        var item = base[0];
        base.Remove(item);

        return item;
    }

    public T DequeueAt(int i)
    {
        var item = base[i];
        base.Remove(item);

        return item;
    }

    public T DequeueSpecific(T item)
    {
        if (base.Contains(item))
        {
            int i = base.IndexOf(item);
            var _item = base[i];

            base.Remove(_item);
            return _item;
        }
        Debug.Log("item not found");
        return default(T);
        
    }
}
