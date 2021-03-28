using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
	public static class StudentContainer
	{
		public static LinkedList<Student> GenerateItems()
		{
			var firstNameList = new string[] {"Артур", "Алексей", "Артём", "Владислав", "Роман", "Тимур"};
			var lastNameList = new string[] {"Иванов", "Петров", "Сидоров", "Козлов", "Тарасов", "Шевченко"};
			var middleNameList = new string[] {"Иванович", "Петрович", "Сидорович", "Александрович", "Алексеевич", "Романович"};
			var groupList = new string[] {"11-012", "11-011", "11-010" };
			
			var random = new Random();
			return new LinkedList<Student>(Enumerable.Range(1, 20).Select(x => new Student
			{
				Course = random.Next(1, 4),
				Birthday = GetBirthdaysBetweenDates(new DateTime(1980, 01, 01), new DateTime(2000, 01, 01)),
				FirstName = firstNameList.Random(random),
				//FirstName = firstNameList[random.Next(0, firstNameList.Length - 1)],
				LastName = lastNameList.Random(random),
				MiddleName = middleNameList.Random(random),
				GroupNumber = groupList.Random(random),
				MarkList = Enumerable.Range(1, 5).Select(_ => random.Next(2, 5)).ToArray()
			}));
		}

		private static DateTime GetBirthdaysBetweenDates(DateTime minDate, DateTime maxDate)
		{
			if (minDate > maxDate) throw new ArgumentException("minDate can't be greater then maxDate");
			var rnd = new Random();
			var ticks = maxDate.Ticks - minDate.Ticks;
			var toAdd = (long)(rnd.NextDouble() * ticks);
			return new DateTime(minDate.Ticks + toAdd);
		}

		public static LinkedList<Student> Sort(LinkedList<Student> list) => Helpers.SortList(list, Helpers.EOrderType.Desc);

		public class Student : IComparable<Student>, IComparable
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string MiddleName { get; set; }
			public DateTime Birthday { get; set; }
			public int Course { get; set; }
			public string GroupNumber { get; set; }
			public int[] MarkList { get; set; }

			public int CompareTo(Student other)
			{
				if (ReferenceEquals(this, other)) return 0;
				if (ReferenceEquals(null, other)) return 1;

				var courseComparison = Course.CompareTo(other.Course);
				if (courseComparison != 0) return courseComparison;

				var lastNameComparison = string.Compare(LastName, other.LastName, StringComparison.Ordinal);
				if (lastNameComparison != 0) return lastNameComparison;

				var firstNameComparison = string.Compare(FirstName, other.FirstName, StringComparison.Ordinal);
				if (firstNameComparison != 0) return firstNameComparison;

				var middleNameComparison = string.Compare(MiddleName, other.MiddleName, StringComparison.Ordinal);
				if (middleNameComparison != 0) return middleNameComparison;
				return string.Compare(GroupNumber, other.GroupNumber, StringComparison.Ordinal);
			}

			public int CompareTo(object obj) => obj is Student student ? student.CompareTo(this) : 0;

			public override string ToString() => $"course: {Course}, name: {LastName} {FirstName[0]}.{MiddleName[0]}, gr: {GroupNumber}";
		}
	}


}