using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    public class UseBaseInfoModel
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 开户账号
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string UserCard { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        public string BankCard { get; set; }
        /// <summary>
        /// 渤海开户
        /// </summary>
        public bool BoHai { get; set; }
        /// <summary>
        /// 结算开户
        /// </summary>
        public bool JieSuan { get; set; }
        /// <summary>
        /// 渤海返回信息
        /// </summary>
        public string BoHaiMsg { get; set; }
        /// <summary>
        /// 结算返回信息
        /// </summary>
        public string JieSuanMsg { get; set; }
        /// <summary>
        /// 渤海返回码
        /// </summary>
        public string BoHaiCode { get; set; }
        /// <summary>
        /// 结算返回码
        /// </summary>
        public string JieSuanCode { get; set; }
        /// <summary>
        /// 渤海开户号
        /// </summary>
        public string PersonalChargeAccount { get; set; }

    }

    public class UserState
    {
        public string JieSuan { get; set; } = "0";

        public string BoHai { get; set; } = "0";

        public string Auth { get; set; } = "0";

        public string Risk { get; set; } = "0";
        /// <summary>
        /// 授权金额
        /// </summary>
        public string AuthMoney { get; set; } = "0.00";
    }

    /// <summary>
    /// 返回用户授权信息
    /// </summary>
    public class RUserAuthInfo
    {
        public string IsAuth { get; set; } = "0";
        public List<RAuthInfo> AuthInfos { get; set; } = new List<RAuthInfo>();
    }
    /// <summary>
    /// 
    /// </summary>
    public class RAuthInfo
    {
        public string AuthType { get; set; }

        public string AuthCode { get; set; }

        public string AuthStart { get; set; }

        public string AuthEnd { get; set; }

        public string AuthState { get; set; }
        /// <summary>
        /// 授权金额
        /// </summary>
        public string AuthMoney { get; set; }
    }
}
