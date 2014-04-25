using System.Windows.Forms;
using MyControlCreator.Base;
using Mysoft.Business.Controls;
using Mysoft.Business.Helpers;
using Mysoft.Common.Extensions;
using Mysoft.Common.Utility;
using System;
using System.Collections.Generic;

namespace MyControlCreator
{
    public class AppFindControl : AppBaseControl
    {
        #region Design

        #region Property

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbkeyword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox isshowcheckbox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbTitleWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbQueryInResult;
        private System.Windows.Forms.CheckBox chbCheckboxDefault;
        private System.Windows.Forms.CheckBox chbIsshowCheckbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnQueryInResult;
        private System.Windows.Forms.Button btnquery;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_add_s;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox ckblst_items_s;
        private System.Windows.Forms.Button btn_del_s;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_title_s;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ckb_grp_s;
        private System.Windows.Forms.ComboBox cmb_type_s;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txb_max_s;
        private System.Windows.Forms.TextBox txb_field_s;
        private System.Windows.Forms.ComboBox cmb_operator_s;
        private System.Windows.Forms.TextBox txb_min_s;
        private System.Windows.Forms.TextBox txb_acc_s;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txb_returnvalue_s;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txb_dt_s;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_del_a;
        private System.Windows.Forms.Button btn_add_a;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txb_title_a;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txb_field_a;
        private System.Windows.Forms.ComboBox cmb_type_a;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_operator_a;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox ckb_grp_a;
        private System.Windows.Forms.TextBox txb_max_a;
        private System.Windows.Forms.TextBox txb_min_a;
        private System.Windows.Forms.TextBox txb_acc_a;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txb_returnvalue_a;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txb_dt_a;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox ckblst_items_a;
        private System.Windows.Forms.ComboBox cmbOption_a;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnEditOptions;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RichTextBox rtxbSql;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txb_action_a;
        private System.Windows.Forms.TextBox txb_action_s;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.BindingSource appFindQueryItemBindingSource;
        private System.Windows.Forms.Button btn_save_s;
        private Button btn_save_a;
        private System.Windows.Forms.Label label1;

        #endregion Property

        public AppFindControl()
        {
            InitializeComponent();

            BindComboBox();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnquery = new System.Windows.Forms.Button();
            this.txbkeyword = new System.Windows.Forms.TextBox();
            this.btnQueryInResult = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.isshowcheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_save_s = new System.Windows.Forms.Button();
            this.btn_del_s = new System.Windows.Forms.Button();
            this.btn_add_s = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txb_action_s = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_title_s = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_field_s = new System.Windows.Forms.TextBox();
            this.cmb_type_s = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_operator_s = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ckb_grp_s = new System.Windows.Forms.CheckBox();
            this.txb_max_s = new System.Windows.Forms.TextBox();
            this.txb_min_s = new System.Windows.Forms.TextBox();
            this.txb_acc_s = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txb_returnvalue_s = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txb_dt_s = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckblst_items_s = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTitleWidth = new System.Windows.Forms.TextBox();
            this.chbQueryInResult = new System.Windows.Forms.CheckBox();
            this.chbCheckboxDefault = new System.Windows.Forms.CheckBox();
            this.chbIsshowCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_save_a = new System.Windows.Forms.Button();
            this.btn_del_a = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txb_title_a = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txb_field_a = new System.Windows.Forms.TextBox();
            this.cmb_type_a = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmb_operator_a = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.ckb_grp_a = new System.Windows.Forms.CheckBox();
            this.txb_max_a = new System.Windows.Forms.TextBox();
            this.txb_min_a = new System.Windows.Forms.TextBox();
            this.txb_acc_a = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txb_returnvalue_a = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txb_dt_a = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.rtxbSql = new System.Windows.Forms.RichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbOption_a = new System.Windows.Forms.ComboBox();
            this.btnEditOptions = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txb_action_a = new System.Windows.Forms.TextBox();
            this.btn_add_a = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ckblst_items_a = new System.Windows.Forms.CheckedListBox();
            this.appFindQueryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appFindQueryItemBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // block
            // 
            this.block.Size = new System.Drawing.Size(691, 873);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnquery);
            this.panel2.Controls.Add(this.txbkeyword);
            this.panel2.Controls.Add(this.btnQueryInResult);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 55);
            this.panel2.TabIndex = 2;
            // 
            // btnquery
            // 
            this.btnquery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnquery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnquery.Location = new System.Drawing.Point(475, 16);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(49, 22);
            this.btnquery.TabIndex = 6;
            this.btnquery.Text = "查找";
            this.btnquery.UseVisualStyleBackColor = true;
            // 
            // txbkeyword
            // 
            this.txbkeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbkeyword.Enabled = false;
            this.txbkeyword.Location = new System.Drawing.Point(313, 17);
            this.txbkeyword.Name = "txbkeyword";
            this.txbkeyword.Size = new System.Drawing.Size(156, 21);
            this.txbkeyword.TabIndex = 3;
            // 
            // btnQueryInResult
            // 
            this.btnQueryInResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQueryInResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQueryInResult.Location = new System.Drawing.Point(530, 16);
            this.btnQueryInResult.Name = "btnQueryInResult";
            this.btnQueryInResult.Size = new System.Drawing.Size(106, 22);
            this.btnQueryInResult.TabIndex = 5;
            this.btnQueryInResult.Text = "结果中查找";
            this.btnQueryInResult.UseVisualStyleBackColor = true;
            this.btnQueryInResult.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "关键字";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "查找按";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(145)))), ((int)(((byte)(184)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.isshowcheckbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 26);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(608, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "高级";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "普通";
            // 
            // isshowcheckbox
            // 
            this.isshowcheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isshowcheckbox.AutoSize = true;
            this.isshowcheckbox.Location = new System.Drawing.Point(459, 6);
            this.isshowcheckbox.Name = "isshowcheckbox";
            this.isshowcheckbox.Size = new System.Drawing.Size(84, 16);
            this.isshowcheckbox.TabIndex = 1;
            this.isshowcheckbox.Text = "视图内查询";
            this.isshowcheckbox.UseVisualStyleBackColor = true;
            this.isshowcheckbox.CheckedChanged += new System.EventHandler(this.isshowcheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "快速查询";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(19, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(654, 81);
            this.panel3.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_save_s);
            this.groupBox3.Controls.Add(this.btn_del_s);
            this.groupBox3.Controls.Add(this.btn_add_s);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Location = new System.Drawing.Point(3, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.groupBox3.Size = new System.Drawing.Size(646, 271);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "普通查询";
            this.toolTip.SetToolTip(this.groupBox3, "普通查询条件下拉框的宽度。默认（不设置）为120。（ERP3.0.2新增）");
            // 
            // btn_save_s
            // 
            this.btn_save_s.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_s.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save_s.Location = new System.Drawing.Point(472, 233);
            this.btn_save_s.Name = "btn_save_s";
            this.btn_save_s.Size = new System.Drawing.Size(48, 23);
            this.btn_save_s.TabIndex = 6;
            this.btn_save_s.Text = "保存";
            this.btn_save_s.UseVisualStyleBackColor = true;
            this.btn_save_s.Click += new System.EventHandler(this.btn_save_s_Click);
            // 
            // btn_del_s
            // 
            this.btn_del_s.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del_s.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del_s.Location = new System.Drawing.Point(582, 233);
            this.btn_del_s.Name = "btn_del_s";
            this.btn_del_s.Size = new System.Drawing.Size(48, 23);
            this.btn_del_s.TabIndex = 5;
            this.btn_del_s.Text = "删除";
            this.btn_del_s.UseVisualStyleBackColor = true;
            this.btn_del_s.Click += new System.EventHandler(this.btn_del_s_Click);
            // 
            // btn_add_s
            // 
            this.btn_add_s.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_s.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_s.Location = new System.Drawing.Point(527, 233);
            this.btn_add_s.Name = "btn_add_s";
            this.btn_add_s.Size = new System.Drawing.Size(48, 23);
            this.btn_add_s.TabIndex = 2;
            this.btn_add_s.Text = "新增";
            this.btn_add_s.UseVisualStyleBackColor = true;
            this.btn_add_s.Click += new System.EventHandler(this.btn_add_s_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(177, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 172);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "字段属性";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.txb_action_s, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label30, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txb_title_s, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txb_field_s, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmb_type_s, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmb_operator_s, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label12, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label13, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.ckb_grp_s, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txb_max_s, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txb_min_s, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txb_acc_s, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txb_returnvalue_s, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label16, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.txb_dt_s, 3, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(450, 152);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txb_action_s
            // 
            this.txb_action_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_action_s.Location = new System.Drawing.Point(93, 128);
            this.txb_action_s.Name = "txb_action_s";
            this.txb_action_s.Size = new System.Drawing.Size(129, 21);
            this.txb_action_s.TabIndex = 29;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(34, 132);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 28;
            this.label30.Text = "Action：";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "显示千分号：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "类型：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "字段名：";
            // 
            // txb_title_s
            // 
            this.txb_title_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_title_s.Location = new System.Drawing.Point(93, 3);
            this.txb_title_s.Name = "txb_title_s";
            this.txb_title_s.Size = new System.Drawing.Size(129, 21);
            this.txb_title_s.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "显示名：";
            // 
            // txb_field_s
            // 
            this.txb_field_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_field_s.Location = new System.Drawing.Point(318, 3);
            this.txb_field_s.Name = "txb_field_s";
            this.txb_field_s.Size = new System.Drawing.Size(129, 21);
            this.txb_field_s.TabIndex = 2;
            // 
            // cmb_type_s
            // 
            this.cmb_type_s.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_type_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_type_s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type_s.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_type_s.FormattingEnabled = true;
            this.cmb_type_s.Location = new System.Drawing.Point(93, 28);
            this.cmb_type_s.Name = "cmb_type_s";
            this.cmb_type_s.Size = new System.Drawing.Size(129, 20);
            this.cmb_type_s.TabIndex = 5;
            this.cmb_type_s.SelectedIndexChanged += new System.EventHandler(this.cmb_type_s_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "查询条件：";
            // 
            // cmb_operator_s
            // 
            this.cmb_operator_s.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_operator_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_operator_s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_operator_s.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_operator_s.FormattingEnabled = true;
            this.cmb_operator_s.Location = new System.Drawing.Point(318, 28);
            this.cmb_operator_s.Name = "cmb_operator_s";
            this.cmb_operator_s.Size = new System.Drawing.Size(129, 20);
            this.cmb_operator_s.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "最大值：";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(259, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "最小值：";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(235, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "保留小数位：";
            // 
            // ckb_grp_s
            // 
            this.ckb_grp_s.AutoSize = true;
            this.ckb_grp_s.Checked = true;
            this.ckb_grp_s.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_grp_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckb_grp_s.Location = new System.Drawing.Point(93, 78);
            this.ckb_grp_s.Name = "ckb_grp_s";
            this.ckb_grp_s.Size = new System.Drawing.Size(129, 19);
            this.ckb_grp_s.TabIndex = 13;
            this.toolTip.SetToolTip(this.ckb_grp_s, "是否显示千分号，默认为“true”。");
            this.ckb_grp_s.UseVisualStyleBackColor = false;
            // 
            // txb_max_s
            // 
            this.txb_max_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_max_s.Location = new System.Drawing.Point(93, 53);
            this.txb_max_s.Name = "txb_max_s";
            this.txb_max_s.Size = new System.Drawing.Size(129, 21);
            this.txb_max_s.TabIndex = 15;
            // 
            // txb_min_s
            // 
            this.txb_min_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_min_s.Location = new System.Drawing.Point(318, 53);
            this.txb_min_s.Name = "txb_min_s";
            this.txb_min_s.Size = new System.Drawing.Size(129, 21);
            this.txb_min_s.TabIndex = 16;
            // 
            // txb_acc_s
            // 
            this.txb_acc_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_acc_s.Location = new System.Drawing.Point(318, 78);
            this.txb_acc_s.Name = "txb_acc_s";
            this.txb_acc_s.Size = new System.Drawing.Size(129, 21);
            this.txb_acc_s.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "控件返回值：";
            // 
            // txb_returnvalue_s
            // 
            this.txb_returnvalue_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_returnvalue_s.Location = new System.Drawing.Point(93, 103);
            this.txb_returnvalue_s.Name = "txb_returnvalue_s";
            this.txb_returnvalue_s.Size = new System.Drawing.Size(129, 21);
            this.txb_returnvalue_s.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(247, 106);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "数据类型：";
            // 
            // txb_dt_s
            // 
            this.txb_dt_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_dt_s.Location = new System.Drawing.Point(318, 103);
            this.txb_dt_s.Name = "txb_dt_s";
            this.txb_dt_s.Size = new System.Drawing.Size(129, 21);
            this.txb_dt_s.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckblst_items_s);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 170);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询字段";
            // 
            // ckblst_items_s
            // 
            this.ckblst_items_s.CheckOnClick = true;
            this.ckblst_items_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckblst_items_s.FormattingEnabled = true;
            this.ckblst_items_s.Location = new System.Drawing.Point(3, 17);
            this.ckblst_items_s.Name = "ckblst_items_s";
            this.ckblst_items_s.Size = new System.Drawing.Size(153, 150);
            this.ckblst_items_s.TabIndex = 0;
            this.ckblst_items_s.SelectedIndexChanged += new System.EventHandler(this.ckblst_items_s_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txbTitleWidth, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(621, 28);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "下拉框宽度：";
            // 
            // txbTitleWidth
            // 
            this.txbTitleWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTitleWidth.Location = new System.Drawing.Point(96, 3);
            this.txbTitleWidth.Name = "txbTitleWidth";
            this.txbTitleWidth.Size = new System.Drawing.Size(211, 21);
            this.txbTitleWidth.TabIndex = 1;
            this.txbTitleWidth.Text = "120";
            // 
            // chbQueryInResult
            // 
            this.chbQueryInResult.AutoSize = true;
            this.chbQueryInResult.Location = new System.Drawing.Point(3, 28);
            this.chbQueryInResult.Name = "chbQueryInResult";
            this.chbQueryInResult.Size = new System.Drawing.Size(156, 16);
            this.chbQueryInResult.TabIndex = 7;
            this.chbQueryInResult.Text = "显示【结果中查找】按钮";
            this.toolTip.SetToolTip(this.chbQueryInResult, "是否显示【结果中查找】按钮。");
            this.chbQueryInResult.UseVisualStyleBackColor = true;
            this.chbQueryInResult.CheckedChanged += new System.EventHandler(this.chbQueryInResult_CheckedChanged);
            // 
            // chbCheckboxDefault
            // 
            this.chbCheckboxDefault.AutoSize = true;
            this.chbCheckboxDefault.Location = new System.Drawing.Point(313, 3);
            this.chbCheckboxDefault.Name = "chbCheckboxDefault";
            this.chbCheckboxDefault.Size = new System.Drawing.Size(156, 16);
            this.chbCheckboxDefault.TabIndex = 6;
            this.chbCheckboxDefault.Text = "默认勾选“视图内查询”";
            this.toolTip.SetToolTip(this.chbCheckboxDefault, "在“视图内查询”选项默认是否勾选。");
            this.chbCheckboxDefault.UseVisualStyleBackColor = true;
            this.chbCheckboxDefault.CheckedChanged += new System.EventHandler(this.chbCheckboxDefault_CheckedChanged);
            // 
            // chbIsshowCheckbox
            // 
            this.chbIsshowCheckbox.AutoSize = true;
            this.chbIsshowCheckbox.Checked = true;
            this.chbIsshowCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIsshowCheckbox.Location = new System.Drawing.Point(3, 3);
            this.chbIsshowCheckbox.Name = "chbIsshowCheckbox";
            this.chbIsshowCheckbox.Size = new System.Drawing.Size(132, 16);
            this.chbIsshowCheckbox.TabIndex = 5;
            this.chbIsshowCheckbox.Text = "显示“视图内查询”";
            this.toolTip.SetToolTip(this.chbIsshowCheckbox, "是否显示“视图内查询”复选框");
            this.chbIsshowCheckbox.UseVisualStyleBackColor = true;
            this.chbIsshowCheckbox.CheckedChanged += new System.EventHandler(this.chbIsshowCheckbox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btn_save_a);
            this.groupBox4.Controls.Add(this.btn_del_a);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.btn_add_a);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(3, 347);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.groupBox4.Size = new System.Drawing.Size(646, 343);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "高级查询";
            this.toolTip.SetToolTip(this.groupBox4, "普通查询条件下拉框的宽度。默认（不设置）为120。（ERP3.0.2新增）");
            // 
            // btn_save_a
            // 
            this.btn_save_a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save_a.Location = new System.Drawing.Point(470, 303);
            this.btn_save_a.Name = "btn_save_a";
            this.btn_save_a.Size = new System.Drawing.Size(48, 23);
            this.btn_save_a.TabIndex = 7;
            this.btn_save_a.Text = "保存";
            this.btn_save_a.UseVisualStyleBackColor = true;
            // 
            // btn_del_a
            // 
            this.btn_del_a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del_a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del_a.Location = new System.Drawing.Point(578, 303);
            this.btn_del_a.Name = "btn_del_a";
            this.btn_del_a.Size = new System.Drawing.Size(48, 23);
            this.btn_del_a.TabIndex = 5;
            this.btn_del_a.Text = "删除";
            this.btn_del_a.UseVisualStyleBackColor = true;
            this.btn_del_a.Click += new System.EventHandler(this.btn_del_a_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tableLayoutPanel4);
            this.groupBox5.Location = new System.Drawing.Point(177, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(456, 270);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "字段属性";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txb_title_a, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txb_field_a, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmb_type_a, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label21, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.cmb_operator_a, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label22, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label23, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.label24, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.ckb_grp_a, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.txb_max_a, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.txb_min_a, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.txb_acc_a, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.label25, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.txb_returnvalue_a, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label26, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.txb_dt_a, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.label28, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.rtxbSql, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.label27, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.cmbOption_a, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.btnEditOptions, 2, 6);
            this.tableLayoutPanel4.Controls.Add(this.label29, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.txb_action_a, 1, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(450, 250);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "显示千分号：";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(46, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 4;
            this.label18.Text = "类型：";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(259, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 3;
            this.label19.Text = "字段名：";
            // 
            // txb_title_a
            // 
            this.txb_title_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_title_a.Location = new System.Drawing.Point(93, 3);
            this.txb_title_a.Name = "txb_title_a";
            this.txb_title_a.Size = new System.Drawing.Size(129, 21);
            this.txb_title_a.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(34, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "显示名：";
            // 
            // txb_field_a
            // 
            this.txb_field_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_field_a.Location = new System.Drawing.Point(318, 3);
            this.txb_field_a.Name = "txb_field_a";
            this.txb_field_a.Size = new System.Drawing.Size(129, 21);
            this.txb_field_a.TabIndex = 2;
            // 
            // cmb_type_a
            // 
            this.cmb_type_a.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_type_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_type_a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type_a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_type_a.FormattingEnabled = true;
            this.cmb_type_a.Location = new System.Drawing.Point(93, 28);
            this.cmb_type_a.Name = "cmb_type_a";
            this.cmb_type_a.Size = new System.Drawing.Size(129, 20);
            this.cmb_type_a.TabIndex = 5;
            this.cmb_type_a.SelectedIndexChanged += new System.EventHandler(this.cmb_type_a_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(247, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 6;
            this.label21.Text = "查询条件：";
            // 
            // cmb_operator_a
            // 
            this.cmb_operator_a.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_operator_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_operator_a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_operator_a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_operator_a.FormattingEnabled = true;
            this.cmb_operator_a.Location = new System.Drawing.Point(318, 28);
            this.cmb_operator_a.Name = "cmb_operator_a";
            this.cmb_operator_a.Size = new System.Drawing.Size(129, 20);
            this.cmb_operator_a.TabIndex = 8;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(34, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 9;
            this.label22.Text = "最大值：";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(259, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 10;
            this.label23.Text = "最小值：";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(235, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 11;
            this.label24.Text = "保留小数位：";
            // 
            // ckb_grp_a
            // 
            this.ckb_grp_a.AutoSize = true;
            this.ckb_grp_a.Checked = true;
            this.ckb_grp_a.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_grp_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckb_grp_a.Location = new System.Drawing.Point(93, 78);
            this.ckb_grp_a.Name = "ckb_grp_a";
            this.ckb_grp_a.Size = new System.Drawing.Size(129, 19);
            this.ckb_grp_a.TabIndex = 13;
            this.toolTip.SetToolTip(this.ckb_grp_a, "是否显示千分号，默认为“true”。");
            this.ckb_grp_a.UseVisualStyleBackColor = false;
            // 
            // txb_max_a
            // 
            this.txb_max_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_max_a.Location = new System.Drawing.Point(93, 53);
            this.txb_max_a.Name = "txb_max_a";
            this.txb_max_a.Size = new System.Drawing.Size(129, 21);
            this.txb_max_a.TabIndex = 15;
            // 
            // txb_min_a
            // 
            this.txb_min_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_min_a.Location = new System.Drawing.Point(318, 53);
            this.txb_min_a.Name = "txb_min_a";
            this.txb_min_a.Size = new System.Drawing.Size(129, 21);
            this.txb_min_a.TabIndex = 16;
            // 
            // txb_acc_a
            // 
            this.txb_acc_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_acc_a.Location = new System.Drawing.Point(318, 78);
            this.txb_acc_a.Name = "txb_acc_a";
            this.txb_acc_a.Size = new System.Drawing.Size(129, 21);
            this.txb_acc_a.TabIndex = 17;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 106);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 12);
            this.label25.TabIndex = 18;
            this.label25.Text = "控件返回值：";
            // 
            // txb_returnvalue_a
            // 
            this.txb_returnvalue_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_returnvalue_a.Location = new System.Drawing.Point(93, 103);
            this.txb_returnvalue_a.Name = "txb_returnvalue_a";
            this.txb_returnvalue_a.Size = new System.Drawing.Size(129, 21);
            this.txb_returnvalue_a.TabIndex = 19;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(247, 106);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 20;
            this.label26.Text = "数据类型：";
            // 
            // txb_dt_a
            // 
            this.txb_dt_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_dt_a.Location = new System.Drawing.Point(318, 103);
            this.txb_dt_a.Name = "txb_dt_a";
            this.txb_dt_a.Size = new System.Drawing.Size(129, 21);
            this.txb_dt_a.TabIndex = 21;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(52, 211);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 12);
            this.label28.TabIndex = 25;
            this.label28.Text = "SQL：";
            // 
            // rtxbSql
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.rtxbSql, 3);
            this.rtxbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxbSql.Location = new System.Drawing.Point(93, 188);
            this.rtxbSql.Name = "rtxbSql";
            this.rtxbSql.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxbSql.Size = new System.Drawing.Size(354, 59);
            this.rtxbSql.TabIndex = 26;
            this.rtxbSql.Text = "";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(22, 164);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 22;
            this.label27.Text = "下拉选项：";
            // 
            // cmbOption_a
            // 
            this.cmbOption_a.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbOption_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOption_a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption_a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOption_a.FormattingEnabled = true;
            this.cmbOption_a.Items.AddRange(new object[] {
            "text",
            "datetime",
            "number",
            "lookup",
            "select"});
            this.cmbOption_a.Location = new System.Drawing.Point(93, 158);
            this.cmbOption_a.Name = "cmbOption_a";
            this.cmbOption_a.Size = new System.Drawing.Size(129, 20);
            this.cmbOption_a.TabIndex = 23;
            // 
            // btnEditOptions
            // 
            this.btnEditOptions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditOptions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditOptions.Location = new System.Drawing.Point(228, 160);
            this.btnEditOptions.Name = "btnEditOptions";
            this.btnEditOptions.Size = new System.Drawing.Size(84, 20);
            this.btnEditOptions.TabIndex = 24;
            this.btnEditOptions.Text = "编辑选项";
            this.btnEditOptions.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(34, 134);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 27;
            this.label29.Text = "Action：";
            // 
            // txb_action_a
            // 
            this.txb_action_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_action_a.Location = new System.Drawing.Point(93, 128);
            this.txb_action_a.Name = "txb_action_a";
            this.txb_action_a.Size = new System.Drawing.Size(129, 21);
            this.txb_action_a.TabIndex = 28;
            // 
            // btn_add_a
            // 
            this.btn_add_a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_a.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_a.Location = new System.Drawing.Point(524, 303);
            this.btn_add_a.Name = "btn_add_a";
            this.btn_add_a.Size = new System.Drawing.Size(48, 23);
            this.btn_add_a.TabIndex = 2;
            this.btn_add_a.Text = "新增";
            this.btn_add_a.UseVisualStyleBackColor = true;
            this.btn_add_a.Click += new System.EventHandler(this.btn_add_a_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ckblst_items_a);
            this.groupBox6.Location = new System.Drawing.Point(12, 27);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(159, 270);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "查询字段";
            // 
            // ckblst_items_a
            // 
            this.ckblst_items_a.CheckOnClick = true;
            this.ckblst_items_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckblst_items_a.FormattingEnabled = true;
            this.ckblst_items_a.Location = new System.Drawing.Point(3, 17);
            this.ckblst_items_a.Name = "ckblst_items_a";
            this.ckblst_items_a.Size = new System.Drawing.Size(153, 250);
            this.ckblst_items_a.TabIndex = 0;
            this.ckblst_items_a.SelectedIndexChanged += new System.EventHandler(this.ckblst_items_a_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Location = new System.Drawing.Point(19, 133);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(654, 716);
            this.panel4.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chbCheckboxDefault, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbIsshowCheckbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbQueryInResult, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 50);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // AppFindControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "AppFindControl";
            this.Size = new System.Drawing.Size(691, 873);
            this.Controls.SetChildIndex(this.block, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appFindQueryItemBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Design

        #region 联动

        protected override void Bind(AppControl control)
        {
            chbIsshowCheckbox.Checked = control.Query.IsShowCheckbox.ToBoolean();
            chbCheckboxDefault.Checked = control.Query.IsShowCheckboxDefault.ToBoolean();
            chbQueryInResult.Checked = control.Query.IsShowQueryInResult.ToBoolean();

            base.Bind(control);
        }

        /// <summary>
        /// 显示视图内查询checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbIsshowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            isshowcheckbox.Visible = chbIsshowCheckbox.Checked;
            //chbCheckboxDefault.Visible = chbIsshowCheckbox.Checked;
        }

        /// <summary>
        /// 视图内查询默认勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbCheckboxDefault_CheckedChanged(object sender, EventArgs e)
        {
            isshowcheckbox.Checked = chbCheckboxDefault.Checked;
        }

        /// <summary>
        /// 显示结果中查找checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbQueryInResult_CheckedChanged(object sender, EventArgs e)
        {
            btnQueryInResult.Visible = chbQueryInResult.Checked;
        }

        /// <summary>
        /// 快速预览上 视图内查询与配置项中 默认勾选“视图内查询”联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isshowcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            chbCheckboxDefault.Checked = isshowcheckbox.Checked;
        }

        #endregion 联动

        #region 标准查询

        private List<AppFindQueryItem> standard = new List<AppFindQueryItem>();

        /// <summary>
        /// 绑定标准查询checkedlistbox
        /// </summary>
        private void BindStandard()
        {
            ckblst_items_s.DataSource = null;

            ckblst_items_s.DataSource = standard;
            ckblst_items_s.ValueMember = "Field";
            ckblst_items_s.DisplayMember = "Title";
        }

        /// <summary>
        /// 新增标准查询项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_s_Click(object sender, EventArgs e)
        {
            AppFindQueryItem item = new AppFindQueryItem();
            item.Action = txb_action_s.Text.Trim();
            item.Field = txb_field_s.Text.Trim();
            item.Operator = cmb_operator_s.SelectedValue.ToString();
            item.Sql = null;
            item.Title = txb_title_s.Text.Trim();
            item.Type = cmb_type_s.SelectedValue.ToString();
            item.Acc = txb_acc_s.Text.Trim();
            item.Dt = txb_dt_s.Text.Trim();
            item.Grp = ckb_grp_s.Checked.ToString();
            item.Max = txb_max_s.Text.Trim();
            item.Min = txb_min_s.Text.Trim();
            standard.Add(item);

            BindStandard();
            ClearStandardPanel();
        }

        /// <summary>
        /// 清空标准查询编辑框
        /// </summary>
        private void ClearStandardPanel()
        {
            txb_action_s.Clear();
            txb_field_s.Clear();
            txb_title_s.Clear();
            txb_acc_s.Clear();
            txb_dt_s.Clear();
            txb_max_s.Clear();
            txb_min_s.Clear();
        }

        /// <summary>
        /// 编辑标准查询项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckblst_items_s_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ckblst_items_s.SelectedIndex > -1)
            {
                AppFindQueryItem item = standard[ckblst_items_s.SelectedIndex];
                txb_action_s.Text = item.Action;
                txb_field_s.Text = item.Field;
                cmb_operator_s.SelectedValue = item.Operator;
                item.Sql = null;
                txb_title_s.Text = item.Title;
                cmb_type_s.SelectedValue = item.Type;
                txb_acc_s.Text = item.Acc;
                txb_dt_s.Text = item.Dt;
                bool b = false;
                bool.TryParse(item.Grp, out b);
                ckb_grp_s.Checked = b;
                txb_max_s.Text = item.Max;
                txb_min_s.Text = item.Min;
            }
        }

        /// <summary>
        /// 保存标准查询项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_s_Click(object sender, EventArgs e)
        {
            if (ckblst_items_s.SelectedIndex > -1)
            {
                AppFindQueryItem item = standard[ckblst_items_s.SelectedIndex];

                item.Action = txb_action_s.Text.Trim();
                item.Field = txb_field_s.Text.Trim();
                item.Operator = cmb_operator_s.SelectedValue.ToString();
                item.Sql = null;
                item.Title = txb_title_s.Text.Trim();
                item.Type = cmb_type_s.SelectedValue.ToString();
                item.Acc = txb_acc_s.Text.Trim();
                item.Dt = txb_dt_s.Text.Trim();
                item.Grp = ckb_grp_s.Checked.ToString();
                item.Max = txb_max_s.Text.Trim();
                item.Min = txb_min_s.Text.Trim();

                ckblst_items_s.Refresh();
            }
        }

        /// <summary>
        /// 删除标准查询选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_s_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var checkedItem in ckblst_items_s.CheckedItems)
                {
                    standard.Remove(checkedItem as AppFindQueryItem);
                }

                BindStandard();
            }
        }

        #endregion 标准查询

        #region 高级查询

        private List<AppFindQueryItem> advanced = new List<AppFindQueryItem>();

        /// <summary>
        /// 绑定标准查询checkedlistbox
        /// </summary>
        private void BindAdvanced()
        {
            ckblst_items_a.DataSource = null;

            ckblst_items_a.DataSource = advanced;
            ckblst_items_a.ValueMember = "Field";
            ckblst_items_a.DisplayMember = "Title";
        }

        private void btn_add_a_Click(object sender, EventArgs e)
        {
            AppFindQueryItem item = new AppFindQueryItem();
            item.Action = txb_action_a.Text.Trim();
            item.Field = txb_field_a.Text.Trim();
            item.Operator = cmb_operator_a.SelectedValue.ToString();
            item.Sql = rtxbSql.Text.Trim();
            item.Title = txb_title_a.Text.Trim();
            item.Type = cmb_type_a.SelectedValue.ToString();
            item.Acc = txb_acc_a.Text.Trim();
            item.Dt = txb_dt_a.Text.Trim();
            item.Grp = ckb_grp_a.Checked.ToString();
            item.Max = txb_max_a.Text.Trim();
            item.Min = txb_min_a.Text.Trim();
            advanced.Add(item);

            BindAdvanced();
            ClearAdvancedPanel();
        }

        /// <summary>
        /// 清空高级查询编辑框
        /// </summary>
        private void ClearAdvancedPanel()
        {
            txb_action_a.Clear();
            txb_field_a.Clear();
            txb_title_a.Clear();
            txb_acc_a.Clear();
            txb_dt_a.Clear();
            txb_max_a.Clear();
            txb_min_a.Clear();
        }

        /// <summary>
        /// 编辑高级查询项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckblst_items_a_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ckblst_items_a.SelectedIndex > -1)
            {
                AppFindQueryItem item = advanced[ckblst_items_a.SelectedIndex];
                txb_action_a.Text = item.Action;
                txb_field_a.Text = item.Field;
                cmb_operator_a.SelectedValue = item.Operator;
                txb_title_a.Text = item.Title;
                cmb_type_a.SelectedValue = item.Type;
                txb_acc_a.Text = item.Acc;
                txb_dt_a.Text = item.Dt;
                bool b = false;
                bool.TryParse(item.Grp, out b);
                ckb_grp_a.Checked = b;
                txb_max_a.Text = item.Max;
                txb_min_a.Text = item.Min;
                rtxbSql.Text = item.Sql;
            }
        }

        private void btn_del_a_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var checkedItem in ckblst_items_a.CheckedItems)
                {
                    advanced.Remove(checkedItem as AppFindQueryItem);
                }

                BindAdvanced();
            }
        }

        #endregion 高级查询

        #region Bind ComboBox

        private void BindComboBox()
        {
            //绑定查询字段CheckBoxList
            ckblst_items_s.DataSource = standard;
            ckblst_items_s.ValueMember = "Field";
            ckblst_items_s.DisplayMember = "Title";

            var operatorKeyValues = EnumHelper.GetEnumKeyValue(typeof(OperatorType));

            //绑定标准查询类型下拉框
            cmb_operator_s.DataSource = null;
            cmb_operator_s.ValueMember = "Value";
            cmb_operator_s.DisplayMember = "Text";
            cmb_operator_s.DataSource = CopyHelper.CopyGenericType(operatorKeyValues);

            //绑定高级查询类型下拉框
            cmb_operator_a.DataSource = null;
            cmb_operator_a.ValueMember = "Value";
            cmb_operator_a.DisplayMember = "Text";
            cmb_operator_a.DataSource = CopyHelper.CopyGenericType(operatorKeyValues);

            //绑定标准查询控件类型下拉框
            cmb_type_s.DataSource = null;
            cmb_type_s.ValueMember = "Value";
            cmb_type_s.DisplayMember = "Text";
            cmb_type_s.DataSource = GetSQueryItemTypeList();

            //绑定标准查询控件类型下拉框
            cmb_type_a.DataSource = null;
            cmb_type_a.ValueMember = "Value";
            cmb_type_a.DisplayMember = "Text";
            cmb_type_a.DataSource = GetAQueryItemTypeList();
        }

        /// <summary>
        /// 标准查询支持的控件类型列表
        /// </summary>
        /// <returns></returns>
        private List<EnumKvPair> GetSQueryItemTypeList()
        {
            List<EnumKvPair> list = new List<EnumKvPair>();
            list.Add(new EnumKvPair("文本控件", "text"));
            list.Add(new EnumKvPair("日期控件", "datetime"));
            list.Add(new EnumKvPair("数值控件", "number"));
            list.Add(new EnumKvPair("查找控件", "lookup"));
            return list;
        }

        /// <summary>
        /// 高级查询支持的控件类型列表
        /// </summary>
        /// <returns></returns>
        private List<EnumKvPair> GetAQueryItemTypeList()
        {
            List<EnumKvPair> list = GetSQueryItemTypeList();
            list.Add(new EnumKvPair("选择控件", "select"));
            return list;
        }

        #endregion Bind ComboBox

        #region 选择不同控件类型

        private void cmb_type_s_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type_s.SelectedValue.ToString().EqualIgnoreCase("number"))
            {
                txb_max_s.Enabled = true;
                txb_acc_s.Enabled = true;
                txb_dt_s.Enabled = true;
                txb_min_s.Enabled = true;
                ckb_grp_s.Enabled = true;
            }
            else
            {
                txb_max_s.Enabled = false;
                txb_acc_s.Enabled = false;
                txb_dt_s.Enabled = false;
                txb_min_s.Enabled = false;
                ckb_grp_s.Enabled = false;
            }
        }

        private void cmb_type_a_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type_a.SelectedValue.ToString().EqualIgnoreCase("number"))
            {
                txb_max_a.Enabled = true;
                txb_acc_a.Enabled = true;
                txb_dt_a.Enabled = true;
                txb_min_a.Enabled = true;
                ckb_grp_a.Enabled = true;
            }
            else
            {
                txb_max_a.Enabled = false;
                txb_acc_a.Enabled = false;
                txb_dt_a.Enabled = false;
                txb_min_a.Enabled = false;
                ckb_grp_a.Enabled = false;
            }
        }

        #endregion 选择不同控件类型

    }
}