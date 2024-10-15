using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HackerSimulation
{
    public class HackerForm : Form
    {
        private TextBox nTextBox, mTextBox, pTextBox, xValueTextBox;
        private Button simulateButton;
        private Chart chart;
        private Chart histogramChart;
        private Chart absFreqChart;
        private Chart relFreqChart;
        private Chart relFreqHistogram;
        private Chart lineChartHistogram;
        private Random random = new Random();
        private List<int> finalPenetrationCounts = new List<int>();
        private List<double> relativeFrequencyAtX10 = new List<double>();

        // TextBoxes for showing mean and variance
        private TextBox histogramMeanTextBox, histogramVarianceTextBox;
        private TextBox relFreqMeanTextBox, relFreqVarianceTextBox;
        private TextBox lineChartMeanTextBox, lineChartVarianceTextBox;

        public HackerForm()
        {
            this.Text = "Hacker Simulation";
            this.Size = new Size(1800, 1000); 

            // TextBox
            Label nLabel = new Label() { Text = "Servers (n):", Left = 10, Top = 10 };
            nTextBox = new TextBox() { Left = 120, Top = 10, Width = 100, Text = "100" };

            Label mLabel = new Label() { Text = "Attackers (m):", Left = 10, Top = 40 };
            mTextBox = new TextBox() { Left = 120, Top = 40, Width = 100, Text = "20" };

            Label pLabel = new Label() { Text = "Probability (p):", Left = 10, Top = 70 };
            pTextBox = new TextBox() { Left = 120, Top = 70, Width = 100, Text = "0.7" };

            Label xValueLabel = new Label() { Text = "X Value:", Left = 10, Top = 100 };
            xValueTextBox = new TextBox() { Left = 120, Top = 100, Width = 100, Text = "50" };

            simulateButton = new Button() { Text = "Simulate", Left = 10, Top = 130, Width = 210 };
            simulateButton.Click += SimulateButton_Click;

            this.Controls.Add(nLabel);
            this.Controls.Add(nTextBox);
            this.Controls.Add(mLabel);
            this.Controls.Add(mTextBox);
            this.Controls.Add(pLabel);
            this.Controls.Add(pTextBox);
            this.Controls.Add(xValueLabel);
            this.Controls.Add(xValueTextBox);
            this.Controls.Add(simulateButton);

            // Line chart
            chart = new Chart() { Left = 240, Top = 10, Width = 800, Height = 350 };
            ChartArea chartArea = new ChartArea("LineChart1");
            chart.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "Servers";
            chartArea.AxisY.Title = "Times to be penetrated";
            this.Controls.Add(chart);

            // Histogram Chart
            histogramChart = new Chart() { Left = 1060, Top = 10, Width = 700, Height = 350 };
            ChartArea histogramArea = new ChartArea("HistogramChart");
            histogramChart.ChartAreas.Add(histogramArea);
            histogramArea.AxisX.Title = "Times";
            histogramArea.AxisY.Title = "Frequency";
            this.Controls.Add(histogramChart);

            // Controls for histogramChart Mean and Variance
            Label histogramMeanLabel = new Label() { Text = "Mean:", Left = 1060, Top = 370 };
            histogramMeanTextBox = new TextBox() { Left = 1160, Top = 370, Width = 100, ReadOnly = true };
            Label histogramVarianceLabel = new Label() { Text = "Variance:", Left = 1060, Top = 400 };
            histogramVarianceTextBox = new TextBox() { Left = 1160, Top = 400, Width = 100, ReadOnly = true };
            this.Controls.Add(histogramMeanLabel);
            this.Controls.Add(histogramMeanTextBox);
            this.Controls.Add(histogramVarianceLabel);
            this.Controls.Add(histogramVarianceTextBox);

            // Absolute Frequency Chart
            absFreqChart = new Chart() { Left = 240, Top = 370, Width = 500, Height = 300 };
            ChartArea absFreqArea = new ChartArea("AbsoluteFrequencyChart");
            absFreqChart.ChartAreas.Add(absFreqArea);
            absFreqArea.AxisX.Title = "Servers";
            absFreqArea.AxisY.Title = "Absolute Frequency";
            this.Controls.Add(absFreqChart);

            // Relative Frequency Chart
            relFreqChart = new Chart() { Left = 760, Top = 370, Width = 500, Height = 300 };
            ChartArea relFreqArea = new ChartArea("RelativeFrequencyChart");
            relFreqChart.ChartAreas.Add(relFreqArea);
            relFreqArea.AxisX.Title = "Servers";
            relFreqArea.AxisY.Title = "Relative Frequency";
            this.Controls.Add(relFreqChart);

            // Relative Frequency Histogram
            relFreqHistogram = new Chart() { Left = 760, Top = 680, Width = 500, Height = 250 };
            ChartArea relFreqHistogramArea = new ChartArea("RelFreqHistogramArea");
            relFreqHistogram.ChartAreas.Add(relFreqHistogramArea);
            relFreqHistogramArea.AxisX.Title = "Relative Frequency at Servers=n";
            relFreqHistogramArea.AxisY.Title = "Frequency";
            this.Controls.Add(relFreqHistogram);

            // Controls for relFreqHistogram Mean and Variance
            Label relFreqMeanLabel = new Label() { Text = "Mean:", Left = 760, Top = 940 };
            relFreqMeanTextBox = new TextBox() { Left = 860, Top = 940, Width = 100, ReadOnly = true };
            Label relFreqVarianceLabel = new Label() { Text = "Variance:", Left = 760, Top = 970 };
            relFreqVarianceTextBox = new TextBox() { Left = 860, Top = 970, Width = 100, ReadOnly = true };
            this.Controls.Add(relFreqMeanLabel);
            this.Controls.Add(relFreqMeanTextBox);
            this.Controls.Add(relFreqVarianceLabel);
            this.Controls.Add(relFreqVarianceTextBox);

            // Line Chart Histogram
            lineChartHistogram = new Chart() { Left = 1280, Top = 370, Width = 500, Height = 300 };
            ChartArea lineChartHistogramArea = new ChartArea("LineChartHistogramArea");
            lineChartHistogram.ChartAreas.Add(lineChartHistogramArea);
            lineChartHistogramArea.AxisX.Title = "Penetrate times values at specified X";
            lineChartHistogramArea.AxisY.Title = "Frequency";
            this.Controls.Add(lineChartHistogram);

            // Controls for lineChartHistogram Mean and Variance
            Label lineChartMeanLabel = new Label() { Text = "Mean:", Left = 1280, Top = 680 };
            lineChartMeanTextBox = new TextBox() { Left = 1380, Top = 680, Width = 100, ReadOnly = true };
            Label lineChartVarianceLabel = new Label() { Text = "Variance:", Left = 1280, Top = 710 };
            lineChartVarianceTextBox = new TextBox() { Left = 1380, Top = 710, Width = 100, ReadOnly = true };
            this.Controls.Add(lineChartMeanLabel);
            this.Controls.Add(lineChartMeanTextBox);
            this.Controls.Add(lineChartVarianceLabel);
            this.Controls.Add(lineChartVarianceTextBox);
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            int n = int.Parse(nTextBox.Text);
            int m = int.Parse(mTextBox.Text);
            double p = double.Parse(pTextBox.Text);

            List<int> absoluteFrequencies = new List<int>();
            List<double> relativeFrequencies = new List<double>();
            int successfulPenetrations = 0;

            // Simulate penetration of each server
            for (int i = 1; i <= n; i++)
            {
                int successfulCountInCurrentIteration = 0;

                // Simulate m attacks
                for (int j = 0; j < m; j++)
                {
                    if (random.NextDouble() < p)
                    {
                        successfulPenetrations++;
                        successfulCountInCurrentIteration++;
                    }
                    else
                    {
                        successfulPenetrations--;
                    }
                }

                // Record the current absolute frequency
                absoluteFrequencies.Add(successfulPenetrations);

                // Calculate the current relative frequency
                double relativeFrequency = (double)successfulCountInCurrentIteration / m;
                relativeFrequencies.Add(relativeFrequency);

                if (i == n)
                {
                    relativeFrequencyAtX10.Add(relativeFrequency);
                }
            }

            finalPenetrationCounts.Add(successfulPenetrations);

            // Update chart
            UpdateAbsoluteFrequencyChart(absoluteFrequencies);
            UpdateRelativeFrequencyChart(relativeFrequencies);
            UpdateLineChart(absoluteFrequencies);
            UpdateHistogram();
            DrawHorizontalHistogramAtXValue();
            DrawRelFreqHistogramAtNValue(relativeFrequencies, n);
        }

        private void UpdateHistogram()
        {
            histogramChart.Series.Clear();

            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach (var count in finalPenetrationCounts)
            {
                if (frequency.ContainsKey(count))
                {
                    frequency[count]++;
                }
                else
                {
                    frequency[count] = 1;
                }
            }

            Series histogramSeries = new Series
            {
                Name = "Histogram",
                ChartType = SeriesChartType.Bar,
                BorderWidth = 1
            };

            histogramSeries["PointWidth"] = "0.8";

            foreach (var entry in frequency.OrderBy(entry => entry.Key))
            {
                histogramSeries.Points.AddXY(entry.Key, entry.Value);
            }

            histogramChart.Series.Add(histogramSeries);

            // Calculate and display mean and variance for histogramChart
            var (mean, variance) = CalculateMeanAndVariance(finalPenetrationCounts);
            histogramMeanTextBox.Text = mean.ToString("F2");
            histogramVarianceTextBox.Text = variance.ToString("F2");
        }

        private void DrawRelFreqHistogramAtNValue(List<double> relativeFrequencies, int n)
        {
            // Get the y-value for all series at the specified n-value.
            List<double> yValuesAtN = new List<double>();

            foreach (var series in relFreqChart.Series)
            {
                if (n - 1 < series.Points.Count)
                {
                    yValuesAtN.Add(series.Points[n - 1].YValues[0]);
                }
            }

            // Update relFreqHistogram
            UpdateRelFreqHistogram(yValuesAtN);
        }

        private void UpdateRelFreqHistogram(List<double> yValuesAtN)
        {
            relFreqHistogram.Series.Clear();

            Dictionary<double, int> frequency = new Dictionary<double, int>();
            foreach (var value in yValuesAtN)
            {
                double roundedValue = Math.Round(value, 2);
                if (frequency.ContainsKey(roundedValue))
                {
                    frequency[roundedValue]++;
                }
                else
                {
                    frequency[roundedValue] = 1;
                }
            }

            Series histogramSeries = new Series
            {
                Name = "RelFreqAtNHistogram",
                ChartType = SeriesChartType.Bar,
                BorderWidth = 1
            };

            foreach (var entry in frequency.OrderBy(entry => entry.Key))
            {
                histogramSeries.Points.AddXY(entry.Key, entry.Value);
            }

            relFreqHistogram.Series.Add(histogramSeries);
            relFreqHistogram.ChartAreas[0].RecalculateAxesScale();

            // Calculate and display mean and variance for relFreqHistogram
            var (mean, variance) = CalculateMeanAndVariance(yValuesAtN);
            relFreqMeanTextBox.Text = mean.ToString("F2");
            relFreqVarianceTextBox.Text = variance.ToString("F2");
        }

        private void DrawHorizontalHistogramAtXValue()
        {
            int xValue = int.Parse(xValueTextBox.Text);

            List<int> yValuesAtX = new List<int>();
            foreach (var series in chart.Series)
            {
                if (xValue - 1 < series.Points.Count)
                {
                    yValuesAtX.Add((int)series.Points[xValue - 1].YValues[0]);
                }
            }

            UpdateLineChartHistogram(yValuesAtX);
        }

        private void UpdateLineChartHistogram(List<int> yValuesAtX)
        {
            lineChartHistogram.Series.Clear();

            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (var value in yValuesAtX)
            {
                if (frequency.ContainsKey(value))
                {
                    frequency[value]++;
                }
                else
                {
                    frequency[value] = 1;
                }
            }

            Series histogramSeries = new Series
            {
                Name = "YValuesAtXHistogram",
                ChartType = SeriesChartType.Bar,
                BorderWidth = 1
            };

            foreach (var entry in frequency.OrderBy(entry => entry.Key))
            {
                histogramSeries.Points.AddXY(entry.Key, entry.Value);
            }

            lineChartHistogram.Series.Add(histogramSeries);
            lineChartHistogram.ChartAreas[0].RecalculateAxesScale();

            // Calculate and display mean and variance for lineChartHistogram
            var (mean, variance) = CalculateMeanAndVariance(yValuesAtX);
            lineChartMeanTextBox.Text = mean.ToString("F2");
            lineChartVarianceTextBox.Text = variance.ToString("F2");
        }

        private (double mean, double variance) CalculateMeanAndVariance(List<double> values)
        {
            if (values.Count == 0) return (0, 0);

            double mean = values.Average();
            double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
            return (mean, variance);
        }

        private (double mean, double variance) CalculateMeanAndVariance(List<int> values)
        {
            if (values.Count == 0) return (0, 0);

            double mean = values.Average();
            double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
            return (mean, variance);
        }

        private void UpdateAbsoluteFrequencyChart(List<int> absoluteFrequencies)
        {
            Series absSeries = new Series
            {
                Name = $"Absolute Frequency {absFreqChart.Series.Count + 1}",
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            for (int i = 0; i < absoluteFrequencies.Count; i++)
            {
                absSeries.Points.AddXY(i + 1, absoluteFrequencies[i]);
            }

            absFreqChart.Series.Add(absSeries);
        }

        private void UpdateRelativeFrequencyChart(List<double> relativeFrequencies)
        {
            Series relSeries = new Series
            {
                Name = $"Relative Frequency {relFreqChart.Series.Count + 1}",
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            for (int i = 0; i < relativeFrequencies.Count; i++)
            {
                relSeries.Points.AddXY(i + 1, relativeFrequencies[i]);
            }

            relFreqChart.Series.Add(relSeries);
        }

        private void UpdateLineChart(List<int> successfulPenetrations)
        {
            Series series = new Series
            {
                Name = $"Line{chart.Series.Count + 1}",
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            for (int i = 0; i < successfulPenetrations.Count; i++)
            {
                series.Points.AddXY(i + 1, successfulPenetrations[i]);
            }
            chart.Series.Add(series);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HackerForm());
        }
    }
}

