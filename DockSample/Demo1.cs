using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DockSample
{
    public partial class Demo1 : Form
    {
        public Demo1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            DummyOutputWindow form = new DummyOutputWindow();
            form.Show(dockPanel1);
            base.OnLoad(e);
        }
    }
}
