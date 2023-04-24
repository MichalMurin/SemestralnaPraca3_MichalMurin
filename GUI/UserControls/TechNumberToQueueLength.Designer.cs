namespace SemestralnaPraca3_MichalMurin.UserControls
{
    partial class TechNumberToQueueLength
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TechniciansCounterStart = new System.Windows.Forms.NumericUpDown();
            this.mechanicsCounter = new System.Windows.Forms.NumericUpDown();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.replicationCounterForOneRunLbl = new System.Windows.Forms.Label();
            this.TechniciansCounterEnd = new System.Windows.Forms.NumericUpDown();
            this.replicationCounterForOneRun = new System.Windows.Forms.NumericUpDown();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.TechniciansCounterStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mechanicsCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TechniciansCounterEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replicationCounterForOneRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Pocet technikov OD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pocet mechanikov";
            // 
            // TechniciansCounterStart
            // 
            this.TechniciansCounterStart.Location = new System.Drawing.Point(812, 112);
            this.TechniciansCounterStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TechniciansCounterStart.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.TechniciansCounterStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TechniciansCounterStart.Name = "TechniciansCounterStart";
            this.TechniciansCounterStart.Size = new System.Drawing.Size(61, 22);
            this.TechniciansCounterStart.TabIndex = 16;
            this.TechniciansCounterStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mechanicsCounter
            // 
            this.mechanicsCounter.Location = new System.Drawing.Point(506, 112);
            this.mechanicsCounter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mechanicsCounter.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mechanicsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mechanicsCounter.Name = "mechanicsCounter";
            this.mechanicsCounter.Size = new System.Drawing.Size(61, 22);
            this.mechanicsCounter.TabIndex = 15;
            this.mechanicsCounter.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(731, 36);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(131, 48);
            this.StopBtn.TabIndex = 13;
            this.StopBtn.Text = "STOP";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(549, 37);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(131, 46);
            this.StartBtn.TabIndex = 12;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // replicationCounterForOneRunLbl
            // 
            this.replicationCounterForOneRunLbl.AutoSize = true;
            this.replicationCounterForOneRunLbl.Location = new System.Drawing.Point(300, 153);
            this.replicationCounterForOneRunLbl.Name = "replicationCounterForOneRunLbl";
            this.replicationCounterForOneRunLbl.Size = new System.Drawing.Size(186, 16);
            this.replicationCounterForOneRunLbl.TabIndex = 21;
            this.replicationCounterForOneRunLbl.Text = "Pocet replikacii pre jeden bod";
            // 
            // TechniciansCounterEnd
            // 
            this.TechniciansCounterEnd.Location = new System.Drawing.Point(812, 151);
            this.TechniciansCounterEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TechniciansCounterEnd.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.TechniciansCounterEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TechniciansCounterEnd.Name = "TechniciansCounterEnd";
            this.TechniciansCounterEnd.Size = new System.Drawing.Size(61, 22);
            this.TechniciansCounterEnd.TabIndex = 20;
            this.TechniciansCounterEnd.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // replicationCounterForOneRun
            // 
            this.replicationCounterForOneRun.Location = new System.Drawing.Point(506, 151);
            this.replicationCounterForOneRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.replicationCounterForOneRun.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.replicationCounterForOneRun.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.replicationCounterForOneRun.Name = "replicationCounterForOneRun";
            this.replicationCounterForOneRun.Size = new System.Drawing.Size(61, 22);
            this.replicationCounterForOneRun.TabIndex = 19;
            this.replicationCounterForOneRun.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chart1
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.Title = "Pocet technikov";
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.Title = "Priemerny pocet zakaznikov v rade na prijatie";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(62, 194);
            this.chart1.Name = "chart1";
            series1.BackSecondaryColor = System.Drawing.Color.Red;
            series1.BorderColor = System.Drawing.Color.Red;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Pocet zakaznikov v prvej rade";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1006, 501);
            this.chart1.TabIndex = 23;
            this.chart1.Text = "MechanicsChart";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pocet technikov DO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Zavislost priemerneho poctu zakaznikov v rade na prijatie od poctu technikov";
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(1108, 204);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(230, 372);
            this.resultsListBox.TabIndex = 26;
            // 
            // TechNumberToQueueLength
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.replicationCounterForOneRunLbl);
            this.Controls.Add(this.TechniciansCounterEnd);
            this.Controls.Add(this.replicationCounterForOneRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TechniciansCounterStart);
            this.Controls.Add(this.mechanicsCounter);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Name = "TechNumberToQueueLength";
            this.Size = new System.Drawing.Size(1550, 761);
            ((System.ComponentModel.ISupportInitialize)(this.TechniciansCounterStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mechanicsCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TechniciansCounterEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replicationCounterForOneRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TechniciansCounterStart;
        private System.Windows.Forms.NumericUpDown mechanicsCounter;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label replicationCounterForOneRunLbl;
        private System.Windows.Forms.NumericUpDown TechniciansCounterEnd;
        private System.Windows.Forms.NumericUpDown replicationCounterForOneRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox resultsListBox;
    }
}
