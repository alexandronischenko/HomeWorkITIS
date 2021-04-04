using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace List_excel
{
    class Order : IComparable<Order>
    {
        public DateTime OrderDate { get; set; }
        public Priority OrderPriority { get; set; }
        public string ProductName { get; set; }
        public DateTime ShipDate { get; set; }
        public int CompareTo(Order order)
        {
            if (OrderPriority > order.OrderPriority) return 1;
            if (OrderPriority < order.OrderPriority) return -1;
            return 0;
        }
    }

    enum Priority
    {
        NotSpecified = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\temp\Study\ITISHomework\Homework\List excel\orders2.csv";
            var items = ParseCsvFile(path);

            //var xlApp = new Excel.Application();
            //var xlWorkbook = xlApp.Workbooks.Open(@"C:\temp\Study\ITISHomework\Homework\List excel\orders.csv");
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //var xlRange = xlWorksheet.UsedRange;
            //var orders = ReadFile(xlRange);

            var value = items.Take(150).ToList();
            value.Sort(ComparisonByPriorityAndDate);

            Console.WriteLine(String.Join("\r\n", value.Select(x => $"{x.ProductName} {x.OrderDate.Date} {x.OrderPriority} {x.ShipDate.Date}")));
            DeleteOrder(value);
            Console.WriteLine(String.Join("\r\n", value.Select(x => $"{x.ProductName} {x.OrderDate.Date} {x.OrderPriority} {x.ShipDate.Date}")));
            
            Console.Read();
        }

        public static void DeleteOrder(List<Order> orders)
        {
            orders.RemoveAt(orders.Count - 1);
        }

        private static int ComparisonByPriorityAndDate(Order x, Order y)
        {
            if (x.OrderPriority > y.OrderPriority) return 1;
            if (x.OrderPriority < y.OrderPriority) return -1;
            
            if (x.OrderDate > y.OrderDate) return 1;
            if (x.OrderDate < y.OrderDate) return -1;
            
            if (x.ShipDate > y.ShipDate) return 1;
            if (x.ShipDate < y.ShipDate) return -1;

            return 0;
        }

        private static List<Order> ReadFile(Excel.Range xlRange)
        {

            var result = new List<Order>();

            var rowCount = xlRange.Rows.Count;
            var colCount = xlRange.Columns.Count;

            const string OrderDateFieldName = "Order Date";
            const string ShipDateFieldName = "Ship Date";
            const string PriorityFieldName = "Order Priority";
            const string ProductNameFieldName = "Product Name";
            
            var OrderDateFieldIndex = 0;
            var ShipDateFieldIndex = 0;
            var PriorityFieldIndex = 0;
            var ProductNameFieldIndex = 0;

            for (var i = 1; i <= colCount; i++)
            {
                var column = xlRange.Cells[1, i].Value2.ToString();
                switch (column)
                {
                    case OrderDateFieldName:
                        OrderDateFieldIndex = i;
                        break;
                    case ShipDateFieldName:
                        ShipDateFieldIndex = i;
                        break;
                    case PriorityFieldName:
                        PriorityFieldIndex = i;
                        break;
                    case ProductNameFieldName:
                        ProductNameFieldIndex = i;
                        break;
                }
            }

            for (var i = 1; i <= 150; i++)
            {
                result.Add(new Order
                {
                    OrderDate = DateTime.Parse(xlRange.Cells[i, OrderDateFieldIndex].Value2.ToString()),
                    OrderPriority = (Priority)int.Parse(xlRange.Cells[i, PriorityFieldIndex].Value2.ToString()),
                    ProductName = xlRange.Cells[i, ProductNameFieldIndex].Value2.ToString(),
                    ShipDate = DateTime.Parse(xlRange.Cells[i, ShipDateFieldIndex].Value2.ToString()),
                });
            }

            return result;
        }

        private static List<Order> ParseCsvFile(string path)
        {
            var content = File.ReadAllText(path);
            var csv = Csv.Parse(content);

            const string orderDateFieldName = "Order Date";
            const string shipDateFieldName = "Ship Date";
            const string priorityFieldName = "Order Priority";
            const string productNameFieldName = "Product Name";

            var orderDateColumn = csv.Columns.FirstOrDefault(x => x.Header.Equals(orderDateFieldName));
            var shipDateColumn = csv.Columns.FirstOrDefault(x => x.Header.Equals(shipDateFieldName));
            var priorityColumn = csv.Columns.FirstOrDefault(x => x.Header.Equals(priorityFieldName));
            var productNameColumn = csv.Columns.FirstOrDefault(x => x.Header.Equals(productNameFieldName));

            if (orderDateColumn == null || shipDateColumn == null || productNameColumn == null || priorityColumn == null)
            {
                return null;
            }

            return csv.Lines.Select(x => new Order
            {
                OrderDate = DateTime.Parse(x.Cells[orderDateColumn]),
                OrderPriority = (Priority) Enum.Parse(typeof(Priority), x.Cells[priorityColumn].Replace(" ", "")),
                ProductName = x.Cells[productNameColumn].ToString(),
                ShipDate = DateTime.TryParse(x.Cells[shipDateColumn], out var value) ? value : DateTime.Now,
            }).ToList();
        }
    }
}
