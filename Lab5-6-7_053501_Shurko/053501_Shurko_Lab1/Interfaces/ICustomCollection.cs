using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Interfaces {
    interface ICustomCollection<T> {
        T this[int index] { get; set; }
        void Reset();
        void Next();
        T Current();
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();

    }
}
