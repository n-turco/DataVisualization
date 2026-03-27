using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataVisualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            testConnectionBTN_Click();
            LoadCases("C:\\AdvancedSQL\\DataVisualization\\DataVisualization\\CovidData\\covid19-download.csv");
            LoadTesting("C:\\AdvancedSQL\\DataVisualization\\DataVisualization\\CovidData\\covid19-epiSummary-labIndicators2.csv");
        }

        public string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        void LoadCases(string filePath)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    using (var reader = new StreamReader(filePath))
                    {
                        reader.ReadLine(); // skip header

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            if (values.Length < 8) continue;

                            string province = values[1];
                            if (province == "Canada") continue;

                            if (!DateTime.TryParse(values[3], out DateTime date)) continue;
                            if (!int.TryParse(values[7], out int totalCases)) continue;

                            SqlCommand cmd = new SqlCommand(
                                "INSERT INTO Cases (Province, Date, TotalCases) VALUES (@p, @d, @c)", conn);

                            cmd.Parameters.AddWithValue("@p", province);
                            cmd.Parameters.AddWithValue("@d", date);
                            cmd.Parameters.AddWithValue("@c", totalCases);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Cases loaded successfully.");
                    }
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load data." + ex.Message);
            }

        }

        void LoadTesting(string filePath)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    using (var reader = new StreamReader(filePath))
                    {
                        reader.ReadLine(); // skip header

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            if (values.Length < 6) continue;

                            string province = values[0];
                            if (province == "Canada") continue;

                            if (!DateTime.TryParse(values[4], out DateTime date)) continue;
                            if (!int.TryParse(values[5], out int tested)) continue;

                            SqlCommand cmd = new SqlCommand(
                                "INSERT INTO Testing (Province, Date, Tested) VALUES (@p, @d, @t)", conn);

                            cmd.Parameters.AddWithValue("@p", province);
                            cmd.Parameters.AddWithValue("@d", date);
                            cmd.Parameters.AddWithValue("@t", tested);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Testing loaded successfully.");
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Failed to load data." + ex.Message);
            }

        }

        private void testConnectionBTN_Click()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed." + ex.Message);
                }
            }
        }
    }
    }
