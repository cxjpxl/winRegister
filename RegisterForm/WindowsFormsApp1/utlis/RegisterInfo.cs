using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.utlis
{
   public  class RegisterInfo
    {
            public String tag { get; set; } //系统 
            public String responseString { get; set; }//显示反馈的东西
            public int status { get; set; } //0未开始  1请求中  2成功  3失败
            public String webUrl { get; set; }//网址
            public String userEditStr { get; set; } //账户
            public String pwdEditStr { get; set; } //密码
            public String nameEidtStr { get; set; }//姓名
            public String moneyPwdEditStr { get; set; }//提款密码
            public  String phoneNumEditStr { get; set; }//手机号码
            public String qqEditStr { get; set; }//qq
            public String yearEditStr { get; set; }//出生年月
            public String questionStr { get; set; }
            public String ansStr { get; set; }
            public String emailStr { get; set; } //邮箱号码

            public JObject expJObject = new JObject();
            public CookieContainer cookie = null;
    }
}
