using System.Collections.Generic;
using System.Windows.Forms;

namespace MyControlCreator.UI
{
    public partial class SelectOptionsUc : UserControl
    {
        public SelectOptionsUc()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            chkboxlist.Items.Add(txbItem.Text);
            txbItem.Clear();
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            for (int i = chkboxlist.CheckedItems.Count - 1; i > -1; i--)
            {
                chkboxlist.Items.Remove(chkboxlist.CheckedItems[i]);
            }
        }

        /// <summary>
        /// 获取列表值
        /// </summary>
        /// <returns></returns>
        public List<string> GetValue()
        {
            List<string> list = new List<string>();
            foreach (var item in chkboxlist.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        /// <summary>
        /// 设置列表值
        /// </summary>
        /// <param name="list"></param>
        public void SetValue(List<string> list)
        {
            foreach (var item in list)
            {
                chkboxlist.Items.Add(item);
            }
        }
    }
}