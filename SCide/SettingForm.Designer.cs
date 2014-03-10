namespace SCide
{
    partial class SettingForm
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbUserId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPwd = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.txbPwd);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.txbUserId);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.txbDb);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.lbServer);
            this.gb.Controls.Add(this.txbServer);
            this.gb.Location = new System.Drawing.Point(12, 12);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(446, 179);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // txbServer
            // 
            this.txbServer.Location = new System.Drawing.Point(94, 20);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(333, 21);
            this.txbServer.TabIndex = 0;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(24, 23);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(47, 12);
            this.lbServer.TabIndex = 1;
            this.lbServer.Text = "Server:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "DataBase:";
            // 
            // txbDb
            // 
            this.txbDb.Location = new System.Drawing.Point(94, 58);
            this.txbDb.Name = "txbDb";
            this.txbDb.Size = new System.Drawing.Size(333, 21);
            this.txbDb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "User Id:";
            // 
            // txbUserId
            // 
            this.txbUserId.Location = new System.Drawing.Point(94, 97);
            this.txbUserId.Name = "txbUserId";
            this.txbUserId.Size = new System.Drawing.Size(333, 21);
            this.txbUserId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // txbPwd
            // 
            this.txbPwd.Location = new System.Drawing.Point(94, 133);
            this.txbPwd.Name = "txbPwd";
            this.txbPwd.Size = new System.Drawing.Size(333, 21);
            this.txbPwd.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(364, 197);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(283, 197);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 9;
            this.btntest.Text = "Test";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 227);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "数据库连接";
            this.TopMost = true;
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox txbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDb;
        private System.Windows.Forms.TextBox txbPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btntest;
    }
}