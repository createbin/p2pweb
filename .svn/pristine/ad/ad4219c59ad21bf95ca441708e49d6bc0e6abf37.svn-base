using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.Customer;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Services.ApiEngines;
using ZFCTPC.Data.ApiModel.Customer;

namespace ZFCTPC.Services.Account
{
    public interface IMyAccountService
    {
        #region 接口 2.0
        /// <summary>
        /// 投资户账户统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RPCAccountStatistics PCAccountStatistics(BaseRequestModel model);

        /// <summary>
        /// 融资账户统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RFinancingAccount FinancingAccount(BaseRequestModel model);

        /// <summary>
        /// 融资转账
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnModel<bool, string> FinanceTransfer(SFinanceTransfer model);

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnModel<RToPage, string> BHAccountRecharge(SBHAccountRecharge model);

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnModel<RToPage, string> BHAccountWithdraw(SBHAccountWithdraw model);

        /// <summary>
        /// 渤海账户信息
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        RBHAccountInfo RBHAccountInfo(SJsQueryChargeAccount model);

        /// <summary>
        /// 用户红包分页
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnPageData<RRedEnvelopesModel> UserRedPage(RequestPageModel model);

        /// <summary>
        /// 我的借款-投标中
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnPageData<RBiddingLoan> MyBiddingLoan(RequestPageModel model);

        /// <summary>
        /// 我的借款-满标中
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnPageData<RFullLoan> MyFullLoan(RequestPageModel model);

        /// <summary>
        /// 我的借款-还款中
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnPageData<RRepaymentLoan> MyRepaymentLoan(RequestPageModel model);

        /// <summary>
        /// 我的借款-已结清
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnPageData<RClearedLoan> MyClearedLoan(RequestPageModel model);

        /// <summary>
        /// 我的借款-借款明细
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        ReturnPageData<RLoanItemDetail> MyLoanDetail(RequestPageModel model);

        /// <summary>
        /// 还款计划-已结清
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RMyLoanPlanModel> UserLoanPlanClear(RequestPageModel model);

        /// <summary>
        /// 还款计划-未结清
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RMyLoanPlanModel> UserLoanPlanWaitClear(RequestPageModel model);

        /// <summary>
        /// 还款计划-项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RMyLoanPlanModel> LoanPayPlan(SLoanPlan model);

        /// <summary>
        /// 还款明细
        /// </summary>
        /// <param name="model">请求模型</param>
        /// <returns></returns>
        RRepayDetail RepayDetail(SRepayDetail model);

        /// <summary>
        /// 我的借款-借款统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RLoanAccountStatistics LoanAccountStatistics(BaseRequestModel model);

        /// <summary>
        /// 我的投资-投标中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RBiddingInvest> MyBiddingInvest(RequestPageModel model);

        /// <summary>
        /// 我的投资-还款中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RRepaymentInvest> MyRepaymentInvest(RequestPageModel model);

        /// <summary>
        /// 我的投资-已结清
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RClearedInvest> MyClearedInvest(RequestPageModel model);

        /// <summary>
        /// 我的投资-账户统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RInvestAccountStatistics InvestAccountStatistics(BaseRequestModel model);

        /// <summary>
        /// 债权转让-可转出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RCanTransfer> CanTransfer(RequestPageModel model);

        /// <summary>
        /// 债权转让-转出中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RTransfering> Transfering(RequestPageModel model);

        /// <summary>
        /// 债权转让-已转出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RTransferOut> TransferOut(RequestPageModel model);

        /// <summary>
        /// 债权转让-已转入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RTransferIn> TransferIn(RequestPageModel model);

        /// <summary>
        /// 债权转让-转让申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> DoTransfer(SDoTransferData model);

        /// <summary>
        /// 债权转让-转让撤销
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> RecallTransfer(SRecallTransfer model);

        /// <summary>
        /// 交易记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RTradingModel> TradingInfo(SAccountTrading model);

        /// <summary>
        /// 用户是否开户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserState UserState(BaseRequestModel model);

        /// <summary>
        /// 用户投资收益
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RInvestEarnings InvestEarnings(BaseRequestModel model);

        /// <summary>
        /// 用户业务统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RBusinessStatistics BusinessStatistics(BaseRequestModel model);

        /// <summary>
        /// 用户是否借款
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool HasLoan(BaseRequestModel model);

        /// <summary>
        /// 获得问卷
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<RiskQuestionnaireModel> RiskQuestionnaire(BaseRequestModel model);

        /// <summary>
        /// 用户投资类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string UserInvestType(BaseRequestModel model);

        /// <summary>
        /// 提交用户积分
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool PostQuestionScore(SQuestionScore model);

        /// <summary>
        /// 银行卡列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RUserBankInfo UserBankInfo(BaseRequestModel model);

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RToPage, string> BoHaiBindCard(BaseRequestModel model);

        /// <summary>
        /// 修改渤海交易密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RToPage, string> BoHaiBindPass(SBoHaiBindPass model);

        /// <summary>
        /// 用户余额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RBHAccountInfo, string> RemainMoney(SJsQueryChargeAccount model);

        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> Repayment(SRepayment model);

        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> ChangePhone(SChangePhoneModel model);

        /// <summary>
        /// 更改登陆密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> ChangeLoginPassword(SChangeLoginPasswordModel model);

        /// <summary>
        /// 发送邮箱验证码
        /// </summary>
        /// <param name="subModel"></param>
        /// <returns></returns>
        ReturnModel<bool, string> SendVCodeToEmail(SVCodeToEmail model);

        /// <summary>
        /// 绑定渤海手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RToPage, string> BoHaiBindMobile(SBhBindMobile model);

        /// <summary>
        /// 用户基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UseBaseInfoModel UseBaseInfo(BaseRequestModel model);

        /// <summary>
        /// 向用户渤海手机号发送验证码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> SendMobileVCodeToBhUser(SVCodeToMobile model);

        /// <summary>
        /// 投资合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RToPage, string> DownInvestContract(SDownInvestContract model);

        /// <summary>
        /// 借款合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RToPage, string> DownLoanContract(SDownLoanContract model);

        /// <summary>
        /// 验证企业信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<List<RVerifyInfo>, string> VerifyCompanyInfo(SVerifyCompanyInfo model);

        /// <summary>
        /// 企业修改密码验证手机号与证件信息是否匹配
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> CompanyForgetPwdValidator(CompanyInfoValidator model);

        ReturnModel<bool, string> SendSms(BaseRequestModel model);

        /// <summary>
        /// 更新用户银行卡信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> UpdateBankInfo(BaseRequestModel model);

        /// <summary>
        /// 计算提现手续费
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<decimal, string> CalcWithdrawFee(SBHAccountWithdraw model);
        #endregion
        #region cala add

        ReturnModel<RUserThirdPartInfo, string> ThirdPartInfo(BaseRequestModel model);

        #endregion
    }

    public class MyAccountService : IMyAccountService
    {
        #region 接口 2.0

        public RPCAccountStatistics PCAccountStatistics(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<RPCAccountStatistics>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("PCAccountStatistics"));
        }

        public RFinancingAccount FinancingAccount(BaseRequestModel model)
        {
            return ZfctApiHelper.GetReturnData<RFinancingAccount>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("FinancingAccount"));
        }

        public ReturnModel<bool, string> Repayment(SRepayment model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("Repayment"));
        }

        public ReturnModel<bool, string> FinanceTransfer(SFinanceTransfer model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("FinanceTransfer"));
        }

        public ReturnModel<RToPage, string> BHAccountRecharge(SBHAccountRecharge model)
        {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("BHAccountRecharge"));
        }

        public ReturnModel<RToPage, string> BHAccountWithdraw(SBHAccountWithdraw model)
        {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("BHAccountWithdraw"));
        }

        public RBHAccountInfo RBHAccountInfo(SJsQueryChargeAccount model)
        {
            return ZfctApiHelper.GetReturnData<RBHAccountInfo>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("RBHAccountInfo"));
        }

        public ReturnPageData<RRedEnvelopesModel> UserRedPage(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RRedEnvelopesModel>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UserRedPage"));
        }

        public ReturnPageData<RBiddingLoan> MyBiddingLoan(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RBiddingLoan>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyBiddingLoan"));
        }

        public ReturnPageData<RFullLoan> MyFullLoan(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RFullLoan>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyFullLoan"));
        }

        public ReturnPageData<RRepaymentLoan> MyRepaymentLoan(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RRepaymentLoan>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyRepaymentLoan"));
        }

        public ReturnPageData<RClearedLoan> MyClearedLoan(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RClearedLoan>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyClearedLoan"));
        }

        public ReturnPageData<RLoanItemDetail> MyLoanDetail(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RLoanItemDetail>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyLoanDetail"));
        }

        public ReturnPageData<RMyLoanPlanModel> UserLoanPlanClear(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RMyLoanPlanModel>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UserLoanPlanClear"));
        }

        public ReturnPageData<RMyLoanPlanModel> UserLoanPlanWaitClear(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RMyLoanPlanModel>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UserLoanPlanWaitClear"));
        }

        public ReturnPageData<RMyLoanPlanModel> LoanPayPlan(SLoanPlan model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RMyLoanPlanModel>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanPayPlan"));
        }

        public RRepayDetail RepayDetail(SRepayDetail model)
        {
            return ZfctApiHelper.GetReturnData<RRepayDetail>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("RepayDetail"));
        }

        public RLoanAccountStatistics LoanAccountStatistics(BaseRequestModel model)
        {
            return ZfctApiHelper.GetReturnData<RLoanAccountStatistics>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanAccountStatistics"));
        }

        public ReturnPageData<RBiddingInvest> MyBiddingInvest(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RBiddingInvest>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyBiddingInvest"));
        }

        public ReturnPageData<RRepaymentInvest> MyRepaymentInvest(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RRepaymentInvest>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyRepaymentInvest"));
        }

        public ReturnPageData<RClearedInvest> MyClearedInvest(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RClearedInvest>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("MyClearedInvest"));
        }

        public RInvestAccountStatistics InvestAccountStatistics(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<RInvestAccountStatistics>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("InvestAccountStatistics"));
        }

        public ReturnPageData<RCanTransfer> CanTransfer(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RCanTransfer>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("CanTransfer"));
        }

        public ReturnPageData<RTransfering> Transfering(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RTransfering>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("Transfering"));
        }

        public ReturnPageData<RTransferOut> TransferOut(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RTransferOut>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("TransferOut"));
        }

        public ReturnPageData<RTransferIn> TransferIn(RequestPageModel model)
        {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RTransferIn>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("TransferIn"));
        }

        public ReturnModel<bool, string> DoTransfer(SDoTransferData model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("DoTransferData"));
        }

        public ReturnModel<bool, string> RecallTransfer(SRecallTransfer model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("RecallTransfer"));
        }

        public ReturnPageData<RTradingModel> TradingInfo(SAccountTrading model) {
            return ZfctApiHelper.GetReturnData<ReturnPageData<RTradingModel>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("TradingInfo"));
        }

        public UserState UserState(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<UserState>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UserState"));
        }

        public RInvestEarnings InvestEarnings(BaseRequestModel model)
        {
            return ZfctApiHelper.GetReturnData<RInvestEarnings>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("InvestEarnings"));
        }

        public RBusinessStatistics BusinessStatistics(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<RBusinessStatistics>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("BusinessStatistics"));
        }

        public bool HasLoan(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("HasLoan"));

        }

        public List<RiskQuestionnaireModel> RiskQuestionnaire(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<List<RiskQuestionnaireModel>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("RiskQuestionnaire"));
        }

        public bool PostQuestionScore(SQuestionScore model)
        {
            return ZfctApiHelper.GetReturnData<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("PostQuestionScore"));
        }

        public string UserInvestType(BaseRequestModel model)
        {
            return ZfctApiHelper.GetReturnData<string>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UserInvestType"));
        }

        public RUserBankInfo UserBankInfo(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<RUserBankInfo>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UserBankInfo"));
        }

        public ReturnModel<RToPage, string> BoHaiBindCard(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("BoHaiBindCard"));
        }

        public ReturnModel<RToPage, string> BoHaiBindPass(SBoHaiBindPass model)
        {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("BoHaiBindPass"));
        }

        public ReturnModel<RBHAccountInfo, string> RemainMoney(SJsQueryChargeAccount model)
        {
            return ZfctApiHelper.GetReturnModel<RBHAccountInfo>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("RBHAccountInfo"));
        }

        public ReturnModel<bool, string> ChangePhone(SChangePhoneModel model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("ChangePhone"));
        }

        public ReturnModel<bool, string> ChangeEmail(SChangeEmailModel model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("ChangeEmail"));
        }

        public ReturnModel<bool, string> ChangeLoginPassword(SChangeLoginPasswordModel model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("ChangeLoginPassword"));
        }

        public ReturnModel<bool, string> SendVCodeToEmail(SVCodeToEmail model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("SendVCodeToEmail"));
        }

        public ReturnModel<RToPage, string> BoHaiBindMobile(SBhBindMobile model) {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("BoHaiBindMobile"));
        }

        public UseBaseInfoModel UseBaseInfo(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnData<UseBaseInfoModel>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UseBaseInfo"));
        }

        public ReturnModel<bool, string> SendMobileVCodeToBhUser(SVCodeToMobile model) {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("SendMobileVCodeToBhUser"));
        }

        public ReturnModel<RToPage, string> DownInvestContract(SDownInvestContract model)
        {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("DownInvestContract"));
        }

        public ReturnModel<RToPage, string> DownLoanContract(SDownLoanContract model)
        {
            return ZfctApiHelper.GetReturnModel<RToPage>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("DownLoanContract"));
        }
        public ReturnModel<bool, string> SendSms(BaseRequestModel model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("SendInvestVCode"));
        }

        public ReturnModel<bool, string> UpdateBankInfo(BaseRequestModel model) {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("UpdateBankInfo"));
        }

        public ReturnModel<decimal,string> CalcWithdrawFee(SBHAccountWithdraw model) {
            return ZfctApiHelper.GetReturnModel<decimal>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("CalcWithdrawFee"));
        }
        #endregion

        #region cala add

        public ReturnModel<RUserThirdPartInfo, string> ThirdPartInfo(BaseRequestModel model)
        {
            return ZfctApiHelper.GetReturnModel<RUserThirdPartInfo>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("ThirdPartInfo"));
        }

        public ReturnModel<List<RVerifyInfo>, string> VerifyCompanyInfo(SVerifyCompanyInfo model)
        {
            return ZfctApiHelper.GetReturnModel<List<RVerifyInfo>>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("VerifyCompanyInfo"));
        }

        public ReturnModel<bool, string> CompanyForgetPwdValidator(CompanyInfoValidator model)
        {
            return ZfctApiHelper.GetReturnModel<bool>(model, ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyForgetPwd"));
        }

        #endregion
    }
}