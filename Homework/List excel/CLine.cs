using System.Collections.Generic;
using System.Linq;

namespace List_excel
{
	public class CLine
	{
		public Dictionary<CColumn, string> Cells { get; } = new Dictionary<CColumn, string>();

		public override string ToString() => string.Join(", ", Cells.Select(x => x.Value));
	}
}