using System;

namespace WindowsFormsApp1.utlis
{
    public class Config
    {
        //打码平台的账户和密码
        public static String codeUserStr = "";
        public static String codePwdStr = "";
        public static String codeMoneyStr = "";

       // public static String netUrl = "http://172.28.2.75:8500";
        public static String netUrl = "http://47.88.168.99:8500";

        //打码平台的开发者配置
        public static int codeAppId = 4320; //appId
        public static String codeSerect = "12a3ebe63f8d503dceaf911ee32cfdf5";
        public static String userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";

        //总的http请求的tag标志
        public static int httpTag = 0;
    }
}
