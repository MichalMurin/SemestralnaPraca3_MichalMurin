namespace SemestralnaPraca3_MichalMurin
{
    partial class STKAgentGUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ValidationCheckBox = new System.Windows.Forms.CheckBox();
            this.GrafTechiciBtn = new System.Windows.Forms.Button();
            this.MechanicsChartTabBtn = new System.Windows.Forms.Button();
            this.FixedSeedCheckbox = new System.Windows.Forms.CheckBox();
            this.FastModeBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.CustomersFlowNumPad = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersFlowNumPad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.header);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1481, 63);
            this.panel1.TabIndex = 0;
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.header.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.Color.White;
            this.header.Location = new System.Drawing.Point(431, 4);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(526, 56);
            this.header.TabIndex = 2;
            this.header.Text = "STK - Agent Simulation";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CustomersFlowNumPad);
            this.panel2.Controls.Add(this.ValidationCheckBox);
            this.panel2.Controls.Add(this.GrafTechiciBtn);
            this.panel2.Controls.Add(this.MechanicsChartTabBtn);
            this.panel2.Controls.Add(this.FixedSeedCheckbox);
            this.panel2.Controls.Add(this.FastModeBtn);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1481, 75);
            this.panel2.TabIndex = 1;
            // 
            // ValidationCheckBox
            // 
            this.ValidationCheckBox.AutoSize = true;
            this.ValidationCheckBox.BackColor = System.Drawing.Color.White;
            this.ValidationCheckBox.Location = new System.Drawing.Point(683, 28);
            this.ValidationCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ValidationCheckBox.Name = "ValidationCheckBox";
            this.ValidationCheckBox.Size = new System.Drawing.Size(108, 20);
            this.ValidationCheckBox.TabIndex = 5;
            this.ValidationCheckBox.Text = "VALIDATION";
            this.ValidationCheckBox.UseVisualStyleBackColor = false;
            this.ValidationCheckBox.CheckedChanged += new System.EventHandler(this.ValidationCheckBox_CheckedChanged);
            // 
            // GrafTechiciBtn
            // 
            this.GrafTechiciBtn.Location = new System.Drawing.Point(480, 0);
            this.GrafTechiciBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GrafTechiciBtn.Name = "GrafTechiciBtn";
            this.GrafTechiciBtn.Size = new System.Drawing.Size(164, 75);
            this.GrafTechiciBtn.TabIndex = 4;
            this.GrafTechiciBtn.Text = "GRAF 2";
            this.GrafTechiciBtn.UseVisualStyleBackColor = true;
            this.GrafTechiciBtn.Click += new System.EventHandler(this.TechniciansChartTabBtn_Click);
            // 
            // MechanicsChartTabBtn
            // 
            this.MechanicsChartTabBtn.Location = new System.Drawing.Point(320, 0);
            this.MechanicsChartTabBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MechanicsChartTabBtn.Name = "MechanicsChartTabBtn";
            this.MechanicsChartTabBtn.Size = new System.Drawing.Size(164, 75);
            this.MechanicsChartTabBtn.TabIndex = 3;
            this.MechanicsChartTabBtn.Text = "GRAF 1";
            this.MechanicsChartTabBtn.UseVisualStyleBackColor = true;
            this.MechanicsChartTabBtn.Click += new System.EventHandler(this.MechanicsChartTabBtn_Click);
            // 
            // FixedSeedCheckbox
            // 
            this.FixedSeedCheckbox.AutoSize = true;
            this.FixedSeedCheckbox.BackColor = System.Drawing.Color.White;
            this.FixedSeedCheckbox.Location = new System.Drawing.Point(808, 28);
            this.FixedSeedCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FixedSeedCheckbox.Name = "FixedSeedCheckbox";
            this.FixedSeedCheckbox.Size = new System.Drawing.Size(107, 20);
            this.FixedSeedCheckbox.TabIndex = 2;
            this.FixedSeedCheckbox.Text = "FIXED SEED";
            this.FixedSeedCheckbox.UseVisualStyleBackColor = false;
            this.FixedSeedCheckbox.CheckedChanged += new System.EventHandler(this.FixedSeedCheckbox_CheckedChanged);
            // 
            // FastModeBtn
            // 
            this.FastModeBtn.Location = new System.Drawing.Point(159, 0);
            this.FastModeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FastModeBtn.Name = "FastModeBtn";
            this.FastModeBtn.Size = new System.Drawing.Size(165, 75);
            this.FastModeBtn.TabIndex = 1;
            this.FastModeBtn.Text = "FAST MODE";
            this.FastModeBtn.UseVisualStyleBackColor = true;
            this.FastModeBtn.Click += new System.EventHandler(this.FasModeBtn_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "SLOW MODE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SlowModeBtn_clicked);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 138);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1481, 711);
            this.panelContainer.TabIndex = 2;
            // 
            // CustomersFlowNumPad
            // 
            this.CustomersFlowNumPad.Location = new System.Drawing.Point(1095, 26);
            this.CustomersFlowNumPad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CustomersFlowNumPad.Name = "CustomersFlowNumPad";
            this.CustomersFlowNumPad.Size = new System.Drawing.Size(98, 22);
            this.CustomersFlowNumPad.TabIndex = 6;
            this.CustomersFlowNumPad.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.CustomersFlowNumPad.ValueChanged += new System.EventHandler(this.CustomersFlowNumPad_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(938, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "CUSTOMERS/HOUR";
            // 
            // STKAgentGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 849);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "STKAgentGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STK";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersFlowNumPad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button FastModeBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox FixedSeedCheckbox;
        private System.Windows.Forms.Button MechanicsChartTabBtn;
        private System.Windows.Forms.Button GrafTechiciBtn;
        private System.Windows.Forms.CheckBox ValidationCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CustomersFlowNumPad;
    }
}

