using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace List_excel
{
	public class Csv
	{
		private static readonly Regex RowRegex = new Regex(@"\r\n|\r|\n");
		private static readonly Regex ColumnRegex = new Regex("\"([^\"]*(?:\"\"[^\"]*)+)\"");

		public CColumn[] Columns { get; }

		public CLine[] Lines { get; }

		public Csv(CColumn[] columns, CLine[] lines)
		{
			Columns = columns;
			Lines = lines;
		}

		public static Csv Parse(string content)
		{
			var lines = RowRegex.Split(content.Trim());
			var separatorReplacement = Guid.NewGuid().ToString();
			var headers = new Dictionary<int, CColumn>();
			var separator = ';';
			var separatorString = separator.ToString();

			var result = new CLine[lines.Length - 1];
			for (var index = 0; index < lines.Length; index++)
			{
				var line = lines[index];
				var resultLine = line;
				var matches = ColumnRegex.Matches(resultLine);
				foreach (var match in matches.Cast<Match>())
				{
					var group = match.Groups[1];
					var value = @group.Value;
					value = value.Replace("\"\"", "\"");
					value = value.Replace(";", separatorReplacement);
					resultLine = resultLine.Remove(match.Index, match.Length);
					resultLine = resultLine.Insert(match.Index, value);
				}

				var items = resultLine.Split(separator);

				if (index != 0)
				{
					result[index - 1] = new CLine();
				}

				for (var i = 0; i < items.Length; i++)
				{
					var item = items[i];
					if (index == 0)
					{
						headers[i] = new CColumn(item);
						continue;
					}

					if (!headers.TryGetValue(i, out var header))
					{
						header = new CColumn(item);
						headers[i] = header;
					}

					result[index - 1].Cells[header] =
						item.Replace(separatorReplacement, separatorString);
				}
			}

			return new Csv(headers.OrderBy(x => x.Key).Select(x => x.Value).ToArray(), result);
		}

		private static string ExportString(string item)
		{
			if (item == null)
			{
				return "";
			}
			var result = item.Replace("\"", "\"\"");
			if (result != item)
			{
				result = $"\"{result}\"";
			}

			return result;
		}

		public string Export()
		{
			var result = "";
			result += string.Join(";", Columns.Select(x => ExportString(x.ToString()))) + "\r\n";
			return Lines.Aggregate(result, (current, line) => current + (string.Join(";", line.Cells.Select(x => ExportString(x.Value))) + "\r\n"));
		}

		public override string ToString() => string.Join(", ", Columns.Select(x => x.ToString()));
	}
}