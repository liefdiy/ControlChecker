namespace MyControlCreator.Base
{
    partial class AppBaseControl
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
            this.block = new MyControlCreator.UI.Block();
            this.SuspendLayout();
            // 
            // block
            // 
            this.block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.block.Location = new System.Drawing.Point(0, 0);
            this.block.Name = "block";
            this.block.Padding = new System.Windows.Forms.Padding(10);
            this.block.Size = new System.Drawing.Size(440, 313);
            this.block.TabIndex = 0;
            this.block.OnRemoved += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // AppBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.block);
            this.Name = "AppBaseControl";
            this.Size = new System.Drawing.Size(440, 313);
            this.ResumeLayout(false);

        }

        #endregion

        protected UI.Block block;


    }
}
