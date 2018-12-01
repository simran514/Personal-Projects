using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace BOM_Creator_GUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//dataGridView1.DataSource = 
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			// To list only csv files, we need to add this filter
			openFileDialog.Filter = "|*.csv";
			DialogResult result = openFileDialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				tbCSVPath.Text = openFileDialog.FileName;
			}
		}

		private void btUpload_Click(object sender, EventArgs e)
		{
			try
			{
				dgCSVData.DataSource = GetDataTableFromCSVFile(tbCSVPath.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK,
  MessageBoxIcon.Error);
			}
		}

		private static DataTable GetDataTableFromCSVFile(string csvfilePath)
		{
			DataTable csvData = new DataTable();
			using ( TextFieldParser csvReader = new TextFieldParser(csvfilePath))
			{
				csvReader.SetDelimiters(new string[] { "," });
				csvReader.HasFieldsEnclosedInQuotes = true;

				//Read columns from CSV file, remove this line if columns not exits  
				string[] colFields = csvReader.ReadFields();

				foreach (string column in colFields)
				{
					DataColumn datecolumn = new DataColumn(column);
					datecolumn.AllowDBNull = true;
					csvData.Columns.Add(datecolumn);
				}

				while (!csvReader.EndOfData)
				{
					string[] fieldData = csvReader.ReadFields();
					//Making empty value as null
					for (int i = 0; i < fieldData.Length; i++)
					{
						if (fieldData[i] == "")
						{
							fieldData[i] = null;
						}
					}
					if (fieldData.Length == colFields.Length)
						csvData.Rows.Add(fieldData);
				}
			}
			return csvData;
		}


	}
}
