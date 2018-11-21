using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.InvestModelReturns;
using ZFCTPC.Data.ApiModelReturn.Tools;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;

namespace ZFCTPC.Services.Tools
{
    public interface IToolsService
    {

        RBankInfos BankInfos();

        /// <summary>
        /// 获取统计信息
        /// </summary>
        /// <returns></returns>
        HomeStatistics GetStatistics();
    }

    public class ToolsService : IToolsService
    {

        public RBankInfos BankInfos()
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("BankInfos");
            var baseModel = new BaseRequestModel { Token = "" };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<RBankInfos, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public HomeStatistics GetStatistics()
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("HomeStatistics");
            var baseModel = new BaseRequestModel { Token = "" };
            //加签
            baseModel.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(baseModel));
            var post = JsonConvert.SerializeObject(baseModel);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<HomeStatistics, string>>(result);
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
