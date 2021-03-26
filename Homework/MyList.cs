using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    //List<T> Онищенко Александр 11-012
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int>(new[] {1, 2, 3});
            var b = new System.Collections.Generic.List<int>(new[] {5, 6, 7});
            a.AddRange(b);
            foreach (var t in a.Items)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("\r\n");
            a.ChangeMin();
            foreach (var t in a.Items)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("\r\n");
            var text = new List<string>(new[] {"aaa", "bb", "c", "abcd"});
            foreach (var t in text.Items)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("\r\n");

            text.AllEq(text);
            foreach (var t in text.Items)
            {
                Console.WriteLine(t);
            }

            Console.ReadKey();
        }
    }

    class List<T>
    {
        public T[] Items { get; set; }
        private T[] Temp { get; set; }

        public List(T[] items)
        {
            Items = items;
        }

        public List<string> AllEq(List<string> list)
        {
            var result = new List<string>(list.Items);
            result.Sort();
            var maxLength = result.Items.Select(t => t.Length).Prepend(0).Max();

            for (int i = 0; i < list.Items.Length; i++)
            {

                while (list.Items[i].Length != maxLength)
                {
                    list.Items[i] += "_";
                }
            }

            return list;
        }

        public void ChangeMin()
        {
            var list = new List<T>(Items);
            list.Sort();
            var min = list.Items[0];
            var max = list.Items[Items.Length - 1];
            for (int i = 0; i < Items.Length; i++)
            {
                if (Equals(Items[i], min))
                {
                    Items[i] = max;
                }
                else if (Equals(Items[i], max))
                {
                    Items[i] = min;
                }
            }

        }

        public void Add(T item)
        {
            this.EnsureCapacity(this.Items.Length + 1);
            Items[Items.Length - 1] = item;
        }

        private void EnsureCapacity(int itemsLength)
        {
            Temp = Items;
            Items = new T[itemsLength];
            for (var i = 0; i < Temp.Length; i++)
            {
                Items[i] = Temp[i];
            }
        }

        public void AddRange(ICollection<T> collection)
        {
            var len = Items.Length;
            this.EnsureCapacity(Items.Length + collection.Count);
            collection.CopyTo(Items, len);
        }

        int IndexOf(T item)
        {
            return Array.IndexOf<T>(this.Items, item, 0, Items.Length);
        }

        void Insert(int index, T item)
        {
            this.EnsureCapacity(Items.Length + 1);
            Array.Copy((Array) this.Items, index, (Array) this.Items, index + 1, this.Items.Length - index);
            this.Items[index] = item;
        }

        bool Remove(T item)
        {
            int index = this.IndexOf(item);
            this.RemoveAt(index);
            return true;
        }

        void RemoveAt(int index)
        {
            Array.Copy((Array) this.Items, index + 1, (Array) this.Items, index, this.Items.Length - index);
            this.Items[this.Items.Length] = default;
        }

        public void Sort()
        {
            Array.Sort<T>(this.Items, 0, Items.Length, null);
        }
    }
}
