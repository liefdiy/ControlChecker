using System;
using System.Windows.Forms;

namespace MyControlCreator.UI
{
    public partial class Block : UserControl
    {
        #region events

        private event EventHandler _OnRemoved;

        public event EventHandler OnRemoved
        {
            add { _OnRemoved += value; }
            remove { _OnRemoved -= value; }
        }

        #endregion events

        public Block()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 移除控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_OnRemoved != null)
            {
                _OnRemoved(sender, e);
            }
        }

        /// <summary>
        /// 控件拖进来要执行的操作
        /// </summary>
        protected virtual void OnDragDrop()
        {
            
        }

        private void wrapPanel_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop();
        }

        private void wrapPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}