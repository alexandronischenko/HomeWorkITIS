using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
	public static class Helpers
	{
		public static T Random<T>(this T[] array, Random random = null)
		{
			random = random ?? new Random();
			return array[random.Next(0, array.Length - 1)];
		}

		public static bool AreTheSetsEqual<T>(LinkedList<T> list1, LinkedList<T> list2) where T : IComparable
		{
			if (list1 == null || list2 == null)
			{
				return false;
			}

			if (list1.Count != list2.Count)
			{
				return false;
			}

			var sortedList1 = Helpers.SortList(list1);
			var sortedList2 = Helpers.SortList(list2);

			using (var enumerator1 = sortedList1.GetEnumerator())
			using (var enumerator2 = sortedList2.GetEnumerator())
			{
				if (!Equals(enumerator1.Current, enumerator2.Current))
				{
					return false;
				}
			}

			return true;
		}

		public static LinkedList<T> SortList<T>(LinkedList<T> items, EOrderType type = EOrderType.Asc) where T : IComparable
		{
			void AddItemToList(T item, LinkedList<T> collection)
			{
				var temp = collection.First;
				while (temp != null)
				{
					if (type == EOrderType.Asc
						? temp.Value.CompareTo(item) > 0
						: temp.Value.CompareTo(item) < 0)
					{
						collection.AddBefore(temp, item);
						break;
					}

					if (temp.Next == null)
					{
						collection.AddLast(item);
						break;
					}

					temp = temp.Next;
				}
			}

			var result = new LinkedList<T>();

			foreach (var item in items)
			{
				if (result.Count == 0)
				{
					result.AddLast(item);
				}
				else
				{
					AddItemToList(item, result);
				}
			}

			return result;
		}

		public enum EOrderType
		{
			Asc,
			Desc
		}
	}
}