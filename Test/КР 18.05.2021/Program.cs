using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Контрольная_работа__2_2_семестр
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1 Задание
            //Console.WriteLine("Введите количество чисел");
            //int n = Convert.ToInt32(Console.ReadLine());
            //List<List<int>> list = new List<List<int>>
            //{
            //    new List<int>{1,2,3},
            //    new List<int>{4,5,6},
            //    new List<int>{7,8,9},
            //    new List<int>{10,11,12}
            //};
            //var result = list.SelectMany(x => x).Take(n);
            //Console.WriteLine(string.Join(" ", result.Select(x => x.ToString())));

            //2 задание
            //StackWithVersion<int> stack = new StackWithVersion<int>();
            //stack.Push(3);
            //stack.Push(1);
            //stack.Push(4);
            //stack.Push(1);
            //stack.Pop();
            //stack.Push(2);
            //stack.Push(1);
            //stack.RollBack(0);
            //stack.Push(2);
            //stack.Push(1);
            //stack.Forget();

            //3 задание
            //var value1 = 1;
            //var value2 = 1;

            //var x1 = Convert.ToInt32(Console.ReadLine());
            //var y1 = Convert.ToInt32(Console.ReadLine());

            //var x2 = Convert.ToInt32(Console.ReadLine());
            //var y2 = Convert.ToInt32(Console.ReadLine());

            //if (x1 == x2) value1 = 1;
            //else if (x1 > x2) value1 = x1 - x2 + 1;
            //else if (x2 > x1) value1 = x2 - x1 + 1;

            //if (y1 == y2) value2 = 1;
            //else if (y1 > y2) value2 = y1 - y2 + 1;
            //else if (y2 > y1) value2 = y2 - y1 + 1;


            //var arrOfX1 = new int[value1];
            //if (x1 > x2)
            //{
            //    for (var i = 0; i < arrOfX1.Length; i++)
            //    {
            //        arrOfX1[i] = x1 - i;
            //    }
            //}
            //else
            //{
            //    for (var i = 0; i < arrOfX1.Length; i++)
            //    {

            //        arrOfX1[i] = x2 - i;
            //    }
            //}

            //var arrOfY1 = new int[value2];
            //if (y1 > y2)
            //{
            //    for (var i = 0; i < arrOfY1.Length; i++)
            //    {
            //        arrOfY1[i] = y1 - i;
            //    }
            //}
            //else
            //{
            //    for (var i = 0; i < arrOfY1.Length; i++)
            //    {
            //        arrOfY1[i] = y2 - i;
            //    }
            //}

            //var x3 = Convert.ToInt32(Console.ReadLine());
            //var y3 = Convert.ToInt32(Console.ReadLine());

            //var x4 = Convert.ToInt32(Console.ReadLine());
            //var y4 = Convert.ToInt32(Console.ReadLine());

            //value1 = 1;
            //value2 = 1;

            //if (x3 == x4) value1 = 1;
            //else if (x3 > x4) value1 = x3 - x4 + 1;
            //else if (x4 > x3) value1 = x4 - x3 + 1;

            //if (y3 == y4) value2 = 2;
            //else if (y3 > y4) value2 = y3 - y4 + 1;
            //else if (y4 > y3) value2 = y4 - y3 + 1;

            //var arrOfX2 = new int[value1];

            //if (x3 > x4)
            //{
            //    for (var i = 0; i < arrOfX2.Length; i++)
            //    {
            //        arrOfX2[i] = x3 - i;
            //    }
            //}
            //else
            //{
            //    for (var i = 0; i < arrOfX2.Length; i++)
            //    {
            //        arrOfX2[i] = x4 - i;
            //    }
            //}

            //var arrOfY2 = new int[value2];

            //if (y3 > y4)
            //{
            //    for (var i = 0; i < arrOfY2.Length; i++)
            //    {
            //        arrOfY2[i] = y3 - i;
            //    }
            //}
            //else
            //{
            //    for (var i = 0; i < arrOfY2.Length; i++)
            //    {
            //        arrOfY2[i] = y3 - i;
            //    }
            //}

            //value1 = 999;
            //value2 = 999;
            //if (arrOfX1.Length > arrOfX2.Length)
            //{
            //    for (var i = 0; i < arrOfX1.Length; i++)
            //    {
            //        if (arrOfX1[i] == arrOfX2[0])
            //        {
            //            value1 = arrOfX1[i];
            //        }
            //    }
            //}
            //else if (arrOfX2.Length > arrOfX1.Length)
            //{
            //    for (var i = 0; i < arrOfX2.Length; i++)
            //    {
            //        if (arrOfX2[i] == arrOfX1[0])
            //        {
            //            value1 = arrOfX2[i];
            //        }
            //    }
            //}

            //if (value1 != 999)
            //{
            //    if (arrOfY1.Length > arrOfY2.Length)
            //    {
            //        for (var i = 0; i < arrOfY1.Length; i++)
            //        {
            //            if (arrOfY1[i] == arrOfY2[0])
            //            {
            //                value2 = arrOfY1[i];
            //            }
            //        }
            //    }
            //    else if (arrOfY2.Length > arrOfY1.Length)
            //    {
            //        for (var i = 0; i < arrOfY2.Length; i++)
            //        {
            //            if (arrOfY2[i] == arrOfY1[0])
            //            {
            //                value2 = arrOfY2[i];
            //            }
            //        }
            //    }
            //}

            //if (value1 != 999 && value2 != 999)
            //    Console.WriteLine($"Точка пересечения x: {value1} y: {value2}");
            //else Console.WriteLine("Отрезки не пересекаются");

            Console.ReadKey();
        }
    }
    class StackWithVersion<T>
    {
        public Stack<T> Stack { get; set; }
        public int Version { get; set; }
        public Dictionary<int, Stack<T>> Versions { get; set; }

        public StackWithVersion()
        {
            Versions = new Dictionary<int, Stack<T>>();
            Stack = new Stack<T>{};
            var newStack = new Stack<T>(Stack);
            Version = 0;
            Versions.Add(Version, newStack);
            Console.WriteLine($"Version {Version}  {string.Join(" ", Stack.Select(x => x.ToString()))}\r\n");
        }

        public void Pop()
        {
            Stack.Pop();
            var newStack = new Stack<T>(Stack);
            Version++;
            if (!Versions.ContainsKey(Version)) Versions.Add(Version, newStack);
            Console.WriteLine($"Version {Version} Pop {string.Join(" ", Stack.Select(x => x.ToString()))}\r\n");
        }

        public void Push(T item)
        {
            Stack.Push(item);
            var newStack = new Stack<T>(Stack);
            Version++;
            if (!Versions.ContainsKey(Version)) Versions.Add(Version, newStack);
            Console.WriteLine($"Version{Version} Push {string.Join(" ", Stack.Select(x => x.ToString()))}\r\n");
        }

        public void RollBack(int version)
        {
            if (!Versions.TryGetValue(version, out var oldStack))
                Console.WriteLine("Не получится откатиться к этой версии");
            else
            {
                Stack = new Stack<T>(oldStack);
                Version = version;
                var take = Versions.Take(version);
                Versions = take.ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"Version{Version} RollBack {string.Join(" ", Stack.Select(x => x.ToString()))}\r\n");
            }
        }

        public void Forget()
        {
            Versions.Clear();
            Version = 0;
            Console.WriteLine($"Version{Version} Forget {string.Join(" ", Stack.Select(x => x.ToString()))}\r\n");
        }

    }

}
