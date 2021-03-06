﻿using Mysoft.Business.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyControlCreator.Base
{
    public partial class AppBaseControl : UserControl
    {
        #region events

        private event EventHandler _OnRemoved;

        public event EventHandler OnRemoved
        {
            add { _OnRemoved += value; }
            remove { _OnRemoved -= value; }
        }

        #endregion events

        #region Property

        /// <summary>
        /// 允许配置多个该控件
        /// </summary>
        [Browsable(true), Category("MAP"), DefaultValue(true)]
        public bool AllowMulti { get; set; }

        public AppControl Control { get; protected set; }

        #endregion Property

        protected AppBaseControl()
        {
            InitializeComponent();
        }

        #region 扩展操作

        /// <summary>
        /// 控件拖进来要执行的操作
        /// </summary>
        protected virtual void OnDragDrop()
        {

        }

        #endregion 扩展操作

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            if (_OnRemoved != null)
            {
                _OnRemoved(sender, e);
            }
        }
    }
}