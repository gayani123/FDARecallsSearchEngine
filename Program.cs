using FDARecallsSearchEngine.Business;
using FDARecallsSearchEngine.Common.Interfaces;
using FDARecallsSearchEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FDARecallsSearchEngine
{
    public class Program
        {
        static int tableWidth = 73;
        static string period = "";

        static void Main(string[] args)
        {

            GetInputFromUser();

            DisplayRecallItemList();
        }

        static void DisplayRecallItemList()
        {
            RecallItemFinder recallItemFinder = new RecallItemFinder();
            var response = recallItemFinder.GetRecallItems(period);

            if (response.Count != 1)
            {

                PrintLine();
                PrintRow("Classification", "Classification Date", "Country", "Product Description", "Reason for Recall");
                PrintLine();
                foreach (var item in response)
                {
                    //DateTime dddd = new DateTime(2016,5,5);
                    //DateTime classificationDate = Convert.ToDateTime(item.ClassificationDate));
                    PrintRow(item.Classification, item.ClassificationDate, item.Country, item.ProductDescription, item.ReasonForRecall);
                   

                }
                PrintLine();
                Console.ReadLine();



            }
            else
            {
                Console.WriteLine("No matching records found");
            }

            Console.WriteLine("Do you want to check another recall set?");
            string userResponse = Console.ReadLine();

            if (userResponse == "yes")
            {
                Console.Clear();
                GetInputFromUser();
                DisplayRecallItemList();
            }
            else
            {
                Console.Clear();
            }
        }
        static void GetInputFromUser()
        {
            DateTime fromdate = new DateTime();
            DateTime todate = new DateTime();

            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Enter start date for recall items?");
                string enteredFromDate = Console.ReadLine();
                Console.WriteLine("Enter end date for recall items?");
                string enteredToDate = Console.ReadLine();

                bool isvalidFromDate = DateTime.TryParse(enteredFromDate, out fromdate);
                bool isvalidToDate = DateTime.TryParse(enteredToDate, out todate);
                //check if date parsing was sucess
                if (isvalidFromDate && isvalidToDate)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Dates entered is in incorrect format!");
                }
            }            
            if (fromdate.Month == todate.Month && fromdate.Year == todate.Year)
            {
                period = string.Format("[{0}+TO+{1}]", fromdate.ToString("yyyyMMdd"), todate.ToString("yyyyMMdd"));
            }
            else
            {
                period = string.Format("[{0}+TO+{1}]", fromdate.ToString("yyyyMMdd"), todate.ToString("yyyyMMdd"));
            }
            Console.Write(period);
            Console.Read();

            //Console.Clear();

        }
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        
    }
}
