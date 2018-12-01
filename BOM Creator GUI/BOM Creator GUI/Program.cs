using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using LinqToExcel;
using System.IO;
using System.Globalization;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Text;
using System.ComponentModel;
using System.Data;


namespace BOM_Creator_GUI
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

			var fileLocation = (@"D:\Documents\Altium\RePlay\Controller\1.2B\Output Files\Replay Controller 1.2B.csv");
			var csv = new CachedCsvReader(new StreamReader(fileLocation), true);
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders();
			string tmpUrl;
			int n;
			string[] fields;
			DataTable dt = new DataTable();

			for (int i = 0; i < headers.Count(); i++)
			{
				dt.Columns.Add(headers[i].ToLower());
			}
			DataRow row;




			string s = "";
			string tmp;
			while (csv.ReadNextRecord())
			{
				row = dt.NewRow();
				for (int i = 0; i < fieldCount; i++)
				{
					row[i] = csv[i];
					tmp = s;
					s = String.Concat(tmp, " " + csv[i] + " ");
					
				}
				dt.Rows.Add(row);
			}
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());


			Console.ReadKey();
		}
	}
}
