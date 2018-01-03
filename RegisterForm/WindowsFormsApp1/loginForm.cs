using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.utlis;

namespace WindowsFormsApp1
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            utlis.YDMWrapper.YDM_SetAppInfo(Config.codeAppId, Config.codeSerect);
            /*codeUserEdit.Text = "cxj81886404";
            codePwdEdit.Text = "cxj13580127662";*/
        }

        //去登录验证
        private void goLogin(object obj)
        {
            JObject jObject = (JObject)obj;
            String codeUserStr = (String)jObject["codeUserStr"];
            String codePwdStr = (String)jObject["codePwdStr"];
            Console.WriteLine(codeUserStr);
            Console.WriteLine(codePwdStr);
            //登录云打码账号
            int uid = utlis.YDMWrapper.YDM_Login(codeUserStr, codePwdStr);
            Console.WriteLine(uid);
            if (uid < 0)
            {
                Invoke(new Action(() =>
                {
                    loginSysBtn.Enabled = true;
                    loginSysBtn.Text = "登录";
                    MessageBox.Show("登录云打码账号失败！");
                }));
                return;
            }
            //获取云代码账号金额
            int codeMoney = utlis.YDMWrapper.YDM_GetBalance(codeUserStr, codePwdStr);
            if (codeMoney <= 0)
            {
                Invoke(new Action(() =>
                {
                    loginSysBtn.Enabled = true;
                    loginSysBtn.Text = "登录";
                    if (codeMoney == -1007)
                    {
                        MessageBox.Show("云打码账户余额不足,请充值！");
                    }
                    else
                    {
                        MessageBox.Show("登录云打码账号失败！");
                    }

                }));
                return;
            }

            if (codeMoney < 10)
            {
                Invoke(new Action(() =>
                {
                    loginSysBtn.Enabled = true;
                    loginSysBtn.Text = "登录";
                    MessageBox.Show("云打码余额快不足,请充值使用！");
                }));
                return;
            }

            Config.codeMoneyStr = codeMoney + "";


            //登录成功
            Invoke(new Action(() =>
            {
                Config.codeUserStr = codeUserStr;
                Config.codePwdStr = codePwdStr;
                Form1 mainFrom = new Form1();
                mainFrom.Show();
                this.Hide();
            }));
        }



        private void loginSysBtn_Click(object sender, EventArgs e)
        {
            String codeUserStr = codeUserEdit.Text.ToString().Trim();
            String codePwdStr = codePwdEdit.Text.ToString().Trim();
            if (String.IsNullOrEmpty(codeUserStr) || String.IsNullOrEmpty(codePwdStr))
            {
                MessageBox.Show("用户或者密码不能为空!");
                return;
            }
            //登录打码平台并记录在程序里面  并显示软件使用时间  时间优先级比较高  同时客户端记录软件使用时间
            loginSysBtn.Text = "登录中，请耐心等待!";
            loginSysBtn.Enabled = false;

            JObject jobject = new JObject();
            jobject.Add("codeUserStr", codeUserStr);
            jobject.Add("codePwdStr", codePwdStr);
            Thread t = new Thread(new ParameterizedThreadStart(goLogin));
            t.Start(jobject);
        }

       
    }
}
