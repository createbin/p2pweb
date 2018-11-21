using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn.Customer
{
    public class LoginInfoReturn
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string picUrl { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 时间戳加密userid 缓存时长和sign in 同步
        /// </summary>
        public string Token { get; set; }
    }

    public class UserChangeInfo
    {
        public bool Success { get; set; }

        public string Msg { get; set; }
    }

}
