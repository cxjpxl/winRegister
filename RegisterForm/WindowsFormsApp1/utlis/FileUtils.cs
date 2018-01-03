using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WindowsFormsApp1.utlis
{
    public class FileUtils
    {
        public static List<RegisterInfo> ReadUrls(string path)
        {

            List<RegisterInfo> listRegisterInfos = new List<RegisterInfo>();
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                if (sr == null) return listRegisterInfos;
                String line;

                 
                while ((line = sr.ReadLine()) != null)
                {
                    String[] strs = line.Split('\t');
                    if (strs.Length < 2) continue;
                    String tag = strs[0].ToUpper();//tag
                    String dataUrl = strs[1];//网址
                    dataUrl = changeDataUrl(dataUrl);
                    RegisterInfo registerInfo = new RegisterInfo(); //添加登陆显示的用户数据
                    registerInfo.tag = tag;
                    registerInfo.webUrl = dataUrl;
                    registerInfo.status = 0;
                    registerInfo.responseString = "未开始";
                    listRegisterInfos.Add(registerInfo);
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
               
            }
            return listRegisterInfos;
        }

        public static String changeBaseUrl(String baseUrl)
        {
            if (baseUrl.Contains("http://"))
            {
                baseUrl = baseUrl.Remove(0, 7);
            }
            if (baseUrl.Contains("https://"))
            {
                baseUrl = baseUrl.Remove(0, 8);
            }
            if (baseUrl.EndsWith("/"))
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }

            if (!baseUrl.Contains("www."))
            {
                baseUrl = "www." + baseUrl;
            }

            return baseUrl;
        }


        public static String changeDataUrl(String dataUrl)
        {
            if (dataUrl.EndsWith("/"))
            {
                dataUrl = dataUrl.Substring(0, dataUrl.Length - 1);
            }
            if (!dataUrl.Contains("www."))
            {
                if (dataUrl.Contains("http://"))
                {
                    dataUrl = "http://" + "www." + dataUrl.Substring(7, dataUrl.Length - 7);
                }
                else if (dataUrl.Contains("https://"))
                {
                    dataUrl = "https://" + "www." + dataUrl.Substring(8, dataUrl.Length - 8);
                }
            }
            return dataUrl;
        }


        //获取cookie
        public static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            try
            {

                Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                    System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

                foreach (object pathList in table.Values)
                {
                    SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                        | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                    foreach (CookieCollection colCookies in lstCookieCol.Values)
                        foreach (Cookie c in colCookies) lstCookies.Add(c);
                }
            }
            catch (Exception e)
            {
                lstCookies = new List<Cookie>();
            }

            return lstCookies;
        }


    }
}
