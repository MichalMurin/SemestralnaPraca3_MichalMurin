namespace SemestralnaPraca3_MichalMurin.UserControls
{
    partial class FastModeUC
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
            this.replicationsNumpad = new System.Windows.Forms.NumericUpDown();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AverageWaitingTimeLbl = new System.Windows.Forms.Label();
            this.AverageTimeInSystemLbl = new System.Windows.Forms.Label();
            this.AverageCustomersNumAtEndDayLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CertificatedMechanicsNumPad = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.TechnicianNumPad = new System.Windows.Forms.NumericUpDown();
            this.FreeMechanicsLbl = new System.Windows.Forms.Label();
            this.FreeTechniciansLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AverageNumberOfCustomersInFirstQueueLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AvgNumberOfCustomersInSystem = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ConfidenceIntervalTimeInSystemLbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.CurrentReplicationLbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NonCertificatedMechanicsNumPad = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.MzdoveNakladyLbl = new System.Windows.Forms.Label();
            this.saveCsvBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.replicationsNumpad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatedMechanicsNumPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TechnicianNumPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonCertificatedMechanicsNumPad)).BeginInit();
            this.SuspendLayout();
            // 
            // replicationsNumpad
            // 
            this.replicationsNumpad.Location = new System.Drawing.Point(160, 20);
            this.replicationsNumpad.Margin = new System.Windows.Forms.Padding(2);
            this.replicationsNumpad.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.replicationsNumpad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.replicationsNumpad.Name = "replicationsNumpad";
            this.replicationsNumpad.Size = new System.Drawing.Size(94, 20);
            this.replicationsNumpad.TabIndex = 0;
            this.replicationsNumpad.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(298, 20);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(74, 38);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pocet replikacii";
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(389, 20);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(74, 38);
            this.StopBtn.TabIndex = 5;
            this.StopBtn.Text = "STOP";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Priemerna doba cakania [min]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Priemerny cas v systeme [min]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Priemerny pocet zakaznikov na konci dna";
            // 
            // AverageWaitingTimeLbl
            // 
            this.AverageWaitingTimeLbl.AutoSize = true;
            this.AverageWaitingTimeLbl.Location = new System.Drawing.Point(238, 89);
            this.AverageWaitingTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageWaitingTimeLbl.Name = "AverageWaitingTimeLbl";
            this.AverageWaitingTimeLbl.Size = new System.Drawing.Size(10, 13);
            this.AverageWaitingTimeLbl.TabIndex = 9;
            this.AverageWaitingTimeLbl.Text = "-";
            // 
            // AverageTimeInSystemLbl
            // 
            this.AverageTimeInSystemLbl.AutoSize = true;
            this.AverageTimeInSystemLbl.Location = new System.Drawing.Point(238, 150);
            this.AverageTimeInSystemLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageTimeInSystemLbl.Name = "AverageTimeInSystemLbl";
            this.AverageTimeInSystemLbl.Size = new System.Drawing.Size(10, 13);
            this.AverageTimeInSystemLbl.TabIndex = 10;
            this.AverageTimeInSystemLbl.Text = "-";
            // 
            // AverageCustomersNumAtEndDayLbl
            // 
            this.AverageCustomersNumAtEndDayLbl.AutoSize = true;
            this.AverageCustomersNumAtEndDayLbl.Location = new System.Drawing.Point(238, 256);
            this.AverageCustomersNumAtEndDayLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageCustomersNumAtEndDayLbl.Name = "AverageCustomersNumAtEndDayLbl";
            this.AverageCustomersNumAtEndDayLbl.Size = new System.Drawing.Size(10, 13);
            this.AverageCustomersNumAtEndDayLbl.TabIndex = 11;
            this.AverageCustomersNumAtEndDayLbl.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pocet certifikovanych mechanikov";
            // 
            // CertificatedMechanicsNumPad
            // 
            this.CertificatedMechanicsNumPad.Location = new System.Drawing.Point(703, 64);
            this.CertificatedMechanicsNumPad.Margin = new System.Windows.Forms.Padding(2);
            this.CertificatedMechanicsNumPad.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.CertificatedMechanicsNumPad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CertificatedMechanicsNumPad.Name = "CertificatedMechanicsNumPad";
            this.CertificatedMechanicsNumPad.Size = new System.Drawing.Size(94, 20);
            this.CertificatedMechanicsNumPad.TabIndex = 12;
            this.CertificatedMechanicsNumPad.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Pocet technikov";
            // 
            // TechnicianNumPad
            // 
            this.TechnicianNumPad.Location = new System.Drawing.Point(603, 27);
            this.TechnicianNumPad.Margin = new System.Windows.Forms.Padding(2);
            this.TechnicianNumPad.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.TechnicianNumPad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TechnicianNumPad.Name = "TechnicianNumPad";
            this.TechnicianNumPad.Size = new System.Drawing.Size(94, 20);
            this.TechnicianNumPad.TabIndex = 14;
            this.TechnicianNumPad.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // FreeMechanicsLbl
            // 
            this.FreeMechanicsLbl.AutoSize = true;
            this.FreeMechanicsLbl.Location = new System.Drawing.Point(238, 314);
            this.FreeMechanicsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FreeMechanicsLbl.Name = "FreeMechanicsLbl";
            this.FreeMechanicsLbl.Size = new System.Drawing.Size(10, 13);
            this.FreeMechanicsLbl.TabIndex = 19;
            this.FreeMechanicsLbl.Text = "-";
            // 
            // FreeTechniciansLbl
            // 
            this.FreeTechniciansLbl.AutoSize = true;
            this.FreeTechniciansLbl.Location = new System.Drawing.Point(238, 285);
            this.FreeTechniciansLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FreeTechniciansLbl.Name = "FreeTechniciansLbl";
            this.FreeTechniciansLbl.Size = new System.Drawing.Size(10, 13);
            this.FreeTechniciansLbl.TabIndex = 18;
            this.FreeTechniciansLbl.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 314);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Priemerny pocet volnych mechanikov";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 285);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Priemerny pocet volnych technikov";
            // 
            // AverageNumberOfCustomersInFirstQueueLbl
            // 
            this.AverageNumberOfCustomersInFirstQueueLbl.AutoSize = true;
            this.AverageNumberOfCustomersInFirstQueueLbl.Location = new System.Drawing.Point(238, 119);
            this.AverageNumberOfCustomersInFirstQueueLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageNumberOfCustomersInFirstQueueLbl.Name = "AverageNumberOfCustomersInFirstQueueLbl";
            this.AverageNumberOfCustomersInFirstQueueLbl.Size = new System.Drawing.Size(10, 13);
            this.AverageNumberOfCustomersInFirstQueueLbl.TabIndex = 21;
            this.AverageNumberOfCustomersInFirstQueueLbl.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 119);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Priemerny pocet ludi v rade na prijatie";
            // 
            // AvgNumberOfCustomersInSystem
            // 
            this.AvgNumberOfCustomersInSystem.AutoSize = true;
            this.AvgNumberOfCustomersInSystem.Location = new System.Drawing.Point(238, 203);
            this.AvgNumberOfCustomersInSystem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvgNumberOfCustomersInSystem.Name = "AvgNumberOfCustomersInSystem";
            this.AvgNumberOfCustomersInSystem.Size = new System.Drawing.Size(10, 13);
            this.AvgNumberOfCustomersInSystem.TabIndex = 23;
            this.AvgNumberOfCustomersInSystem.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 203);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Priemerny pocet zakaznikov v systeme";
            // 
            // ConfidenceIntervalTimeInSystemLbl
            // 
            this.ConfidenceIntervalTimeInSystemLbl.AutoSize = true;
            this.ConfidenceIntervalTimeInSystemLbl.Location = new System.Drawing.Point(238, 178);
            this.ConfidenceIntervalTimeInSystemLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConfidenceIntervalTimeInSystemLbl.Name = "ConfidenceIntervalTimeInSystemLbl";
            this.ConfidenceIntervalTimeInSystemLbl.Size = new System.Drawing.Size(10, 13);
            this.ConfidenceIntervalTimeInSystemLbl.TabIndex = 25;
            this.ConfidenceIntervalTimeInSystemLbl.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 178);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "90% Interval spolahlivosti";
            // 
            // ConfidenceIntervalNumberOfCustomersInSystemLbl
            // 
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.AutoSize = true;
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.Location = new System.Drawing.Point(238, 232);
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.Name = "ConfidenceIntervalNumberOfCustomersInSystemLbl";
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.Size = new System.Drawing.Size(10, 13);
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.TabIndex = 27;
            this.ConfidenceIntervalNumberOfCustomersInSystemLbl.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 232);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "95% Interval spolahlivosti";
            // 
            // CurrentReplicationLbl
            // 
            this.CurrentReplicationLbl.AutoSize = true;
            this.CurrentReplicationLbl.Location = new System.Drawing.Point(629, 178);
            this.CurrentReplicationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentReplicationLbl.Name = "CurrentReplicationLbl";
            this.CurrentReplicationLbl.Size = new System.Drawing.Size(10, 13);
            this.CurrentReplicationLbl.TabIndex = 29;
            this.CurrentReplicationLbl.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(504, 178);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Aktualna repliakcia:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(504, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Pocet necertifikovanych mechanikov";
            // 
            // NonCertificatedMechanicsNumPad
            // 
            this.NonCertificatedMechanicsNumPad.Location = new System.Drawing.Point(703, 98);
            this.NonCertificatedMechanicsNumPad.Margin = new System.Windows.Forms.Padding(2);
            this.NonCertificatedMechanicsNumPad.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.NonCertificatedMechanicsNumPad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NonCertificatedMechanicsNumPad.Name = "NonCertificatedMechanicsNumPad";
            this.NonCertificatedMechanicsNumPad.Size = new System.Drawing.Size(94, 20);
            this.NonCertificatedMechanicsNumPad.TabIndex = 30;
            this.NonCertificatedMechanicsNumPad.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(504, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Mzdove naklady";
            // 
            // MzdoveNakladyLbl
            // 
            this.MzdoveNakladyLbl.AutoSize = true;
            this.MzdoveNakladyLbl.Location = new System.Drawing.Point(629, 134);
            this.MzdoveNakladyLbl.Name = "MzdoveNakladyLbl";
            this.MzdoveNakladyLbl.Size = new System.Drawing.Size(10, 13);
            this.MzdoveNakladyLbl.TabIndex = 33;
            this.MzdoveNakladyLbl.Text = "-";
            // 
            // saveCsvBtn
            // 
            this.saveCsvBtn.Location = new System.Drawing.Point(24, 354);
            this.saveCsvBtn.Name = "saveCsvBtn";
            this.saveCsvBtn.Size = new System.Drawing.Size(223, 28);
            this.saveCsvBtn.TabIndex = 34;
            this.saveCsvBtn.Text = "SAVE CSV";
            this.saveCsvBtn.UseVisualStyleBackColor = true;
            this.saveCsvBtn.Click += new System.EventHandler(this.saveCsvBtn_Click);
            // 
            // FastModeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveCsvBtn);
            this.Controls.Add(this.MzdoveNakladyLbl);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NonCertificatedMechanicsNumPad);
            this.Controls.Add(this.CurrentReplicationLbl);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ConfidenceIntervalNumberOfCustomersInSystemLbl);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ConfidenceIntervalTimeInSystemLbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AvgNumberOfCustomersInSystem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AverageNumberOfCustomersInFirstQueueLbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FreeMechanicsLbl);
            this.Controls.Add(this.FreeTechniciansLbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TechnicianNumPad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CertificatedMechanicsNumPad);
            this.Controls.Add(this.AverageCustomersNumAtEndDayLbl);
            this.Controls.Add(this.AverageTimeInSystemLbl);
            this.Controls.Add(this.AverageWaitingTimeLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.replicationsNumpad);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FastModeUC";
            this.Size = new System.Drawing.Size(943, 718);
            ((System.ComponentModel.ISupportInitialize)(this.replicationsNumpad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatedMechanicsNumPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TechnicianNumPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonCertificatedMechanicsNumPad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown replicationsNumpad;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AverageWaitingTimeLbl;
        private System.Windows.Forms.Label AverageTimeInSystemLbl;
        private System.Windows.Forms.Label AverageCustomersNumAtEndDayLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown CertificatedMechanicsNumPad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TechnicianNumPad;
        private System.Windows.Forms.Label FreeMechanicsLbl;
        private System.Windows.Forms.Label FreeTechniciansLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label AverageNumberOfCustomersInFirstQueueLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label AvgNumberOfCustomersInSystem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label ConfidenceIntervalTimeInSystemLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label ConfidenceIntervalNumberOfCustomersInSystemLbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label CurrentReplicationLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NonCertificatedMechanicsNumPad;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label MzdoveNakladyLbl;
        private System.Windows.Forms.Button saveCsvBtn;
    }
}
