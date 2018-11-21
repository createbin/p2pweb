using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;

namespace ZFCTPC.Services.Account
{
    public interface IBhAccountService
    {
        RUserThirdPartInfo UserBaseInfo(BaseRequestModel model);

        /// <summary>
        /// 结算开户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string JieSuanRegister(JsRegister model);

        ReturnModel<RToPage, string> BoHaiRealName(RealName model);

        ReturnModel<UserState, string> UserState(BaseRequestModel model);
        /// <summary>
        /// 用户授权信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RUserAuthInfo, string> AuthQuery(BaseRequestModel model);

        ReturnModel<RToPage, string> BoHaiAutoAuth(SAuthType model);

        /// <summary>
        /// 线下充值记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<ReturnPageData<RToTradingModel>, string> OfflineRechargeRecord(OfflineRechargeRecord model);
    }


    public class BhAccountService:IBhAccountService
    {
        /// <summary>
        /// 用户基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RUserThirdPartInfo UserBaseInfo(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("ThirdPartInfo");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RUserThirdPartInfo, string>>(result);
            return resultInfo.ReturnData;
        }
        /// <summary>
        /// 结算注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string JieSuanRegister(JsRegister model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("JieSuanRegister");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            return resultInfo.Message;
        }
        /// <summary>
        /// 渤海开户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnModel<RToPage, string> BoHaiRealName(RealName model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("BoHaiRealName");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RToPage, string>>(result);
            return resultInfo;
        }

        public ReturnModel<UserState, string> UserState(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("UserState");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<UserState, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RUserAuthInfo, string> AuthQuery(BaseRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("AuthQuery");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RUserAuthInfo, string>>(result);
            return resultInfo;
        }

        public ReturnModel<RToPage, string> BoHaiAutoAuth(SAuthType model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("AutoInvestAuth");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RToPage, string>>(result);
            return resultInfo;
        }

        public ReturnModel<ReturnPageData<RToTradingModel>, string> OfflineRechargeRecord(OfflineRechargeRecord model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("OfflineRechargeRecord");
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<Data.ApiModelReturn.RToTradingModel>, string>>(result);
            return resultInfo;
        }
    }
}
