using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericListForEach
{
    public class Node<T>
    {
        public Node(T t)
        {
            Next = null;
            Data = t;
        }

        public Node<T> Next { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
        public T Data { get; set; }
    }

    //泛型链表类
    public class GenericList<T> : IEnumerable<T>
    {
        public delegate T FuncOnOne(T x);

        public delegate T FuncOnTwo(T x, T y);

        public delegate void ProcudureOnOne(T x);

        private Node<T> tail;

        public GenericList(T headElement)
        {
            tail = Head = new Node<T>(headElement);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public Node<T> Head { get; private set; }

        public void Add(T t)
        {
            var n = new Node<T>(t);
            if (tail == null)
            {
                Head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public IEnumerable<T> ForEach(FuncOnOne func)
        {
            var n = Head;
            while (n != null)
            {
                yield return func(n.Data);
                n = n.Next;
            }
        }

        public void ForEach(ProcudureOnOne func)
        {
            var n = Head;
            while (n != null)
            {
                func(n.Data);
                n = n.Next;
            }
        }

        public T Reduce(FuncOnTwo func, T init)
        {
            var n = Head;
            while (n != null)
            {
                init = func(n.Data, init);
                n = n.Next;
            }

            return init;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ForEach(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            var list = new GenericList<int>(0);
            foreach (var i in Enumerable.Range(1, 10)) list.Add(i);

            foreach (var i in list) Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine($"Total: {list.Reduce((x, y) => x + y, 0)}");
            Console.WriteLine($"Max: {list.Reduce((x, y) => x > y ? x : y, int.MinValue)}");
            Console.WriteLine($"Min: {list.Reduce((x, y) => x < y ? x : y, int.MaxValue)}");

            var list2 = list.ForEach(x => x * x);
            foreach (var i in list2) Console.Write($"{i} ");
            Console.ReadLine();
        }
    }
}