namespace IiPUlab3._2_battery_
{
    partial class Battery
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
            this.label1 = new System.Windows.Forms.Label();
            this.PowerLineStatus = new System.Windows.Forms.TextBox();
            this.BatteryLifePercent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BatteryLifeRemaining = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BlackoutTimeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PowerLineStatus";
            // 
            // PowerLineStatus
            // 
            this.PowerLineStatus.Location = new System.Drawing.Point(15, 35);
            this.PowerLineStatus.Name = "PowerLineStatus";
            this.PowerLineStatus.ReadOnly = true;
            this.PowerLineStatus.Size = new System.Drawing.Size(257, 20);
            this.PowerLineStatus.TabIndex = 1;
            // 
            // BatteryLifePercent
            // 
            this.BatteryLifePercent.Location = new System.Drawing.Point(15, 81);
            this.BatteryLifePercent.Name = "BatteryLifePercent";
            this.BatteryLifePercent.ReadOnly = true;
            this.BatteryLifePercent.Size = new System.Drawing.Size(257, 20);
            this.BatteryLifePercent.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BatteryLifePercent";
            // 
            // BatteryLifeRemaining
            // 
            this.BatteryLifeRemaining.Location = new System.Drawing.Point(15, 127);
            this.BatteryLifeRemaining.Name = "BatteryLifeRemaining";
            this.BatteryLifeRemaining.ReadOnly = true;
            this.BatteryLifeRemaining.Size = new System.Drawing.Size(257, 20);
            this.BatteryLifeRemaining.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "BatteryLifeRemaining";
            // 
            // BlackoutTimeComboBox
            // 
            this.BlackoutTimeComboBox.FormattingEnabled = true;
            this.BlackoutTimeComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "45",
            "60",
            "120",
            "180",
            "240",
            "300"});
            this.BlackoutTimeComboBox.Location = new System.Drawing.Point(15, 180);
            this.BlackoutTimeComboBox.Name = "BlackoutTimeComboBox";
            this.BlackoutTimeComboBox.Size = new System.Drawing.Size(257, 21);
            this.BlackoutTimeComboBox.TabIndex = 6;
            this.BlackoutTimeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlackoutTimeComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DisplayBlackoutTime";
            // 
            // Battery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BlackoutTimeComboBox);
            this.Controls.Add(this.BatteryLifeRemaining);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BatteryLifePercent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PowerLineStatus);
            this.Controls.Add(this.label1);
            this.Name = "Battery";
            this.Text = "Battery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Battery_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PowerLineStatus;
        private System.Windows.Forms.TextBox BatteryLifePercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BatteryLifeRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BlackoutTimeComboBox;
        private System.Windows.Forms.Label label4;
    }
}

