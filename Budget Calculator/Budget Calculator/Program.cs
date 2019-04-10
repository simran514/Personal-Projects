using System;
using System.Collections.Generic;
using System.IO;
//using CsvHelper;
using LumenWorks.Framework.IO.Csv;

namespace Budget_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //need to have an object that holds 5 or so strings
            //and then a list or something to hold a bunch of those
            List<List<string>> csvData = new List<List<string>>();

            using (CsvReader csv = new CsvReader(new StreamReader("Chase5226_Activity_20190410.csv"), true))
            {
                int fieldCount = csv.FieldCount;
                //csv.Columns.
                string[] headers = csv.GetFieldHeaders();

                while (csv.ReadNextRecord())
                {
                    csvData.Add(new List<string>());
                    
                    for (int i = 0; i < fieldCount; i++)
                    {
                        csvData[csvData.Capacity - 1].Add(csv[i]);
                        Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
