using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.Customer
{
    public class RegisterModel: BaseRequestModel
    {
        //用户名
        public string UserName { get; set; }
        //手机号
        public string Phone { get; set; }
        //密码
        public string Password { get; set; }
        public string Email { get; set; }
        //邀请码
        public string RecommendCode { get; set; }
        //验证码
        public string VerCode { set; get; }
    }
    public class SCompanyRegisterModel : RegisterModel
    {
        public bool IsOne { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 税务登记号
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// 营业执照编号
        /// </summary>
        public string BusinessLicense { get; set; }
        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string SocialCredit { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactUser { get; set; }
    }

    public class SJsCoRegisterModel : BaseRequestModel
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 法人代表姓名
        /// </summary>
        public string CorperationName { get; set; }

        /// <summary>
        /// 法人证件号
        /// </summary>
        public string CorperationIdCard { get; set; }

        /// <summary>
        /// 开户名称
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 是否为但保户
        /// 1：不是 2：是
        /// </summary>
        public int IsGuarantee { get; set; }


        public string ContactUser { get; set; }

        public string ContactPhone { get; set; }
        /// <summary>
        /// 三证号或者组织构代码
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 营业执照bianhao
        /// </summary>
        public string LicenseCode { get; set; }
        /// <summary>
        /// 税务登记号
        /// </summary>
        public string TaxId { get; set; }
    }

    public class SJsOpenChargeModel : BaseRequestModel
    {
        /// <summary>
        /// 行外对公账号
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 清算行号
        /// </summary>
        public string AccountBk { get; set; }

        public string AccountName { get; set; }
    }
    public class SUserType : BaseRequestModel
    {
        /// <summary>
        /// 0:投资户 1:融资户
        /// </summary>
        public string UserType { get; set; } = "1";
    }
}
