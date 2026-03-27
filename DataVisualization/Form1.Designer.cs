namespace DataVisualization
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnLoadCases;
        private System.Windows.Forms.Button btnLoadTesting;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button btnPie;
        private System.Windows.Forms.DateTimePicker startPicker;
        private System.Windows.Forms.DateTimePicker endPicker;
        private System.Windows.Forms.ComboBox comboProvince;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnLoadCases = new System.Windows.Forms.Button();
            this.btnLoadTesting = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnPie = new System.Windows.Forms.Button();
            this.startPicker = new System.Windows.Forms.DateTimePicker();
            this.endPicker = new System.Windows.Forms.DateTimePicker();
            this.comboProvince = new System.Windows.Forms.ComboBox();
            this.btnLine = new System.Windows.Forms.Button();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadCases
            // 
            this.btnLoadCases.Location = new System.Drawing.Point(20, 20);
            this.btnLoadCases.Name = "btnLoadCases";
            this.btnLoadCases.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCases.TabIndex = 0;
            this.btnLoadCases.Text = "Load Cases";
            this.btnLoadCases.Click += new System.EventHandler(this.btnLoadCases_Click);
            // 
            // btnLoadTesting
            // 
            this.btnLoadTesting.Location = new System.Drawing.Point(150, 20);
            this.btnLoadTesting.Name = "btnLoadTesting";
            this.btnLoadTesting.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTesting.TabIndex = 1;
            this.btnLoadTesting.Text = "Load Testing";
            this.btnLoadTesting.Click += new System.EventHandler(this.btnLoadTesting_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(20, 60);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 26);
            this.datePicker.TabIndex = 2;
            // 
            // btnPie
            // 
            this.btnPie.Location = new System.Drawing.Point(226, 60);
            this.btnPie.Name = "btnPie";
            this.btnPie.Size = new System.Drawing.Size(75, 23);
            this.btnPie.TabIndex = 3;
            this.btnPie.Text = "Pie Chart";
            this.btnPie.Click += new System.EventHandler(this.btnPie_Click);
            // 
            // startPicker
            // 
            this.startPicker.Location = new System.Drawing.Point(20, 100);
            this.startPicker.Name = "startPicker";
            this.startPicker.Size = new System.Drawing.Size(200, 26);
            this.startPicker.TabIndex = 4;
            // 
            // endPicker
            // 
            this.endPicker.Location = new System.Drawing.Point(226, 100);
            this.endPicker.Name = "endPicker";
            this.endPicker.Size = new System.Drawing.Size(200, 26);
            this.endPicker.TabIndex = 5;
            // 
            // comboProvince
            // 
            this.comboProvince.Location = new System.Drawing.Point(451, 98);
            this.comboProvince.Name = "comboProvince";
            this.comboProvince.Size = new System.Drawing.Size(121, 28);
            this.comboProvince.TabIndex = 6;
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(631, 100);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 7;
            this.btnLine.Text = "Line Chart";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // chartMain
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMain.Legends.Add(legend2);
            this.chartMain.Location = new System.Drawing.Point(20, 140);
            this.chartMain.Name = "chartMain";
            this.chartMain.Size = new System.Drawing.Size(900, 400);
            this.chartMain.TabIndex = 8;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.btnLoadCases);
            this.Controls.Add(this.btnLoadTesting);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnPie);
            this.Controls.Add(this.startPicker);
            this.Controls.Add(this.endPicker);
            this.Controls.Add(this.comboProvince);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.chartMain);
            this.Name = "Form1";
            this.Text = "COVID Data Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.ResumeLayout(false);

        }
    }
}