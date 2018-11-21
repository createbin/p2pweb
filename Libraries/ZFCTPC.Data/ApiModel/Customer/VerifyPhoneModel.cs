using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.Customer
{
    public class SVCodeToMobile : BaseRequestModel
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobileNumber { get; set; }
    }


    /// <summary>
    /// 投资合同
    /// </summary>
    public class SDownInvestContract : BaseRequestModel
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int InvestId { get; set; }
    }

    /// <summary>
    /// 借款合同
    /// </summary>
    public class SDownLoanContract : BaseRequestModel
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }
    }

    public class SVerifyCompanyInfo : BaseRequestModel
    {
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
    }
}
