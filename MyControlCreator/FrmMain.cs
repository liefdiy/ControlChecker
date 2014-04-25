using MyControlCreator.Base;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MyControlCreator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //lb_appForm.MouseHover += (obj, args) => { lb_appForm.BackColor = Color.Aquamarine; };
            //lb_appForm.MouseLeave += (obj, args) => { lb_appForm.BackColor = SystemColors.Control; };

            base.OnLoad(e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Label ctrl = sender as Label;
            if (ctrl == null) return;

            if (e.Button == MouseButtons.Left)
            {
                ctrl.DoDragDrop(ctrl, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }

        private void splitContainer1_Panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e)
        {
            Point p = pnEditor.Location;
            int height = 0;

            if (pnEditor.Controls.Count > 0)
            {
                Control ctrl = pnEditor.Controls[pnEditor.Controls.Count - 1];
                p = ctrl.Location;
                height = ctrl.Height;
            }

            Label lb = e.Data.GetData(typeof(Label)) as Label;
            if (lb == null) return;

            Assembly assembly = GetType().Assembly;
            var obj = assembly.CreateInstance(assembly.GetName().Name + "." + lb.Tag);
            AppBaseControl uc = obj as AppBaseControl;
            if (uc == null) return;

            if (!uc.AllowMulti)
            {
                var controls = pnEditor.Controls.Find(uc.Name, false);
                if (controls.Length > 0)
                {
                    MessageBox.Show("控件不允许添加多个！");
                    return;
                }
            }
            //uc.Location = new Point(10, p.Y + height + 10);
            //uc.Width = pnEditor.Width - 20;
            uc.Dock = DockStyle.Top;
            //appFind.Location = this.PointToClient(new Point(e.X - p.X, e.Y));
            //appFind.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnEditor.Controls.Add(uc);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            splitContainer1_Panel2_DragDrop(sender, null);
        }
    }
}