using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ConsoleApp5
{
	class Program
	{
		static void Main(string[] args)
		{

			//1 задача
			//Book();
			//2 задача
			//OrderedNotAscending();
			//3 задача
            //OrderByPositiveAndIndex2();
			//4 задача
			//AreTheSetsEqual();
			//5 задача 
			//AddListAfterElements();
			//6 задача
			//ChangeWord();
            //7 задача
			//FileRead();
            //9 задача:
			//StudentList();

			Console.ReadKey();
        }

		private static void StudentList()
		{
			var students = StudentContainer.GenerateItems();
			Console.WriteLine($"student list:\r\n{PrintCollection(students, "\r\n")}");
			Console.WriteLine();
			var sortedList = StudentContainer.Sort(students);
			Console.WriteLine($"sordet list:\r\n{PrintCollection(sortedList, "\r\n")}");

		}

		private static void ChangeWord()
		{
			LinkedList<string> list = new LinkedList<string>(){};
            list.AddLast("itmathrepetitorit");
            list.AddLast("it");
            list.AddLast("math");
            list.AddLast("repetitorit");

            Console.WriteLine($"{PrintCollection(list)}");
			string badWord = "itmathrepetitor";
            string goodWord = "silence";

            var temp = list.First;
            while (temp != null)
            {
                temp.Value = TryReplace(temp.Value, badWord, goodWord);
				temp = temp.Next;
            }

            Console.WriteLine($"{PrintCollection(list)}");
        }

        private static string TryReplace(string tempValue, string badWord, string goodWord)
        {
            return tempValue.Replace(badWord, goodWord);
        }

        private static void FileRead()
		{
			var result = new LinkedList<int>();
			var path = $"";
			if (File.Exists(path))
			{
				var stringList = File.ReadAllLines(path);
				var charCountList = stringList.Select(x => x.Length);
				result = new LinkedList<int>(charCountList);

				Console.WriteLine($"{PrintCollection(result)}");
			}
		}

		public static void Book()
		{
			LinkedList<string> list = new LinkedList<string>();
			list = AddBook("Моя жизнь");

			var temp = list.First;
			while (temp != null)
			{
				Console.WriteLine($"{temp.Value}");
				temp = temp.Next;
			}
		}

		public static LinkedList<string> AddBook(string book)
		{
			LinkedList<string> list = new LinkedList<string>();
			list.AddLast("Азбука");
			list.AddLast("Остров сокровищ");
			list.AddLast("Последний единорог");
			list.AddLast("Тёмный Охотник");

			var temp = list.First;
			while (temp != null)
			{
				if (String.Compare(book, temp.Value, StringComparison.OrdinalIgnoreCase) <= 0 ||
				    temp.Next == null)
				{
					list.AddBefore(temp, book);
					break;
				}

				temp = temp.Next;
			}

			return list;
		}

		public static void OrderedNotAscending()
		{
			LinkedList<int> list1 = new LinkedList<int>();
			LinkedList<int> list2 = new LinkedList<int>();
			list1.AddLast(9);
			list2.AddLast(8);
			list1.AddLast(7);
			list2.AddLast(6);
			list1.AddLast(5);
			list2.AddLast(4);
			list1.AddLast(3);
			list2.AddLast(2);
			list1.AddLast(1);
			list2.AddLast(0);

			var value = list1.Concat(list2).OrderByDescending(x => x).ToList();
			var result = new LinkedList<int>(value);

			var temp = result.First;
			while (temp != null)
			{
				Console.WriteLine($"{temp.Value}");
				temp = temp.Next;
			}
		}

		public static void OrderByPositiveAndIndex2()
		{
			LinkedList<int> list = new LinkedList<int>();
			Random rand = new Random();
			for (int i = 0; i < 10; i++)
			{
				list.AddLast(rand.Next(-10, 10));
			}

			LinkedList<int> value = new LinkedList<int>();
			var temp = list.First;
			int index = 0;
			while (temp != null)
			{
				Console.WriteLine($"{temp.Value}");
				if (temp.Value > 0 || index % 2 == 0)
				{
					value.AddLast(temp.Value);
				}

				temp = temp.Next;
				index++;
			}

			Console.WriteLine("\r\n");
			var result = value.OrderBy(x => x).ToList();
			LinkedList<int> a = new LinkedList<int>(result);
			temp = a.First;
			while (temp != null)
			{
				Console.WriteLine($"{temp.Value}");
				temp = temp.Next;
			}
		}

		public static void AreTheSetsEqual()
		{
			var list1 = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
			var list2 = new LinkedList<int>(new[] { 5, 4, 3, 2, 1 });

			Console.WriteLine($"collection 1: {PrintCollection(list1)}");
			Console.WriteLine($"collection 2: {PrintCollection(list2)}");
			Console.WriteLine($"sets are equal: {Helpers.AreTheSetsEqual(list1, list2)}");

		}

		private static void AddListAfterElements()
		{
			var collection = new LinkedList<int>(Enumerable.Range(1, 5));
			var result = AddListAfterElementsSimple(collection);

			Console.WriteLine($"source: {PrintCollection(collection)}");
			Console.WriteLine($"source: {PrintCollection(result)}");
		}

		private static LinkedList<T> AddListAfterElementsLinq<T>(LinkedList<T> list) where T : new()
		{
			var result = list.Select((x, i) => new { item = x, index = i })
				.SelectMany(x => WrapItem(x.item).Concat(list.Take(x.index)))
				.ToList();
			return new LinkedList<T>(result);
		}

		private static LinkedList<T> AddListAfterElementsSimple<T>(LinkedList<T> list) where T : new()
		{
			var result = new LinkedList<T>();

			var index = 0;
			foreach (var item in list)
			{
				result.AddLast(item);

				var temp = list.First;
				var j = 0;
				while (temp != null && j < index)
				{
					result.AddLast(temp.Value);
					temp = temp.Next;
					j++;
				}

				index++;
			}

			return new LinkedList<T>(result);
		}

		private static IEnumerable<T> WrapItem<T>(T item) => new[] { item };

		#region new

		private static string PrintCollection<T>(IEnumerable<T> enumerable, string separator = ", ") =>
			string.Join(separator, enumerable.Select(x => x.ToString()));

		public static LinkedList<int> SortEvenPositive(LinkedList<int> list)
		{
			var result = new LinkedList<int>();

			var count = 0;
			var temp = list.First;
			while (temp != null)
			{
				if (temp.Value > 0 && count % 2 == 0)
				{
					result.AddLast(temp.Value);
				}

				count++;
				temp = temp.Next;
			}

			return Helpers.SortList(result);
		}

		#endregion

	}
}