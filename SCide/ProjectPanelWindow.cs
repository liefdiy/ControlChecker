using Mysoft.Business.Manager;
using Mysoft.Common.Extensions;
using SCide.Properties;
using System;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SCide
{
    public partial class ProjectPanelWindow : DockContent
    {
        private string _filter = "*.xml";

        public ProjectPanelWindow()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            OnLoad(null);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Directory.Exists(AppConfigManager.Setting.WebSite.SiteRoot)) return;
            
            _filter = txbFilter.Text;

            if (string.IsNullOrEmpty(_filter))
            {
                _filter = "*.xml";
            }

            projectTreeView.Nodes.Clear();

            DirectoryInfo root = new DirectoryInfo(AppConfigManager.Setting.WebSite.SiteRoot);

            ImageList imgs = new ImageList();
            imgs.Images.Add("dir", Resources.Directory);
            imgs.Images.Add("xml", Resources.File);
            imgs.Images.Add("file", Resources.ImageFileNew);
            projectTreeView.ImageList = imgs;

            TreeNode rootNode = GetDirectory(root);

            projectTreeView.Nodes.Add(rootNode);
            projectTreeView.ExpandAll();
            base.OnLoad(e);
        }

        private TreeNode GetDirectory(DirectoryInfo root)
        {
            TreeNode rootNode = new TreeNode();
            rootNode.Text = root.Name;
            rootNode.Tag = root;
            rootNode.ImageKey = "dir";
            rootNode.SelectedImageKey = rootNode.ImageKey;

            DirectoryInfo[] directorie = root.GetDirectories();
            foreach (DirectoryInfo di in directorie)
            {
                try
                {
                    FileInfo[] files = di.GetFiles(_filter);
                    if (files.Length == 0)
                    {
                        TreeNode tn = GetDirectory(di);
                        if (tn.Nodes.Count > 0)
                        {
                            rootNode.Nodes.Add(tn);
                        }
                    }

                    foreach (FileInfo fi in files)
                    {
                        rootNode.Nodes.Add(GetFile(fi));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }

            return rootNode;
        }

        private TreeNode GetFile(FileInfo fi)
        {
            TreeNode rootNode = new TreeNode();
            rootNode.Text = fi.Name;
            rootNode.Tag = fi;
            rootNode.ImageKey = fi.Extension.Replace(".", "").EqualIgnoreCase("xml") ? "xml" : "file";
            rootNode.SelectedImageKey = rootNode.ImageKey;
            return rootNode;
        }

        private void txbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnLoad(null);
            }
        }

        private void projectTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileInfo fi = e.Node.Tag as FileInfo;
            if (fi == null) return;
            
            MainForm frm = ParentForm as MainForm;
            if (frm == null) return;
            frm.OpenFile(fi.FullName);
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            projectTreeView.CollapseAll();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            projectTreeView.ExpandAll();
        }
    }
}