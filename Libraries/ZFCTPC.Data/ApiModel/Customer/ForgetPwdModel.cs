using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.Customer
{
    public class ForgetPwdModel: BaseRequestModel
    {
        //手机号码
        public string Phone { get; set; }
        //验证码
        public string VerCode { get; set; }
        //修改后用户密码
        public string Password { get; set; }
    }

    public class VerifyPhoneCode: BaseRequestModel
    {
        public string PhoneNumber { get; set; }

        public string VerCode { get; set; }

    }

    public class VerifyCompanyInfo: BaseRequestModel
    {
        public string PhoneNumber { get; set; }

        public string VerCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string InstuCode { get; set; }

        /// <summary>
        /// 营业执照编号
        /// </summary>
        public string BusiCode { get; set; }

        /// <summary>
        /// 税务登记号
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// 身份证账号
        /// </summary>
        public string IDCard { get; set; }
    }

    public class CompanyInfoValidator: VerifyCompanyInfo
    {
        public bool VerifyType { get; set; }
    }
}
