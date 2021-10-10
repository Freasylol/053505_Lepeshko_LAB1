using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CollectionItem<T> 
{
    public CollectionItem() { }

    public CollectionItem(T data) => this.data = data;

    public T data { get; set; }

    public CollectionItem<T> prev { get; set; }
    public CollectionItem<T> next { get; set; }

}


class MyCustomCollection<T>
{
    public MyCustomCollection() { }

    public MyCustomCollection(T data)
    {
        head = new CollectionItem<T>(data);
        tail = head;
        cursor = head;
    }

    public T this[int index]
    {
        get
        {
                    CollectionItem<T> current = head;
                    for (int i = 0; i < index; i++)
                    {

                        if (current != null)
                        {
                            current = current.next;
                        }
                        if (i + 1 == index)
                        {

                        }
                    }
                    return current.data;
        }

        set
        {
            CollectionItem<T> current = head;
            for (int i = 0; i < index; i++)
            {
                if (current != null)
                {
                    current = current.next;
                }
            }
            if (index >= Count)
            {
                this.Add(value);
            }
        }
    }

    public void Add(T item)
    {
        if (head != null)
        {
            CollectionItem<T> newItem = new CollectionItem<T>(item);
            tail.next = newItem;
            newItem.prev = tail;
            tail = newItem;
        } else
        {
            head = new CollectionItem<T>(item);
            tail = head;
        }
        
    }

    public void Remove(T item)
    {
        if(Count > 0)
        {
            int index = -1;
            CollectionItem<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                if (current.data.Equals(item))
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                if (index <= (Count - 1) / 2)
                {
                    current = this.head;

                    for (int i = 0; i < index; i++)
                    {
                        current = current.next;
                    }
                } else
                {
                    current = this.tail;

                    for (int i = Count - 1; i > index; i--)
                    {
                        current = current.prev;
                    }
                }

                CollectionItem<T> prevItem = current.prev;
                CollectionItem<T> nextItem = current.next;

                if (prevItem != null)
                {
                    prevItem.next = nextItem;
                }
                if (nextItem != null)
                {
                    nextItem = prevItem;
                }

                if (index == 0)
                {
                    head = nextItem;
                } else if (index == Count - 1)
                {
                    tail = prevItem;
                }
            }
        } else 
        {
            Console.WriteLine("Error! Can't delete element from empty list");
        }
            
    }

    public void Print()
    {
        string outputStr = "";
        if (head != null)
        {
            CollectionItem<T> current = head;
            outputStr += current.data.ToString() + " ";
            while(current.next != null)
            {
                outputStr += current.next.data + " ";
                current = current.next;
            }
        }
        Console.WriteLine("Collection output: " + outputStr);
    }

    public CollectionItem<T> head { get; set; }

    public CollectionItem<T> tail { get; set; }

    public CollectionItem<T> cursor { get; set; }

    public int Count
    {
        get
        {
            int count = 0;
            CollectionItem<T> current = new CollectionItem<T>();
            current = head;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }
    }

    public void Next() {
        if (cursor != null) {
            cursor = cursor.next;
        } else {
            if (head != null) {
                cursor = head;
            }
        }
            
    }

    public void Reset() => cursor = head;

    public T Current() => cursor.data;

    public string CurrentStr() => cursor.data.ToString();

    public T RemoveCurrent() {
        T data = cursor.data;
        this.Remove(data);
        return data;
    }

}
