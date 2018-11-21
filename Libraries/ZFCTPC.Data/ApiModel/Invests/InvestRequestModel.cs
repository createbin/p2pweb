using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.Invests
{
    public class RequestLoanInvester : RequestPageModel
    {
        /// <summary>
        /// 标的id
        /// </summary>
        public int LoanId { get; set; }
    }

    public class RequestLoanDetail : BaseRequestModel
    {
        /// <summary>
        /// 标的id
        /// </summary>
        public int LoanId { get; set; }
    }

    public class RequestInvestIncome : BaseRequestModel
    {
        /// <summary>
        /// 标的id
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public string RepaymentType { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        public string DeadLine { get; set; }

        public string BillDay { get; set; }

        public string InType { get; set; }

        public string LoanRate { get; set; }
    }

    /// <summary>
    /// 投资标
    /// </summary>
    public class SInvestLoan : BaseRequestModel
    {
        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 标编号
        /// </summary>
        public int LoanId { get; set; }
        /// <summary>
        /// 红包id
        /// </summary>
        public int RedId { get; set; }
    }

    public class LoanRedPackage : BaseRequestModel
    {
        public int LoanId { get; set; }

        public decimal InvestMoney { get; set; }
    }

    public class WaitPay: BaseRequestModel
    {
        public int investId { get; set; }
        /// <summary>
        /// 请求来源
        /// </summary>
        public int source { get; set; }
    }

    public class NewHandCount: BaseRequestModel
    {
        public int Count { get; set; }
    }
}
