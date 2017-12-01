namespace Laba_4
{
    partial class USBView
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.usbList = new System.Windows.Forms.ListView();
            this.DeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FreeSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UsedSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ejectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 8000;
            this.timer.Tick += new System.EventHandler(this.TickTimer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 8000;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-14, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // usbList
            // 
            this.usbList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeviceName,
            this.FreeSpace,
            this.UsedSpace,
            this.TotalSpace});
            this.usbList.Location = new System.Drawing.Point(12, 12);
            this.usbList.Name = "usbList";
            this.usbList.Size = new System.Drawing.Size(445, 180);
            this.usbList.TabIndex = 7;
            this.usbList.UseCompatibleStateImageBehavior = false;
            this.usbList.View = System.Windows.Forms.View.Details;
            this.usbList.SelectedIndexChanged += new System.EventHandler(this.usbList_SelectedIndexChanged);
            this.usbList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ExecuteDevice);
            // 
            // DeviceName
            // 
            this.DeviceName.Text = "Название";
            this.DeviceName.Width = 111;
            // 
            // FreeSpace
            // 
            this.FreeSpace.Text = "Доступно";
            this.FreeSpace.Width = 80;
            // 
            // UsedSpace
            // 
            this.UsedSpace.Text = "Использовано";
            this.UsedSpace.Width = 70;
            // 
            // TotalSpace
            // 
            this.TotalSpace.Text = "Емкость";
            this.TotalSpace.Width = 91;
            // 
            // ejectButton
            // 
            this.ejectButton.Location = new System.Drawing.Point(12, 195);
            this.ejectButton.Name = "ejectButton";
            this.ejectButton.Size = new System.Drawing.Size(75, 23);
            this.ejectButton.TabIndex = 8;
            this.ejectButton.Text = "Извлечь";
            this.ejectButton.UseVisualStyleBackColor = true;
            this.ejectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // USBView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 221);
            this.Controls.Add(this.ejectButton);
            this.Controls.Add(this.usbList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "USBView";
            this.Text = "USB Manager";
            this.Load += new System.EventHandler(this.LoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView usbList;
        private System.Windows.Forms.ColumnHeader DeviceName;
        private System.Windows.Forms.ColumnHeader FreeSpace;
        private System.Windows.Forms.ColumnHeader UsedSpace;
        private System.Windows.Forms.ColumnHeader TotalSpace;
        public System.Windows.Forms.Button ejectButton;
    }
}

