using System;
using System.Collections.Generic;

namespace ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels
{

    #region 接口 2.0

    /// <summary>
    /// PC投资户统计
    /// </summary>
    public class RPCAccountStatistics
    {
        /// <summary>
        /// 总资产（不包括冻结金额）
        /// </summary>
        public decimal AccountMoney { get; set; }

        /// <summary>
        /// 累计收益
        /// </summary>
        public decimal CumulativeIncome { get; set; }

        /// <summary>
        /// 待收本金
        /// </summary>
        public decimal WaitReceivePrincipal { get; set; }

        /// <summary>
        /// 今日待收
        /// </summary>
        public decimal TodayWaitReceive { get; set; }

        /// <summary>
        /// 投资数量
        /// </summary>
        public int InvestCount { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 投标中投资数量
        /// </summary>
        public decimal InvestBiddingCount { get; set; }

        /// <summary>
        /// 还款中投资数量
        /// </summary>
        public decimal InvesRepayCount { get; set; }

        /// <summary>
        /// 已结清投资数量
        /// </summary>
        public decimal InvesSettledtCount { get; set; }

        /// <summary>
        /// 可转让债权数量
        /// </summary>
        public int TransferCanCount { get; set; }

        /// <summary>
        /// 已转入债权
        /// </summary>
        public int TransferInCount { get; set; }

        /// <summary>
        /// 转出中债权
        /// </summary>
        public int TransferWaitCount { get; set; }

        /// <summary>
        /// 已转出债权
        /// </summary>
        public int TransferOutCount { get; set; }

        /// <summary>
        /// 可用红包金额
        /// </summary>
        public decimal RedMoney { get; set; }

        /// <summary>
        /// 是否借款
        /// </summary>
        public bool HasLoan { get; set; }

        /// <summary>
        /// 是否开户
        /// </summary>
        public bool IsOpenAccount { get; set; }

        /// <summary>
        /// 是否老用户
        /// </summary>
        public bool IsOldAccount { get; set; }
    }

    /// <summary>
    /// 融资账户统计
    /// </summary>
    public class RFinancingAccount
    {
        /// <summary>
        /// 下期还款日期
        /// </summary>
        public string NextPayDate { get; set; } = "无";

        /// <summary>
        /// 下期还款总金额
        /// </summary>
        public decimal NextPayMoney { get; set; }

        /// <summary>
        /// 代还总额
        /// </summary>
        public decimal WaitPayAllMoney { get; set; }

        /// <summary>
        /// 剩余天数
        /// </summary>
        public int SurplusDays { get; set; }

        /// <summary>
        /// 满标中已结清数量
        /// </summary>
        public int FullCount { get; set; }

        /// <summary>
        /// 还款中数量
        /// </summary>
        public int RepaymentCount { get; set; }

        /// <summary>
        /// 已结清数量
        /// </summary>
        public int ClearedCount { get; set; }

        /// <summary>
        /// 募集中数量
        /// </summary>
        public int BiddingCount { get; set; }

        /// <summary>
        /// 借款总数
        /// </summary>
        public int LoanCount { get; set; }

        /// <summary>
        /// 借款总金额
        /// </summary>
        public decimal LoanMoney { get; set; }

    }

    /// <summary>
    /// 渤海账户信息
    /// </summary>
    public class RBHAccountInfo
    {
        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 可提现金额
        /// </summary>
        public decimal WithdrawAmount { get; set; }

        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal FreezeAmout { get; set; }
    }

    /// <summary>
    /// 用户红包
    /// </summary>
    public class RRedEnvelopesModel
    {
        /// <summary>
        /// 红包编号
        /// </summary>
        public int RedId { get; set; }

        /// <summary>
        /// 红包金额
        /// </summary>
        public decimal RedMoney { get; set; }

        /// <summary>
        /// 红包开始时间
        /// </summary>
        public DateTime? RedStartDate { get; set; }

        /// <summary>
        /// 红包截至时间
        /// </summary>
        public DateTime? RedEndDate { get; set; }

        /// <summary>
        /// 红包名称
        /// </summary>
        public string RedName { get; set; }

        /// <summary>
        ///  红包类型
        /// </summary>
        public string RedType { get; set; }

        /// <summary>
        /// 使用说明
        /// </summary>
        public string RedInstructions { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public string RedValidity { get; set; }

        /// <summary>
        ///  红包状态
        /// </summary>
        public string RedUseState { get; set; }

        /// <summary>
        ///  使用的标编号
        /// </summary>
        public int? RedLoanId { get; set; }
    }

    /// <summary>
    /// 借款-招标中
    /// </summary>
    public class RBiddingLoan
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 借款期限描述
        /// </summary>
        public string LoanPeriodDesc { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 招标进度
        /// </summary>
        public decimal LoanSpeed { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }

        /// <summary>
        /// 借款利息
        /// </summary>
        public decimal LoanInterest { get; set; }

        /// <summary>
        /// 借款服务费
        /// </summary>
        public decimal LoanServiceFee { get; set; }

        /// <summary>
        /// 还款总额
        /// </summary>
        public decimal LoanRePayMoney { get; set; }
    }

    /// <summary>
    /// 借款-满标中
    /// </summary>
    public class RFullLoan
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 借款期限描述
        /// </summary>
        public string LoanPeriodDesc { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }

        /// <summary>
        /// 借款利息
        /// </summary>
        public decimal LoanInterest { get; set; }

        /// <summary>
        /// 借款服务费
        /// </summary>
        public decimal LoanServiceFee { get; set; }

        /// <summary>
        /// 还款总额
        /// </summary>
        public decimal LoanRePayMoney { get; set; }

        public string FullDate { get; set; }
    }

    /// <summary>
    /// 借款-还款中
    /// </summary>
    public class RRepaymentLoan
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 借款期限描述
        /// </summary>
        public string LoanPeriodDesc { get; set; }

        /// <summary>
        /// 应还时间
        /// </summary>
        public DateTime NoRepayDate { get; set; }

        /// <summary>
        /// 未还期数
        /// </summary>
        public int NoRepayPeriod { get; set; }

        /// <summary>
        /// 未还金额
        /// </summary>
        public decimal NoRepayMoney { get; set; }

        /// <summary>
        /// 借款罚息
        /// </summary>
        public decimal LoanOverRate { get; set; }

        /// <summary>
        /// 借款利息
        /// </summary>
        public decimal LoanInterest { get; set; }

        /// <summary>
        /// 借款服务费
        /// </summary>
        public decimal LoanServiceFee { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        public string LoanState { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }

        /// <summary>
        /// 还款总额
        /// </summary>
        public decimal LoanRePayMoney { get; set; }


    }

    /// <summary>
    /// 借款-已结清
    /// </summary>
    public class RClearedLoan
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ClearDate { get; set; }

        /// <summary>
        /// 借款期限描述
        /// </summary>
        public string LoanPeriodDesc { get; set; }

        /// <summary>
        /// 借款罚息
        /// </summary>
        public decimal LoanOverRate { get; set; }

        /// <summary>
        /// 借款利息
        /// </summary>
        public decimal LoanInterest { get; set; }

        /// <summary>
        /// 借款服务费
        /// </summary>
        public decimal LoanServiceFee { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        public string LoanState { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }

        /// <summary>
        /// 还款总额
        /// </summary>
        public decimal LoanRePayMoney { get; set; }
    }

    /// <summary>
    /// 借款明细
    /// </summary>
    public class RLoanItemDetail
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 借款期限
        /// </summary>
        public string LoanPeriod { get; set; }

        /// <summary>
        /// 期限类型
        /// </summary>
        public string PeriodType { get; set; }

        /// <summary>
        /// 已还本息
        /// </summary>
        public decimal RepayMoney { get; set; }

        /// <summary>
        /// 待还本息
        /// </summary>
        public decimal WaitRepayMoney { get; set; }

        /// <summary>
        /// 待还期数
        /// </summary>
        public int WaitRepayPeriod { get; set; }
    }

    /// <summary>
    /// 还款计划
    /// </summary>
    public class RMyLoanPlanModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 应还日期
        /// </summary>
        public DateTime? PayDate { get; set; }

        /// <summary>
        /// 应还本金
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 应还利息
        /// </summary>
        public decimal PayRate { get; set; }

        /// <summary>
        /// 应还本息
        /// </summary>
        public decimal PayPrincipal { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public decimal? Interest { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 还款时间
        /// </summary>
        public DateTime? CollectDate { get; set; }

        /// <summary>
        /// 应还服务费
        /// </summary>
        public decimal? PayServiceFee { get; set; }

        /// <summary>
        /// 是否还清
        /// </summary>
        public string IsClear { get; set; }

        /// <summary>
        /// 是否正在使用
        /// </summary>
        public bool IsUsing { get; set; }

        /// <summary>
        /// 还款类型
        /// </summary>
        public string CollectType { get; set; }

        /// <summary>
        /// 逾期金额
        /// </summary>
        public decimal OverRateMoney { get; set; } = 0.00m;
    }
    /// <summary>
    /// 还款明细
    /// </summary>
    public class RRepayDetail
    {
        /// <summary>
        /// 记录id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 项目名称(用途)
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 借款期限
        /// </summary>
        public string LoanPeriod { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string LoanState { get; set; }

        /// <summary>
        /// 下次还款日期
        /// </summary>
        public DateTime NextRepayDate { get; set; }

        /// <summary>
        /// 还款日期
        /// </summary>
        public DateTime RepayDate { get; set; }

        /// <summary>
        /// 剩余期数
        /// </summary>
        public decimal SurplusPeriod { get; set; }

        /// <summary>
        /// 已还期数
        /// </summary>
        public decimal SettledPeriod { get; set; }

        /// <summary>
        /// 已还本金
        /// </summary>
        public decimal SettledPrincipal { get; set; }

        /// <summary>
        /// 未还本金
        /// </summary>
        public decimal Principal { get; set; }

        /// <summary>
        /// 已还利息
        /// </summary>
        public decimal SettledInterest { get; set; }

        /// <summary>
        /// 未还利息
        /// </summary>
        public decimal Interest { get; set; }

        /// <summary>
        /// 应还逾期费
        /// </summary>
        public decimal LateFee { get; set; }

        /// <summary>
        /// 已还逾期费
        /// </summary>
        public decimal SettledLateFee { get; set; }

        /// <summary>
        /// 应还服务费
        /// </summary>
        public decimal ServiceFee { get; set; }

        /// <summary>
        /// 已还服务费
        /// </summary>
        public decimal SettledServiceFee { get; set; }

        /// <summary>
        /// 下次应还费用
        /// </summary>
        public decimal NextWaitPayMoney { get; set; }

        /// <summary>
        /// 本期应还总额
        /// </summary>
        public decimal CurrenyWaitPayMoney { get; set; }

        /// <summary>
        /// 应还总额
        /// </summary>
        public decimal WaitPayMoney { get; set; }

        /// <summary>
        /// 是否还清
        /// </summary>
        public string IsClear { get; set; }
    }

    /// <summary>
    /// 借款账户统计
    /// </summary>
    public class RLoanAccountStatistics
    {
        /// <summary>
        /// 已还本金
        /// </summary>
        public decimal RepayPrincipal { get; set; }

        /// <summary>
        /// 已还利息
        /// </summary>
        public decimal RepayRate { get; set; }

        /// <summary>
        /// 已还服务费
        /// </summary>
        public decimal RepayServiceFee { get; set; }
    }

    /// <summary>
    /// 我的投资-投标中
    /// </summary>
    public class RBiddingInvest
    {
        /// <summary>
        /// 投资编号
        /// </summary>
        public int InvestId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 项目利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 项目期限
        /// </summary>    
        public int LoanPeriod { get; set; }

        /// <summary>
        /// 项目期限类型
        /// </summary>    
        public int LoanPeriodType { get; set; }

        /// <summary>
        /// 项目期限描述
        /// </summary>    
        public string LoanPeriodDesc { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 项目还款方式
        /// </summary>
        public string LoanRepayType { get; set; }

        /// <summary>
        /// 投资时间
        /// </summary>
        public DateTime InvestDate { get; set; }

        /// <summary>
        /// 预期收益
        /// </summary>
        public decimal ExpectedRevenue { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public int TraState { get; set; }


        /// <summary>
        /// 项目状态
        /// </summary>
        public int LoanState { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }

        /// <summary>
        /// 是否渤海项目
        /// </summary>
        public bool Bohai { get; set; }
    }

    /// <summary>
    /// 我的投资-还款中
    /// </summary>
    public class RRepaymentInvest
    {
        /// <summary>
        /// 投资编号
        /// </summary>
        public int InvestId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名车
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 项目利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public DateTime PayDate { get; set; }

        /// <summary>
        /// 还款金额
        /// </summary>
        public decimal PayMoeny { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        public int LoanState { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }
    }

    /// <summary>
    /// 我的投资-已结清
    /// </summary>
    public class RClearedInvest
    {
        /// <summary>
        /// 投资编号
        /// </summary>
        public int InvestId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public int LoanId { get; set; }

        /// <summary>
        /// 项目名车
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 项目利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime ClearedDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// 起息时间
        /// </summary>
        public DateTime InterestDate { get; set; }

        /// <summary>
        /// 预期收益
        /// </summary>
        public decimal ExpectedRevenue { get; set; }

        /// <summary>
        /// 项目状态
        /// </summary>
        public int LoanState { get; set; }

        /// <summary>
        /// 项目状态描述
        /// </summary>
        public string LoanStateDesc { get; set; }

        /// <summary>
        /// 项目期限
        /// </summary>    
        public int LoanPeriod { get; set; }

        /// <summary>
        /// 项目期限类型
        /// </summary>    
        public int LoanPeriodType { get; set; }

        /// <summary>
        /// 项目期限描述
        /// </summary>  
        public string LoanPeriodDesc { get; set; }

        /// <summary>
        /// 项目还款方式
        /// </summary>
        public string LoanRepayType { get; set; }
    }

    /// <summary>
    /// 我的投资-投资账户统计
    /// </summary>
    public class RInvestAccountStatistics
    {
        /// <summary>
        /// 累计投资
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 待收本金
        /// </summary>
        public decimal WaitRepayPrincipal { get; set; }

        /// <summary>
        /// 待收收益
        /// </summary>
        public decimal WaitRepayEarnings { get; set; }

        /// <summary>
        /// 已收本金
        /// </summary>
        public decimal RepayPrincipal { get; set; }

        /// <summary>
        /// 已收收益
        /// </summary>
        public decimal RepayEarnings { get; set; }
    }

    /// <summary>
    /// 债权转让-可转出
    /// </summary>
    public class RCanTransfer
    {
        /// <summary>
        /// 投资编号
        /// </summary>
        public int InvestId { get; set; }

        /// <summary>
        /// 债权转让编号
        /// </summary>
        public int TransferId { get; set; }


        /// <summary>
        /// 可转份额
        /// </summary>
        public decimal CanTransferMoney { get; set; }

        /// <summary>
        /// 下个还款日
        /// </summary>
        public DateTime NextPayData { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 待收本息
        /// </summary>
        public decimal WaitPrincipal { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public decimal Period { get; set; }

        /// <summary>
        /// 折让率
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 折让金额
        /// </summary>
        public decimal DiscountMoney { get; set; }

        /// <summary>
        /// 剩余天数
        /// </summary>
        public int SurplusDay { get; set; }

        /// <summary>
        /// 手续费率
        /// </summary>
        public decimal TransferRate { get; set; }


        /// <summary>
        /// 是否申请中
        /// </summary>
        public bool IsApply { get; set; }


    }

    /// <summary>
    /// 债权转让-转出中
    /// </summary>
    public class RTransfering
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 可转份额
        /// </summary>
        public decimal CanTransferMoney { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public decimal Period { get; set; }

        /// <summary>
        /// 折让率
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 折让金额
        /// </summary>
        public decimal DiscountMoney { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal produceFee { get; set; }

        /// <summary>
        /// 认购金额
        /// </summary>
        public decimal BuyMoney { get; set; }

        /// <summary>
        /// 认购金额
        /// </summary>
        public decimal BuySpeed { get; set; }

        /// <summary>
        /// 转让时间
        /// </summary>
        public DateTime TransferData { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime EndData { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
    }

    /// <summary>
    /// 债权转让-已转出
    /// </summary>
    public class RTransferOut
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 可转份额
        /// </summary>
        public decimal CanTransferMoney { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public decimal Period { get; set; }

        /// <summary>
        /// 折让率
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 折让金额
        /// </summary>
        public decimal DiscountMoney { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal produceFee { get; set; }

        /// <summary>
        /// 认购金额
        /// </summary>
        public decimal BuyMoney { get; set; }

        /// <summary>
        /// 认购进度
        /// </summary>
        public decimal BuySpeed { get; set; }

        /// <summary>
        /// 转让时间
        /// </summary>
        public DateTime TransferData { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime EndData { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
    }

    /// <summary>
    /// 债权转让-已转入
    /// </summary>
    public class RTransferIn
    {
        /// <summary>
        /// 投资编号
        /// </summary>
        public int InvestId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public decimal LoanRate { get; set; }

        /// <summary>
        /// 可转份额
        /// </summary>
        public decimal CanTransferMoney { get; set; }

        /// <summary>
        /// 期数
        /// </summary>
        public decimal Period { get; set; }

        /// <summary>
        /// 折让率
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 折让金额
        /// </summary>
        public decimal DiscountMoney { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal produceFee { get; set; }

        /// <summary>
        /// 认购金额
        /// </summary>
        public decimal BuyMoney { get; set; }

        /// <summary>
        /// 认购进度
        /// </summary>
        public decimal BuySpeed { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
    }

    /// <summary>
    /// 用户交易记录
    /// </summary>
    public class RTradingModel
    {
        //主键id
        public int id;

        //交易类型
        public string TradingType { get; set; }

        //交易金额
        public decimal TradingMoney { get; set; }

        //交易时间
        public string TradingDate { get; set; }

        //交易状态
        public string TradingStatus { get; set; }

        //交易流水号
        public string TradingOrderNo { get; set; }

        //项目名称
        public string TradingName { get; set; }

        //交易后账户余额
        public decimal TrandingAccountMoney { get; set; }

        //交易后融资账户余额
        public decimal FTrandingAccountMoney { get; set; }
    }

    /// <summary>
    /// 用户是否开户
    /// </summary>
    public class RUserState
    {
        public bool JieSuan { get; set; }

        public bool BoHai { get; set; }
    }

    /// <summary>
    /// 用户投资收益
    /// </summary>
    public class RInvestEarnings
    {
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 30天收益
        /// </summary>
        public decimal ThridDayEarnings { get; set; }

        /// <summary>
        /// 累计收益
        /// </summary>
        public decimal AccumulativeEarnings { get; set; }
    }

    /// <summary>
    /// 我的业务统计
    /// </summary>
    public class RBusinessStatistics
    {
        /// <summary>
        /// 投资总数
        /// </summary>
        public int InvestCount { get; set; }

        /// <summary>
        /// 借款总数
        /// </summary>
        public int LoanCount { get; set; }

        /// <summary>
        /// 债权转让总数
        /// </summary>
        public int TransferCount { get; set; }

        /// <summary>
        /// 可用红包总数
        /// </summary>
        public int CanUserRedCount { get; set; }
    }

    /// <summary>
    /// 风险问卷
    /// </summary>
    public class RiskQuestionnaireModel
    {
        public int Qid { get; set; }

        public string Description { get; set; }

        public List<RiskQuestionnaireAnswerModel> Answer { get; set; }
    }

    public class RiskQuestionnaireAnswerModel
    {
        public int Aid { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal Integral { get; set; }
    }


    /// <summary>
    /// 用户银行卡信息
    /// </summary>
    public class RUserBankInfo
    {

        /// <summary>
        /// 用户是否结算开户
        /// </summary>
        public bool IsJieSuan { get; set; } = false;

        /// <summary>
        /// 用户是否渤海开户
        /// </summary>
        public bool IsBoHai { get; set; } = false;

        /// <summary>
        /// 银行卡信息
        /// </summary>
        public IEnumerable<RBankInfo> BankInfos { get; set; }
    }

    /// <summary>
    /// 银行卡信息
    /// </summary>
    public class RBankInfo
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 银行代号
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行图片链接 
        /// </summary>
        public string BankUrl { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }
    }

    #endregion

    #region 接口 1.0
    /// <summary>
    /// 我的财富
    /// </summary>
    public class MyAccount
    {
        /// <summary>
        /// 第三方支付账号
        /// </summary>
        public string OtherAccount { get; set; }

        /// <summary>
        /// 账户总额
        /// </summary>
        public decimal account_balance { get; set; }

        /// <summary>
        /// 可用金额
        /// </summary>
        public decimal enable_amount { get; set; }

        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal freezing_amount { get; set; }

        /// <summary>
        /// 收入总额
        /// </summary>
        public decimal gross_receipts { get; set; }

        /// <summary>
        /// 已收回本金
        /// </summary>
        public decimal recovered_principal { get; set; }

        /// <summary>
        /// 已赚利息
        /// </summary>
        public decimal earned_interest { get; set; }

        /// <summary>
        /// 已赚罚息
        /// </summary>
        public decimal earned_penalty { get; set; }

        /// <summary>
        /// 今日待收
        /// </summary>
        public decimal collecting_today { get; set; }

        /// <summary>
        /// 今日待还
        /// </summary>
        public decimal returning_today { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string user_pic { get; set; }

        /// <summary>
        /// 投资等级图片
        /// </summary>
        public string investment_pic { get; set; }

        /// <summary>
        /// 投资等级
        /// </summary>
        public string investment_grade { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public string investment_score { get; set; }

        /// <summary>
        /// 安全等级
        /// </summary>
        public int security_classification { get; set; }

        /// <summary>
        ///可用资金
        /// </summary>
        public decimal expendable_fund { get; set; }

        /// <summary>
        /// 冻结资金
        /// </summary>
        public decimal frozen_fund { get; set; }

        /// <summary>
        /// 待收总额
        /// </summary>
        public decimal await_totalmoney { get; set; }

        /// <summary>
        /// 待收本金
        /// </summary>
        public decimal principal_amount { get; set; }

        /// <summary>
        /// 待收利息
        /// </summary>
        public decimal collect_interest { get; set; }

        /// <summary>
        /// 待收罚息
        /// </summary>
        public decimal default_interest { get; set; }

        /// <summary>
        /// 资产总额
        /// </summary>
        public decimal general_assets { get; set; }

        /// <summary>
        /// 待还总额
        /// </summary>
        public decimal total_samount { get; set; }

        /// <summary>
        /// 待还本金
        /// </summary>
        public decimal also_principal { get; set; }

        /// <summary>
        /// 待还利息
        /// </summary>
        public decimal still_interest { get; set; }

        /// <summary>
        /// 待还罚息
        /// </summary>
        public decimal punitive_interest { get; set; }

        /// <summary>
        /// 待还服务费
        /// </summary>
        public decimal service_charge { get; set; }

        /// <summary>
        /// 已赚奖励
        /// </summary>
        public decimal earned_awards { get; set; }

        /// <summary>
        /// 净收益
        /// </summary>
        public decimal net_earning { get; set; }

        /// <summary>
        /// 已还本金
        /// </summary>
        public decimal already_principal { get; set; }

        /// <summary>
        /// 已还利息
        /// </summary>
        public decimal interest_rate { get; set; }

        /// <summary>
        /// 已还罚息
        /// </summary>
        public decimal penalty_rate { get; set; }

        /// <summary>
        /// 已还服务费
        /// </summary>
        public decimal serviced_charged { get; set; }

        /// <summary>
        /// 已还担保费
        /// </summary>
        public decimal guarantee_fee { get; set; }

        /// <summary>
        /// 支出总额
        /// </summary>
        public decimal gross_expenditure { get; set; }

        /// <summary>
        /// 净支出
        /// </summary>
        public decimal net_disbursement { get; set; }

        /// <summary>
        ///  1：是 0：否
        /// </summary>
        public int? bank_isdefalut { get; set; }

        public decimal cst_score_available { get; set; }

        public decimal? cst_red_money { get; set; }

        /// <summary>
        /// 可用红包数量
        /// </summary>
        public int cst_red_count { get; set; }

        #region 我的借款

        /// <summary>
        /// 总数量
        /// </summary>
        public int loanCount { get; set; }

        public decimal loanMomey { get; set; }

        /// <summary>
        /// 投标中
        /// </summary>
        public int loantenderCount { get; set; }

        /// <summary>
        /// 待还款
        /// </summary>
        public int loanstayrepayCount { get; set; }

        /// <summary>
        /// 还款中
        /// </summary>
        public int loanrepeyCount { get; set; }

        /// <summary>
        /// 已结清
        /// </summary>
        public int loansettledCount { get; set; }

        #endregion 我的借款

        #region 我的投资

        /// <summary>
        /// 总数量
        /// </summary>
        public int investCount { get; set; }

        public decimal investMoney { get; set; }

        /// <summary>
        /// 投标中
        /// </summary>
        public int investtenderCount { get; set; }

        /// <summary>
        /// 还款中
        /// </summary>
        public int investrepayCount { get; set; }

        /// <summary>
        /// 已结清
        /// </summary>
        public int investsettledCount { get; set; }

        #endregion 我的投资

        #region 我的债权转让

        /// <summary>
        /// 可转让
        /// </summary>
        public int transfercanCount { get; set; }

        /// <summary>
        /// 投标中
        /// </summary>
        public int transfertenderCount { get; set; }

        /// <summary>
        /// 已转出
        /// </summary>
        public int transfertenderedCount { get; set; }

        /// <summary>
        /// 已转入
        /// </summary>
        public int transfersettledCount { get; set; }

        #endregion 我的债权转让
    }

    /// <summary>
    /// 我的收益
    /// </summary>
    public class MyEarnings
    {
        public string username { get; set; }

        /// <summary>
        /// 累计收益
        /// </summary>
        public decimal accumulated_income { get; set; }

        /// <summary>
        /// 近30天收益
        /// </summary>
        public decimal ThirtyDays_income { get; set; }
    }

    /// <summary>
    /// 我的财富
    /// </summary>
    public class MyAccountHuiFu
    {
        /// <summary>
        /// 账户总额
        /// </summary>
        public decimal account_balance { get; set; }

        /// <summary>
        /// 可用金额
        /// </summary>
        public decimal enable_amount { get; set; }

        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal freezing_amount { get; set; }
    }

    /// <summary>
    /// 投标统计
    /// </summary>
    public class InvestStatistics
    {
        /// <summary>
        /// 投资中数量
        /// </summary>
        public int tenderCount { get; set; }

        /// <summary>
        /// 投资中项目总金额
        /// </summary>
        public decimal tenderMoney { get; set; }

        /// <summary>
        /// 还款中统计
        /// </summary>
        public int repayCount { get; set; }

        /// <summary>
        /// 还款中项目总金额
        /// </summary>
        public decimal repayMoney { get; set; }

        /// <summary>
        /// 已结清数量
        /// </summary>
        public int setteldCount { get; set; }

        /// <summary>
        /// 已结清金额
        /// </summary>
        public decimal setteldMoney { get; set; }

        /// <summary>
        /// 待收本金
        /// </summary>
        public decimal principal_amount { get; set; }

        /// <summary>
        /// 待收利息
        /// </summary>
        public decimal collect_interest { get; set; }

        /// <summary>
        /// 累计投资
        /// </summary>
        public decimal invest_money { get; set; }

        /// <summary>
        /// 已收本金
        /// </summary>
        public decimal recovered_principal { get; set; }

        /// <summary>
        /// 已赚收益
        /// </summary>
        public decimal earned_interest { get; set; }
    }

    /// <summary>
    /// 我的业务
    /// </summary>
    public class MyBusiness
    {
        #region 我的借款

        /// <summary>
        /// 总数量
        /// </summary>
        public int LoanCount { get; set; }

        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 投标中
        /// </summary>
        public int LoanTenderCount { get; set; }

        public decimal LoanTenderMoney { get; set; }

        /// <summary>
        /// 待还款
        /// </summary>
        public int LoanStayRepayCount { get; set; }

        public decimal LoanStayRepayMoney { get; set; }

        /// <summary>
        /// 还款中
        /// </summary>
        public int LoanRepayCount { get; set; }

        public decimal LoanRepayMoney { get; set; }

        /// <summary>
        /// 已结清
        /// </summary>
        public int LoanSettledCount { get; set; }

        public decimal LoanSettledMoney { get; set; }

        #endregion 我的借款

        #region 我的投资

        /// <summary>
        /// 总数量
        /// </summary>
        public int InvestCount { get; set; }

        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 投标中
        /// </summary>
        public int InvestTenderCount { get; set; }

        public decimal InvestTenderMoney { get; set; }

        /// <summary>
        /// 还款中
        /// </summary>
        public int InvestRepayCount { get; set; }

        public decimal InvestRepayMoney { get; set; }

        /// <summary>
        /// 已结清
        /// </summary>
        public int InvestSettledCount { get; set; }

        public decimal InvestSettledMoney { get; set; }

        #endregion 我的投资

        #region 我的债权转让

        /// <summary>
        /// 总数量
        /// </summary>
        public int TransferCount { get; set; }

        /// <summary>
        /// 可转让
        /// </summary>
        public int CanTransferCount { get; set; }

        /// <summary>
        /// 投标中
        /// </summary>
        public int TransferTenderCount { get; set; }

        /// <summary>
        /// 已转出
        /// </summary>
        public int TransferTenderedCount { get; set; }

        /// <summary>
        /// 已转入
        /// </summary>
        public int TransferSettledCount { get; set; }

        #endregion 我的债权转让

        #region 我的红包

        /// <summary>
        /// 总数量
        /// </summary>
        public int RedCount { get; set; }

        public decimal RedMoney { get; set; }

        /// <summary>
        /// 未使用
        /// </summary>
        public int RedNotUsedCount { get; set; }

        public decimal RedNotUsedMoney { get; set; }

        /// <summary>
        /// 已使用
        /// </summary>
        public int RedUsedCount { get; set; }

        public decimal RedUsedMoney { get; set; }

        /// <summary>
        /// 已逾期
        /// </summary>
        public int RedNotExpiredCount { get; set; }

        public decimal RedNotExpiredMoney { get; set; }

        #endregion 我的红包
    }

    /// <summary>
    /// 投标记录
    /// </summary>
    public class ReRepaymentModel
    {
        //投资id
        public int InvestId { get; set; }

        public int? pro_loan_id { get; set; }

        //投资项目name
        public string LoanName { get; set; }

        //项目金额
        public decimal LoanMoney { get; set; }

        //项目利率
        public decimal LoanRate { get; set; }

        //投资金额
        public decimal InvestMoney { get; set; }

        //预期收益
        public decimal ExpectedReturn { get; set; }

        //实际收益
        public decimal RealIncome { get; set; }

        //投资进度  在投标之后赋值
        public decimal InvestSpeed { get; set; }

        //项目开始时间
        public string LoanStrat { get; set; }

        //项目结束时间
        public string LoanEnd { get; set; }

        //项目状态
        public string LoanState { get; set; }

        public string traState { get; set; }

        public decimal iduaMoney { get; set; }

        /// <summary>
        ///  投资日期
        /// </summary>
        public DateTime? pro_invest_date { get; set; }

        /// <summary>
        ///  应还总额
        /// </summary>
        public decimal? pro_pay_total { get; set; }

        /// <summary>
        ///  应还日期
        /// </summary>
        public DateTime? pro_pay_date { get; set; }

        /// <summary>
        ///  实还日期
        /// </summary>
        public DateTime? pro_collect_date { get; set; }
    }

    /// <summary>
    /// 交易记录
    /// </summary>
    public class ReTradingModel
    {
        //主键id
        public int id;

        //交易类型
        public string TradingType { get; set; }

        //交易金额
        public decimal TradingMoney { get; set; }

        //交易时间
        public string TradingDate { get; set; }

        //交易状态
        public string TradingStatus { get; set; }

        //交易流水号
        public string TradingOrderNo { get; set; }

        //项目名称
        public string TradingName { get; set; }

        //交易后账户余额
        public decimal TrandingAccountMoney { get; set; }
    }

    /// <summary>
    /// 债权转让
    /// </summary>
    public class MyTransfer
    {
        /// <summary>
        ///  转让申请标主键
        /// </summary>
        public int Id { get; set; }

        public int pro_transfer_id { get; set; }

        /// <summary>
        ///  项目申请标主键
        /// </summary>
        public int pro_loan_id { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string pro_loan_use { get; set; }

        /// <summary>
        /// 剩余债权（可转债权）
        /// </summary>
        public decimal pro_residual_claim { get; set; }

        /// <summary>
        /// 实际应付金额(转让价格)
        /// </summary>
        public decimal pro_realtransfer_money { get; set; }

        /// <summary>
        /// 年利化收益率
        /// </summary>
        public decimal investProcess { get; set; }

        /// <summary>
        /// 债权总额
        /// </summary>
        public decimal protransfer_summoney { get; set; }

        /// <summary>
        /// 转让金额
        /// </summary>
        public decimal pro_transfer_money { get; set; }

        /// <summary>
        /// 项目状态(中文)
        /// </summary>
        public string pro_transfer_statename { get; set; }

        /// <summary>
        /// 转让期数
        /// </summary>
        public int pro_realtransfer_time { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime pro_start_time { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime pro_stop_time { get; set; }

        /// <summary>
        /// 认购债权
        /// </summary>
        public decimal pao_subscription_money { get; set; }

        /// <summary>
        /// 折让率
        /// </summary>
        public decimal pro_transfer_harf_rate { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal pro_transfer_fee { get; set; }

        public string InvestProess { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal protransfer_summoney1 { get; set; }
    }

    /// <summary>
    /// 我的红包
    /// </summary>
    public class RedInfoModel
    {
        /// <summary>
        /// 获取或设置 Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_money
        /// </summary>
        public decimal cst_red_money { get; set; }

        /// <summary>
        /// 获取或设置  外键表：CST_user_info
        /// </summary>
        public int cst_user_id { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_id
        /// </summary>
        public int cst_red_id { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_useId
        /// </summary>
        public int cst_red_useId { get; set; }

        /// <summary>
        /// 获取或设置 cst_create_date
        /// </summary>
        public string cst_create_date { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_employ
        /// </summary>
        public bool cst_red_employ { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_startDate
        /// </summary>
        public string cst_red_startDate { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_endDate
        /// </summary>
        public string cst_red_endDate { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_surplusAmt
        /// </summary>
        public decimal cst_red_surplusAmt { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_number
        /// </summary>
        public int cst_red_number { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_exc
        /// </summary>
        public bool cst_red_exc { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_name 红包名称
        /// </summary>
        public string cst_red_name { get; set; }

        /// <summary>
        ///  获取或设置 cst_red_type 类型
        /// </summary>
        public string cst_red_type { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_instructions 使用说明
        /// </summary>
        public string cst_red_instructions { get; set; }

        /// <summary>
        /// 获取或设置 cst_red_validity 有效期
        /// </summary>
        public string cst_red_validity { get; set; }

        /// <summary>
        ///  获取或设置 cst_red_employName 红包使用状态名称
        /// </summary>
        public string cst_red_employName { get; set; }

        /// <summary>
        ///  获取或设置 cst_invest_id 红包投资id
        /// </summary>
        public string cst_loan_id { get; set; }
    }

    /// <summary>
    /// 我的借款记录
    /// </summary>
    public class MyLoanrecord
    {
        /// <summary>
        /// 记录id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 项目名称(用途)
        /// </summary>
        public string loaname { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal loanmoney { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal pro_loan_rate { get; set; }

        /// <summary>
        /// 借款期限
        /// </summary>
        public decimal pro_loan_period { get; set; }

        //时间单位
        public string pro_loan_period_unit { get; set; }

        /// <summary>
        /// 已还款
        /// </summary>
        public decimal repayment { get; set; }

        /// <summary>
        /// 进度
        /// </summary>
        public decimal pro_loan_speed { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public decimal pro_loan_state { get; set; }

        public string traState { get; set; }

        //满标日期
        public DateTime FullDate { get; set; }

        /// <summary>
        ///  添加日期即申请日期
        /// </summary>
        public DateTime? pro_add_date { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal? loan_invest_money { get; set; }

        /// <summary>
        /// 最早应还日期
        /// </summary>
        public DateTime loan_repay_date { get; set; }

        /// <summary>
        /// 最早应还期数
        /// </summary>
        public int loan_repay_period { get; set; }

        /// <summary>
        /// 最早应还应还金额
        /// </summary>
        public decimal loan_repay_money { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime loan_pay_date { get; set; }

        /// <summary>
        /// 还款本金
        /// </summary>
        public decimal loan_pay_money { get; set; }

        /// <summary>
        /// 还款利息
        /// </summary>
        public decimal loan_pay_rate { get; set; }

        /// <summary>
        /// 还款罚金
        /// </summary>
        public decimal loan_pay_over_rate { get; set; }

        /// <summary>
        /// 还款服务费
        /// </summary>
        public decimal loan_pay_service_fee { get; set; }
    }

    /// <summary>
    /// 我的借款统计
    /// </summary>
    public class LoanStatistics
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string pro_loan_name { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal pro_loan_money { get; set; }

        /// <summary>
        /// 项目期限
        /// </summary>
        public string pro_loan_peroid { get; set; }

        /// <summary>
        /// 已还本息
        /// </summary>
        public decimal pro_loan_paymoney { get; set; }

        /// <summary>
        /// 未还本息
        /// </summary>
        public decimal pro_loan_notpaymoney { get; set; }

        /// <summary>
        /// 未还期数
        /// </summary>
        public string pro_loan_notpayperoid { get; set; }
    }

    /// <summary>
    /// 我的借款明细
    /// </summary>
    public class MyLoanDetails
    {
        /// <summary>
        /// 已还本金
        /// </summary>
        public decimal already_principal { get; set; }

        /// <summary>
        /// 已还利息
        /// </summary>
        public decimal interest_rate { get; set; }

        /// <summary>
        /// 已还服务费
        /// </summary>
        public decimal serviced_charged { get; set; }
    }

    /// <summary>
    /// 还款计划记录
    /// </summary>
    public class RepaymentPlanView
    {
        //应还日期
        public string Loan_next_date { get; set; }

        //应还本息
        public decimal? Real_loan_money { get; set; }

        //期数
        public int? Pro_loan_period { get; set; }

        //还款利息
        public decimal? Pro_loan_Interest_not { get; set; }

        //还款时间
        public DateTime pro_pay_Date { get; set; }

        //应还服务费
        public decimal? Pro_pay_service_fee { get; set; }

        //还款类型
        public string Pro_state { get; set; }

        //是否还清
        public string IsClear { get; set; }

        public int Id { get; set; }
        public string loaname { get; set; }
    }

    /// <summary>
    /// 还款计划信息
    /// </summary>
    public class LoanInfoDeatil
    {
        /// <summary>
        /// 记录id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 具体某一期的id
        /// </summary>
        public int laon_plan_id { get; set; }

        /// <summary>
        /// 项目名称(用途)
        /// </summary>
        public string loaname { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal loanmoney { get; set; }

        /// <summary>
        /// 借款利率
        /// </summary>
        public decimal pro_loan_rate { get; set; }

        /// <summary>
        /// 借款期限
        /// </summary>
        public int pro_loan_period { get; set; }

        /// <summary>
        /// 进度
        /// </summary>
        public decimal pro_loan_speed { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public decimal pro_loan_state { get; set; }

        /// <summary>
        /// 应还总额
        /// </summary>
        public decimal real_loan_money { get; set; }

        /// <summary>
        /// 下次还款日期
        /// </summary>
        public DateTime loan_next_date { get; set; }

        /// <summary>
        /// 剩余期数
        /// </summary>
        public decimal surplus_loan_period { get; set; }

        /// <summary>
        /// 已换期数
        /// </summary>
        public decimal pro_loan_period_over { get; set; }

        /// <summary>
        /// 已还本金
        /// </summary>
        public decimal pro_loan_principal { get; set; }

        /// <summary>
        /// 已还利息
        /// </summary>
        public decimal pro_loan_Interest { get; set; }

        /// <summary>
        /// 未还本金
        /// </summary>
        public decimal pro_loan_principal_not { get; set; }

        /// <summary>
        /// 未还利息
        /// </summary>
        public decimal pro_loan_Interest_not { get; set; }

        /// <summary>
        /// 逾期费
        /// </summary>
        public decimal pro_Late_fee { get; set; }

        /// <summary>
        /// 下次应还费用
        /// </summary>
        public decimal pro_loan_money_next { get; set; }

        /// <summary>
        /// 本期应还总额
        /// </summary>
        public decimal pro_loan_money_curreny { get; set; }

        /// <summary>
        /// 应还总额
        /// </summary>
        public decimal pro_loan_moeny_sum { get; set; }

        public bool pro_is_clear { get; set; }
    }

    ///
    /// 充值
    /// </summary>
    public class SuRechargeModel
    {
        //充值金额
        public decimal RechargeMoney { get; set; }

        //充值类型
        public string RechargeType { get; set; }

        //用户id
        public int userid { get; set; }

        public DateTime RechargeTime { get; set; }

        public string RechargeOrderNo { get; set; }
    }

    /// <summary>
    /// 提现
    /// </summary>
    public class SuWithdrawalModel
    {
        //提现金额
        public decimal WithdrawalMoney { get; set; }

        //用户id
        public int userid { get; set; }

        public string RechargeOrderNo { get; set; }
    }

    /// <summary>
    /// 添加银行卡
    /// </summary>
    public class AddBankCardnewModel
    {
        public int userid { get; set; }
    }

    /// <summary>
    /// 银行卡信息
    /// </summary>
    public partial class CSTBankCardinfoModel
    {
        /// <summary>
        /// 获取或设置 银行卡名称
        /// </summary>
        public string bank_name { get; set; }

        /// <summary>
        /// 获取或设置 银行卡图片地址
        /// </summary>
        public string bank_pic_addr { get; set; }

        /// <summary>
        /// 获取或设置 银行卡是否可删除
        /// </summary>
        public bool bankcard_isDelAdd { get; set; }

        /// <summary>
        /// 获取或设置 Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置  外键表：ACT_account_info
        /// </summary>
        public int mon_account_id { get; set; }

        /// <summary>
        /// 获取或设置 bank_no
        /// </summary>
        public string bank_no { get; set; }

        /// <summary>
        /// 获取或设置 bank_code
        /// </summary>
        public string bank_code { get; set; }

        /// <summary>
        /// 获取或设置 bank_prov
        /// </summary>
        public string bank_prov { get; set; }

        /// <summary>
        /// 获取或设置 bank_area
        /// </summary>
        public string bank_area { get; set; }

        /// <summary>
        /// 获取或设置  1：是 0：否
        /// </summary>
        public int bank_isdefalut { get; set; }

        //绑卡时间
        public string add_time { get; set; }
    }

    /// <summary>
    /// 开户信息
    /// </summary>
    public class AccountInforModel
    {
        //开户姓名
        public string act_user_name { get; set; }

        //开户账号
        public string act_user_number { get; set; }

        //开户邮箱
        public string act_user_email { get; set; }

        //身份证
        public string act_id_card { get; set; }
    }

    /// <summary>
    /// 可转让债权
    /// </summary>
    public class PRO_ClaimsCanTransModel
    {
        public int pro_transfer_id { get; set; }
        public int pro_invest_emp { get; set; }

        public string pro_loan_use { get; set; }

        public int pro_loan_id { get; set; }

        public DateTime pro_start_date { get; set; }

        public int pro_invest_id { get; set; }

        public decimal pro_loan_rate { get; set; }

        public int pro_transfer_state { get; set; }
        public decimal prinInt { get; set; }
        public int leftPeriod { get; set; }

        /// <summary>
        /// 删除标记（初审未通过或流标的转让可以再次转让，将之前的转让标删除标记置为1）
        /// </summary>
        public bool pro_is_del { get; set; }

        /// <summary>
        /// 折让率
        /// </summary>
        public decimal? pro_transfer_harf_rate { get; set; }

        /// <summary>
        /// 最近一次还款日
        /// </summary>
        public DateTime minPayDate { get; set; }

        /// <summary>
        /// 可转份额
        /// </summary>
        public decimal pro_idual_money { get; set; }

        public decimal? pro_transfer_money { get; set; }

        public string BZCH { get; set; }
    }

    /// <summary>
    /// 开户提交信息
    /// </summary>
    public class OpenAccountProcessRequest
    {
        // 开户需要的实体字段

        /// <summary>
        /// 业务逻辑层传过来的页面返回地址
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 注册类型
        /// </summary>
        public string OpenAccountType { set; get; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public int AccountType { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string OpenAccountMobile { set; get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string OpenAccountEmail { set; get; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string OpenAccountRealName { set; get; }

        /// <summary>
        /// 身份证号/营业执照号
        /// </summary>
        public string OpenAccountCardNo { set; get; }

        /// <summary>
        /// 用户在网贷平台的账号
        /// </summary>
        public string OpenAccountUserName { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OpenAccountReMark1 { set; get; }

        /// <summary>
        /// 用户在user_info表的主键
        /// </summary>
        public int OpenAccountUserID { set; get; }

        /// <summary>
        /// 经办人custom表主键
        /// </summary>
        public int JinbanrenCustomId { set; get; }

        //富有增加
        /// <summary>
        /// 登录密码
        /// </summary>
        public string lpassword { set; get; }

        /// <summary>
        /// 提现密码
        /// </summary>
        public string password { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string rem { set; get; }

        /// <summary>
        /// 开户行支行名称
        /// </summary>
        public string bank_nm { set; get; }

        /// <summary>
        /// 户名 提现账户开户名 此字段值已无效，后台强制取值同客户姓名
        /// </summary>
        public string capAcntNm { set; get; }

        /// <summary>
        /// 帐号
        /// </summary>
        public string capAcntNo { set; get; }

        /// <summary>
        /// 开户行地区代码
        /// </summary>
        public string city_id { set; get; }

        /// <summary>
        /// 开户行行别
        /// </summary>
        public string parent_bank_id { set; get; }

        /// <summary>
        /// 是否是后台个人用户开户
        /// </summary>
        public bool is_back_person { get; set; }
    }

    public class RemainMoeny
    {
        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal remainMoeny { get; set; }
    }

    /// <summary>
    /// 安全中心
    /// </summary>
    public class SafeCenter
    {
        //是否实名
        public string Is_RealName { get; set; }

        //是否开户
        public string Is_Account { get; set; }

        //是否绑定手机
        public string Is_Phone { get; set; }

        //是否邮箱认证
        public string Is_Email { get; set; }

        //是否设置登录密码
        public string Is_Loginpwd { get; set; }

        //是否设置交易密码
        public string Is_Tradepwd { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Is_UserCard { get; set; }

        //是否绑卡
        public string Is_BandCard { get; set; }

        //是否存在推荐人
        public int Is_TJID { get; set; }

        //推荐人用户名
        public string Is_UserName { get; set; }

        //推荐人手机号
        public string Is_Userphone { get; set; }
    }

    #endregion

    #region cala add

    public class RUserThirdPartInfo
    {
        public string RealName { get; set; }

        public string IdCard { get; set; }

        public string PhoneNo { get; set; }

        public string BankCode { get; set; }

        public string BankName { get; set; }

        public string BankNo { get; set; }
        /// <summary>
        /// 0 失败 1成功
        /// </summary>
        public string JieSuan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BoHai { get; set; }
        /// <summary>
        /// 结算返回码
        /// </summary>
        public string JieSuanCode { get; set; }
        /// <summary>
        /// 结算返回信息
        /// </summary>
        public string JieSuanMsg { get; set; }
        /// <summary>
        /// 渤海返回碼
        /// </summary>
        public string BoHaiCode { get; set; }
        /// <summary>
        /// 渤海返回信息
        /// </summary>
        public string BohaiMsg { get; set; }
        /// <summary>
        /// 是否有曾经绑卡的操作
        /// </summary>
        public string OnceBohai { get; set; } = "0";
        /// <summary>
        /// 是否又曾经开户操作
        /// </summary>
        public string OnceJieSuan { get; set; } = "0";
        /// <summary>
        /// 账户类型 1=投资户；2=融资户
        /// </summary>
        public string BusinessProperty { get; set; }
    }

    public class RMyRepayLoans
    {
        public int Count { get; set; }

        public List<RMyRepayLoan> RepayLoans { get; set; } = new List<RMyRepayLoan>();
    }

    public class RMyRepayLoan
    {
        public int LoanId { get; set; }

        public string LoanName { get; set; }

        public string WaitRepayMoney { get; set; }

        public string WaitRepayPeriod { get; set; }

        public string LoanMoney { get; set; }

        public string LoanPeriod { get; set; }

        public string LoanRate { get; set; }

        public string FullDate { get; set; }

        public string RepayType { get; set; }

        public string RepayTypeName { get; set; }

        public List<RMyLoanPlanModel> RepayLoanPlans { get; set; } = new List<RMyLoanPlanModel>();
    }

    public class RGurClearedPlan
    {
        public string LoanId { get; set; }

        public string LoanNo { get; set; }

        public string LoanName { get; set; }

        public string PlanPeriod { get; set; }
        /// <summary>
        /// 还款日期
        /// </summary>
        public string PayDate { get; set; }
        /// <summary>
        /// 已还本金
        /// </summary>
        public string PayMoney { get; set; }
        /// <summary>
        /// 已还利息
        /// </summary>
        public string PayRate { get; set; }
        /// <summary>
        /// 已还逾期
        /// </summary>
        public string PayOverdue { get; set; }
        /// <summary>
        /// 已还总额
        /// </summary>
        public string PayPrincipal { get; set; }
        /// <summary>
        /// 已还服务费
        /// </summary>
        public string PayServiceFee { get; set; }
    }
    #endregion
}