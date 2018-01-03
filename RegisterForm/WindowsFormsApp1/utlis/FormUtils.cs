using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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


    }
}
