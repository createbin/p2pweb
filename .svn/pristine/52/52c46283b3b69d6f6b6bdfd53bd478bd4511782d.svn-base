using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.InvestModelReturns;
using ZFCTPC.Data.ApiModelReturn.LoanReturnModels;

namespace ZFCTPC.Services.Loans
{
    public interface ILoanServices
    {
        /// <summary>
        /// 首页新手标的
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        ReturnPageData<RLoanAbstract> HomeNewHand(int count);
        /// <summary>
        /// 首页推荐标的
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        ReturnPageData<RLoanAbstractLable> HomeLoanList(int count);

        #region recommand list


        /// <summary>
        /// 标的列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RLoanAbstractLable> LoanList(RequestPageModel model);
        /// <summary>
        /// 新手标的列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<RLoanAbstract> NewHandList(RequestPageModel model);
        #endregion
    }

    public class LoanServices:ILoanServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public ReturnPageData<RLoanAbstract> HomeNewHand(int count)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("NewHandList");
            var baseModel = new RequestPageModel { Token = "", Page =1,PageSize = count};
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

        public ReturnPageData<RLoanAbstractLable> HomeLoanList(int count)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("LoanList");
            var baseModel = new RequestPageModel { Token = "", Page = 1, PageSize = count };
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

        #region recommand list
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

        public ReturnPageData<RLoanAbstract> NewHandList(RequestPageModel model)
        {
            string postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("NewHandList");
            var baseModel = new RequestLoanInvester { Token = "", Page = model.Page, PageSize = model.PageSize };
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

        #endregion


        #region loan detail

        #endregion
    }
}
