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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.label2 = new System.Windows.Forms.Label();
            this.CertificatedRatio = new System.Windows.Forms.NumericUpDown();
            this.NonCertificatedRation = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replicationCounterForOneRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicsCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatedRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonCertificatedRation)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Pocet mechanikov DO";
            // 
            // chart1
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.Title = "Pocet mechanikov";
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.Title = "Priemerny cas zakaznikov v systeme [min]";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(46, 158);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Priemerny cas v systeme";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(754, 407);
            this.chart1.TabIndex = 34;
            this.chart1.Text = "MechanicsChart";
            // 
            // replicationCounterForOneRunLbl
            // 
            this.replicationCounterForOneRunLbl.AutoSize = true;
            this.replicationCounterForOneRunLbl.Location = new System.Drawing.Point(225, 124);
            this.replicationCounterForOneRunLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.replicationCounterForOneRunLbl.Name = "replicationCounterForOneRunLbl";
            this.replicationCounterForOneRunLbl.Size = new System.Drawing.Size(147, 13);
            this.replicationCounterForOneRunLbl.TabIndex = 33;
            this.replicationCounterForOneRunLbl.Text = "Pocet replikacii pre jeden bod";
            // 
            // MechanicsCounterEnd
            // 
            this.MechanicsCounterEnd.Location = new System.Drawing.Point(609, 123);
            this.MechanicsCounterEnd.Margin = new System.Windows.Forms.Padding(2);
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
            this.MechanicsCounterEnd.Size = new System.Drawing.Size(46, 20);
            this.MechanicsCounterEnd.TabIndex = 32;
            this.MechanicsCounterEnd.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // replicationCounterForOneRun
            // 
            this.replicationCounterForOneRun.Location = new System.Drawing.Point(380, 123);
            this.replicationCounterForOneRun.Margin = new System.Windows.Forms.Padding(2);
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
            this.replicationCounterForOneRun.Size = new System.Drawing.Size(46, 20);
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
            this.label4.Location = new System.Drawing.Point(472, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Pocet mechanikov OD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Pocet technikov";
            // 
            // MechanicsCounterStart
            // 
            this.MechanicsCounterStart.Location = new System.Drawing.Point(609, 91);
            this.MechanicsCounterStart.Margin = new System.Windows.Forms.Padding(2);
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
            this.MechanicsCounterStart.Size = new System.Drawing.Size(46, 20);
            this.MechanicsCounterStart.TabIndex = 28;
            this.MechanicsCounterStart.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // technicsCounter
            // 
            this.technicsCounter.Location = new System.Drawing.Point(380, 91);
            this.technicsCounter.Margin = new System.Windows.Forms.Padding(2);
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
            this.technicsCounter.Size = new System.Drawing.Size(46, 20);
            this.technicsCounter.TabIndex = 27;
            this.technicsCounter.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(548, 29);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(98, 39);
            this.StopBtn.TabIndex = 26;
            this.StopBtn.Text = "STOP";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(412, 30);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(98, 37);
            this.StartBtn.TabIndex = 25;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Zavislost priemerneho casu zakaznikov v systeme na pocte mechanikov";
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.Location = new System.Drawing.Point(831, 166);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(174, 303);
            this.resultsListBox.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Certifikovani : Necertifikovani";
            // 
            // CertificatedRatio
            // 
            this.CertificatedRatio.Location = new System.Drawing.Point(716, 122);
            this.CertificatedRatio.Margin = new System.Windows.Forms.Padding(2);
            this.CertificatedRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CertificatedRatio.Name = "CertificatedRatio";
            this.CertificatedRatio.Size = new System.Drawing.Size(46, 20);
            this.CertificatedRatio.TabIndex = 38;
            this.CertificatedRatio.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // NonCertificatedRation
            // 
            this.NonCertificatedRation.Location = new System.Drawing.Point(778, 122);
            this.NonCertificatedRation.Margin = new System.Windows.Forms.Padding(2);
            this.NonCertificatedRation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NonCertificatedRation.Name = "NonCertificatedRation";
            this.NonCertificatedRation.Size = new System.Drawing.Size(46, 20);
            this.NonCertificatedRation.TabIndex = 40;
            this.NonCertificatedRation.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(765, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = ":";
            // 
            // MechanicsToTimeInSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NonCertificatedRation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CertificatedRatio);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MechanicsToTimeInSystem";
            this.Size = new System.Drawing.Size(1076, 622);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replicationCounterForOneRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MechanicsCounterStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.technicsCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatedRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonCertificatedRation)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CertificatedRatio;
        private System.Windows.Forms.NumericUpDown NonCertificatedRation;
        private System.Windows.Forms.Label label6;
    }
}
