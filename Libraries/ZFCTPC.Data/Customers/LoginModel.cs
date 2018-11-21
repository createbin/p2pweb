using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.Customers
{
    public partial class LoginModel : BaseModel
    {
        public bool CheckoutAsGuest { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneIp { get; set; }

        public bool RememberMe { get; set; }

        public bool DisplayCaptcha { get; set; }

        /// <summary>
        /// 登录授权令牌
        /// </summary>
        public string AuthorizationLoginToken { get; set; }
    }
}
