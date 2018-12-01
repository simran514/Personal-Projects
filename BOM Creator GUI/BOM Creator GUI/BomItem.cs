using HtmlAgilityPack;
using System;
using System.Xml;
using System.Xml.XPath;

namespace BOM_Creator
{
	internal class BomItem
	{
		public int itemNum { get; set; }
		public string manufacturer { get; set; }
		public string partNum { get; set; }
		public string description { get; set; }
		public int quantity { get; set; }
		public string designators { get; set; }
		public string package { get; set; }
		public string url { get; set; }

		public BomItem()
		{

		}

		public BomItem(string url)
		{
			if (url == "DNM")
			{
				createDNM();				
			}
			else
			{
				this.url = url;
				getParameters(url);
			}
		}

		private void createDNM()
		{
			this.manufacturer = "";
			this.partNum = "";
			this.description = "DNM";
			this.url = "";
		}

		private void getParameters(string url)
		{
			HtmlWeb web = new HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load(url);

			this.description = getDescription(doc);
			this.partNum = getPartNum(doc);
			this.manufacturer = getManufacturer(doc);
			this.package = getPackage(doc);
		}

		private string getPackage(HtmlDocument doc)
		{
			HtmlNodeCollection tmp = doc.DocumentNode.SelectNodes(".//*[@id=\"product-attribute-table\"]");
			XPathNavigator xPathNavigator = tmp[0].CreateNavigator();
			//*[@id="product-attribute-table"]/tbody/tr[18]/td[1]
			//tmp[0].
			
			int startIndex = xPathNavigator.InnerXml.IndexOf("Package");
			if (startIndex > -1)
			{
				startIndex = xPathNavigator.InnerXml.IndexOf("<td>", startIndex) + 4;
				int endIndex = xPathNavigator.InnerXml.IndexOf("</td>", startIndex);
				string tempString = xPathNavigator.InnerXml.Substring(startIndex, endIndex - startIndex);
				string result = cleanUpString(tempString);
				return result;
			}
			return "";
		}

		private string getDescription(HtmlDocument doc)
		{
			HtmlNodeCollection tmp = doc.DocumentNode.SelectNodes(".//*[@itemprop=\"description\"]");

			string result = cleanUpString(tmp[0].InnerText);

			return result;
		}

		private string getPartNum(HtmlDocument doc)
		{
			HtmlNodeCollection tmp = doc.DocumentNode.SelectNodes(".//*[@itemprop=\"model\"]");

			string partNum = cleanUpString(tmp[0].InnerText);
			return partNum;
		}



		private string getManufacturer(HtmlDocument doc)
		{
			HtmlNodeCollection result = doc.DocumentNode.SelectNodes(".//*[@itemprop=\"name\"]");

			string manufacturer = result[0].InnerText;

			return manufacturer;
		}

		private string cleanUpString(string input)
		{
			string output = input;

			for (int i = 0; i < 32; i++)
			{
				output = output.Replace(((char)i).ToString(), "");
			}

			output = output.Trim(' ');
			return output;
		}
	}
}