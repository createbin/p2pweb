using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.MyAccountRequestModels
{
    public class JsRegister : BaseRequestModel
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }

        /// <summary>
        /// 用户类型 1投资 2融资
        /// </summary>
        public int BusinessProperty { get; set; } = 1;
    }

    public class RealName: BaseRequestModel
    {
        /// <summary>
        /// 银行卡代号
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行卡号码
        /// </summary>
        public string BankCodeNo { get; set; }
        /// <summary>
        /// 用户属性1，2
        /// </summary>
        public int UserAttr { get; set; }
    }

    /// <summary>
    /// 用户账户查询
    /// </summary>
    public class SAuthType : BaseRequestModel
    {
        /// <summary>
        /// 授权类型1：授权2：解授权
        /// </summary>
        public string AuthType { get; set; } = "1";
    }

    /// <summary>
    /// 线下充值记录
    /// </summary>
    public class OfflineRechargeRecord: BaseRequestModel
    {
        public DateTime SDate { get; set; }

        public DateTime EDate { get; set; }

        public int Page { get; set; }

        /// <summary>
        /// 总页数 page不为1 时返回
        /// </summary>
        public int PageTotal { get; set; }
        /// <summary>
        /// 总页数 page不为1 时返回
        /// </summary>
        public int Total { get; set; }
    }
}
