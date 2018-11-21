using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Enums;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.InvestModelReturns;
using ZFCTPC.Data.ApiModelReturn.LoanReturnModels;
using ZFCTPC.Services.ApiEngines;

namespace ZFCTPC.Services.Invests
{
    public interface IInvestService
    {

        /// <summary>
        /// 获取标的投资人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RLoanInvester> GetLoanInvester(RequestLoanInvester model);

        /// <summary>
        /// 新手标列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        LoanList NewHandList(RequestPageModel model);

        /// <summary>
        /// 标详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        LoanDetail LoanDetail(RequestLoanDetail model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RepaymentPlan LoaneRepaymentPlan(RequestLoanDetail model);

        /// <summary>
        /// 投资收益
        /// </summary>
        /// <returns></returns>
        decimal InvestIncome(RequestInvestIncome model);
        /// <summary>
        /// 投标接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RToInvestResult, string> InvestLoan(SInvestLoan model);

        List<LoanRedPackages> LoanRedPackage(LoanRedPackage model);

        /// <summary>
        /// 最匹配红包
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RedPackage BestRedInfo(LoanRedPackage model);


        ReturnPageData<RLoanAbstract> RecommandLoan(string token);

        decimal LoanAvaliableMoney(RequestLoanDetail model);

        bool IsNewHand(BaseRequestModel model);

        int AvaliableRedCount(BaseRequestModel model);

        /// <summary>
        /// 投标接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<ReLoanModel<InvestProcessRequest>, string> WaitPay(WaitPay model);

        /// <summary>
        /// 标的列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RLoanAbstractLable> LoanList(RequestPageModel model);

        /// <summary>
        /// 4月 融资信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        LoanProjectDetails LoanProjectDetails(RequestLoanDetail model);
        /// <summary>
        /// 4月 还款追踪
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TrackingDetails TrackingDetails(RequestLoanDetail model);
    }

    public class InvestService : IInvestService
    {

        public ReturnPageData<RLoanInvester> GetLoanInvester(RequestLoanInvester model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanInvester");
            model.Token = "";
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RLoanInvester>, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public LoanList NewHandList(RequestPageModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetAppSettingsUrl("NewHandList");
            var baseModel = new RequestLoanInvester { Token = "",Page = model.Page,PageSize = model.PageSize};
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<LoanList, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public LoanDetail LoanDetail(RequestLoanDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanDetail");
            var baseModel = new RequestLoanInvester { Token = "",LoanId = model.LoanId};
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<LoanDetail, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public RepaymentPlan LoaneRepaymentPlan(RequestLoanDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoaneRepaymentPlan");
            var baseModel = new RequestLoanInvester { Token = "", LoanId = model.LoanId };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<RepaymentPlan, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public decimal InvestIncome(RequestInvestIncome model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("InvestIncome");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return Convert.ToDecimal(returnInfo.ReturnData);
            }
            else
            {
                return 0.00m;
            }
        }

        public ReturnModel<RToInvestResult, string> InvestLoan(SInvestLoan model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("InvestLoan");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<RToInvestResult, string>>(result);
            return returnInfo;
        }

        public List<LoanRedPackages> LoanRedPackage(LoanRedPackage model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanRedPackage");            
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<List<LoanRedPackages>, string>>(result);
            return returnInfo.ReturnCode == (int) ReturnCodeEnum.Success ? returnInfo.ReturnData : null;
        }

        public RedPackage BestRedInfo(LoanRedPackage model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("BestLoanRedPackage");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<RedPackage,string>>(result);
            return returnInfo.ReturnCode == (int)ReturnCodeEnum.Success ? returnInfo.ReturnData : null;
        }

        public ReturnPageData<RLoanAbstract> RecommandLoan(string token)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("RecommandLoan");
            var baseModel = new BaseRequestModel { Token = token };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RLoanAbstract>, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public decimal LoanAvaliableMoney(RequestLoanDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanAvaliableMoney");
            model.Token = "";
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<decimal, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return 0.0m;
            }
        }

        public bool IsNewHand(BaseRequestModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("IsNewHand");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<bool, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return false;
            }
        }

        public int AvaliableRedCount(BaseRequestModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("AvaliableRedCount");

            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<int, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            return 0;
        }
        /// <summary>
        /// 待修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnModel<ReLoanModel<InvestProcessRequest>, string> WaitPay(WaitPay model)
        {
            string postUrl = ApiEngineToConfiguration.GetAppSettingsUrl("InvestWaitPay");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<ReLoanModel<InvestProcessRequest>, string>>(result);
            return returnInfo;
        }

        public ReturnPageData<RLoanAbstractLable> LoanList(RequestPageModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanList");
            var baseModel = new RequestLoanInvester { Token = "", Page = model.Page, PageSize = model.PageSize };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RLoanAbstractLable>, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }
        public LoanProjectDetails LoanProjectDetails(RequestLoanDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanProjectDetail");
            var baseModel = new RequestLoanInvester { Token = "", LoanId = model.LoanId };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<LoanProjectDetails, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public TrackingDetails TrackingDetails(RequestLoanDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanTracking");
            var baseModel = new RequestLoanInvester { Token = "", LoanId = model.LoanId };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<TrackingDetails, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }
    }
}
