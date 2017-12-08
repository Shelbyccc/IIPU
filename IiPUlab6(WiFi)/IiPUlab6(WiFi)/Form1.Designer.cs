namespace Getting_WIFI_Networks
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
            this.NetworkList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NetworkInformation = new System.Windows.Forms.TextBox();
            this.ConnectionB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordF = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ConnectionStatusL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NetworkList
            // 
            this.NetworkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.NetworkList.FullRowSelect = true;
            this.NetworkList.Location = new System.Drawing.Point(12, 12);
            this.NetworkList.MultiSelect = false;
            this.NetworkList.Name = "NetworkList";
            this.NetworkList.Size = new System.Drawing.Size(270, 291);
            this.NetworkList.TabIndex = 0;
            this.NetworkList.UseCompatibleStateImageBehavior = false;
            this.NetworkList.View = System.Windows.Forms.View.Details;
            this.NetworkList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NetworkList_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Signal strength";
            this.columnHeader2.Width = 103;
            // 
            // NetworkInformation
            // 
            this.NetworkInformation.Location = new System.Drawing.Point(288, 12);
            this.NetworkInformation.Multiline = true;
            this.NetworkInformation.Name = "NetworkInformation";
            this.NetworkInformation.Size = new System.Drawing.Size(206, 216);
            this.NetworkInformation.TabIndex = 1;
            // 
            // ConnectionB
            // 
            this.ConnectionB.Location = new System.Drawing.Point(372, 261);
            this.ConnectionB.Name = "ConnectionB";
            this.ConnectionB.Size = new System.Drawing.Size(75, 23);
            this.ConnectionB.TabIndex = 2;
            this.ConnectionB.Text = "Connection";
            this.ConnectionB.UseVisualStyleBackColor = true;
            this.ConnectionB.Click += new System.EventHandler(this.ConnectionB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // PasswordF
            // 
            this.PasswordF.Location = new System.Drawing.Point(348, 235);
            this.PasswordF.Name = "PasswordF";
            this.PasswordF.PasswordChar = '*';
            this.PasswordF.Size = new System.Drawing.Size(146, 20);
            this.PasswordF.TabIndex = 4;
            this.PasswordF.TabIndex = 4;
            this.PasswordF.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PasswordFieldClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ConnectionStatusL
            // 
            this.ConnectionStatusL.AutoSize = true;
            this.ConnectionStatusL.Location = new System.Drawing.Point(289, 268);
            this.ConnectionStatusL.Name = "ConnectionStatusL";
            this.ConnectionStatusL.Size = new System.Drawing.Size(0, 13);
            this.ConnectionStatusL.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 315);
            this.Controls.Add(this.ConnectionStatusL);
            this.Controls.Add(this.PasswordF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectionB);
            this.Controls.Add(this.NetworkInformation);
            this.Controls.Add(this.NetworkList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView NetworkList;
        private System.Windows.Forms.TextBox NetworkInformation;
        private System.Windows.Forms.Button ConnectionB;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordF;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ConnectionStatusL;
    }
}

