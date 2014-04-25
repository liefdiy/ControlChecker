namespace MyControlCreator.UI
{
    partial class Block
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.wrapPanel = new System.Windows.Forms.Panel();
            this.gnSeperator = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wrapPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // wrapPanel
            // 
            this.wrapPanel.AllowDrop = true;
            this.wrapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wrapPanel.Controls.Add(this.gnSeperator);
            this.wrapPanel.Controls.Add(this.menuStrip);
            this.wrapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wrapPanel.Location = new System.Drawing.Point(10, 10);
            this.wrapPanel.Name = "wrapPanel";
            this.wrapPanel.Size = new System.Drawing.Size(612, 293);
            this.wrapPanel.TabIndex = 2;
            this.wrapPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.wrapPanel_DragDrop);
            this.wrapPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.wrapPanel_DragEnter);
            // 
            // gnSeperator
            // 
            this.gnSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gnSeperator.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gnSeperator.Location = new System.Drawing.Point(3, 28);
            this.gnSeperator.Name = "gnSeperator";
            this.gnSeperator.Size = new System.Drawing.Size(604, 1);
            this.gnSeperator.TabIndex = 3;
            this.gnSeperator.TabStop = false;
            this.gnSeperator.Text = "0";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(610, 25);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "工具栏";
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.delToolStripMenuItem.Text = "移除";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // Block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wrapPanel);
            this.Name = "Block";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(632, 313);
            this.wrapPanel.ResumeLayout(false);
            this.wrapPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel wrapPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.GroupBox gnSeperator;
    }
}
