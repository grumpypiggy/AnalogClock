namespace AnalogClock
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupTimeDisplay = new System.Windows.Forms.GroupBox();
            this.lblStopWatch = new System.Windows.Forms.Label();
            this.groupStopWatch = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupMode = new System.Windows.Forms.GroupBox();
            this.btnAnalogClock = new System.Windows.Forms.RadioButton();
            this.btnStopWatch = new System.Windows.Forms.RadioButton();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerStopWatch = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupTimeDisplay.SuspendLayout();
            this.groupStopWatch.SuspendLayout();
            this.groupMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupTimeDisplay);
            this.panel1.Controls.Add(this.groupStopWatch);
            this.panel1.Controls.Add(this.groupMode);
            this.panel1.Location = new System.Drawing.Point(359, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 402);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(451, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupTimeDisplay
            // 
            this.groupTimeDisplay.Controls.Add(this.lblStopWatch);
            this.groupTimeDisplay.Location = new System.Drawing.Point(12, 24);
            this.groupTimeDisplay.Name = "groupTimeDisplay";
            this.groupTimeDisplay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupTimeDisplay.Size = new System.Drawing.Size(441, 74);
            this.groupTimeDisplay.TabIndex = 3;
            this.groupTimeDisplay.TabStop = false;
            this.groupTimeDisplay.Text = "Time";
            // 
            // lblStopWatch
            // 
            this.lblStopWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopWatch.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopWatch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStopWatch.Location = new System.Drawing.Point(3, 22);
            this.lblStopWatch.Name = "lblStopWatch";
            this.lblStopWatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStopWatch.Size = new System.Drawing.Size(435, 49);
            this.lblStopWatch.TabIndex = 1;
            this.lblStopWatch.Text = "Time";
            this.lblStopWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupStopWatch
            // 
            this.groupStopWatch.Controls.Add(this.btnStop);
            this.groupStopWatch.Controls.Add(this.btnStart);
            this.groupStopWatch.Controls.Add(this.btnClear);
            this.groupStopWatch.Controls.Add(this.listBox);
            this.groupStopWatch.Controls.Add(this.btnRecord);
            this.groupStopWatch.Enabled = false;
            this.groupStopWatch.Location = new System.Drawing.Point(12, 177);
            this.groupStopWatch.Name = "groupStopWatch";
            this.groupStopWatch.Size = new System.Drawing.Size(441, 210);
            this.groupStopWatch.TabIndex = 2;
            this.groupStopWatch.TabStop = false;
            this.groupStopWatch.Text = "Stopwatch  Settings";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(10, 76);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(119, 31);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(225, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(135, 76);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 31);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(10, 113);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(425, 84);
            this.listBox.TabIndex = 4;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(241, 39);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(194, 68);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // groupMode
            // 
            this.groupMode.Controls.Add(this.btnAnalogClock);
            this.groupMode.Controls.Add(this.btnStopWatch);
            this.groupMode.Location = new System.Drawing.Point(12, 104);
            this.groupMode.Name = "groupMode";
            this.groupMode.Size = new System.Drawing.Size(441, 67);
            this.groupMode.TabIndex = 1;
            this.groupMode.TabStop = false;
            this.groupMode.Text = "Mode";
            // 
            // btnAnalogClock
            // 
            this.btnAnalogClock.AutoSize = true;
            this.btnAnalogClock.Checked = true;
            this.btnAnalogClock.Location = new System.Drawing.Point(31, 30);
            this.btnAnalogClock.Name = "btnAnalogClock";
            this.btnAnalogClock.Size = new System.Drawing.Size(127, 24);
            this.btnAnalogClock.TabIndex = 0;
            this.btnAnalogClock.TabStop = true;
            this.btnAnalogClock.Text = "Analog Clock";
            this.btnAnalogClock.UseVisualStyleBackColor = true;
            this.btnAnalogClock.CheckedChanged += new System.EventHandler(this.btnAnalogClock_CheckedChanged);
            // 
            // btnStopWatch
            // 
            this.btnStopWatch.AutoSize = true;
            this.btnStopWatch.Location = new System.Drawing.Point(209, 30);
            this.btnStopWatch.Name = "btnStopWatch";
            this.btnStopWatch.Size = new System.Drawing.Size(110, 24);
            this.btnStopWatch.TabIndex = 1;
            this.btnStopWatch.Text = "Stopwatch";
            this.btnStopWatch.UseVisualStyleBackColor = true;
            this.btnStopWatch.CheckedChanged += new System.EventHandler(this.btnStopWatch_CheckedChanged);
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerStopWatch
            // 
            this.timerStopWatch.Interval = 1;
            this.timerStopWatch.Tick += new System.EventHandler(this.timerStopWatch_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 863);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Illumina Analog Clock";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupTimeDisplay.ResumeLayout(false);
            this.groupStopWatch.ResumeLayout(false);
            this.groupMode.ResumeLayout(false);
            this.groupMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton btnStopWatch;
        private System.Windows.Forms.RadioButton btnAnalogClock;
        private System.Windows.Forms.GroupBox groupMode;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupStopWatch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerStopWatch;
        private System.Windows.Forms.Label lblStopWatch;
        private System.Windows.Forms.GroupBox groupTimeDisplay;
        private System.Windows.Forms.Label label1;
    }
}

