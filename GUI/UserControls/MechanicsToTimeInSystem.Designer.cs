namespace SemestralnaPraca3_MichalMurin.UserControls
{
    partial class MechanicsToTimeInSystem
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.replicationCounterForOneRunLbl = new System.Windows.Forms.Label();
            this.MechanicsCounterEnd = new System.Windows.Forms.NumericUpDown();
            this.replicationCounterForOneRun = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MechanicsCounterStart = new System.Windows.Forms.NumericUpDown();
            this.technicsCounter = new System.Windows.Forms.NumericUpDown();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replicationCounterForOneRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicsCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Pocet mechanikov DO";
            // 
            // chart1
            // 
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.Title = "Pocet mechanikov";
            chartArea2.AxisY.IsMarginVisible = false;
            chartArea2.AxisY.Title = "Priemerny cas zakaznikov v systeme [min]";
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(62, 194);
            this.chart1.Name = "chart1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Priemerny cas v systeme";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1006, 501);
            this.chart1.TabIndex = 34;
            this.chart1.Text = "MechanicsChart";
            // 
            // replicationCounterForOneRunLbl
            // 
            this.replicationCounterForOneRunLbl.AutoSize = true;
            this.replicationCounterForOneRunLbl.Location = new System.Drawing.Point(300, 153);
            this.replicationCounterForOneRunLbl.Name = "replicationCounterForOneRunLbl";
            this.replicationCounterForOneRunLbl.Size = new System.Drawing.Size(186, 16);
            this.replicationCounterForOneRunLbl.TabIndex = 33;
            this.replicationCounterForOneRunLbl.Text = "Pocet replikacii pre jeden bod";
            // 
            // MechanicsCounterEnd
            // 
            this.MechanicsCounterEnd.Location = new System.Drawing.Point(812, 151);
            this.MechanicsCounterEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MechanicsCounterEnd.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.MechanicsCounterEnd.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MechanicsCounterEnd.Name = "MechanicsCounterEnd";
            this.MechanicsCounterEnd.Size = new System.Drawing.Size(61, 22);
            this.MechanicsCounterEnd.TabIndex = 32;
            this.MechanicsCounterEnd.Value = new decimal(new int[] {
            25,
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
            this.replicationCounterForOneRun.TabIndex = 31;
            this.replicationCounterForOneRun.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Pocet mechanikov OD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Pocet technikov";
            // 
            // MechanicsCounterStart
            // 
            this.MechanicsCounterStart.Location = new System.Drawing.Point(812, 112);
            this.MechanicsCounterStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MechanicsCounterStart.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.MechanicsCounterStart.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MechanicsCounterStart.Name = "MechanicsCounterStart";
            this.MechanicsCounterStart.Size = new System.Drawing.Size(61, 22);
            this.MechanicsCounterStart.TabIndex = 28;
            this.MechanicsCounterStart.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // technicsCounter
            // 
            this.technicsCounter.Location = new System.Drawing.Point(506, 112);
            this.technicsCounter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.technicsCounter.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.technicsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.technicsCounter.Name = "technicsCounter";
            this.technicsCounter.Size = new System.Drawing.Size(61, 22);
            this.technicsCounter.TabIndex = 27;
            this.technicsCounter.Value = new decimal(new int[] {
            4,
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
            this.StopBtn.TabIndex = 26;
            this.StopBtn.Text = "STOP";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(549, 37);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(131, 46);
            this.StartBtn.TabIndex = 25;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Zavislost priemerneho casu zakaznikov v systeme na pocte mechanikov";
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(1108, 204);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(230, 372);
            this.resultsListBox.TabIndex = 37;
            // 
            // MechanicsToTimeInSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.replicationCounterForOneRunLbl);
            this.Controls.Add(this.MechanicsCounterEnd);
            this.Controls.Add(this.replicationCounterForOneRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MechanicsCounterStart);
            this.Controls.Add(this.technicsCounter);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Name = "MechanicsToTimeInSystem";
            this.Size = new System.Drawing.Size(1435, 765);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replicationCounterForOneRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicsCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label replicationCounterForOneRunLbl;
        private System.Windows.Forms.NumericUpDown MechanicsCounterEnd;
        private System.Windows.Forms.NumericUpDown replicationCounterForOneRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MechanicsCounterStart;
        private System.Windows.Forms.NumericUpDown technicsCounter;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox resultsListBox;
    }
}
