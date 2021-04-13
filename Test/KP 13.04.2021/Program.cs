using System;
using System.Collections.Generic;
using System.Linq;

namespace KP_13._04._2021
{
    public struct SetOfStack<T>
    {
        private int StackSize { get; }
        private List<Stack<T>> List { get; set; }
        private int CurrentIndex { get; set; }

        public SetOfStack(int stackSize)
        {
            StackSize = stackSize;
            CurrentIndex = -1;
            List = new List<Stack<T>>();
        }

        public void Push(T item)
        {
            if (CurrentIndex < 0 || List[CurrentIndex].Count == StackSize)
            {
                CurrentIndex++;
                List.Add(new Stack<T>(StackSize));
            }

            var currentStack = List[CurrentIndex];
            currentStack.Push(item);
        }

        public T Pop()
        {
            if (CurrentIndex > -1)
            {
                if (List[CurrentIndex].Count == 0)
                {
                    CurrentIndex--;
                }
                return List[CurrentIndex].Pop();
            }

            return default;
        }

        public T PopAt(int index)
        {
            return List[index].Pop();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1
            TestStack();
            
            //2
            //GetNewList();

            //3
            //TestFunctions();
            Console.ReadKey();
        }

        private static void TestStack()
        {
            var stackSize = 2;
            var stacks = new SetOfStack<int>(stackSize);
        
            stacks.Push(1);
            stacks.Push(2);
            stacks.Push(3);
            stacks.Push(4);
            stacks.Pop();
            stacks.PopAt(1);
            stacks.Push(3);


        }

        private static void TestFunctions()
        {
            List<Dictionary<string, int>> dictionaries = new List<Dictionary<string, int>>();
            
            var d1 = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "c", 3 } };

            var d2 = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "d", 3 } };

            var d3 = new Dictionary<string, int> { { "a", 2 }, { "b", 2 }, { "e", 3 } };

            dictionaries.Add(d1);
            dictionaries.Add(d2);
            dictionaries.Add(d3);

            var result = MaxDict(dictionaries);
            Console.WriteLine(string.Join("\r\n", result.Select(x => $"key: {x.Key}, value: {x.Value}")));

            result = SumDict(dictionaries);
            Console.WriteLine(string.Join("\r\n", result.Select(x => $"key: {x.Key}, value: {x.Value}")));
        }

        private static Dictionary<string, int> MaxDict(List<Dictionary<string, int>> dictionaries)
        {
            var result = new Dictionary<string, int>();

            result = dictionaries.SelectMany(dict => dict)
                 .ToLookup(pair => pair.Key, pair => pair.Value)
                 .ToDictionary(group => group.Key, group => group.Max());

            return result;
        }

        private static Dictionary<string, int> SumDict(List<Dictionary<string, int>> dictionaries)
        {
            var result = new Dictionary<string, int>();

            result = dictionaries.SelectMany(dict => dict)
                 .ToLookup(pair => pair.Key, pair => pair.Value)
                 .ToDictionary(group => group.Key, group => group.Sum());

            return result;
        }

        private static void GetNewList()
        {
            List<double> list = new List<double> {1.25, 3.15, 5.31, 4.23, 9.23};
            Console.WriteLine(string.Join("\t", list.Select(x => x.ToString())));
            List<double> newList = GetNewList(list);
            Console.WriteLine(string.Join("\t", newList.Select(x => x.ToString())));
        }

        private static List<double> GetNewList(List<double> list)
        {
            var result = new List<double>();
            var temp = new List<double>();

            for (var i = 0; i < list.Count; i++)
            {
                temp = list.GetRange(0, i + 1);
                var sum = temp.Sum();
                result.Add(sum);
            }

            return result;
        }

    }
}
