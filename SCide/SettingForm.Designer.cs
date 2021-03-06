﻿using System;
using System.Drawing;
using System.Windows.Forms;

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
            this.txbPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
            this.cbb_reg = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.gb.Location = new System.Drawing.Point(12, 38);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(446, 179);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            // 
            // txbPwd
            // 
            this.txbPwd.Location = new System.Drawing.Point(94, 133);
            this.txbPwd.Name = "txbPwd";
            this.txbPwd.Size = new System.Drawing.Size(333, 21);
            this.txbPwd.TabIndex = 7;
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
            // txbUserId
            // 
            this.txbUserId.Location = new System.Drawing.Point(94, 97);
            this.txbUserId.Name = "txbUserId";
            this.txbUserId.Size = new System.Drawing.Size(333, 21);
            this.txbUserId.TabIndex = 5;
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
            // txbDb
            // 
            this.txbDb.Location = new System.Drawing.Point(94, 58);
            this.txbDb.Name = "txbDb";
            this.txbDb.Size = new System.Drawing.Size(333, 21);
            this.txbDb.TabIndex = 3;
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
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(24, 23);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(47, 12);
            this.lbServer.TabIndex = 1;
            this.lbServer.Text = "Server:";
            // 
            // txbServer
            // 
            this.txbServer.Location = new System.Drawing.Point(94, 20);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(333, 21);
            this.txbServer.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(364, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(283, 236);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(75, 23);
            this.btntest.TabIndex = 9;
            this.btntest.Text = "Test";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // cbb_reg
            // 
            this.cbb_reg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_reg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbb_reg.FormattingEnabled = true;
            this.cbb_reg.Location = new System.Drawing.Point(106, 12);
            this.cbb_reg.Name = "cbb_reg";
            this.cbb_reg.Size = new System.Drawing.Size(333, 20);
            this.cbb_reg.TabIndex = 10;
            this.cbb_reg.SelectedValueChanged += new System.EventHandler(this.cbb_reg_SelectedValueChanged);
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "选择配置项:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 271);
            this.Controls.Add(this.cbb_reg);
            base.Controls.Add(this.label4);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ComboBox cbb_reg;
        private System.Windows.Forms.Label label4;
    }
}