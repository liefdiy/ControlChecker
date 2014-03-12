using System.Windows.Forms;

namespace SCide
{
    partial class OutputWindow
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
            this.levelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.allToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.errorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.warnToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.msgToolStripButton = new System.Windows.Forms.ToolStripButton();
            dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.levelCol,
            this.titleCol,
            this.messageCol});
            dataGridView.ContextMenuStrip = this.contextMenuStrip1;
            dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            dataGridView.GridColor = System.Drawing.SystemColors.Window;
            dataGridView.Location = new System.Drawing.Point(0, 25);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 23;
            dataGridView.Size = new System.Drawing.Size(376, 236);
            dataGridView.TabIndex = 3;
            // 
            // levelCol
            // 
            this.levelCol.DataPropertyName = "Level";
            this.levelCol.FillWeight = 10F;
            this.levelCol.HeaderText = "Level";
            this.levelCol.Name = "levelCol";
            this.levelCol.ReadOnly = true;
            // 
            // titleCol
            // 
            this.titleCol.DataPropertyName = "Title";
            this.titleCol.FillWeight = 20F;
            this.titleCol.HeaderText = "Title";
            this.titleCol.Name = "titleCol";
            this.titleCol.ReadOnly = true;
            // 
            // messageCol
            // 
            this.messageCol.DataPropertyName = "Message";
            this.messageCol.FillWeight = 70F;
            this.messageCol.HeaderText = "Message";
            this.messageCol.Name = "messageCol";
            this.messageCol.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem, this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripButton,
            this.toolStripSeparator1,
            this.errorToolStripButton,
            this.toolStripSeparator2,
            this.warnToolStripButton,
            this.toolStripSeparator3,
            this.msgToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(376, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // allToolStripButton
            // 
            this.allToolStripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.allToolStripButton.Image = global::SCide.Properties.Resources._29_03_;
            this.allToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allToolStripButton.Name = "allToolStripButton";
            this.allToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.allToolStripButton.Tag = "All";
            this.allToolStripButton.Text = "全部";
            this.allToolStripButton.Click += new System.EventHandler(this.allToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // errorToolStripButton
            // 
            this.errorToolStripButton.Image = global::SCide.Properties.Resources.PngError;
            this.errorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.errorToolStripButton.Name = "errorToolStripButton";
            this.errorToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.errorToolStripButton.Tag = "Error";
            this.errorToolStripButton.Text = "错误";
            this.errorToolStripButton.Click += new System.EventHandler(this.allToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // warnToolStripButton
            // 
            this.warnToolStripButton.Image = global::SCide.Properties.Resources.PngWarn;
            this.warnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.warnToolStripButton.Name = "warnToolStripButton";
            this.warnToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.warnToolStripButton.Tag = "Warn";
            this.warnToolStripButton.Text = "警告";
            this.warnToolStripButton.Click += new System.EventHandler(this.allToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // msgToolStripButton
            // 
            this.msgToolStripButton.Image = global::SCide.Properties.Resources.PngMessage;
            this.msgToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.msgToolStripButton.Name = "msgToolStripButton";
            this.msgToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.msgToolStripButton.Tag = "Message";
            this.msgToolStripButton.Text = "消息";
            this.msgToolStripButton.Click += new System.EventHandler(this.allToolStripButton_Click);
            // 
            // OutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 261);
            this.Controls.Add(dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "OutputWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.Text = "输出";
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton allToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton errorToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton warnToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton msgToolStripButton;
        private DataGridViewTextBoxColumn levelCol;
        private DataGridViewTextBoxColumn titleCol;
        private DataGridViewTextBoxColumn messageCol;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
    }
}