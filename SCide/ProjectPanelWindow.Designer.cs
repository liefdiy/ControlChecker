namespace SCide
{
    partial class ProjectPanelWindow
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
            this.projectTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.execute = new System.Windows.Forms.ToolStripMenuItem();
            this.openPath = new System.Windows.Forms.ToolStripMenuItem();
            this.txbFilter = new System.Windows.Forms.TextBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbCollapse = new System.Windows.Forms.Label();
            this.lbExpand = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectTreeView
            // 
            this.projectTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectTreeView.ContextMenuStrip = this.contextMenuStrip;
            this.projectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTreeView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.projectTreeView.FullRowSelect = true;
            this.projectTreeView.HotTracking = true;
            this.projectTreeView.Location = new System.Drawing.Point(0, 0);
            this.projectTreeView.Name = "projectTreeView";
            this.projectTreeView.ShowNodeToolTips = true;
            this.projectTreeView.Size = new System.Drawing.Size(281, 565);
            this.projectTreeView.TabIndex = 0;
            this.projectTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.projectTreeView_NodeMouseDoubleClick);
            this.projectTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projectTreeView_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.execute,
            this.openPath});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(185, 48);
            // 
            // execute
            // 
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(184, 22);
            this.execute.Text = "执行验证";
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // openPath
            // 
            this.openPath.Name = "openPath";
            this.openPath.Size = new System.Drawing.Size(184, 22);
            this.openPath.Text = "在资源管理器中打开";
            this.openPath.Click += new System.EventHandler(this.openPath_Click);
            // 
            // txbFilter
            // 
            this.txbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFilter.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.txbFilter.Location = new System.Drawing.Point(42, 4);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(194, 22);
            this.txbFilter.TabIndex = 1;
            this.txbFilter.Text = "*.xml";
            this.txbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbFilter_KeyDown);
            // 
            // lbFilter
            // 
            this.lbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbFilter.Location = new System.Drawing.Point(5, 7);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(37, 16);
            this.lbFilter.TabIndex = 2;
            this.lbFilter.Text = "Filter:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbCollapse);
            this.splitContainer1.Panel1.Controls.Add(this.lbExpand);
            this.splitContainer1.Panel1.Controls.Add(this.txbFilter);
            this.splitContainer1.Panel1.Controls.Add(this.lbFilter);
            this.splitContainer1.Panel1MinSize = 30;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.projectTreeView);
            this.splitContainer1.Size = new System.Drawing.Size(283, 598);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 3;
            // 
            // lbCollapse
            // 
            this.lbCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCollapse.AutoSize = true;
            this.lbCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCollapse.Location = new System.Drawing.Point(259, 4);
            this.lbCollapse.Name = "lbCollapse";
            this.lbCollapse.Size = new System.Drawing.Size(11, 12);
            this.lbCollapse.TabIndex = 6;
            this.lbCollapse.Text = "-";
            this.lbCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // lbExpand
            // 
            this.lbExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExpand.AutoSize = true;
            this.lbExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbExpand.Location = new System.Drawing.Point(242, 4);
            this.lbExpand.Name = "lbExpand";
            this.lbExpand.Size = new System.Drawing.Size(11, 12);
            this.lbExpand.TabIndex = 5;
            this.lbExpand.Text = "+";
            this.lbExpand.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // ProjectPanelWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 598);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ProjectPanelWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "Project Explorer";
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView projectTreeView;
        private System.Windows.Forms.TextBox txbFilter;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbExpand;
        private System.Windows.Forms.Label lbCollapse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openPath;
        private System.Windows.Forms.ToolStripMenuItem execute;
    }
}