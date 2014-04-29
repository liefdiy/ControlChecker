namespace MyControlCreator
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_appFormMenu = new System.Windows.Forms.Label();
            this.lb_appForm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_appDatasource = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_appGrid = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnEditor = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pnEditor);
            this.splitContainer1.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragDrop);
            this.splitContainer1.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragEnter);
            this.splitContainer1.Size = new System.Drawing.Size(764, 577);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 553);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MAP";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lb_appFormMenu, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lb_appForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_appDatasource, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_appGrid, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnsave, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 7);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(152, 533);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 6;
            this.label1.Tag = "AppFindControl";
            this.label1.Text = "AppFind";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // lb_appFormMenu
            // 
            this.lb_appFormMenu.AllowDrop = true;
            this.lb_appFormMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_appFormMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_appFormMenu.Location = new System.Drawing.Point(5, 155);
            this.lb_appFormMenu.Margin = new System.Windows.Forms.Padding(5);
            this.lb_appFormMenu.Name = "lb_appFormMenu";
            this.lb_appFormMenu.Padding = new System.Windows.Forms.Padding(3);
            this.lb_appFormMenu.Size = new System.Drawing.Size(142, 20);
            this.lb_appFormMenu.TabIndex = 5;
            this.lb_appFormMenu.Tag = "AppFormMenu";
            this.lb_appFormMenu.Text = "AppFormMenu";
            // 
            // lb_appForm
            // 
            this.lb_appForm.AllowDrop = true;
            this.lb_appForm.BackColor = System.Drawing.SystemColors.Control;
            this.lb_appForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_appForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_appForm.Location = new System.Drawing.Point(5, 5);
            this.lb_appForm.Margin = new System.Windows.Forms.Padding(5);
            this.lb_appForm.Name = "lb_appForm";
            this.lb_appForm.Padding = new System.Windows.Forms.Padding(3);
            this.lb_appForm.Size = new System.Drawing.Size(142, 20);
            this.lb_appForm.TabIndex = 0;
            this.lb_appForm.Tag = "AppFormControl";
            this.lb_appForm.Text = "AppForm";
            this.lb_appForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 4;
            this.label3.Tag = "AppGridE";
            this.label3.Text = "AppGridE";
            // 
            // lb_appDatasource
            // 
            this.lb_appDatasource.AllowDrop = true;
            this.lb_appDatasource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_appDatasource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_appDatasource.Location = new System.Drawing.Point(5, 35);
            this.lb_appDatasource.Margin = new System.Windows.Forms.Padding(5);
            this.lb_appDatasource.Name = "lb_appDatasource";
            this.lb_appDatasource.Padding = new System.Windows.Forms.Padding(3);
            this.lb_appDatasource.Size = new System.Drawing.Size(142, 20);
            this.lb_appDatasource.TabIndex = 1;
            this.lb_appDatasource.Tag = "AppDataSource";
            this.lb_appDatasource.Text = "AppDataSource";
            this.lb_appDatasource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(5, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 3;
            this.label2.Tag = "AppViewListControl";
            this.label2.Text = "AppViewList";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // lb_appGrid
            // 
            this.lb_appGrid.AllowDrop = true;
            this.lb_appGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_appGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_appGrid.Location = new System.Drawing.Point(5, 65);
            this.lb_appGrid.Margin = new System.Windows.Forms.Padding(5);
            this.lb_appGrid.Name = "lb_appGrid";
            this.lb_appGrid.Padding = new System.Windows.Forms.Padding(3);
            this.lb_appGrid.Size = new System.Drawing.Size(142, 20);
            this.lb_appGrid.TabIndex = 2;
            this.lb_appGrid.Tag = "AppGrid";
            this.lb_appGrid.Text = "AppGrid";
            // 
            // btnsave
            // 
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsave.Location = new System.Drawing.Point(3, 243);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnEditor
            // 
            this.pnEditor.AutoScroll = true;
            this.pnEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnEditor.Location = new System.Drawing.Point(0, 0);
            this.pnEditor.Name = "pnEditor";
            this.pnEditor.Size = new System.Drawing.Size(576, 577);
            this.pnEditor.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 577);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lb_appDatasource;
        private System.Windows.Forms.Label lb_appForm;
        private System.Windows.Forms.Panel pnEditor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_appGrid;
        private System.Windows.Forms.Label lb_appFormMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button button1;
    }
}

