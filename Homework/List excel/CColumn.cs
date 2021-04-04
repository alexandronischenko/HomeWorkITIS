namespace List_excel
{
	public class CColumn
	{
		public string Header { get; }

		public CColumn(string header) => Header = header;

		public override string ToString() => Header;
	}
}