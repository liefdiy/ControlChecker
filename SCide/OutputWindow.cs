using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Mysoft.Business.Validation.Entity;
using WeifenLuo.WinFormsUI.Docking;

namespace SCide
{
    public partial class OutputWindow : DockContent
    {
        private List<PageResult> _pageResults = new List<PageResult>();

        public OutputWindow()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        private Level _showLevel = Level.Error | Level.Warn | Level.Message | Level.Success;

        public void ShowPageResult(PageResult page)
        {
            _pageResults.Clear();
            _pageResults.Add(page);
            ShowPageResults(_showLevel);
        }

        private void ShowPageResults(Level level)
        {
            BindingList<Result> data = new BindingList<Result>();

            for (int i = 0; i < _pageResults.Count; i++)
            {
                PageResult page = _pageResults[i];
                for (int j = 0; j < page.Results.Count; j++)
                {
                    Result result = page.Results[j];
                    if (result.Level == (level & result.Level))
                    {
                        data.Add(result);
                    }
                }
            }

            if (data.Count == 0 && level == _showLevel)
            {
                data.Add(new Result("验证通过", "配置正确  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Level.Success, typeof(OutputWindow)));
            }

            dataGridView.DataSource = data;
        }

        private void copyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                string clipstring = dataGridView.CurrentCell.Value.ToString();
                Clipboard.SetText(clipstring);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _pageResults.Clear();
            dataGridView.DataSource = new BindingList<Result>();
        }

        private void allToolStripButton_Click(object sender, System.EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn == null) return;

            foreach (var c in toolStrip1.Items)
            {
                ToolStripButton ctrl = c as ToolStripButton;
                if (ctrl != null)
                {
                    ctrl.BackColor = SystemColors.Control;
                }
            }

            btn.BackColor = System.Drawing.Color.FromArgb(196, 225, 255);

            string str = btn.Tag.ToString();
            Level level = (Level.Error | Level.Warn | Level.Message | Level.Success);
            if (!str.Equals("All"))
            {
                level = (Level)Enum.Parse(typeof(Level), str);
            }
            ShowPageResults(level);
        }
    }
}