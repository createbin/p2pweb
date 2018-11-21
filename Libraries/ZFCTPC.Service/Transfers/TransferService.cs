using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.ApiModel.Transfers;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.InvestModelReturns;
using ZFCTPC.Data.ApiModelReturn.LoanReturnModels;
using ZFCTPC.Data.ApiModelReturn.Transfers;
using ZFCTPC.Services.ApiEngines;

namespace ZFCTPC.Services.Transfers
{

    public interface ITransferService
    {
        /// <summary>
        /// 债权转让列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RTansferAbstract> TransferList(RequestPageModel model);
        /// <summary>
        /// 债权转让详情页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RTansferDetail TransferDetail(RequestTransferDetail model);

        RLoanInvester TransferInvester(RequestTransferDetail model);
        /// <summary>
        /// 投资债权转让
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<ReLoanModel<InvestProcessRequest>, string> InvestTransfer(InvestTransfer model);
    }

    public class TransferService:ITransferService
    {
        public ReturnPageData<RTansferAbstract> TransferList(RequestPageModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("TransferCanInvestList");
            model.Token = "";
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result; 
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<RTansferAbstract>, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public RTansferDetail TransferDetail(RequestTransferDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetAppSettingsUrl("TransferDetail");
            model.Token = "";
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result; 
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<RTansferDetail, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public RLoanInvester TransferInvester(RequestTransferDetail model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("TransferInvester");
            model.Token = "";
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<RLoanInvester, string>>(result);
            if (returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return null;
            }
        }

        public ReturnModel<ReLoanModel<InvestProcessRequest>, string> InvestTransfer(InvestTransfer model)
        {
            string postUrl = ApiEngineToConfiguration.GetAppSettingsUrl("InvestTransfer");
            //加签
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            var post = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
            var returnInfo = JsonConvert.DeserializeObject<ReturnModel<ReLoanModel<InvestProcessRequest>, string>>(result);
            return returnInfo;
        }
    }
}
