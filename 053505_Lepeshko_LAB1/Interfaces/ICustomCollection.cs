using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ICustomCollection<T>
{
    T this[int index] { get; set; }

    void Add(T item);

    void Print();

    void Remove(T item);

    void Next();
    
    void Reset();

    T RemoveCurrent();

    T Current();

    int Count { get; }
     
}
