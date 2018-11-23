using HtmlAgilityPack;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;




namespace BOM_Creator
{
	internal class Program
	{
		
		private static string[,] BomToArray(ExcelQueryFactory bom)
		{
			var worksheetNames = bom.GetWorksheetNames();
			var columnNames = bom.GetColumnNames(worksheetNames.ElementAt(0));

			List<string> itemNums = new List<string>();
			List<string> colNames = new List<string>();

			foreach (var c in columnNames)
			{
				colNames.Add(c.ToString());
			}

			foreach (var c in bom.Worksheet())
			{
				if (c[0].ToString() == "")
				{
					break;
				}

				itemNums.Add(c[0].ToString());
			}

			String[,] bomArray = new string[itemNums.Count() + 1, colNames.Count()];

			for (int i = 0; i < colNames.Count; i++)
			{
				bomArray[0, i] = colNames.ElementAt(i);
			}

			int bomRows = bomArray.GetLength(0);
			int bomCols = bomArray.GetLength(1);

			int row = 1;
			foreach (var c in bom.Worksheet())
			{
				for (int col = 0; col < bomCols; col++)
				{
					bomArray[row, col] = c[col];
				}
				row++;

				if (row == bomRows)
				{
					break;
				}
			}
			return bomArray;
		}

		private static int GetDigikeyQty(string url)
		{
			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load(url);

			var htmlNodes = doc.DocumentNode.SelectNodes("//*[@id=\"dkQty\"]");
			var test = doc.DocumentNode.SelectNodes("span[text()='10,000']");

			string qty = doc.DocumentNode.SelectNodes("//*[@id=\"dkQty\"]")[0].InnerText;

			for (int i = 32; i < 48; i++)
			{
				qty = qty.Replace(((char)i).ToString(), "");
			}

			for (int i = 58; i < 127; i++)
			{
				qty = qty.Replace(((char)i).ToString(), "");
			}
			return Convert.ToInt32(qty);
		}

		//Looks like Mouser.com is only allowing me to access their web page a set number of times within a certain time range?
		//After attempting to scrape web page after a set number of attemtps, all further access attempts return null values
		//SOLUTION: only use digikey links?
		private static int GetMouserQty(string url)
		{
			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load(url);

			var htmlNodes = doc.DocumentNode.SelectNodes("//*[@id=\"pdpMainContentDiv\"]");
			var test = doc.DocumentNode.SelectNodes("h4[text()='In Stock']");

			string qty = doc.DocumentNode.SelectNodes("//*[@id=\"pdpPricingAvailability\"]/div[2]/div[1]/div[1]/div[2]/div/text()")[0].InnerText;

			for (int i = 0; i < 48; i++)
			{
				qty = qty.Replace(((char)i).ToString(), "");
			}

			for (int i = 58; i < 127; i++)
			{
				qty = qty.Replace(((char)i).ToString(), "");
			}

			return Convert.ToInt32(qty);
		}

		
		[STAThread]
		private static void Main(string[] args)
		{
			//var bom = new ExcelQueryFactory(@"C:\Users\SIMRA\Downloads\Replay Module Interface 1.2D BOM.xlsx");

			/*
			 * Import the CSV file
			 * figure out what each column is and pay attention to the ones that matter
			 * start creating bom items for each item
			 *		go through each line, display info, and prompt user for digikey part url
			 *		after getting url, fill bomItem with all the relevant info
			 *		Keep doing this for every item until we reach the end
			 *		Allow user to enter DNM for the url to keep that line empty
			 * spit out a new csv or something using the bomitems	
			 *	
			 * 
			 * 
			 * 
			 */

			List<BomItem> bomItems = new List<BomItem>();
			var fileLocation = (@"D:\Documents\Altium\RePlay\Controller\1.2B\Output Files\Replay Controller 1.2B.csv");
			var csv = new CachedCsvReader(new StreamReader(fileLocation), true);
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders();
			string tmpUrl;
			int n;

			string[] bomHeaders = {"Item",
								   "Manufacturer",
								   "Part#",
								   "Description",
								   "Qty",
								   "Units",
								   "Ref",
								   "Package",
								   "Link"};

			ExcelPackage excel = new ExcelPackage();
			excel.Workbook.Worksheets.Add("Sheet1");
			ExcelWorksheet ws = excel.Workbook.Worksheets[1];
			ws.Name = "Sheet1";
			ws.Cells.Style.Font.Size = 11;
			ws.Cells.Style.Font.Name = "Arial";


			var format = new ExcelTextFormat();
			format.Delimiter = ',';
			format.SkipLinesBeginning = 5;



			var csvDir = new DirectoryInfo(fileLocation);
			var file = new System.IO.FileInfo(csvDir.ToString());
			//var range = ws.Cells["A1"].LoadFromText(file);




		
	
			while (csv.ReadNextRecord())
			{
				for (int i = 0; i < fieldCount; i++)
				{
				//	ws.Cells[j, i + 1].Value = csv[i];
					//bomItems.Add(new BomItem)
					Console.WriteLine(string.Format("{0} = {1}; ", headers[i], csv[i]));					
				}
				

				Console.WriteLine("Enter DigiKey URL for this part, or DNM if you want it empty: ");
				tmpUrl = Console.ReadLine();

				if (tmpUrl == "exit")
					break;

				bomItems.Add(new BomItem(tmpUrl));
				bomItems[bomItems.Count - 1].designators = csv[2];
				bomItems[bomItems.Count - 1].itemNum = bomItems.Count;
				int.TryParse(csv[5], out n);
				bomItems[bomItems.Count - 1].quantity = n;

				Console.Clear();
			}

			int j = 1;
			foreach(string s in bomHeaders)
			{
				ws.Cells[1, j].Value = s;
				j++;
			}

			j = 2;
			foreach (BomItem b in bomItems)
			{

				ws.Cells[j, 1].Value = b.itemNum;
				ws.Cells[j, 2].Value = b.manufacturer;
				ws.Cells[j, 3].Value = b.partNum;
				ws.Cells[j, 4].Value = b.description;
				ws.Cells[j, 5].Value = b.quantity;
				ws.Cells[j, 6].Value = "EA";
				ws.Cells[j, 7].Value = b.designators;
				ws.Cells[j, 8].Value = b.package;
				ws.Cells[j, 9].Formula = "HYPERLINK(\"" + b.url + "\",\"" + b.url + "\")"; 

				j++;
			}
			int a = bomHeaders.Count();
			int c = bomItems.Count;

			ws.Cells[1, 1, bomItems.Count + 1, bomHeaders.Count()].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
			ws.Cells[1, 1, bomItems.Count + 1, bomHeaders.Count()].Style.Border.Top.Style    = ExcelBorderStyle.Thin;
			ws.Cells[1, 1, bomItems.Count + 1, bomHeaders.Count()].Style.Border.Left.Style   = ExcelBorderStyle.Thin;
			ws.Cells[1, 1, bomItems.Count + 1, bomHeaders.Count()].Style.Border.Right.Style  = ExcelBorderStyle.Thin;

			ws.Cells[1, 1, 1, a].Style.Font.Bold = true;
			ws.Cells[1, 1, 1, a].Style.Fill.PatternType = ExcelFillStyle.Solid;
			ws.Cells[1, 1, 1, a].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
			ws.Column(5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
			//ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

			ws.Cells.AutoFitColumns(0);

			var xlFile = new System.IO.FileInfo("sample1.xlsx");
			excel.SaveAs(xlFile);
			Console.WriteLine(xlFile.FullName);


			Console.ReadKey();
		}
	}
}