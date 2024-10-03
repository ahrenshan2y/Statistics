using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace homeworkone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取用户输入的n, m, p值
                // Get user inputs for n, m, p
                int n = int.Parse(nTextBox.Text);
                int m = int.Parse(mTextBox.Text);
                double p = double.Parse(pTextBox.Text);

                // 检查输入的合法性
                // Checking the correctness of inputs
                if (n <= 0 || m <= 0 || p < 0 || p > 1)
                {
                    MessageBox.Show("Make sure that n and m are positive integers and that p is a probability value between 0 and 1!");
                    return;
                }


                // Clear the previous chart data
                //chart.Series.Clear();


                // Create Line Charts
                //Series series = new Series
                //{
                //Name = "Penetration_Test",
                //Color = System.Drawing.Color.Blue,
                //ChartType = SeriesChartType.Line
                //};

                // Create Multiple Line Charts
                Series series = new Series
                {
                    Name = $"Penetrations {seriesCounter++}",
                    ChartType = SeriesChartType.Line
                };


                List<int> successfulPenetrations = new List<int>();
                Random random = new Random();
                int penetrationCount = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (random.NextDouble() < p) // +1：pene successfully
                        {
                            penetrationCount++;
                        }
                    }
                    successfulPenetrations.Add(penetrationCount);
                }

                // 将模拟结果添加到图表
                // Adding simulation results to a chart
                for (int i = 0; i < successfulPenetrations.Count; i++)
                {
                    series.Points.AddXY(i + 1, successfulPenetrations[i]);
                }

                chart.Series.Add(series);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integer and floating point values!");
            }
        }

      
    }
}
