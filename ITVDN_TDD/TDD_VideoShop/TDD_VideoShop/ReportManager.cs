using System;
using TDD_VideoShop;
using System.IO;
using System.Text;

namespace TDD_VideoShop
{
    public class ReportManager
    {
        public static void CreateReport(string path, Customer customer)
        {
            TextWriter textWriter = TextWriterFactory.GetTextWriter(path);

            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(string.Format("Отчет по клиенту: {0}", customer.Name));

            foreach (Rental item in customer.Rental)
            {
                strBuilder.AppendLine(string.Format("{0} {1} days: {2:C}", item.Movie.Name, item.Days, item.CalculateDebt()));
            }

            strBuilder.AppendLine(string.Format("Сумма долга: {0:C}", customer.CalculateTotal()));

            textWriter.Write(strBuilder.ToString());
            textWriter.Flush();
        }
    }
}