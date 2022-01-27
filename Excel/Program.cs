using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Ex = Microsoft.Office.Interop.Excel;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlDocument();
            WebClient client = new WebClient();
            string html = client.DownloadString("https://www.investing.com/indices/us-spx-vix-futures");
            doc.LoadHtml(html);

            HtmlNode nodeone = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/h1[1]");
            string strValueone = nodeone.InnerText;
            Console.WriteLine(strValueone);

            HtmlNode nodetwo = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/span[1]");
            string strValuetwo = nodetwo.InnerText;
            Console.WriteLine(strValuetwo);

            HtmlNode nodethree = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/span[1]");
            string strValuethree = nodethree.InnerText;
            Console.WriteLine(strValuethree);

            HtmlNode nodefour = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[2]/div[1]/div[2]/span[2]");
            string strValuefour = nodefour.InnerText;
            Console.WriteLine(strValuefour);

            var excelapp = new Ex.Application();
            excelapp.Workbooks.Add();
            string path = "C:\\Users\\Administrator\\Desktop\\GreekExcel\\GreekExcel.xls";
            Ex.Workbook workbook = excelapp.Workbooks.Open(path);
            Ex.Worksheet workSheet = workbook.Worksheets.get_Item("FINAL");
            //Ex.Range source = strValueone;
            Ex.Range dest = workSheet.Range["AP3"];
            strValueone.Copy(dest);
        }
    }
}
