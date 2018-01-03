﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.utils;
using WindowsFormsApp1.utlis;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private List<RegisterInfo> list = new List<RegisterInfo>();
        private BindingSource customersBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            HttpUtils.setMaxContectionNum(200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = FileUtils.ReadUrls(@"C:\register.txt");
            this.sysDataGridView.MultiSelect = false;
            this.customersBindingSource.DataSource = list;
            this.sysDataGridView.DataSource = this.customersBindingSource;
            // customersBindingSource.ResetBindings(true);
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //点击批量注册
        private void registerBtn_Click(object sender, EventArgs e)
        {

         /*   userEdit.Text = "ccc11116";
            pwdEdit.Text = "a123456";
            curPwdEdit.Text = "a123456";
            nameEidt.Text = "王姆都";
            moneyPwdEdit.Text = "123456";
            phoneNumEdit.Text = "13539322122";
            qqEdit.Text = "8754222";
            emailEdit.Text = "8754222@qq.com";*/
            String userEditStr = userEdit.Text.ToString().Trim();
            if (String.IsNullOrEmpty(userEditStr)) {
                MessageBox.Show("账号不能为空!");
                return;
            }

            if (!FormUtils.canGo(userEditStr, "^[a-z](?![a-z]+$)[0-9a-z]{5,9}$")) {
                MessageBox.Show("账号必须小写字母开头，含小写和数字，6-10位");
                return;
            }

            String pwdEditStr = pwdEdit.Text.ToString().Trim();
            if (String.IsNullOrEmpty(pwdEditStr))
            {
                MessageBox.Show("密码不能为空!");
                return;
            }
            if (!FormUtils.canGo(pwdEditStr, "^[a-z](?![a-z]+$)[0-9a-z]{5,9}$"))
            {
                MessageBox.Show("密码必须小写字母开头，含小写和数字，6-10位");
                return;
            }


            String nameEidtStr = nameEidt.Text.ToString().Trim();
            if (String.IsNullOrEmpty(nameEidtStr))
            {
                MessageBox.Show("姓名不能为空!");
                return;
            }

            if (!FormUtils.canGo(nameEidtStr, "[^\u0000-\u00FF]")) {
                MessageBox.Show("真实姓名必须是中文!");
                return;
            }

            String moneyPwdEditStr = moneyPwdEdit.Text.ToString().Trim();
            if (String.IsNullOrEmpty(moneyPwdEditStr))
            {
                MessageBox.Show("提款密码不能为空!");
                return;
            }

            if (!FormUtils.canGo(moneyPwdEditStr, "^[0-9]{6}$"))
            {
                MessageBox.Show("提款密码为6位数字");
                return;
            }

            String phoneNumEditStr = phoneNumEdit.Text.ToString().Trim();
            if (String.IsNullOrEmpty(phoneNumEditStr))
            {
                MessageBox.Show("手机号码不能为空!");
                return;
            }

            if (!FormUtils.canGo(phoneNumEditStr, "^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$"))
            {
                MessageBox.Show("手机号码格式不正确!");
                return;
            }

            String qqEditStr = qqEdit.Text.ToString().Trim();
            if (String.IsNullOrEmpty(qqEditStr))
            {
                MessageBox.Show("QQ号码不能为空!");
                return;
            }


            if (!FormUtils.canGo(qqEditStr, "^[0-9]{6,12}$"))
            {
                MessageBox.Show("qq号码为纯数字，6-12位!");
                return;
            }

            String emailStr = emailEdit.Text.ToString();
            if (!FormUtils.canGo(emailStr, "^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\\.[a-zA-Z0-9_-]+)+$"))
            {
                MessageBox.Show("邮箱格式错误");
                return;
            }
            
            String yearEditStr = "1984-01-03";

            Config.httpTag++;

            //数据源的处理
            for (int i = 0; i < list.Count; i++) {
                RegisterInfo registerInfo = list[i];
                registerInfo.userEditStr = userEditStr;
                registerInfo.pwdEditStr = pwdEditStr;
                registerInfo.nameEidtStr = nameEidtStr;
                registerInfo.moneyPwdEditStr = moneyPwdEditStr;
                registerInfo.emailStr = emailStr;
                if (registerInfo.tag.Equals("A")  //这些密码都是4位的
                    || registerInfo.tag.Equals("U")
                    || registerInfo.tag.Equals("R")
                    || registerInfo.tag.Equals("G")
                    || registerInfo.tag.Equals("F"))
                {
                    registerInfo.moneyPwdEditStr = moneyPwdEditStr.Substring(0, 4);
                }
                registerInfo.phoneNumEditStr = phoneNumEditStr;
                registerInfo.qqEditStr = qqEditStr;
                registerInfo.yearEditStr = yearEditStr;
                //开始更新数据  更新数据后 重新user更新时间 然后打开定时器
                Thread t = new Thread(new ParameterizedThreadStart(this.goRegister));
                t.Start(i);

            }
            updateUi(Config.httpTag);
        }


        //开始注册
        private void goRegister(object obj) {
            int index = (int)obj;
            int httpTag = Config.httpTag;
            RegisterInfo registerInfo = list[index];
            try
            {
                //发送http请求
                switch (registerInfo.tag)
                {
                    case "A":
                        RegisterUtils.goRegisterA(this, registerInfo, httpTag, index);
                        break;
                    case "B":
                        RegisterUtils.goRegisterB(this, registerInfo, httpTag, index);
                        break;
                    case "C":
                        RegisterUtils.goRegisterC(this, registerInfo, httpTag, index);
                        break;
                    case "F":
                        RegisterUtils.goRegisterF(this, registerInfo, httpTag, index);
                        break;
                    case "G":
                        RegisterUtils.goRegisterG(this, registerInfo, httpTag, index);
                        break;
                    case "I":
                        RegisterUtils.goRegisterI(this, registerInfo, httpTag, index);
                        break;
                    case "K":
                        RegisterUtils.goRegisterK(this, registerInfo, httpTag, index);
                        break;
                    case "R":
                        RegisterUtils.goRegisterR(this, registerInfo, httpTag, index);
                        break;
                    case "U": 
                        RegisterUtils.goRegisterU(this, registerInfo, httpTag, index);
                        break;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                if (httpTag != Config.httpTag) return;
                Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "未知错误";
                    updateUi(httpTag);
                }));
            }
        }


        public void updateUi(int httpTag) {
            if (Config.httpTag != httpTag) return;
            customersBindingSource.ResetBindings(true);
        }

    }
}
