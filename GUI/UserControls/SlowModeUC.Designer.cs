namespace SemestralnaPraca3_MichalMurin.UserControls
{
    partial class SlowModeUC
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
            this.RychlostMenic = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SystemTime = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.techniciansCounter = new System.Windows.Forms.NumericUpDown();
            this.CertificatedMechanicCounter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RadaNaPrijatieLbl = new System.Windows.Forms.Label();
            this.RadaNaPlatenieLbl = new System.Windows.Forms.Label();
            this.ZaparkovaneAutaLbl = new System.Windows.Forms.Label();
            this.VolnyParkingLbl = new System.Windows.Forms.Label();
            this.VolniTechniciLbl = new System.Windows.Forms.Label();
            this.VolniMechanicLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.NUmberAllCustomersLbl = new System.Windows.Forms.Label();
            this.CurrentNUmberOfCstomersLbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.AverageTimeInSystemLbl = new System.Windows.Forms.Label();
            this.AverageTWaitingTimeLbl = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.AvgFreeMechanicsLbl = new System.Windows.Forms.Label();
            this.AvgFreeTechniciansLbl = new System.Windows.Forms.Label();
            this.MechanicsListBox = new System.Windows.Forms.ListBox();
            this.CustomersListBox = new System.Windows.Forms.ListBox();
            this.QueueForPaymentListBox = new System.Windows.Forms.ListBox();
            this.QueueForAcceptanceListbox = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.QueueShowCheckbox = new System.Windows.Forms.CheckBox();
            this.TechniciansListBox = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.NonCertificatedMechanicsCounter = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.SalaryLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RychlostMenic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.techniciansCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatedMechanicCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonCertificatedMechanicsCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // RychlostMenic
            // 
            this.RychlostMenic.Location = new System.Drawing.Point(14, 56);
            this.RychlostMenic.Margin = new System.Windows.Forms.Padding(2);
            this.RychlostMenic.Maximum = 500;
            this.RychlostMenic.Minimum = 1;
            this.RychlostMenic.Name = "RychlostMenic";
            this.RychlostMenic.Size = new System.Drawing.Size(355, 45);
            this.RychlostMenic.TabIndex = 0;
            this.RychlostMenic.Value = 400;
            this.RychlostMenic.Scroll += new System.EventHandler(this.RychlostMenic_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nastav rychlost simulacie";
            // 
            // SystemTime
            // 
            this.SystemTime.AutoSize = true;
            this.SystemTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemTime.Location = new System.Drawing.Point(126, 95);
            this.SystemTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SystemTime.Name = "SystemTime";
            this.SystemTime.Size = new System.Drawing.Size(16, 24);
            this.SystemTime.TabIndex = 2;
            this.SystemTime.Text = "-";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(392, 16);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(98, 37);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "START";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(621, 17);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(98, 39);
            this.StopBtn.TabIndex = 4;
            this.StopBtn.Text = "STOP";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Systemovy cas";
            // 
            // PauseBtn
            // 
            this.PauseBtn.Location = new System.Drawing.Point(508, 17);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(98, 39);
            this.PauseBtn.TabIndex = 7;
            this.PauseBtn.Text = "PAUSE";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // techniciansCounter
            // 
            this.techniciansCounter.Location = new System.Drawing.Point(495, 76);
            this.techniciansCounter.Margin = new System.Windows.Forms.Padding(2);
            this.techniciansCounter.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.techniciansCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.techniciansCounter.Name = "techniciansCounter";
            this.techniciansCounter.Size = new System.Drawing.Size(46, 20);
            this.techniciansCounter.TabIndex = 8;
            this.techniciansCounter.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CertificatedMechanicCounter
            // 
            this.CertificatedMechanicCounter.Location = new System.Drawing.Point(754, 76);
            this.CertificatedMechanicCounter.Margin = new System.Windows.Forms.Padding(2);
            this.CertificatedMechanicCounter.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.CertificatedMechanicCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CertificatedMechanicCounter.Name = "CertificatedMechanicCounter";
            this.CertificatedMechanicCounter.Size = new System.Drawing.Size(46, 20);
            this.CertificatedMechanicCounter.TabIndex = 9;
            this.CertificatedMechanicCounter.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pocet technikov";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pocet certifikovanych mechanikov";
            // 
            // RadaNaPrijatieLbl
            // 
            this.RadaNaPrijatieLbl.AutoSize = true;
            this.RadaNaPrijatieLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadaNaPrijatieLbl.Location = new System.Drawing.Point(126, 121);
            this.RadaNaPrijatieLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RadaNaPrijatieLbl.Name = "RadaNaPrijatieLbl";
            this.RadaNaPrijatieLbl.Size = new System.Drawing.Size(16, 24);
            this.RadaNaPrijatieLbl.TabIndex = 13;
            this.RadaNaPrijatieLbl.Text = "-";
            // 
            // RadaNaPlatenieLbl
            // 
            this.RadaNaPlatenieLbl.AutoSize = true;
            this.RadaNaPlatenieLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadaNaPlatenieLbl.Location = new System.Drawing.Point(126, 144);
            this.RadaNaPlatenieLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RadaNaPlatenieLbl.Name = "RadaNaPlatenieLbl";
            this.RadaNaPlatenieLbl.Size = new System.Drawing.Size(16, 24);
            this.RadaNaPlatenieLbl.TabIndex = 14;
            this.RadaNaPlatenieLbl.Text = "-";
            // 
            // ZaparkovaneAutaLbl
            // 
            this.ZaparkovaneAutaLbl.AutoSize = true;
            this.ZaparkovaneAutaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZaparkovaneAutaLbl.Location = new System.Drawing.Point(126, 168);
            this.ZaparkovaneAutaLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZaparkovaneAutaLbl.Name = "ZaparkovaneAutaLbl";
            this.ZaparkovaneAutaLbl.Size = new System.Drawing.Size(16, 24);
            this.ZaparkovaneAutaLbl.TabIndex = 15;
            this.ZaparkovaneAutaLbl.Text = "-";
            // 
            // VolnyParkingLbl
            // 
            this.VolnyParkingLbl.AutoSize = true;
            this.VolnyParkingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolnyParkingLbl.Location = new System.Drawing.Point(126, 192);
            this.VolnyParkingLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VolnyParkingLbl.Name = "VolnyParkingLbl";
            this.VolnyParkingLbl.Size = new System.Drawing.Size(16, 24);
            this.VolnyParkingLbl.TabIndex = 16;
            this.VolnyParkingLbl.Text = "-";
            // 
            // VolniTechniciLbl
            // 
            this.VolniTechniciLbl.AutoSize = true;
            this.VolniTechniciLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolniTechniciLbl.Location = new System.Drawing.Point(126, 215);
            this.VolniTechniciLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VolniTechniciLbl.Name = "VolniTechniciLbl";
            this.VolniTechniciLbl.Size = new System.Drawing.Size(16, 24);
            this.VolniTechniciLbl.TabIndex = 17;
            this.VolniTechniciLbl.Text = "-";
            // 
            // VolniMechanicLbl
            // 
            this.VolniMechanicLbl.AutoSize = true;
            this.VolniMechanicLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VolniMechanicLbl.Location = new System.Drawing.Point(126, 239);
            this.VolniMechanicLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VolniMechanicLbl.Name = "VolniMechanicLbl";
            this.VolniMechanicLbl.Size = new System.Drawing.Size(16, 24);
            this.VolniMechanicLbl.TabIndex = 18;
            this.VolniMechanicLbl.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Rad na prijatie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Rad na platenie";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 179);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Zaparkovane auta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 202);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Volne miesta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 226);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Volni technici";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 247);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Volni mechanici";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 294);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Celkovy pocet zakaznikov ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 271);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Pocet aktualnych zakaznikov";
            // 
            // NUmberAllCustomersLbl
            // 
            this.NUmberAllCustomersLbl.AutoSize = true;
            this.NUmberAllCustomersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUmberAllCustomersLbl.Location = new System.Drawing.Point(178, 287);
            this.NUmberAllCustomersLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NUmberAllCustomersLbl.Name = "NUmberAllCustomersLbl";
            this.NUmberAllCustomersLbl.Size = new System.Drawing.Size(16, 24);
            this.NUmberAllCustomersLbl.TabIndex = 26;
            this.NUmberAllCustomersLbl.Text = "-";
            // 
            // CurrentNUmberOfCstomersLbl
            // 
            this.CurrentNUmberOfCstomersLbl.AutoSize = true;
            this.CurrentNUmberOfCstomersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentNUmberOfCstomersLbl.Location = new System.Drawing.Point(178, 263);
            this.CurrentNUmberOfCstomersLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentNUmberOfCstomersLbl.Name = "CurrentNUmberOfCstomersLbl";
            this.CurrentNUmberOfCstomersLbl.Size = new System.Drawing.Size(16, 24);
            this.CurrentNUmberOfCstomersLbl.TabIndex = 25;
            this.CurrentNUmberOfCstomersLbl.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 343);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Priemerny cas v systeme [min]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 319);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(157, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Priemerny cas v prvej rade [min]";
            // 
            // AverageTimeInSystemLbl
            // 
            this.AverageTimeInSystemLbl.AutoSize = true;
            this.AverageTimeInSystemLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageTimeInSystemLbl.Location = new System.Drawing.Point(179, 335);
            this.AverageTimeInSystemLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageTimeInSystemLbl.Name = "AverageTimeInSystemLbl";
            this.AverageTimeInSystemLbl.Size = new System.Drawing.Size(16, 24);
            this.AverageTimeInSystemLbl.TabIndex = 30;
            this.AverageTimeInSystemLbl.Text = "-";
            // 
            // AverageTWaitingTimeLbl
            // 
            this.AverageTWaitingTimeLbl.AutoSize = true;
            this.AverageTWaitingTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AverageTWaitingTimeLbl.Location = new System.Drawing.Point(179, 312);
            this.AverageTWaitingTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AverageTWaitingTimeLbl.Name = "AverageTWaitingTimeLbl";
            this.AverageTWaitingTimeLbl.Size = new System.Drawing.Size(16, 24);
            this.AverageTWaitingTimeLbl.TabIndex = 29;
            this.AverageTWaitingTimeLbl.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 393);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Priemerny pocet volnych mechanikov";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 369);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(173, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Priemerny pocet volnych technikov";
            // 
            // AvgFreeMechanicsLbl
            // 
            this.AvgFreeMechanicsLbl.AutoSize = true;
            this.AvgFreeMechanicsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgFreeMechanicsLbl.Location = new System.Drawing.Point(211, 386);
            this.AvgFreeMechanicsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvgFreeMechanicsLbl.Name = "AvgFreeMechanicsLbl";
            this.AvgFreeMechanicsLbl.Size = new System.Drawing.Size(16, 24);
            this.AvgFreeMechanicsLbl.TabIndex = 34;
            this.AvgFreeMechanicsLbl.Text = "-";
            // 
            // AvgFreeTechniciansLbl
            // 
            this.AvgFreeTechniciansLbl.AutoSize = true;
            this.AvgFreeTechniciansLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgFreeTechniciansLbl.Location = new System.Drawing.Point(211, 362);
            this.AvgFreeTechniciansLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvgFreeTechniciansLbl.Name = "AvgFreeTechniciansLbl";
            this.AvgFreeTechniciansLbl.Size = new System.Drawing.Size(16, 24);
            this.AvgFreeTechniciansLbl.TabIndex = 33;
            this.AvgFreeTechniciansLbl.Text = "-";
            // 
            // MechanicsListBox
            // 
            this.MechanicsListBox.DataSource = this.CustomersListBox.CustomTabOffsets;
            this.MechanicsListBox.FormattingEnabled = true;
            this.MechanicsListBox.Location = new System.Drawing.Point(436, 177);
            this.MechanicsListBox.Name = "MechanicsListBox";
            this.MechanicsListBox.Size = new System.Drawing.Size(305, 95);
            this.MechanicsListBox.TabIndex = 37;
            // 
            // CustomersListBox
            // 
            this.CustomersListBox.FormattingEnabled = true;
            this.CustomersListBox.Location = new System.Drawing.Point(436, 404);
            this.CustomersListBox.Name = "CustomersListBox";
            this.CustomersListBox.Size = new System.Drawing.Size(305, 186);
            this.CustomersListBox.TabIndex = 38;
            // 
            // QueueForPaymentListBox
            // 
            this.QueueForPaymentListBox.FormattingEnabled = true;
            this.QueueForPaymentListBox.Location = new System.Drawing.Point(754, 404);
            this.QueueForPaymentListBox.Name = "QueueForPaymentListBox";
            this.QueueForPaymentListBox.Size = new System.Drawing.Size(284, 186);
            this.QueueForPaymentListBox.TabIndex = 40;
            // 
            // QueueForAcceptanceListbox
            // 
            this.QueueForAcceptanceListbox.DataSource = this.QueueForPaymentListBox.CustomTabOffsets;
            this.QueueForAcceptanceListbox.FormattingEnabled = true;
            this.QueueForAcceptanceListbox.Location = new System.Drawing.Point(754, 177);
            this.QueueForAcceptanceListbox.Name = "QueueForAcceptanceListbox";
            this.QueueForAcceptanceListbox.Size = new System.Drawing.Size(284, 199);
            this.QueueForAcceptanceListbox.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(434, 163);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Pracovnici:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(434, 388);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Zakaznici:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(752, 163);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 13);
            this.label19.TabIndex = 43;
            this.label19.Text = "Rad na prijatie auta:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(752, 384);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 13);
            this.label20.TabIndex = 44;
            this.label20.Text = "Rad na zaplatenie:";
            // 
            // QueueShowCheckbox
            // 
            this.QueueShowCheckbox.AutoSize = true;
            this.QueueShowCheckbox.Location = new System.Drawing.Point(754, 137);
            this.QueueShowCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.QueueShowCheckbox.Name = "QueueShowCheckbox";
            this.QueueShowCheckbox.Size = new System.Drawing.Size(133, 17);
            this.QueueShowCheckbox.TabIndex = 45;
            this.QueueShowCheckbox.Text = "Zobrazovat stav radov";
            this.QueueShowCheckbox.UseVisualStyleBackColor = true;
            this.QueueShowCheckbox.CheckedChanged += new System.EventHandler(this.QueueShowCheckbox_CheckedChanged);
            // 
            // TechniciansListBox
            // 
            this.TechniciansListBox.DataSource = this.CustomersListBox.CustomTabOffsets;
            this.TechniciansListBox.FormattingEnabled = true;
            this.TechniciansListBox.Location = new System.Drawing.Point(436, 281);
            this.TechniciansListBox.Name = "TechniciansListBox";
            this.TechniciansListBox.Size = new System.Drawing.Size(305, 95);
            this.TechniciansListBox.TabIndex = 46;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(560, 106);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(183, 13);
            this.label21.TabIndex = 48;
            this.label21.Text = "Pocet necertifikovanych mechanikov";
            // 
            // NonCertificatedMechanicsCounter
            // 
            this.NonCertificatedMechanicsCounter.Location = new System.Drawing.Point(754, 101);
            this.NonCertificatedMechanicsCounter.Margin = new System.Windows.Forms.Padding(2);
            this.NonCertificatedMechanicsCounter.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.NonCertificatedMechanicsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NonCertificatedMechanicsCounter.Name = "NonCertificatedMechanicsCounter";
            this.NonCertificatedMechanicsCounter.Size = new System.Drawing.Size(46, 20);
            this.NonCertificatedMechanicsCounter.TabIndex = 47;
            this.NonCertificatedMechanicsCounter.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 419);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 13);
            this.label22.TabIndex = 50;
            this.label22.Text = "Mzdove naklady";
            // 
            // SalaryLbl
            // 
            this.SalaryLbl.AutoSize = true;
            this.SalaryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryLbl.Location = new System.Drawing.Point(125, 411);
            this.SalaryLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SalaryLbl.Name = "SalaryLbl";
            this.SalaryLbl.Size = new System.Drawing.Size(16, 24);
            this.SalaryLbl.TabIndex = 49;
            this.SalaryLbl.Text = "-";
            // 
            // SlowModeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label22);
            this.Controls.Add(this.SalaryLbl);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.NonCertificatedMechanicsCounter);
            this.Controls.Add(this.TechniciansListBox);
            this.Controls.Add(this.QueueShowCheckbox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.QueueForPaymentListBox);
            this.Controls.Add(this.QueueForAcceptanceListbox);
            this.Controls.Add(this.CustomersListBox);
            this.Controls.Add(this.MechanicsListBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.AvgFreeMechanicsLbl);
            this.Controls.Add(this.AvgFreeTechniciansLbl);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.AverageTimeInSystemLbl);
            this.Controls.Add(this.AverageTWaitingTimeLbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.NUmberAllCustomersLbl);
            this.Controls.Add(this.CurrentNUmberOfCstomersLbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VolniMechanicLbl);
            this.Controls.Add(this.VolniTechniciLbl);
            this.Controls.Add(this.VolnyParkingLbl);
            this.Controls.Add(this.ZaparkovaneAutaLbl);
            this.Controls.Add(this.RadaNaPlatenieLbl);
            this.Controls.Add(this.RadaNaPrijatieLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CertificatedMechanicCounter);
            this.Controls.Add(this.techniciansCounter);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.SystemTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RychlostMenic);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SlowModeUC";
            this.Size = new System.Drawing.Size(1163, 653);
            ((System.ComponentModel.ISupportInitialize)(this.RychlostMenic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.techniciansCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CertificatedMechanicCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonCertificatedMechanicsCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar RychlostMenic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SystemTime;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.NumericUpDown techniciansCounter;
        private System.Windows.Forms.NumericUpDown CertificatedMechanicCounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RadaNaPrijatieLbl;
        private System.Windows.Forms.Label RadaNaPlatenieLbl;
        private System.Windows.Forms.Label ZaparkovaneAutaLbl;
        private System.Windows.Forms.Label VolnyParkingLbl;
        private System.Windows.Forms.Label VolniTechniciLbl;
        private System.Windows.Forms.Label VolniMechanicLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label NUmberAllCustomersLbl;
        private System.Windows.Forms.Label CurrentNUmberOfCstomersLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label AverageTimeInSystemLbl;
        private System.Windows.Forms.Label AverageTWaitingTimeLbl;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label AvgFreeMechanicsLbl;
        private System.Windows.Forms.Label AvgFreeTechniciansLbl;
        private System.Windows.Forms.ListBox MechanicsListBox;
        private System.Windows.Forms.ListBox CustomersListBox;
        private System.Windows.Forms.ListBox QueueForPaymentListBox;
        private System.Windows.Forms.ListBox QueueForAcceptanceListbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox QueueShowCheckbox;
        private System.Windows.Forms.ListBox TechniciansListBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown NonCertificatedMechanicsCounter;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label SalaryLbl;
    }
}
