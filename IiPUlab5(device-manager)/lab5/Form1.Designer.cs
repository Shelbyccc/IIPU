namespace lab5
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
            this.ListOfDevices = new System.Windows.Forms.ListView();
            this.DeviceDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TurnOn = new System.Windows.Forms.Button();
            this.TurnOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListOfDevices
            // 
            this.ListOfDevices.Location = new System.Drawing.Point(12, 32);
            this.ListOfDevices.Name = "ListOfDevices";
            this.ListOfDevices.Size = new System.Drawing.Size(196, 323);
            this.ListOfDevices.TabIndex = 0;
            this.ListOfDevices.UseCompatibleStateImageBehavior = false;
            this.ListOfDevices.View = System.Windows.Forms.View.Tile;
            // 
            // DeviceDescription
            // 
            this.DeviceDescription.Location = new System.Drawing.Point(214, 32);
            this.DeviceDescription.Multiline = true;
            this.DeviceDescription.Name = "DeviceDescription";
            this.DeviceDescription.Size = new System.Drawing.Size(355, 355);
            this.DeviceDescription.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "List of devices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device description";
            // 
            // TurnOn
            // 
            this.TurnOn.Location = new System.Drawing.Point(12, 362);
            this.TurnOn.Name = "TurnOn";
            this.TurnOn.Size = new System.Drawing.Size(75, 23);
            this.TurnOn.TabIndex = 4;
            this.TurnOn.Text = "Turn on";
            this.TurnOn.UseVisualStyleBackColor = true;
            // 
            // TurnOff
            // 
            this.TurnOff.Location = new System.Drawing.Point(133, 362);
            this.TurnOff.Name = "TurnOff";
            this.TurnOff.Size = new System.Drawing.Size(75, 23);
            this.TurnOff.TabIndex = 5;
            this.TurnOff.Text = "Turn off";
            this.TurnOff.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 399);
            this.Controls.Add(this.TurnOff);
            this.Controls.Add(this.TurnOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeviceDescription);
            this.Controls.Add(this.ListOfDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Device Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListOfDevices;
        private System.Windows.Forms.TextBox DeviceDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TurnOn;
        private System.Windows.Forms.Button TurnOff;
    }
}

