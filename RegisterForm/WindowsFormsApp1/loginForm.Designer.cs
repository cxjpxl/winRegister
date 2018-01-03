namespace WindowsFormsApp1
{
    partial class loginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginSysBtn = new System.Windows.Forms.Button();
            this.codePwdEdit = new System.Windows.Forms.TextBox();
            this.codePwdlable = new System.Windows.Forms.Label();
            this.codeUserEdit = new System.Windows.Forms.TextBox();
            this.codeUserLable = new System.Windows.Forms.Label();
            this.userText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginSysBtn
            // 
            this.loginSysBtn.Location = new System.Drawing.Point(45, 237);
            this.loginSysBtn.Name = "loginSysBtn";
            this.loginSysBtn.Size = new System.Drawing.Size(246, 29);
            this.loginSysBtn.TabIndex = 15;
            this.loginSysBtn.Text = "登录";
            this.loginSysBtn.UseVisualStyleBackColor = true;
            this.loginSysBtn.Click += new System.EventHandler(this.loginSysBtn_Click);
            // 
            // codePwdEdit
            // 
            this.codePwdEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codePwdEdit.Location = new System.Drawing.Point(129, 173);
            this.codePwdEdit.Name = "codePwdEdit";
            this.codePwdEdit.PasswordChar = '*';
            this.codePwdEdit.Size = new System.Drawing.Size(172, 26);
            this.codePwdEdit.TabIndex = 14;
            // 
            // codePwdlable
            // 
            this.codePwdlable.AutoSize = true;
            this.codePwdlable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codePwdlable.ForeColor = System.Drawing.Color.Red;
            this.codePwdlable.Location = new System.Drawing.Point(42, 178);
            this.codePwdlable.Name = "codePwdlable";
            this.codePwdlable.Size = new System.Drawing.Size(72, 16);
            this.codePwdlable.TabIndex = 13;
            this.codePwdlable.Text = "打码密码";
            // 
            // codeUserEdit
            // 
            this.codeUserEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeUserEdit.Location = new System.Drawing.Point(129, 129);
            this.codeUserEdit.Name = "codeUserEdit";
            this.codeUserEdit.Size = new System.Drawing.Size(172, 26);
            this.codeUserEdit.TabIndex = 12;
            // 
            // codeUserLable
            // 
            this.codeUserLable.AutoSize = true;
            this.codeUserLable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeUserLable.ForeColor = System.Drawing.Color.Red;
            this.codeUserLable.Location = new System.Drawing.Point(42, 134);
            this.codeUserLable.Name = "codeUserLable";
            this.codeUserLable.Size = new System.Drawing.Size(72, 16);
            this.codeUserLable.TabIndex = 11;
            this.codeUserLable.Text = "打码账户";
            // 
            // userText
            // 
            this.userText.AutoSize = true;
            this.userText.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userText.ForeColor = System.Drawing.Color.Brown;
            this.userText.Location = new System.Drawing.Point(54, 33);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(202, 24);
            this.userText.TabIndex = 8;
            this.userText.Text = "体育投注注册系统";
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 300);
            this.Controls.Add(this.loginSysBtn);
            this.Controls.Add(this.codePwdEdit);
            this.Controls.Add(this.codePwdlable);
            this.Controls.Add(this.codeUserEdit);
            this.Controls.Add(this.codeUserLable);
            this.Controls.Add(this.userText);
            this.Name = "loginForm";
            this.Text = "注册";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginSysBtn;
        private System.Windows.Forms.TextBox codePwdEdit;
        private System.Windows.Forms.Label codePwdlable;
        private System.Windows.Forms.TextBox codeUserEdit;
        private System.Windows.Forms.Label codeUserLable;
        private System.Windows.Forms.Label userText;
    }
}