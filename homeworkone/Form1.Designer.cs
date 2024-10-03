using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
namespace homeworkone
{
    partial class Form1
    {
        private TextBox nTextBox;
        private TextBox mTextBox;
        private TextBox pTextBox;
        private Button simulateButton;
        private Chart chart;
        private System.ComponentModel.IContainer components = null;
        private int seriesCounter = 0;
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.nLabel = new System.Windows.Forms.Label();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.pLabel = new System.Windows.Forms.Label();
            this.pTextBox = new System.Windows.Forms.TextBox();
            this.simulateButton = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Server_Label
            // 
            this.nLabel.Font = new System.Drawing.Font("宋体", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nLabel.Location = new System.Drawing.Point(205, 263);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(403, 56);
            this.nLabel.TabIndex = 2;
            this.nLabel.Text = "Servers (n):";
            // 
            // ServersInput
            // 
            this.nTextBox.Location = new System.Drawing.Point(686, 263);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(264, 35);
            this.nTextBox.TabIndex = 3;
            // 
            // Attackers_label
            // 
            this.mLabel.Font = new System.Drawing.Font("宋体", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mLabel.Location = new System.Drawing.Point(201, 377);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(407, 49);
            this.mLabel.TabIndex = 4;
            this.mLabel.Text = "Attackers (m):";
            // 
            // AttackersInput
            // 
            this.mTextBox.Location = new System.Drawing.Point(686, 377);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(258, 35);
            this.mTextBox.TabIndex = 5;
            // 
            // Probability_Label
            // 
            this.pLabel.Font = new System.Drawing.Font("宋体", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pLabel.Location = new System.Drawing.Point(201, 477);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(407, 46);
            this.pLabel.TabIndex = 10;
            this.pLabel.Text = "Probability (p):";
            // 
            // ProbabilityInput
            // 
            this.pTextBox.Location = new System.Drawing.Point(686, 488);
            this.pTextBox.Name = "pTextBox";
            this.pTextBox.Size = new System.Drawing.Size(258, 35);
            this.pTextBox.TabIndex = 7;
            // 
            // simulateButton
            // 
            this.simulateButton.Location = new System.Drawing.Point(910, 730);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(269, 65);
            this.simulateButton.TabIndex = 8;
            this.simulateButton.Text = "click_to_see";
            this.simulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // chart
            // 
            chartArea1.AxisX.Title = "Servers";
            chartArea1.AxisY.Title = "Times_tobe_penetrated";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(2343, 1198);
            this.chart.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2397, 1217);
            this.Controls.Add(this.nLabel);
            this.Controls.Add(this.nTextBox);
            this.Controls.Add(this.mLabel);
            this.Controls.Add(this.mTextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.pTextBox);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "Hacker Simulations";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private Label nLabel;
        private Label mLabel;
        private Label pLabel;
    }
}

