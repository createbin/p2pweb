using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ZFCTPC.Core.Helpers
{
    public class UserInfoVerifyHelper
    {
        private static string verifyPhoneCode = @"^[1]+\d{10}";//手机号正则表达式
        /// <summary>
        /// 验证合法的手机号格式
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool VerifyPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return false;
            }
            if (phone.Length > 11)
            {
                return false;
            }
            return Regex.IsMatch(phone, verifyPhoneCode);
        }
    }
}
