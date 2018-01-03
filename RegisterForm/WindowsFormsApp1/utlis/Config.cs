using System;

namespace WindowsFormsApp1.utlis
{
    public class Config
    {
        //打码平台的账户和密码
        public static String codeUserStr = "";
        public static String codePwdStr = "";
        public static String codeMoneyStr = "";


        //打码平台的开发者配置
        public static int codeAppId = 4320; //appId
        public static String codeSerect = "12a3ebe63f8d503dceaf911ee32cfdf5";
        public static String userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3269.3 Safari/537.36";

        //总的http请求的tag标志
        public static int httpTag = 0;
    }
}
