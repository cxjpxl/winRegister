using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.utlis
{
    public class FormUtils
    {
        public static bool canGo(String value,String pattern) {
            return Regex.IsMatch(value, pattern);
        }

        public static long getCurrentTime()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }


        //判断是否json
        public static bool IsJsonObject(String str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.StartsWith("{") && str.EndsWith("}"))
            {
                return true;
            }
            return false;
        }

        //判断是否json
        public static bool IsJsonArray(String str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.StartsWith("[") && str.EndsWith("]"))
            {
                return true;
            }
            return false;
        }

        public static String getCardNo() {
            String num = "";
            Random ro = new Random();
            for (int i = 0; i < 19; i++) {
                int iResult;
                int iUp = 9;
                int iDown = 0;
                iResult = ro.Next(iDown, iUp);
                num = num + iResult + "";
            }
            return num;
        }


        public static string GetMD5(string myString)
        {
            if (myString == null)
            {
                return null;
            }

            MD5 md5Hash = MD5.Create();

            // 将输入字符串转换为字节数组并计算哈希数据 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(myString));

            // 创建一个 Stringbuilder 来收集字节并创建字符串 
            StringBuilder sBuilder = new StringBuilder();

            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // 返回十六进制字符串 
            return sBuilder.ToString();
        }
    }
}
