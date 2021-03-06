﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using WindowsFormsApp1.utils;

namespace WindowsFormsApp1.utlis
{
    public class RegisterUtils
    {
        /******************A系统注册***********************************/
        public static void goRegisterA(Form1 form1, RegisterInfo registerInfo,int httpTag,int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null) {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }
            
            if (Config.httpTag != httpTag) return;
            registerInfo.cookie = new CookieContainer();
            String codeUrl = registerInfo.webUrl + "/member/aspx/verification_code.aspx?_=" + FormUtils.getCurrentTime();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            int codeNum = HttpUtils.getImage(codeUrl, index+"-"+httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory+"/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //开始条用注册接口
            String registerUrl = registerInfo.webUrl + "/member/aspx/do.aspx?action=register_bb";
            String pStr = "lang=cn" +
                          "&backurl=" + WebUtility.UrlEncode("/") +
                          "&member_parentid=-1" +
                          "&member_regdomain=" + FileUtils.changeBaseUrl(registerInfo.webUrl) +
                          "&Intr=" +
                          "&username=" + registerInfo.userEditStr +
                          "&password=" + registerInfo.pwdEditStr +
                          "&passwd=" + registerInfo.pwdEditStr +
                          "&currency=2" +
                          "&rmNum=" + codeStrBuf.ToString()+
                          "&real_name="+ WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                          "&birthday="+ WebUtility.UrlEncode(registerInfo.yearEditStr.Replace("-", "/").Replace(" ", "")) +
                          "&idopt=&idcode=&tel="+registerInfo.phoneNumEditStr+
                          "&pwd1="+registerInfo.moneyPwdEditStr.Substring(0,1)+
                          "&pwd2=" + registerInfo.moneyPwdEditStr.Substring(1, 1)+
                          "&pwd3=" + registerInfo.moneyPwdEditStr.Substring(2, 1)+
                          "&pwd4=" + registerInfo.moneyPwdEditStr.Substring(3, 1)+
                          "&MultiPwd=4&qq_num="+registerInfo.qqEditStr+"&email="+registerInfo.emailStr+"&agree=Y&OK2="+ WebUtility.UrlEncode("确认");
            headJObject["Origin"] = registerInfo.webUrl;
            String rlt = HttpUtils.HttpPostHeader(registerUrl,pStr, "application/x-www-form-urlencoded", registerInfo.cookie,headJObject);
            if (String.IsNullOrEmpty(rlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("已被注册"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; 
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("成功"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2; 
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /******************B系统注册***********************************/
        public static void goRegisterB(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }
            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
            registerInfo.cookie = new CookieContainer();
            String codeUrl = registerInfo.webUrl + "/yzm.php?type=1&" + FormUtils.getCurrentTime();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/reg.php";
            String pStr = "zcname=" + registerInfo.userEditStr +
                          "&zcpwd1=" + registerInfo.pwdEditStr +
                          "&zcpwd2=" + registerInfo.pwdEditStr +
                          "&zcturename=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                          "&zctel=" + WebUtility.UrlEncode("保密") +
                          "&zcemail=" +
                          "&jsr=" +
                          "&ask=" + WebUtility.UrlEncode("您的车牌号码是多少？") +
                          "&answer=fe5e9d4da3c3499f6fd4670654b66e4a" +
                          "&qk_pwd=" + registerInfo.moneyPwdEditStr +
                          "&inv_code=" +
                          "&zcyzm=" + codeStrBuf.ToString() +
                          "&zccheck=1";
            headJObject["Origin"] = registerInfo.webUrl;
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("已经存在"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("成功"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /******************C系统注册***********************************/
        public static void goRegisterC(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }


            //开始使用注册接口
            registerInfo.cookie = new CookieContainer();
            String registerUrl = registerInfo.webUrl + "/app/member/reg/mem_reg.php";
            String pStr = "keys=add" +
                          "&website=" +FileUtils.changeBaseUrl(registerInfo.webUrl).Replace("www.","")+
                          "&reg=2"+
                          "&intr=" +
                          "&username=" + registerInfo.userEditStr +
                          "&password=" +registerInfo.pwdEditStr+
                          "&password2=" + registerInfo.pwdEditStr +
                          "&alias=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                          "&sex=" + WebUtility.UrlEncode("男") +
                          "&drpAuthCodea=" + registerInfo.moneyPwdEditStr.Substring(0,1) +
                          "&drpAuthCodeb=" + registerInfo.moneyPwdEditStr.Substring(1, 1) +
                          "&drpAuthCodec=" + registerInfo.moneyPwdEditStr.Substring(2, 1) +
                          "&drpAuthCoded=" + registerInfo.moneyPwdEditStr.Substring(3, 1) +
                          "&drpAuthCodee=" + registerInfo.moneyPwdEditStr.Substring(4, 1) +
                          "&drpAuthCodef=" + registerInfo.moneyPwdEditStr.Substring(5, 1) +
                          "&askvalue=3" +
                          "&answer=" + WebUtility.UrlEncode("篮球") +
                          "&year11=" + registerInfo.yearEditStr.Split('-')[0] +
                          "&maoth11=" + registerInfo.yearEditStr.Split('-')[1] +
                          "&day11=" + registerInfo.yearEditStr.Split('-')[2] +
                          "&city="+ WebUtility.UrlEncode("广东省清远市") +
                          "&know_site=3" + 
                          "&Checkbox=on";
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("有人使用"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("欢迎您的加入"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /*****************I系统注册***********************************/
        public static void goRegisterI(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }
            registerInfo.cookie = new CookieContainer();
            String codeUrl = registerInfo.webUrl + "/app/member/index/verify/t/" + FormUtils.getCurrentTime();
            JObject headJObject = new JObject();

            String nameUrl = registerInfo.webUrl + "/app/member/index/valid";
            String p = "param=" + registerInfo.userEditStr + "&name=username";
            String nameRlt = HttpUtils.HttpPostHeader(nameUrl, p, "application/x-www-form-urlencoded; charset=UTF-8", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(nameRlt)||!FormUtils.IsJsonObject(nameRlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "接口有问题";
                    form1.updateUi(httpTag);
                }));
                return;
            }


            JObject nameJObject = JObject.Parse(nameRlt);

            String nameInfo = (String)nameJObject["info"];
            Console.WriteLine(nameRlt);
            if (nameInfo!=null && nameInfo.Contains("该用户名已经存在")) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "被注册过";
                    form1.updateUi(httpTag);
                }));
                return;
            }



            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
           
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            headJObject["Origin"] = registerInfo.webUrl;
           
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/app/member/index/regIndex";
            String pStr = "agents=" +
                          "&username=" + registerInfo.userEditStr +
                          "&password=" + registerInfo.pwdEditStr +
                          "&password2=" + registerInfo.pwdEditStr +
                          "&province=2" +
                           "&mobile=" + registerInfo.phoneNumEditStr+
                          "&email=" + WebUtility.UrlEncode(registerInfo.emailStr) +
                            "&qq=" +registerInfo.qqEditStr+
                            "&birthday="+registerInfo.yearEditStr+
                          "&payname=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                          "&moneypass=" + registerInfo.moneyPwdEditStr +
                          "&moneypass2=" + registerInfo.moneyPwdEditStr +
                          "&question=" + WebUtility.UrlEncode("您最喜欢的休闲运动是什么？") +
                          "&answer=" + WebUtility.UrlEncode("篮球") +
                          "&code=" + codeStrBuf.ToString() +
                          "&screensize=1366x768";
            headJObject["Referer"] = registerInfo.webUrl+"/sweb/register.html";
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded; charset=UTF-8", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt)||!FormUtils.IsJsonObject(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            JObject jObject = JObject.Parse(rlt);
            String info = (String)jObject["info"];
            Console.WriteLine(rlt);
            if (info.Contains("正常"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = info;
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /*****************R系统注册***********************************/
        public static void goRegisterR(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;
            
            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
            String codeUrl = registerInfo.webUrl + "/app/member/verify/mkcode.ashx?type=" + FormUtils.getCurrentTime();
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            headJObject["Referer"] = registerInfo.webUrl + "/app/member/mem_cash.aspx?intr=";
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/app/member/login.ashx";
            String pStr = "key=add" +
                       "&act=reg" +
                       "&intr=" +
                       "&introducer=" +
                       "&username=" + registerInfo.userEditStr +
                       "&password=" + registerInfo.pwdEditStr +
                       "&passwd=" + registerInfo.pwdEditStr +
                       "&currency=RMB"+
                       "&real_name=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                       "&birthday=" +
                        "&rmNum=" +codeStrBuf.ToString()+
                       "&pwd1=" + registerInfo.moneyPwdEditStr.Substring(0, 1) +
                       "&pwd2=" + registerInfo.moneyPwdEditStr.Substring(1, 1) +
                       "&pwd3=" + registerInfo.moneyPwdEditStr.Substring(2, 1) +
                       "&pwd4=" + registerInfo.moneyPwdEditStr.Substring(3, 1) +
                       "&MultiPwd=4" +
                       "&qq_num=" + registerInfo.qqEditStr+
                       "&email=" +
                       "&tel=" + registerInfo.phoneNumEditStr +
                       "&agree=Y"  +
                       "&OK2=" + WebUtility.UrlEncode("确认") ;
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("已经存在"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    if (rlt.Contains(registerInfo.phoneNumEditStr))
                    {
                        registerInfo.responseString = "手机号码,已被注册";
                    }
                    else if (rlt.Contains(registerInfo.nameEidtStr))
                    {
                        registerInfo.responseString = "姓名,已被注册";
                    }
                    else {
                        registerInfo.responseString = "已被注册";
                    }
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("/app/member/chk_rule.aspx?UID="))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /*****************U系统注册***********************************/
        public static void goRegisterU(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;

            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
            String codeUrl = registerInfo.webUrl + "/ValidateCode?id=" + FormUtils.getCurrentTime();
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
           
            headJObject["Referer"] = registerInfo.webUrl + "/New_User?agentid=";
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/New_User";
            String pStr =
                        "dailia=" +
                        "&IntrId=427" +
                        "&Intr=" +
                       "&us=" + registerInfo.userEditStr +
                       "&password1=" + registerInfo.pwdEditStr +
                       "&password2=" + registerInfo.pwdEditStr +
                       "&currency=RMB" +
                       "&code=" + codeStrBuf.ToString() +
                       "&fanshui=0" +
                       "&realname=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                       "&none=" +
                       "&tel=" + registerInfo.phoneNumEditStr +
                       "&pwd1=" + registerInfo.moneyPwdEditStr.Substring(0, 1) +
                       "&pwd2=" + registerInfo.moneyPwdEditStr.Substring(1, 1) +
                       "&pwd3=" + registerInfo.moneyPwdEditStr.Substring(2, 1) +
                       "&pwd4=" + registerInfo.moneyPwdEditStr.Substring(3, 1) +
                       "&none=" +
                       "&agree=Y";
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            Console.WriteLine(rlt);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("用户名存在"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("注册成功"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
           
        }

        /******************G系统注册***********************************/
        public static void goRegisterG(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }
            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
            registerInfo.cookie = new CookieContainer();
            String codeUrl = registerInfo.webUrl + "/yzm.php?type=" + FormUtils.getCurrentTime();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String pk_token = null;
            String tokenUrl = registerInfo.webUrl + "/index.php/webcenter/Register_web/getDemoUserToken";
            HttpUtils.HttpGetHeader(tokenUrl, "application/javascript", registerInfo.cookie, headJObject);
            List<Cookie> list = FileUtils.GetAllCookies(registerInfo.cookie);
            for (int i = 0; i < list.Count; i++) {
                Cookie cookie = list[i];
                if (cookie != null && cookie.Name.Equals("registerDemo")) {
                    pk_token = cookie.Value.ToString();
                }
            }

            if (String.IsNullOrEmpty(pk_token)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取token失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }


            String joinUrl = registerInfo.webUrl;
            String joinStr = HttpUtils.HttpGetHeader(joinUrl,"",registerInfo.cookie,headJObject);
            String mobile = "";
            if (joinStr.Contains("手机号码")) {
                mobile = "&mobile=" + registerInfo.phoneNumEditStr;
            }



            headJObject["Referer"] = registerInfo.webUrl + "/index.php/webcenter/Register_web/join_member";
            headJObject["Origin"] = registerInfo.webUrl;
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/index.php/webcenter/Register_web/join_member_do";
            String pStr ="Intr=10260"+
                        "&pk_token=" + pk_token +
                          "&zcname=" + registerInfo.userEditStr +
                          "&zcpwd1=" + registerInfo.pwdEditStr +
                          "&zcpwd2=" + registerInfo.pwdEditStr +
                           mobile +
                          "&currency=RMB"  +
                          "&zcyzm=" + codeStrBuf.ToString() +
                          "&zcturename=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                           "&birthday1=" + registerInfo.yearEditStr.Split('-')[0] +
                          "&birthday2=" + registerInfo.yearEditStr.Split('-')[1] +
                          "&birthday3=" + registerInfo.yearEditStr.Split('-')[2] +
                          "&address1="  +registerInfo.moneyPwdEditStr.Substring(0, 1) +
                           "&address2=" + registerInfo.moneyPwdEditStr.Substring(1, 1) +
                          "&address3=" + registerInfo.moneyPwdEditStr.Substring(2, 1) +
                          "&address4=" + registerInfo.moneyPwdEditStr.Substring(3, 1) +
                           "&MultiPwd=4"+
                            "&agree=Y" +
                          "&OK2=" + WebUtility.UrlEncode("确认");
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("已被人使用"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status =3;
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("欢迎您的加入!"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /*****************K系统注册***********************************/
        public static void goRegisterK(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;

            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
            String codeUrl = registerInfo.webUrl + "/app/member/yzm.php?" + FormUtils.getCurrentTime();
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            headJObject["Referer"] = registerInfo.webUrl + "/app/member/reg.php";
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/app/member/add_reg_mem.php?keys=add";
            String pStr =
                       "intr=ddm999" +
                       "&username=" + registerInfo.userEditStr +
                       "&password=" + registerInfo.pwdEditStr +
                       "&repassword=" + registerInfo.pwdEditStr +
                       "&alias=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                       "&address=" + registerInfo.moneyPwdEditStr +
                        "&zcyzm=" + codeStrBuf.ToString() +
                       "&submit=" + WebUtility.UrlEncode("提 交");
                       
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("有人使用"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("已成功"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /*****************F系统注册***********************************/
        public static void goRegisterF(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;

            //第一步获取验证码
            int codeMoney = YDMWrapper.YDM_GetBalance(Config.codeUserStr, Config.codePwdStr);
            if (codeMoney <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码平台余额不足";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (Config.httpTag != httpTag) return;
            String codeUrl = registerInfo.webUrl + "/validCode?t=" + FormUtils.getCurrentTime();
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            StringBuilder codeStrBuf = new StringBuilder();
            int num = YDMWrapper.YDM_EasyDecodeByPath(
                              Config.codeUserStr, Config.codePwdStr,
                              Config.codeAppId, Config.codeSerect,
                              AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg",
                              1004, 20, codeStrBuf);
            if (num <= 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String infoUrl = registerInfo.webUrl + "/member/member?type=returnSavaMember";
            String infoRlt = HttpUtils.HttpGetHeader(infoUrl, "", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(infoRlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取信息失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String phone = "";
            if (infoRlt.Contains("手机号码")) {
                phone = "&phone=" + registerInfo.phoneNumEditStr;
            }

            String birthday = "";
            if (infoRlt.Contains("生日")) {
                birthday = "&birthday=" + registerInfo.yearEditStr.Replace("-", "/");
            }


            headJObject["Referer"] = registerInfo.webUrl + "/member/member?type=returnSavaMember";
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/member/member?type=saveAccount";   
            String pStr =
                       "key=add" +
                       "&SS=&SR=&TS=" +
                       "&moneyType=1" +
                       "&parentName=" +
                       "&parentName2=203308" +
                       "&account2=" + registerInfo.userEditStr +
                       "&password=" + registerInfo.pwdEditStr +
                       "&qurenPasswrod=" + registerInfo.pwdEditStr +
                       "&realName=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                        phone+
                        birthday +
                       "&MultiPwd=" + registerInfo.moneyPwdEditStr +
                       "&drawMoneyPwd1=" + registerInfo.moneyPwdEditStr.Substring(0,1) +
                       "&drawMoneyPwd2=" + registerInfo.moneyPwdEditStr.Substring(1, 1) +
                       "&drawMoneyPwd3=" + registerInfo.moneyPwdEditStr.Substring(2, 1) +
                       "&drawMoneyPwd4=" + registerInfo.moneyPwdEditStr.Substring(3, 1) +
                        "&qq=" + registerInfo.qqEditStr +
                        "&email="+
                        "&zhuceYm=" +codeStrBuf.ToString()+
                       "&agree=Y";

            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rlt.Contains("有人使用")|| rlt.Contains("已经注册"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "已被注册";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else if (rlt.Contains("注册成功"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }

        /*****************D系统注册***********************************/
        public static void goRegisterD(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            //先处理注册的
            String limitStr = registerInfo.webUrl+ "/data/json/limit/registerLimit.json?" + FormUtils.getCurrentTime() ;
            String limitRlt = HttpUtils.HttpGetHeader(limitStr,"", registerInfo.cookie,headJObject);

            if (String.IsNullOrEmpty(limitRlt) || !FormUtils.IsJsonObject(limitRlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "失败,限制失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }




            JObject limitJObject = JObject.Parse(limitRlt);
            /*****************判断真实姓名被注册了吗*********************/
            //
            String checkUrl = registerInfo.webUrl + "/v/user/checkUnique?val=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) + "&type=1";
            String rltCheck = HttpUtils.HttpGetHeader(checkUrl,"",registerInfo.cookie,headJObject);
            if (String.IsNullOrEmpty(rltCheck)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取检查接口失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (rltCheck.Equals("true")) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "该姓名被注册过";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String codeUrl = registerInfo.webUrl + "/v/vCode?t=" + FormUtils.getCurrentTime();
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String codeStrBuf = CodeUtils.getImageCode(AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg");
           
            registerInfo.cookie.Add(new Cookie("md5Password", "false","/", FileUtils.changeBaseUrl(registerInfo.webUrl)));
            registerInfo.cookie.Add(new Cookie("alertShade", "ok", "/", FileUtils.changeBaseUrl(registerInfo.webUrl)));
            List<Cookie> list = FileUtils.GetAllCookies(registerInfo.cookie);
            for (int i = 0; i < list.Count; i++)
            {
                Cookie cookie = list[i];
            }
            headJObject["Origin"] = registerInfo.webUrl;
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            if (Config.httpTag != httpTag) return;

            headJObject["Referer"] = registerInfo.webUrl + "/views/html/register.html";
            //开始使用注册接口
            String registerUrl = registerInfo.webUrl + "/v/user/reg";
            String pStr ="account="+registerInfo.userEditStr+
                        "&password="+registerInfo.pwdEditStr+
                        "&confirmPassword="+registerInfo.pwdEditStr+
                        "&fullName="+ WebUtility.UrlEncode(registerInfo.nameEidtStr)+
                        "&pwd1=" + registerInfo.moneyPwdEditStr.Substring(0, 1) +
                        "&pwd2="+ registerInfo.moneyPwdEditStr.Substring(1, 1) +
                        "&pwd3="+ registerInfo.moneyPwdEditStr.Substring(2, 1) +
                        "&pwd4="+ registerInfo.moneyPwdEditStr.Substring(3, 1) +
                        "&phone="+registerInfo.phoneNumEditStr+
                        "&qq=" + registerInfo.qqEditStr +
                         "&weixin=" + registerInfo.qqEditStr +
                         "&email=" + WebUtility.UrlEncode(registerInfo.emailStr) +
                         "&agree=on" +""+
                         "&fundPwd="+registerInfo.moneyPwdEditStr+
                         "&vCode="+ codeStrBuf.ToString();
            Console.WriteLine(pStr);
            String rlt = HttpUtils.HttpPostHeader(registerUrl, pStr, "application/x-www-form-urlencoded; charset=UTF-8", registerInfo.cookie, headJObject);
            if (rlt == null) {
                    form1.Invoke(new Action(() =>
                    {
                        if (Config.httpTag != httpTag) return;
                        registerInfo.status = 3; //失败处理
                        registerInfo.responseString = "已被注册";
                        form1.updateUi(httpTag);
                    }));
                    return;
             }
            
            Console.WriteLine("D:" + rlt);
            if (rlt.Equals(""))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

        }

        /*****************E系统注册***********************************/
        public static void goRegisterE(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
          
            //先处理注册的
            String configUrl = registerInfo.webUrl + "/regconf.do";
            String configRlt = HttpUtils.HttpGetHeader(configUrl,"",registerInfo.cookie,headJObject);
            if (String.IsNullOrEmpty(configRlt) || !configRlt.Contains("$_regconf")) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取配置参数失败!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            configRlt = configRlt.Replace("var $_regconf = ", "").Trim();
            configRlt = configRlt.Replace(";", "").Trim();
            if (!FormUtils.IsJsonArray(configRlt))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取配置参数失败!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (configRlt.Contains("promoCode")) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "未知,需要邀请码!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            /*
             cardNo  银行卡
            wechat  微信
            receiptPwd 提款密码
            phone	手机号码
            userName	真实姓名
            QQ   qq号码
            promoCode	邀请码
             */
            JArray configArray = JArray.Parse(configRlt);
            JObject pJObject  =  new JObject();
            String cardNo = FormUtils.getCardNo() + "";
            for (int i = 0; i < configArray.Count; i++) {
                JObject jObject =(JObject) configArray[i];
                String key = (String)jObject["key"];
                switch (key) {
                    case "cardNo":  //银行卡
                        {
                            pJObject["" + key] = FormUtils.getCardNo();
                        }
                        break;
                    case "wechat": //微信
                        {
                            pJObject["" + key] = registerInfo.qqEditStr.ToString();
                        }
                        break;
                    case "receiptPwd": //提款密码六到20
                        {
                            pJObject["" + key] = registerInfo.moneyPwdEditStr.ToString();
                        }
                        break;
                    case "phone": //手机号码
                        {
                            pJObject["" + key] = registerInfo.phoneNumEditStr.ToString();
                        }
                        break;
                    case "userName"://真实姓名
                        {
                            pJObject["" + key] = registerInfo.nameEidtStr.ToString();
                        }
                        break;
                    case "QQ"://QQ
                    case "qq"://QQ
                        {
                            pJObject["" + key] = registerInfo.qqEditStr.ToString();
                        }
                        break;
                    default: { //默认
                            form1.Invoke(new Action(() =>
                            {
                                if (Config.httpTag != httpTag) return;
                                registerInfo.status = 3; //失败处理
                                registerInfo.responseString = "key:"+key;
                                form1.updateUi(httpTag);
                            }));
                            return;
                        }
                        break;
                }
            }

            pJObject["account"] = registerInfo.userEditStr.ToString(); //账户  
            pJObject["password"] = registerInfo.pwdEditStr.ToString(); //密码
            pJObject["rpassword"] = registerInfo.pwdEditStr.ToString(); //确认密码
            //获取验证码
            if (Config.httpTag != httpTag) return;
            String codeUrl = registerInfo.webUrl + "/verifycode.do?timestamp=" + FormUtils.getCurrentTime();
            int codeNum = HttpUtils.getImage(codeUrl, index + "-" + httpTag + ".jpg", registerInfo.cookie, headJObject); //这里要分系统获取验证码
            if (codeNum < 0)
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "码图下载失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            //获取打码平台的码
            String codeStr = CodeUtils.getImageCode(AppDomain.CurrentDomain.BaseDirectory + "/pic/" + index + "-" + httpTag + ".jpg");
            if (String.IsNullOrEmpty(codeStr)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "打码失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            pJObject["verifyCode"] = codeStr.Trim();
            Thread.Sleep(3000);
            headJObject["X-Requested-With"] = "XMLHttpRequest";
            String regUrl = registerInfo.webUrl + "/register.do";
            String p = "data=" + WebUtility.UrlEncode(pJObject.ToString());
            String regRlt = HttpUtils.HttpPostHeader(regUrl, p, "application/x-www-form-urlencoded; charset=UTF-8", registerInfo.cookie, headJObject);
            Console.WriteLine(regRlt);
            if (String.IsNullOrEmpty(regRlt) || !FormUtils.IsJsonObject(regRlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            if (regRlt.Contains("success") && regRlt.Contains("true")) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status =2; //失败处理
                    registerInfo.responseString = "成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            JObject rltbect = JObject.Parse(regRlt);
            String msg = (String)rltbect["msg"];

            form1.Invoke(new Action(() =>
            {
                if (Config.httpTag != httpTag) return;
                registerInfo.status = 3; //失败处理
                registerInfo.responseString = String.IsNullOrEmpty(msg)?"失败":msg;
                form1.updateUi(httpTag);
            }));
            return;
        }

        /*****************H系统注册***********************************/
        public static void goRegisterH(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;
            headJObject["Referer"] = registerInfo.webUrl + "/cn/register";
            headJObject["X-Requested-With"] = "XMLHttpRequest";
            String checkUrl = registerInfo.webUrl + "/cn/check-username/" + registerInfo.userEditStr;
            String checkRlt = HttpUtils.HttpPostHeader(checkUrl,"","",registerInfo.cookie,headJObject);
            Console.WriteLine(checkRlt);
            if (String.IsNullOrEmpty(checkRlt) || !FormUtils.IsJsonObject(checkRlt) || !checkRlt.Contains("result")) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "无法通过接口检测";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            JObject checkObject = JObject.Parse(checkRlt);
            int result =(int) checkObject["result"];
            if (result != 0) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "已被注册!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            /*
            tjid:
            submit: 提 交 
             */
            String pString = "username=" + registerInfo.userEditStr
                            + "&" + "password=" + registerInfo.pwdEditStr
                            + "&" + "repassword=" + registerInfo.pwdEditStr
                            + "&" + "realname=" + WebUtility.UrlEncode(registerInfo.nameEidtStr)
                            + "&" + "tel=" + registerInfo.phoneNumEditStr
                            + "&" + "qq=" + registerInfo.qqEditStr
                            + "&" + "qkmm=" + registerInfo.moneyPwdEditStr
                            + "&" + "reqkmm=" + registerInfo.moneyPwdEditStr
                            + "&" + "question=" + WebUtility.UrlEncode("您喜欢的球星")
                            + "&" + "answer=" + WebUtility.UrlEncode("文思卡特")
                            + "&" + "tjid=" + "&" + "submit=" + WebUtility.UrlEncode("提交")
                            + "&" + "weixin=" + registerInfo.qqEditStr
                            + "&" + "email=" + WebUtility.UrlEncode(registerInfo.emailStr);
            String registerUrl = registerInfo.webUrl + "/cn/register";
            String regisiterRlt = HttpUtils.HttpPostHeader(registerUrl, pString, "application/x-www-form-urlencoded;",registerInfo.cookie,headJObject);
            if (String.IsNullOrEmpty(regisiterRlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败!";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            if (regisiterRlt.Contains(registerInfo.userEditStr)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2; 
                    registerInfo.responseString = "成功!";
                    form1.updateUi(httpTag);
                }));
                return;
            }


            form1.Invoke(new Action(() =>
            {
                if (Config.httpTag != httpTag) return;
                registerInfo.status = 3; //失败处理
                registerInfo.responseString = "注册失败!";
                form1.updateUi(httpTag);
            }));
            return;

        }

        /*******************B1注册************************************/
        public static void goRegisterB1(Form1 form1, RegisterInfo registerInfo, int httpTag, int index)
        {
            if (Config.httpTag != httpTag) return;
            registerInfo.status = 1; //请求中
            registerInfo.responseString = "请求中";
            if (form1 != null)
            {
                form1.Invoke(new Action(() =>
                {
                    form1.updateUi(httpTag);
                }));
            }

            registerInfo.cookie = new CookieContainer();
            JObject headJObject = new JObject();
            headJObject["Host"]= FileUtils.changeBaseUrl(registerInfo.webUrl);

            String homeRlt = HttpUtils.HttpGetHeader(registerInfo.webUrl,"",registerInfo.cookie,headJObject);
            if (String.IsNullOrEmpty(homeRlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "无法访问网站";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            String configUrl = registerInfo.webUrl + "/app/member/Regster/index.php";
            String configRlt = HttpUtils.HttpGetHeader(configUrl,"",registerInfo.cookie,headJObject);
            if (String.IsNullOrEmpty(configRlt) || !configRlt.Contains("<form") || !configRlt.Contains("myFORM"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取配置失败!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            int startIndex = configRlt.IndexOf("<form");
            int endIndex = configRlt.IndexOf("</form>");

            if (startIndex >= endIndex) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取配置解析错误!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            configRlt = configRlt.Substring(startIndex, endIndex + 7 - startIndex);
            String[] strs = configRlt.Split('\n');
            if (strs.Length == 0) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取配置解析错误!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String agent_name = null;
            String agent_id = null;
            String registerUrl = null;
            for (int i = 0; i < strs.Length; i++) {
                String str = strs[i].Trim();
                if (String.IsNullOrEmpty(str)) {
                    continue;
                }

                if (str.Contains("myFORM") && str.Contains("action")) {
                    int tempIndex = str.IndexOf("action=\"");
                    registerUrl = str.Substring(tempIndex + 8, str.Length - (tempIndex + 8)).Replace("\">","").Trim();
                    continue;
                }

                if (str.Contains("agent_name"))
                {
                    int tempIndex = str.IndexOf("value=\"");
                    str = str.Substring(tempIndex + 7, str.Length - (tempIndex + 7)).Trim();
                    tempIndex = str.IndexOf("\"");
                    agent_name = str.Substring(0, tempIndex).Trim();
                    continue;
                }


                if (str.Contains("agent_id"))
                {
                    int tempIndex = str.IndexOf("value=\"");
                    str = str.Substring(tempIndex + 7, str.Length - (tempIndex + 7)).Trim();
                    tempIndex = str.IndexOf("\"");
                    agent_id = str.Substring(0, tempIndex).Trim();
                    continue;
                }
            }

            if (String.IsNullOrEmpty(agent_name)
                || String.IsNullOrEmpty(agent_id)
                || String.IsNullOrEmpty(registerUrl)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "获取注册信息失败!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            String reqP = "key=add" +
                          "&agent_name=" + agent_name +
                          "&agent_id=" + agent_id +
                          "&username=" + registerInfo.userEditStr +
                          "&password=" + registerInfo.pwdEditStr +
                          "&passwd=" + registerInfo.pwdEditStr +
                          "&real_name=" + WebUtility.UrlEncode(registerInfo.nameEidtStr) +
                          "&tel=" + registerInfo.phoneNumEditStr +
                          "&pwd1=" + registerInfo.moneyPwdEditStr.Substring(0, 1) +
                          "&pwd2=" + registerInfo.moneyPwdEditStr.Substring(1, 1) +
                          "&pwd3=" + registerInfo.moneyPwdEditStr.Substring(2, 1) +
                          "&pwd4=" + registerInfo.moneyPwdEditStr.Substring(3, 1) +
                          "&MultiPwd=4" +
                          "&qq_num=" + registerInfo.qqEditStr +
                          "&email=" + WebUtility.UrlEncode(registerInfo.emailStr) +
                          "&agree=Y" +
                          "&OK2=" + WebUtility.UrlEncode("确认");

            headJObject["Host"] = FileUtils.changeBaseUrl(registerInfo.webUrl);
            headJObject["Origin"] = registerInfo.webUrl;
            registerUrl = registerInfo.webUrl + registerUrl;
            String rlt = HttpUtils.HttpPostHeader(registerUrl, reqP, "application/x-www-form-urlencoded", registerInfo.cookie, headJObject);
            if (String.IsNullOrEmpty(rlt)) {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3; //失败处理
                    registerInfo.responseString = "注册失败!";
                    form1.updateUi(httpTag);
                }));
                return;
            }

            Console.WriteLine(rlt);

            //注册成功
            if (rlt.Contains("注册成功") || rlt.Contains("我同意"))
            {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 2;
                    registerInfo.responseString = "注册成功";
                    form1.updateUi(httpTag);
                }));
                return;
            }
            else {
                form1.Invoke(new Action(() =>
                {
                    if (Config.httpTag != httpTag) return;
                    registerInfo.status = 3;
                    if (rlt.Contains("已存在"))
                    {
                        registerInfo.responseString = "已被注册!";
                    }
                    else {
                        registerInfo.responseString = "可能已被注册!";
                    }
                    
                    form1.updateUi(httpTag);
                }));
                return;
            }
        }
    }
}
