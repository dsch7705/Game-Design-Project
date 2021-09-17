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
}
