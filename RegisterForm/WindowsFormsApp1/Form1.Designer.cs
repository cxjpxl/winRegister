namespace WindowsFormsApp1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outPutBtn = new System.Windows.Forms.Button();
            this.emailEdit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.qqEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.phoneNumEdit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.moneyPwdEdit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameEidt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pwdEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sysDataGridView = new System.Windows.Forms.DataGridView();
            this.emailStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userEditStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pwdEditStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameEidtStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyPwdEditStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumEditStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qqEditStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearEditStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ansStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outPutBtn);
            this.groupBox1.Controls.Add(this.emailEdit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.qqEdit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.phoneNumEdit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.registerBtn);
            this.groupBox1.Controls.Add(this.moneyPwdEdit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nameEidt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pwdEdit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.userEdit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "注册信息添写";
            // 
            // outPutBtn
            // 
            this.outPutBtn.Location = new System.Drawing.Point(11, 316);
            this.outPutBtn.Name = "outPutBtn";
            this.outPutBtn.Size = new System.Drawing.Size(223, 22);
            this.outPutBtn.TabIndex = 17;
            this.outPutBtn.Text = "导出";
            this.outPutBtn.UseVisualStyleBackColor = true;
            this.outPutBtn.Click += new System.EventHandler(this.outPutBtn_Click);
            // 
            // emailEdit
            // 
            this.emailEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emailEdit.Location = new System.Drawing.Point(80, 223);
            this.emailEdit.Name = "emailEdit";
            this.emailEdit.Size = new System.Drawing.Size(164, 23);
            this.emailEdit.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(8, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "邮箱：";
            // 
            // qqEdit
            // 
            this.qqEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qqEdit.Location = new System.Drawing.Point(79, 189);
            this.qqEdit.Name = "qqEdit";
            this.qqEdit.Size = new System.Drawing.Size(164, 23);
            this.qqEdit.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(7, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "QQ号码：";
            // 
            // phoneNumEdit
            // 
            this.phoneNumEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneNumEdit.Location = new System.Drawing.Point(80, 156);
            this.phoneNumEdit.Name = "phoneNumEdit";
            this.phoneNumEdit.Size = new System.Drawing.Size(164, 23);
            this.phoneNumEdit.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(8, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "手机号码：";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(10, 266);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(224, 23);
            this.registerBtn.TabIndex = 10;
            this.registerBtn.Text = "批量注册";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // moneyPwdEdit
            // 
            this.moneyPwdEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.moneyPwdEdit.Location = new System.Drawing.Point(80, 124);
            this.moneyPwdEdit.Name = "moneyPwdEdit";
            this.moneyPwdEdit.Size = new System.Drawing.Size(164, 23);
            this.moneyPwdEdit.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(8, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "取款密码：";
            // 
            // nameEidt
            // 
            this.nameEidt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameEidt.Location = new System.Drawing.Point(80, 93);
            this.nameEidt.Name = "nameEidt";
            this.nameEidt.Size = new System.Drawing.Size(164, 23);
            this.nameEidt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "取款姓名：";
            // 
            // pwdEdit
            // 
            this.pwdEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwdEdit.Location = new System.Drawing.Point(53, 61);
            this.pwdEdit.Name = "pwdEdit";
            this.pwdEdit.Size = new System.Drawing.Size(190, 23);
            this.pwdEdit.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // userEdit
            // 
            this.userEdit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userEdit.Location = new System.Drawing.Point(53, 31);
            this.userEdit.Name = "userEdit";
            this.userEdit.Size = new System.Drawing.Size(190, 23);
            this.userEdit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号：";
            // 
            // sysDataGridView
            // 
            this.sysDataGridView.AllowUserToAddRows = false;
            this.sysDataGridView.AllowUserToDeleteRows = false;
            this.sysDataGridView.AllowUserToResizeColumns = false;
            this.sysDataGridView.AllowUserToResizeRows = false;
            this.sysDataGridView.AutoGenerateColumns = false;
            this.sysDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sysDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagDataGridViewTextBoxColumn,
            this.responseStringDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.webUrlDataGridViewTextBoxColumn,
            this.userEditStrDataGridViewTextBoxColumn,
            this.pwdEditStrDataGridViewTextBoxColumn,
            this.nameEidtStrDataGridViewTextBoxColumn,
            this.moneyPwdEditStrDataGridViewTextBoxColumn,
            this.phoneNumEditStrDataGridViewTextBoxColumn,
            this.qqEditStrDataGridViewTextBoxColumn,
            this.emailStrDataGridViewTextBoxColumn,
            this.yearEditStrDataGridViewTextBoxColumn,
            this.questionStrDataGridViewTextBoxColumn,
            this.ansStrDataGridViewTextBoxColumn});
            this.sysDataGridView.DataSource = this.registerInfoBindingSource;
            this.sysDataGridView.Location = new System.Drawing.Point(308, 26);
            this.sysDataGridView.Name = "sysDataGridView";
            this.sysDataGridView.RowHeadersVisible = false;
            this.sysDataGridView.RowTemplate.Height = 23;
            this.sysDataGridView.Size = new System.Drawing.Size(590, 384);
            this.sysDataGridView.TabIndex = 1;
            this.sysDataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sysDataGridView_Scroll);
            // 
            // emailStrDataGridViewTextBoxColumn
            // 
            this.emailStrDataGridViewTextBoxColumn.DataPropertyName = "emailStr";
            this.emailStrDataGridViewTextBoxColumn.HeaderText = "邮箱";
            this.emailStrDataGridViewTextBoxColumn.Name = "emailStrDataGridViewTextBoxColumn";
            this.emailStrDataGridViewTextBoxColumn.Width = 150;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tagDataGridViewTextBoxColumn
            // 
            this.tagDataGridViewTextBoxColumn.DataPropertyName = "tag";
            this.tagDataGridViewTextBoxColumn.HeaderText = "系统";
            this.tagDataGridViewTextBoxColumn.Name = "tagDataGridViewTextBoxColumn";
            this.tagDataGridViewTextBoxColumn.ReadOnly = true;
            this.tagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tagDataGridViewTextBoxColumn.Width = 50;
            // 
            // responseStringDataGridViewTextBoxColumn
            // 
            this.responseStringDataGridViewTextBoxColumn.DataPropertyName = "responseString";
            this.responseStringDataGridViewTextBoxColumn.HeaderText = "结果";
            this.responseStringDataGridViewTextBoxColumn.Name = "responseStringDataGridViewTextBoxColumn";
            this.responseStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.responseStringDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.responseStringDataGridViewTextBoxColumn.Width = 60;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Visible = false;
            this.statusDataGridViewTextBoxColumn.Width = 66;
            // 
            // webUrlDataGridViewTextBoxColumn
            // 
            this.webUrlDataGridViewTextBoxColumn.DataPropertyName = "webUrl";
            this.webUrlDataGridViewTextBoxColumn.HeaderText = "网址";
            this.webUrlDataGridViewTextBoxColumn.Name = "webUrlDataGridViewTextBoxColumn";
            this.webUrlDataGridViewTextBoxColumn.ReadOnly = true;
            this.webUrlDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.webUrlDataGridViewTextBoxColumn.Width = 150;
            // 
            // userEditStrDataGridViewTextBoxColumn
            // 
            this.userEditStrDataGridViewTextBoxColumn.DataPropertyName = "userEditStr";
            this.userEditStrDataGridViewTextBoxColumn.HeaderText = "账户";
            this.userEditStrDataGridViewTextBoxColumn.Name = "userEditStrDataGridViewTextBoxColumn";
            this.userEditStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.userEditStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pwdEditStrDataGridViewTextBoxColumn
            // 
            this.pwdEditStrDataGridViewTextBoxColumn.DataPropertyName = "pwdEditStr";
            this.pwdEditStrDataGridViewTextBoxColumn.HeaderText = "密码";
            this.pwdEditStrDataGridViewTextBoxColumn.Name = "pwdEditStrDataGridViewTextBoxColumn";
            this.pwdEditStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.pwdEditStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nameEidtStrDataGridViewTextBoxColumn
            // 
            this.nameEidtStrDataGridViewTextBoxColumn.DataPropertyName = "nameEidtStr";
            this.nameEidtStrDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.nameEidtStrDataGridViewTextBoxColumn.Name = "nameEidtStrDataGridViewTextBoxColumn";
            this.nameEidtStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameEidtStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // moneyPwdEditStrDataGridViewTextBoxColumn
            // 
            this.moneyPwdEditStrDataGridViewTextBoxColumn.DataPropertyName = "moneyPwdEditStr";
            this.moneyPwdEditStrDataGridViewTextBoxColumn.HeaderText = "提款密码";
            this.moneyPwdEditStrDataGridViewTextBoxColumn.Name = "moneyPwdEditStrDataGridViewTextBoxColumn";
            this.moneyPwdEditStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.moneyPwdEditStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // phoneNumEditStrDataGridViewTextBoxColumn
            // 
            this.phoneNumEditStrDataGridViewTextBoxColumn.DataPropertyName = "phoneNumEditStr";
            this.phoneNumEditStrDataGridViewTextBoxColumn.HeaderText = "手机号码";
            this.phoneNumEditStrDataGridViewTextBoxColumn.Name = "phoneNumEditStrDataGridViewTextBoxColumn";
            this.phoneNumEditStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneNumEditStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // qqEditStrDataGridViewTextBoxColumn
            // 
            this.qqEditStrDataGridViewTextBoxColumn.DataPropertyName = "qqEditStr";
            this.qqEditStrDataGridViewTextBoxColumn.HeaderText = "QQ号码";
            this.qqEditStrDataGridViewTextBoxColumn.Name = "qqEditStrDataGridViewTextBoxColumn";
            this.qqEditStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.qqEditStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // yearEditStrDataGridViewTextBoxColumn
            // 
            this.yearEditStrDataGridViewTextBoxColumn.DataPropertyName = "yearEditStr";
            this.yearEditStrDataGridViewTextBoxColumn.HeaderText = "出生年月";
            this.yearEditStrDataGridViewTextBoxColumn.Name = "yearEditStrDataGridViewTextBoxColumn";
            this.yearEditStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearEditStrDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // questionStrDataGridViewTextBoxColumn
            // 
            this.questionStrDataGridViewTextBoxColumn.DataPropertyName = "questionStr";
            this.questionStrDataGridViewTextBoxColumn.HeaderText = "questionStr";
            this.questionStrDataGridViewTextBoxColumn.Name = "questionStrDataGridViewTextBoxColumn";
            this.questionStrDataGridViewTextBoxColumn.Visible = false;
            this.questionStrDataGridViewTextBoxColumn.Width = 96;
            // 
            // ansStrDataGridViewTextBoxColumn
            // 
            this.ansStrDataGridViewTextBoxColumn.DataPropertyName = "ansStr";
            this.ansStrDataGridViewTextBoxColumn.HeaderText = "ansStr";
            this.ansStrDataGridViewTextBoxColumn.Name = "ansStrDataGridViewTextBoxColumn";
            this.ansStrDataGridViewTextBoxColumn.Visible = false;
            this.ansStrDataGridViewTextBoxColumn.Width = 66;
            // 
            // registerInfoBindingSource
            // 
            this.registerInfoBindingSource.DataSource = typeof(WindowsFormsApp1.utlis.RegisterInfo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 422);
            this.Controls.Add(this.sysDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userEdit;
        private System.Windows.Forms.TextBox pwdEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameEidt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox moneyPwdEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox phoneNumEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox qqEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView sysDataGridView;
        private System.Windows.Forms.BindingSource registerInfoBindingSource;
        private System.Windows.Forms.TextBox emailEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn webUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userEditStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pwdEditStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameEidtStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyPwdEditStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumEditStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qqEditStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearEditStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ansStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button outPutBtn;
        private System.Windows.Forms.Timer timer1;
    }
}

