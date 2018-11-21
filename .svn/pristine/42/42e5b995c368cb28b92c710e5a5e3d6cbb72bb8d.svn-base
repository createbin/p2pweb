using System;
using System.Collections.Generic;
using System.Text;
using ZFCTPC.Data.ApiModelReturn.LoanReturnModels;

namespace ZFCTPC.Data.ApiModelReturn.InvestModelReturns
{
    #region 统计信息
    public class HomeStatistics
    {
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal AllTranscationMoney { get; set; }
        /// <summary>
        /// 总收益
        /// </summary>
        public decimal AllProfitMoney { get; set; }
        /// <summary>
        /// 总用户
        /// </summary>
        public int AllUser { get; set; }
        /// <summary>
        /// 安全日期
        /// </summary>
        public int SecureDay { get; set; }
    }

    #endregion

    #region 首页标记数据
    public class HomeLoanModel
    {
        public HomeLoanModel()
        {
            loanInfos = new List<HomeLoanInfo>();
        }
        public int loanTypeId { get; set; }

        public string loanType { get; set; }

        public List<HomeLoanInfo> loanInfos { get; set; }
    }

    public class HomeLoanInfo
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public int LoanId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }
        /// <summary>
        /// 年华收益率
        /// </summary>
        public decimal YearRate { get; set; }
        /// <summary>
        /// 原始收益率
        /// </summary>
        public decimal? OriginalRate { get; set; }
        /// <summary>
        /// 加息利率
        /// </summary>
        public decimal? HikeRate { get; set; }
        /// <summary>
        /// 投资期限
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        public string RepaymentType { get; set; }
        /// <summary>
        /// 项目进度
        /// </summary>
        public decimal LoanSpeed { get; set; }
        /// <summary>
        /// 剩余可投金额
        /// </summary>
        public decimal SurplusMoney { get; set; }
        /// <summary>
        /// 是否可用红包
        /// </summary>
        public bool IsRedPackage { get; set; }
        /// <summary>
        /// 是否可以转让
        /// </summary>
        public bool IsTransfer { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public string LoanState { get; set; }
        /// <summary>
        /// 项目状态id
        /// </summary>
        public int LoanStateId { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        public string RepeymentTypeCode { get; set; }
        /// <summary>
        /// 最少投资金额
        /// </summary>
        public decimal LeastMoney { get; set; }
        /// <summary>
        /// 最多允许投资金额
        /// </summary>
        public decimal MaxMoney { get; set; }
    }
    #endregion


    #region 列表页数据

    public class AvaliableLoanCount
    {
        public int loanType { get; set; }

        public string loanName { get; set; }
        public int count { get; set; }
    }

    public class LoanList
    {
        public LoanList()
        {
            LoanAbstracts = new List<LoanAbstract>();
        }

        public int count { get; set; }

        public int page { get; set; }

        public int pageSize { get; set; }

        public List<LoanAbstract> LoanAbstracts { get; set; }
    }

    public class LoanAbstract : HomeLoanInfo
    {


    }


    public class LoanDetail : LoanAbstract
    {
        public decimal LoanMoney { get; set; }

        public string ProductType { get; set; }

        public decimal MinInvestMoney { get; set; }

        public decimal MaxInvestMoney { get; set; }

        public string Lables { get; set; }

        public string LableIcons { get; set; }

        public int LoanType { get; set; }

        public string LoanTypeName { get; set; }

        public string PublishDate { get; set; }

        /// <summary>
        /// 标的风险类型 by gaochao 2018 02 28
        /// </summary>
        public string LoanRiskType { get; set; }

        public string IsCompany { get; set; }


    }
    /// <summary>
    /// 借款人信息
    /// </summary>
    public class LoanerInfo
    {
        public LoanerInfo()
        {
            annexes = new List<LoanAnnex>();
        }
        public int loanId { get; set; }

        public string loanerIntro { get; set; }

        public string repaymentResource { get; set; }

        public List<LoanAnnex> annexes { get; set; }
    }

    public class LoanAnnex
    {
        //影像资料id
        public int AnnexId { get; set; }
        //影像资料Name
        public string AnnexName { get; set; }
        //影像资料URl
        public string AnnexURl { get; set; }
        //上传时间
        public string AnnexTime { get; set; }
    }


    public class InvestIncome
    {
        public decimal intrest { get; set; }
    }
    #endregion

    #region 投资实体
    public class InvestProcessRequest
    {

        public InvestProcessRequest()
        {
            this.Investor = new InvesterEntity();
            this.Borrower = new List<BorrowerEntity>();
            this.Warrant = new WarrantEntity();

        }
        /// <summary>
        /// 是不是众筹用户
        /// </summary>
        public bool IsRaise { get; set; }


        /// <summary>
        /// 投资人信息
        /// </summary>
        public InvesterEntity Investor { set; get; }

        /// <summary>
        /// 借款人信息
        /// </summary>
        public List<BorrowerEntity> Borrower { set; get; }


        /// <summary>
        /// 投资记录表ID
        /// </summary>
        public string InvestId { set; get; }

        /// <summary>
        /// 项目ID 项目类型为1，则PRO_loan_apply表主键; 2为PRO_transfer_apply表主键;3为PRO_buy_apply表主键
        /// </summary>
        public string ProjectID { set; get; }

        /// <summary>
        /// 项目类型 1普通项目 2转让标 3收购标
        /// </summary>
        public string ProjectType { set; get; }


        /// <summary>
        /// 投资人获取的红包或奖励
        /// </summary>
        public decimal OtherMoney { set; get; }

        /// <summary>
        /// 投资人使用红包的用户红包表ID
        /// </summary>
        public int redId { set; get; }

        /// <summary>
        /// 担保机构
        /// </summary>
        public WarrantEntity Warrant { set; get; }

        /// <summary>
        /// 服务费/手续费
        /// </summary>
        public decimal Fee { set; get; }


        /// <summary>
        /// 经办人custom表主键
        /// </summary>
        public int JinbanrenCustomId { set; get; }

        /// <summary>
        /// 标的id
        /// </summary>
        public string ProId { get; set; }

    }
    #region 投资人信息
    /// <summary>
    /// 投资人信息
    /// </summary>
    public class InvesterEntity
    {
        public InvesterEntity()
        {
            this.bidDetails = new BidDetails();
        }

        /// <summary>
        /// 投资人主键
        /// </summary>
        public string InvestorID { set; get; }

        /// <summary>
        /// 投资人类型 1个人;2企业
        /// </summary>
        public string InvestorType { set; get; }
        /// <summary>
        /// 投资人第三方账户开户账户
        /// </summary>
        public string InverstorThirdPartAccountNo { set; get; }


        /// <summary>
        /// 投资金额/应收总额/实际项目金额/转让金额/ 承接金额
        /// </summary>
        public decimal Amount { set; get; }

        ///// <summary>
        ///// 承接金额
        ///// </summary>
        //public decimal CreditDealAmt { set; get; }

        /// <summary>
        /// 投资流水号
        /// </summary>
        public string TradeFlowNo { set; get; }

        /// <summary>
        /// 自动债权转让接口  债权转让明细
        /// </summary>
        public BidDetails bidDetails { get; set; }

        /// <summary>
        /// 投资人备用字段1
        /// </summary>
        public string Remark1 { set; get; }

        /// <summary>
        /// 投资人备用字段2
        /// </summary>
        public string Remark2 { set; get; }

        /// <summary>
        /// 投资人备用字段3
        /// </summary>
        public string Remark3 { set; get; }

    }

    #endregion

    #region 借款人


    /// <summary>
    /// 借款人信息
    /// </summary>
    public class BorrowerEntity
    {
        /// <summary> 
        /// 借款人主键
        /// </summary>
        public string BorrowerID { set; get; }

        /// <summary>
        /// 借款人类型 1个人;2企业;3担保小贷;4平台
        /// </summary>
        public string BorrowerType { set; get; }


        /// <summary>
        /// 借款人第三方账户开户号
        /// </summary>
        public string InverstorThirdPartAccountNo { set; get; }

        /// <summary>
        /// 借款用途
        /// </summary>
        public string BorrowUse { set; get; }

        /// <summary>
        /// 借款人金额/担保费/服务费
        /// </summary>
        public decimal Amount { set; get; }

        /// <summary>
        /// 投资人备用字段1
        /// </summary>
        public string Remark1 { set; get; }

        /// <summary>
        /// 投资人备用字段2
        /// </summary>
        public string Remark2 { set; get; }

        /// <summary>
        /// 投资人备用字段3
        /// </summary>
        public string Remark3 { set; get; }
    }
    #endregion

    #region 担保，小贷机构
    /// <summary>
    /// 担保/小贷机构信息
    /// </summary>
    public class WarrantEntity
    {
        /// <summary> 
        /// 担保/小贷机构主键
        /// </summary>
        public string BorrowerID { set; get; }


        /// <summary>
        /// 担保/小贷机构第三方账户开户号
        /// </summary>
        public string InverstorThirdPartAccountNo { set; get; }


        /// <summary>
        /// 担保费
        /// </summary>
        public decimal Amount { set; get; }

        /// <summary>
        /// 担保/小贷机构备用字段1
        /// </summary>
        public string Remark1 { set; get; }

        /// <summary>
        /// 担保/小贷机构备用字段2
        /// </summary>
        public string Remark2 { set; get; }

        /// <summary>
        /// 担保/小贷机构备用字段3
        /// </summary>
        public string Remark3 { set; get; }
    }

    #endregion

    #region 债权转让明细
    /// <summary>
    /// /债权转让明细
    /// </summary>
    public class BidDetails
    {
        /// <summary>
        /// 被转让的投标订单号
        /// </summary>
        public string BidOrdId { get; set; }
        /// <summary>
        /// 被转让的投标订单日期
        /// </summary>
        public string BidOrdDate { get; set; }
        /// <summary>
        /// 转让金额
        /// </summary>
        public string BidCreditAmt { get; set; }
        /// <summary>
        /// 借款人客户号
        /// </summary>
        public string BorrowerCustId { get; set; }
        /// <summary>
        /// 明细转让金额    BorrowerDetails中的明细转让金额的总和等于BidCreditAmt
        /// </summary>
        public string BorrowerCreditAmt { get; set; }
        /// <summary>
        /// 已还款金额
        /// </summary>
        public string PrinAmt { get; set; }
    }
    #endregion
    #endregion

    #region 红包实体

    public class LoanRedPackages
    {
        public LoanRedPackages()
        {
            RedPackages = new List<RedPackage>();
        }
        public int LoanId { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// 红包可用状态
        /// </summary>
        public bool State { get; set; }

        public List<RedPackage> RedPackages { get; set; }
    }

    public class RedPackage
    {
        public int RedId { get; set; }

        public string RedName { get; set; }
        public decimal RedMoney { get; set; }

        public int RedPackageState { get; set; }

        public string EndDate { get; set; }

        public string Condition { get; set; }

        public decimal? AtLeatMoney { get; set; }
    }

    #endregion

    #region p2p3.1
    public class LoanListLable
    {
        public LoanListLable()
        {
            LoanAbstracts = new List<LoanAbstractLable>();
        }

        public int count { get; set; }

        public int page { get; set; }

        public int pageSize { get; set; }

        public List<LoanAbstractLable> LoanAbstracts { get; set; }
    }

    public class LoanAbstractLable : HomeLoanInfo
    {
        public int periodDay { get; set; }

        public string lables { get; set; }

        public string lableIcons { get; set; }
    }

    #endregion

    #region 还款跟踪
    public class LoanFollow
    {
        public LoanFollow()
        {
            results = new List<LoanFollowDetail>();
        }

        public List<LoanFollowDetail> results { get; set; }
    }

    public class LoanFollowDetail
    {
        public string followDate { get; set; }

        public string followIntro { get; set; }
    }
    #endregion

    #region 4月 融资信息
    public class LoanProjectDetails
    {
        public LoanProjectDetails()
        {
            Info = new FinancingInformation();
            Guar = new RepaymentGuarantee();
            Personal = new LoanerInfomation();
            Coer = new CoInfomation();
            History = new LoanerHistory();
            RiskInfo = new LoanRiskResult();
            Check = new ReviewProject();
            Annexes = new List<LoanAnnex>();
        }
        /// <summary>
        /// 标的id
        /// </summary>
        public string LoanId { get; set; }
        /// <summary>
        /// 是否为企业
        /// </summary>
        public string IsCo { get; set; }

        /// <summary>
        /// 融资信息
        /// </summary>
        public FinancingInformation Info { get; set; }
        /// <summary>
        /// 还款保障
        /// </summary>
        public RepaymentGuarantee Guar { get; set; }
        /// <summary>
        /// 个人借款人信息
        /// </summary>
        public LoanerInfomation Personal { get; set; }
        /// <summary>
        /// 企业借款人信息
        /// </summary>
        public CoInfomation Coer { get; set; }
        /// <summary>
        /// 借款人历史数据
        /// </summary>
        public LoanerHistory History { get; set; }
        /// <summary>
        /// 风险信息
        /// </summary>
        public LoanRiskResult RiskInfo { get; set; }
        /// <summary>
        /// 审查项目
        /// </summary>
        public ReviewProject Check { get; set; }

        /// <summary>
        /// 项目资料
        /// </summary>
        public List<LoanAnnex> Annexes { get; set; }
    }
    /// <summary>
    /// 融资信息
    /// </summary>
    public class FinancingInformation
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string LoanName { get; set; }
        /// <summary>
        /// 项目简介
        /// </summary>
        public string LoanIntro { get; set; }
        /// <summary>
        /// 借款人主体性质
        /// </summary>
        public string LoanerCharacter { get; set; }
        /// <summary>
        /// 借款人姓名
        /// </summary>
        public string LoanerName { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public string LoanMoney { get; set; }
        /// <summary>
        /// 借款期限
        /// </summary>
        public string LoanPeriod { get; set; }
        /// <summary>
        /// 借款用途
        /// </summary>
        public string LoanUse { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        public string LoanType { get; set; }
        /// <summary>
        ///还款方式
        /// </summary>
        public string LoanRepayment { get; set; }
        /// <summary>
        /// 还款来源
        /// </summary>
        public string LoanSource { get; set; }
        /// <summary>
        /// 安全保障
        /// </summary>
        public string SafetyPrecautions { get; set; }
    }

    /// <summary>
    /// 还款保障
    /// </summary>
    public class RepaymentGuarantee
    {
        /// <summary>
        /// 还款保障
        /// </summary>
        public string Guarantee { get; set; }
    }

    public class LoanerInfomation
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; } = "";
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; } = "";
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; } = "";
        /// <summary>
        /// 教育情况
        /// </summary>
        public string Education { get; set; } = "";
        /// <summary>
        /// 工作
        /// </summary>
        public string Industry { get; set; } = "";
        /// <summary>
        /// 工作年限
        /// </summary>
        public string WorkYear { get; set; } = "";
        /// <summary>
        /// 收入
        /// </summary>
        public string Income { get; set; } = "";
    }

    public class CoInfomation
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// 法人
        /// </summary>
        public string Corporate { get; set; } = "";
        /// <summary>
        /// 注册资本
        /// </summary>
        public string RegisteredCapital { get; set; } = "";
        /// <summary>
        /// 实缴资本
        /// </summary>
        public string PaidCapital { get; set; } = "";
        /// <summary>
        /// 所属行业
        /// </summary>
        public string Industry { get; set; } = "";
        /// <summary>
        /// 经营年限
        /// </summary>
        public string BusinessLife { get; set; } = "";
        /// <summary>
        /// 企业年收入
        /// </summary>
        public string AnnualIncome { get; set; } = "";
    }

    public class LoanerHistory
    {
        /// <summary>
        /// 负债
        /// </summary>
        public string Liabilities { get; set; }
        /// <summary>
        /// 历史借款笔数
        /// </summary>
        public string HistoryLoan { get; set; }
        /// <summary>
        /// 历史逾期
        /// </summary>
        public string HistoryOverDue { get; set; }
        public string UnclearLoan { get; set; }
        /// <summary>
        /// 未结清金额
        /// </summary>
        public string UnclearMoney { get; set; }
        /// <summary>
        /// 其他平台情况
        /// </summary>
        public string OtherPlatform { get; set; }
    }

    public class LoanRiskResult
    {
        public string RiskResult { get; set; }
    }

    public class ReviewProject
    {
        public ReviewProject()
        {
            Reviewed = new List<string>();
        }
        public List<string> Reviewed { get; set; }
    }
    #endregion

    #region 4月 还款追踪
    public class TrackingDetails
    {
        public string LoanId { get; set; }

        public string Count { get; set; }

        public List<RepaymentTracking> Trackings { get; set; } = new List<RepaymentTracking>();
    }

    public class RepaymentTracking
    {
        public string TrackingDate { get; set; }

        public List<TrackInfo> TrackInfos { get; set; } = new List<TrackInfo>();
    }


    public class TrackInfo
    {
        public string Order { get; set; }

        public string TrackTitle { get; set; }

        public string TrackDesc { get; set; }
    }
    #endregion
}
