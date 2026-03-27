using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataVisualization
{
    public partial class Form1 : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            LoadProvinces();

            string basePath = Application.StartupPath;

            string casesPath = Path.Combine(basePath, "CovidData", "covid19-download.csv");
            string testingPath = Path.Combine(basePath, "CovidData", "covid19-epiSummary-labIndicators2.csv");
        }

        // ===================== PIE CHART =====================
        private void btnPie_Click(object sender, EventArgs e)
        {
            LoadPieChart(datePicker.Value);
        }

        void LoadPieChart(DateTime selectedDate)
        {
            chartMain.Series.Clear();
            chartMain.Titles.Clear();

            chartMain.Series.Add("Cases");
            chartMain.Series["Cases"].ChartType = SeriesChartType.Pie;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT Province, MAX(TotalCases) AS Total
                    FROM Cases
                    WHERE Date = @date
                    GROUP BY Province", conn);

                cmd.Parameters.AddWithValue("@date", selectedDate);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    chartMain.Series["Cases"].Points.AddXY(
                        reader["Province"], reader["Total"]);
                }
            }

            chartMain.Titles.Add("COVID Cases by Province");
        }

        // ===================== LINE CHART =====================
        private void btnLine_Click(object sender, EventArgs e)
        {
            LoadLineChart(startPicker.Value, endPicker.Value, comboProvince.Text);
        }

        void LoadLineChart(DateTime start, DateTime end, string province)
        {
            chartMain.Series.Clear();
            chartMain.Titles.Clear();

            chartMain.Series.Add("Cases");
            chartMain.Series.Add("Tested");

            chartMain.Series["Cases"].ChartType = SeriesChartType.Line;
            chartMain.Series["Tested"].ChartType = SeriesChartType.Line;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT c.Date,
                           SUM(c.TotalCases) AS Cases,
                           SUM(t.Tested) AS Tested
                    FROM Cases c
                    JOIN Testing t 
                        ON c.Date = t.Date AND c.Province = t.Province
                    WHERE c.Date BETWEEN @start AND @end
                    AND (@province = 'Canada' OR c.Province = @province)
                    GROUP BY c.Date
                    ORDER BY c.Date", conn);

                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@province", province);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    chartMain.Series["Cases"].Points.AddXY(reader["Date"], reader["Cases"]);
                    chartMain.Series["Tested"].Points.AddXY(reader["Date"], reader["Tested"]);
                }
            }

            chartMain.ChartAreas[0].AxisX.Title = "Date";
            chartMain.ChartAreas[0].AxisY.Title = "Count";
            chartMain.Titles.Add("Cases vs Testing");
        }

        // ===================== LOAD DATA =====================
        private void btnLoadCases_Click(object sender, EventArgs e)
        {
           if(!IsTablePopulated("Cases"))
            {
                string path = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\CovidData\covid19-download.csv"));

                LoadCases(path);
                
            }
            else
            {
                MessageBox.Show("Cases already loaded.");
            }
        }

        private void btnLoadTesting_Click(object sender, EventArgs e)
        {
            if (!IsTablePopulated("Testing"))
            {
                string path = Path.GetFullPath(
               Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\CovidData\covid19-epiSummary-labIndicators2.csv"));

                LoadTesting(path);
            }
            else
            {
                MessageBox.Show("Testing already loaded.");
            }
           
        }

        void LoadCases(string filePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');

                        if (values.Length < 8) continue;

                        string province = values[1];
                        if (province == "Canada") continue;

                        if (!DateTime.TryParse(values[3], out DateTime date)) continue;
                        if (!int.TryParse(values[7], out int cases)) continue;

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Cases (Province, Date, TotalCases) VALUES (@p,@d,@c)", conn);

                        cmd.Parameters.AddWithValue("@p", province);
                        cmd.Parameters.AddWithValue("@d", date);
                        cmd.Parameters.AddWithValue("@c", cases);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Cases loaded.");
        }

        void LoadTesting(string filePath)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var reader = new StreamReader(filePath))
                {
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');

                        if (values.Length < 6) continue;

                        string province = values[0];
                        if (province == "Canada") continue;

                        if (!DateTime.TryParse(values[4], out DateTime date)) continue;
                        if (!int.TryParse(values[5], out int tested)) continue;

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Testing (Province, Date, Tested) VALUES (@p,@d,@t)", conn);

                        cmd.Parameters.AddWithValue("@p", province);
                        cmd.Parameters.AddWithValue("@d", date);
                        cmd.Parameters.AddWithValue("@t", tested);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Testing loaded.");
        }

        bool IsTablePopulated(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    $"SELECT COUNT(1) FROM {tableName}", conn);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        void LoadProvinces()
        {
            comboProvince.Items.Add("Canada");
            comboProvince.Items.Add("Ontario");
            comboProvince.Items.Add("Alberta");
            comboProvince.Items.Add("Quebec");
            comboProvince.SelectedIndex = 0;
        }
    }
}