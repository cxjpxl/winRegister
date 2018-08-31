using System;
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
        private int x = 0, y = 0;
        private bool hasData = false;
        private bool isFirst = false;

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
            ThreadPool.SetMaxThreads(50, 50);//不宜设置过大
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
            Application.Exit();
        }

        //点击批量注册
        private void registerBtn_Click(object sender, EventArgs e)
        {

            userEdit.Text = "ww665588";
             pwdEdit.Text = "w987651";
             nameEidt.Text = "吴五";
             moneyPwdEdit.Text = "123456";
             phoneNumEdit.Text = "13877388632";
             qqEdit.Text = "189185422";
            emailEdit.Text = "189185422@qq.com";

         /* userEdit.Text = "ww987655";
            pwdEdit.Text = "w987651";
            nameEidt.Text = "吴五天";
            moneyPwdEdit.Text = "123456";
            phoneNumEdit.Text = "13877388611";
            qqEdit.Text = "1891854221";
            emailEdit.Text = "1891854221@qq.com";*/

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
            
            String yearEditStr = "1984-01-05";

            Config.httpTag++;
            isFirst = true;
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
                    || registerInfo.tag.Equals("F")
                    || registerInfo.tag.Equals("D")
                    || registerInfo.tag.Equals("B1"))
                {
                    registerInfo.moneyPwdEditStr = moneyPwdEditStr.Substring(0, 4);
                }
                registerInfo.phoneNumEditStr = phoneNumEditStr;
                registerInfo.qqEditStr = qqEditStr;
                registerInfo.yearEditStr = yearEditStr;
                //开始更新数据  更新数据后 重新user更新时间 然后打开定时器
                /*  Thread t = new Thread(new ParameterizedThreadStart(this.goRegister));
                    t.IsBackground = true;
                    t.Start(i);*/
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.goRegister),i);
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
                    case "D":
                        RegisterUtils.goRegisterD(this, registerInfo, httpTag, index);
                        break;
                    case "E":
                        RegisterUtils.goRegisterE(this, registerInfo, httpTag, index);
                        break;
                    case "H":
                        RegisterUtils.goRegisterH(this, registerInfo, httpTag, index);
                        break;
                    case "B1":
                        RegisterUtils.goRegisterB1(this, registerInfo, httpTag, index);
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
            hasData = true;
            if (list.Count < 50) {
                timer1.Stop();
                customersBindingSource.ResetBindings(true);
                this.sysDataGridView.FirstDisplayedScrollingRowIndex = this.y;
                this.sysDataGridView.FirstDisplayedScrollingColumnIndex = this.x;
                return;
            }
            if (this.isFirst) {
                this.isFirst = false;
                customersBindingSource.ResetBindings(true);
                this.sysDataGridView.FirstDisplayedScrollingRowIndex = this.y;
                this.sysDataGridView.FirstDisplayedScrollingColumnIndex = this.x;
                return;
            }
        }

        //导出按键
        private void outPutBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "文本文件(.txt)|*.txt";
            saveFile1.FilterIndex = 1;
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile1.FileName, false);
                try
                {

                    for (int i = 0; i < list.Count; i++) {
                        RegisterInfo registerInfo = list[i];
                        if (!String.IsNullOrEmpty(registerInfo.userEditStr)&&registerInfo.status ==2 ) {
                            String str = registerInfo.tag + "\t" +
                                    registerInfo.webUrl + "\n";
                            sw.WriteLine(str);
                        }
                    }
                    
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (hasData) {
                customersBindingSource.ResetBindings(true);
                this.sysDataGridView.FirstDisplayedScrollingRowIndex = this.y;
                this.sysDataGridView.FirstDisplayedScrollingColumnIndex = this.x;
                hasData = false;
            }
            timer1.Start();
        }

    

        private void sysDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                this.y = e.NewValue;
            }
            else if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll) {
                this.x = e.NewValue;
            }
        }
    }
}
