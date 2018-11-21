using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.InvestModelReturns;
using ZFCTPC.Data.ApiModelReturn.Invites;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Data.ApiModel.Invites;

namespace ZFCTPC.Services.Invites
{
    public interface IInviteService
    {
        /// <summary>
        /// 邀请统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InviteStatistics InviteStatistics(BaseRequestModel model);
        /// <summary>
        /// 分月邀请统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InviteMonthAbstract InviteMonthAbstract(BaseRequestModel model);
        /// <summary>
        /// 月详细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InviteMonthDetail InviteMonthDetail(MonthInvester model);
    }

    public class InviteService : IInviteService
    {
        public InviteStatistics InviteStatistics(BaseRequestModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("InviteStatistics");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<InviteStatistics, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                LogsHelper.WriteLog("returncode1:"+returnInfo.ReturnCode);
                return null;
            }
        }

        public InviteMonthAbstract InviteMonthAbstract(BaseRequestModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("InviteMonthAbstract");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<InviteMonthAbstract, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                LogsHelper.WriteLog("returncode2:" + returnInfo.ReturnCode);
                return null;
            }
        }

        public InviteMonthDetail InviteMonthDetail(MonthInvester model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("InviteMonthDetails");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<InviteMonthDetail, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                LogsHelper.WriteLog("returncode3:" + returnInfo.ReturnCode);
                return null;
            }
        }
    }
}
