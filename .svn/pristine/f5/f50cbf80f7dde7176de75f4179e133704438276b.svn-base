using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Customer;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.Customer;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;
using ZFCTPC.Data.Customers;

namespace ZFCTPC.Services.Customers
{
    public interface ICompanyService
    {
        ReturnModel<RegisterReturnModel, string> CompanyRegister(SCompanyRegisterModel model);

        ReturnModel<ReturnPageData<RMyLoanPlanModel>, string> LastDateWaitClear(RequestPageModel model);

        ReturnModel<RMyRepayLoans, string> MyRepayLoan(RequestPageModel model);

        ReturnModel<RMyRepayLoan, string> GurRepayLoan(SGuaranteeLoans model);

        ReturnModel<ReturnPageData<RGurClearedPlan>, string> GurRepayedLoan(RequestPageModel model);

        ReturnModel<ReturnPageData<RMyLoanPlanModel>, string> MyRepayLoanPlans(SLoanPlan model);

        ReturnModel<RMyRepayLoans, string> MyRepayedLoan(RequestPageModel model);

        ReturnModel<RCompanyRealInfo, string> CompanyRealInfo(BaseRequestModel model);

        ReturnModel<string, string> JieSuanCoRegister(SJsCoRegisterModel model);

        ReturnModel<RToPage, string> OpenChargeAccount(SJsOpenChargeModel model);

        ReturnModel<string, string> RechargeSyn(BaseRequestModel model);

        RCompanyStatics LoanStatics(BaseRequestModel model);

        ReturnModel<string, string> RealNameState(BaseRequestModel model);
    }

    public class CompanyService: ICompanyService
    {
        /// <summary>
        /// 企业用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnModel<RegisterReturnModel, string> CompanyRegister(SCompanyRegisterModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyRegister");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));

            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RegisterReturnModel, string>>(result);
            return resultInfo;
        }

        public ReturnModel<ReturnPageData<RMyLoanPlanModel>, string> LastDateWaitClear(RequestPageModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LastDateWaitClear");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RMyLoanPlanModel>, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RMyRepayLoans, string> MyRepayLoan(RequestPageModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("MyRepayLoan");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RMyRepayLoans, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RMyRepayLoan, string> GurRepayLoan(SGuaranteeLoans model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("GuaranteeRepayLoan");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RMyRepayLoan, string>>(result);
            return resultInfo;
        }

        public ReturnModel<ReturnPageData<RGurClearedPlan>, string> GurRepayedLoan(RequestPageModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("GurRepayedLoan");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RGurClearedPlan>, string>>(result);
            return resultInfo;
        }

        public ReturnModel<ReturnPageData<RMyLoanPlanModel>, string> MyRepayLoanPlans(SLoanPlan model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("MyRepayLoanPlans");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RMyLoanPlanModel>, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RMyRepayLoans, string> MyRepayedLoan(RequestPageModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("MyRepayedLoan");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RMyRepayLoans, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RCompanyRealInfo, string> CompanyRealInfo(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyRealInfo");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RCompanyRealInfo, string>>(result);
            return resultInfo;
        }

        public ReturnModel<string, string> JieSuanCoRegister(SJsCoRegisterModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("JieSuanCoRegister");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RToPage, string> OpenChargeAccount(SJsOpenChargeModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("OpenChargeAccount");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RToPage, string>>(result);
            return resultInfo;
        }

        public ReturnModel<string, string> RechargeSyn(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("RechargeSyn");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            return resultInfo;
        }

        public RCompanyStatics LoanStatics(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanStatics");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RCompanyStatics, string>>(result);
            return resultInfo.ReturnData;
        }

        public ReturnModel<string, string> RealNameState(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("QueryChargeAccountResult");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            return resultInfo;
        }
    }
}
