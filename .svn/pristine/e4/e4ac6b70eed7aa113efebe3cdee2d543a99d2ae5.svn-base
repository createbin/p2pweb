using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Core.Helpers
{
    public class DataHelper
    {
        /// <summary>
        /// 金额转换
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static string GetFormatMoney(decimal money)
        {
            var retMoney = string.Format("{0:c}", money).Replace("¥", "").Replace("$", "");
            return retMoney;
        }
        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="content"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string StringCut(string content, int length)
        {
            var result = string.Empty;
            if(string.IsNullOrEmpty(content))
            {
                result = "-";
            }
            result = content.Length <= length ? content : content.Substring(0, length);
            return result;
        }


        public static string GetFormatPercent(object  percent)
        {
            if (percent == null)
                return "-";
            return string.Format("{0:c}", percent).Replace("¥", "").Replace("$", "") + "%";
        }
    }
}
