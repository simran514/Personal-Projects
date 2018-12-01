namespace BOM_Creator_GUI
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgCSVData = new System.Windows.Forms.DataGridView();
			this.tbCSVPath = new System.Windows.Forms.TextBox();
			this.btBrowse = new System.Windows.Forms.Button();
			this.btUpload = new System.Windows.Forms.Button();
			this.btBOMFormat = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAutofill = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnExport = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dgCSVData)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgCSVData
			// 
			this.dgCSVData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCSVData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgCSVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgCSVData.Location = new System.Drawing.Point(0, 150);
			this.dgCSVData.Name = "dgCSVData";
			this.dgCSVData.Size = new System.Drawing.Size(926, 474);
			this.dgCSVData.TabIndex = 0;
			this.dgCSVData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// tbCSVPath
			// 
			this.tbCSVPath.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbCSVPath.Location = new System.Drawing.Point(0, 0);
			this.tbCSVPath.Name = "tbCSVPath";
			this.tbCSVPath.Size = new System.Drawing.Size(808, 20);
			this.tbCSVPath.TabIndex = 1;
			// 
			// btBrowse
			// 
			this.btBrowse.Dock = System.Windows.Forms.DockStyle.Right;
			this.btBrowse.Location = new System.Drawing.Point(813, 0);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(112, 29);
			this.btBrowse.TabIndex = 2;
			this.btBrowse.Text = "Browse...";
			this.btBrowse.UseVisualStyleBackColor = true;
			this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
			// 
			// btUpload
			// 
			this.btUpload.Dock = System.Windows.Forms.DockStyle.Top;
			this.btUpload.Location = new System.Drawing.Point(0, 0);
			this.btUpload.Name = "btUpload";
			this.btUpload.Size = new System.Drawing.Size(170, 31);
			this.btUpload.TabIndex = 3;
			this.btUpload.Text = "Upload";
			this.btUpload.UseVisualStyleBackColor = true;
			this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
			// 
			// btBOMFormat
			// 
			this.btBOMFormat.Dock = System.Windows.Forms.DockStyle.Top;
			this.btBOMFormat.Location = new System.Drawing.Point(0, 31);
			this.btBOMFormat.Name = "btBOMFormat";
			this.btBOMFormat.Size = new System.Drawing.Size(170, 30);
			this.btBOMFormat.TabIndex = 4;
			this.btBOMFormat.Text = "Format to BOM";
			this.btBOMFormat.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(182, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(287, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Add more rows if necessary, then click on \"Format to BOM\"";
			// 
			// btnAutofill
			// 
			this.btnAutofill.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAutofill.Location = new System.Drawing.Point(0, 61);
			this.btnAutofill.Name = "btnAutofill";
			this.btnAutofill.Size = new System.Drawing.Size(170, 30);
			this.btnAutofill.TabIndex = 6;
			this.btnAutofill.Text = "Autofill BOM";
			this.btnAutofill.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(182, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(265, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Insert URL or DNM, when finished click \"Autofill BOM\"";
			// 
			// btnExport
			// 
			this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnExport.Location = new System.Drawing.Point(813, 11);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(112, 79);
			this.btnExport.TabIndex = 8;
			this.btnExport.Text = "Export BOM";
			this.btnExport.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.tbCSVPath);
			this.panel1.Controls.Add(this.btBrowse);
			this.panel1.Location = new System.Drawing.Point(0, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(925, 29);
			this.panel1.TabIndex = 9;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.btnExport);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new System.Drawing.Point(0, 38);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(925, 106);
			this.panel2.TabIndex = 10;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnAutofill);
			this.panel3.Controls.Add(this.btBOMFormat);
			this.panel3.Controls.Add(this.btUpload);
			this.panel3.Location = new System.Drawing.Point(6, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(170, 95);
			this.panel3.TabIndex = 9;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(926, 624);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dgCSVData);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgCSVData)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgCSVData;
		private System.Windows.Forms.TextBox tbCSVPath;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.Button btUpload;
		private System.Windows.Forms.Button btBOMFormat;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAutofill;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
	}
}

