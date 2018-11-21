using System;
using System.Collections.Generic;

namespace ZFCTPC.Data.ApiModel.MyAccountRequestModels
{

    #region 接口 1.0
    /// <summary>
    /// 我的业务统计
    /// </summary>
    public class MyBusinessModel : BaseRequestModel
    {
        /// <summary>
        /// 项目状态
        /// 0 全部 1 投标数量统计 2 借款数据统计 3 债权数量统计 4 红包数量统计
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// 投标记录
    /// </summary>
    public class SuMyInvestRecord : RequestPageModel
    {
        /// <summary>
        /// 项目状态
        /// 1为还款中 2为投标中 3为已结清
        /// </summary>
        public int Type { get; set; }
    }

    /// <summary>
    /// 交易记录
    /// </summary>
    public class SuTradingRecord : RequestPageModel
    {
        /// <summary>
        /// 交易类型
        /// 1为全部交易记录 2为充值记录  3为提现记录 5 充值提现
        /// </summary>
        public int TradingType { get; set; }

        public DateTime? min { get; set; }

        public DateTime? Max { get; set; }
    }

    /// <summary>
    /// 债权转让
    /// </summary>
    public class MyTransferList : RequestPageModel
    {
        //类型（0,转让中 1:已转出 2 已转入）
        public int Type { get; set; }
    }

    /// <summary>
    /// 我的红包
    /// </summary>
    public class SubRedList : RequestPageModel
    {
        //类型 不传 已转让 1 已使用 2 未使用 3 已过期
        public string Type { get; set; }
    }

    /// <summary>
    /// 我的借款
    /// </summary>
    public class MyLoanList : RequestPageModel
    {
        //类型（0,还款中 1:投标中 2：已结清）
        public int Type { get; set; }
    }

    /// <summary>
    /// 还款计划
    /// </summary>
    public class RepaymentData : RequestPageModel
    {
        // 标
        public int id { get; set; }
    }

    /// <summary>
    /// 还款计划信息
    /// </summary>
    public class LoanDetails : BaseRequestModel
    {
        //还款计划
        public int id { get; set; }
    }

    /// <summary>
    /// 还款
    /// </summary>
    public class RepaymentPlanData : BaseRequestModel
    {
        //还款计划
        public int id { get; set; }

        //验证码
        public string VerCode { get; set; }
    }

    /// <summary>
    /// 充值
    /// </summary>
    public class RechargeModel : BaseRequestModel
    {
        //充值金额
        public decimal RechargeMoney { get; set; }

        //充值类型
        public string RechargeType { get; set; }

        public string bank { get; set; }

        public string DF { get; set; }
    }

    /// <summary>
    /// 提现
    /// </summary>
    public class WithdrawalMdoel : BaseRequestModel
    {
        public decimal WithdrawalMoney { get; set; }
        //签名
    }

    /// <summary>
    /// 删除银行卡
    /// </summary>
    public class DelBankModel : BaseRequestModel
    {
        public int bankId { get; set; }
    }

    public class SubRepayment : RequestPageModel
    {
        /// <summary>
        /// 0 已还清 1 未还清
        /// </summary>
        public int Type { get; set; }
    }

    public class SendEmail : BaseRequestModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }

    public class ChangeEmail : BaseRequestModel
    {
        public string Email { get; set; }
        public string VerCode { get; set; }
    }

    public class ChangePhone : BaseRequestModel
    {
        public string Phone { get; set; }
        public string VerCode { get; set; }
    }

    public class ChangePassword : BaseRequestModel
    {
        //修改后用户密码
        public string Password { get; set; }

        //原密码
        public string OldPassword { get; set; }
    }

    /// <summary>
    /// 撤回债权转让
    /// </summary>
    public class RecallTransfer : BaseRequestModel
    {
        /// <summary>
        /// 转让申请id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// 撤回债权转让
    /// </summary>
    public class DoTransferData : BaseRequestModel
    {
        public int investId { get; set; }
        public decimal discount { get; set; }
        public decimal idualMoney { get; set; }
    }

    /// <summary>
    /// 下载合同
    /// </summary>
    public class DownloadFile : BaseRequestModel
    {
        public int id { get; set; }
    }

    /// <summary>
    /// 调查问卷
    /// </summary>
    public class QuestionScore : BaseRequestModel
    {
        public int score { get; set; }
        public List<QuestionnAnswer> answers { get; set; }
    }

    public class QuestionnAnswer
    {
        public decimal Score { get; set; }

        public int Aid { get; set; }
    }
    #endregion

    #region 接口 2.0
    /// <summary>
    /// 融资转账
    /// </summary>
    public class SFinanceTransfer : BaseRequestModel
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
    }

    /// <summary>
    /// 充值
    /// </summary>
    public class SBHAccountRecharge : BaseRequestModel
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 用户属性
        /// </summary>
        public int UserAttribute { get; set; }
    }

    /// <summary>
    /// 提现
    /// </summary>
    public class SBHAccountWithdraw : BaseRequestModel
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 用户属性
        /// </summary>
        public int UserAttribute { get; set; }
    }

    /// <summary>
    /// 渤海账户信息
    /// </summary>
    public class SJsQueryChargeAccount : BaseRequestModel
    {
        /// <summary>
        /// 用户属性
        /// </summary>
        public int UserAttribute { get; set; }
    }

    /// <summary>
    /// 项目还款计划
    /// </summary>
    public class SLoanPlan : RequestPageModel
    {
        /// <summary>
        /// 标的id
        /// </summary>
        public int LoanId { get; set; }
    }

    /// <summary>
    /// 还款明细
    /// </summary>
    public class SRepayDetail : BaseRequestModel

    {
        /// <summary>
        /// 项目还款计划的id
        /// </summary>
        public int LoanPlanId { get; set; }
    }

    /// <summary>
    /// 债权转让申请
    /// </summary>
    public class SDoTransferData : BaseRequestModel
    {
        /// <summary>
        /// 投资ID
        /// </summary>
        public int InvestId { get; set; }

        /// <summary>
        /// 转让折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 转让金额
        /// </summary>
        public decimal IdualMoney { get; set; }
    }

    /// <summary>
    /// 撤回债权转让
    /// </summary>
    public class SRecallTransfer: BaseRequestModel
    { 
        /// <summary>
        /// 转让申请id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// 用户交易记录
    /// </summary>
    public class SAccountTrading : RequestPageModel
    {
        /// <summary>
        /// 交易类型
        /// 0 全部
        /// 1 非充值提现
        /// 2 充值提现
        /// 3 充值
        /// 4 提现
        /// 5 项目回款
        /// 6 投资
        /// 7 红包
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Max { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? Min { get; set; }
    }

    /// <summary>
    /// 用户问卷积分
    /// </summary>
    public class SQuestionScore : BaseRequestModel
    {
        public int score { get; set; }

        public List<SQuestionnAnswer> answers { get; set; }
    }

    public class SQuestionnAnswer
    {
        public decimal Score { get; set; }

        public int Aid { get; set; }
    }

    /// <summary>
    /// 还款
    /// </summary>
    public class SRepayment: BaseRequestModel
    {
        /// <summary>
        /// 还款计划ID
        /// </summary>
        public int LoanPlanId { get; set; }

        /// <summary>
        /// true 担保户还款，false 借款人还款
        /// </summary>
        public bool IsGuar { get; set; }


        public string VerCode { get; set; }
    }

    /// <summary>
    /// 更改手机号
    /// </summary>
    public class SChangePhoneModel : BaseRequestModel
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerCode { get; set; }
    }

    /// <summary>
    /// 更改邮箱
    /// </summary>
    public class SChangeEmailModel : BaseRequestModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmailNumber { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerCode { get; set; }
    }

    /// <summary>
    /// 更改登陆密码
    /// </summary>
    public class SChangeLoginPasswordModel : BaseRequestModel
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 老密码
        /// </summary>
        public string OldPassword { get; set; }
    }

    /// <summary>
    /// 发送邮箱验证码
    /// </summary>
    public class SVCodeToEmail : BaseRequestModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmailCode { get; set; }
    }

    /// <summary>
    /// 绑定渤海手机号
    /// </summary>
    public class SBhBindMobile : BaseRequestModel
    {
        public string NewPhone { get; set; }

        public string VerCode { get; set; }
    }
    /// <summary>
    /// 修改找回渤海密码
    /// </summary>
    public class SBoHaiBindPass : BaseRequestModel
    {
        /// <summary>
        /// 1修改支付密码,0找回支付密码
        /// </summary>
        public string OperationType { get; set; }
    }
    #endregion

    public class SGuaranteeLoans : BaseRequestModel
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public string LoanNo { get; set; }
        /// <summary>
        /// 借款人/借款企业姓名
        /// </summary>
        public string Loaner { get; set; }
    }
}