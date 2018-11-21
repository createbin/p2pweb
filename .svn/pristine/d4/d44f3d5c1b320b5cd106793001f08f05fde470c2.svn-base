using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModelReturn;
using System.Linq;
using System.Net;
using System.Net.Http;
using ZFCTPC.Core.ApiEngines;

namespace ZFCTPC.Services.ApiEngines
{
    public class ZfctApiHelper
    {
        #region Field

        #endregion Field

        #region Function

        public T GetResponseReturnModel<T>(BaseRequestModel request, string postUrl)
        {
            //加签
            request.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(request));

            var post = JsonConvert.SerializeObject(request);
            ReturnModel<T, string> returnInfo = new ReturnModel<T, string>();
            try
            {
                string result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
                returnInfo = JsonConvert.DeserializeObject<ReturnModel<T, string>>(result);
            }
            catch
            {
                returnInfo = null;
            }

            if (returnInfo != null && returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return default(T);
            }
        }

        public ReturnModel<T, string> GetResponseModel<T>(BaseRequestModel request, string postUrl)
        {
            //加签
            request.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(request));
            var post = JsonConvert.SerializeObject(request);
            ReturnModel<T, string> returnInfo = new ReturnModel<T, string>();
            try
            {
                string result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
                returnInfo = JsonConvert.DeserializeObject<ReturnModel<T, string>>(result);
            }
            catch
            {
                returnInfo = null;
            }
            return returnInfo;
        }

        public string GetRequestUrl(BaseRequestModel request, string postUrl)
        {
            //加签
            request.Signature = WebUtility.UrlEncode(RSAHelper.Encrypt(JsonConvert.SerializeObject(request)));
            request.Token = WebUtility.UrlEncode(request.Token);
            string querystring = string.Join("&", JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(request)).Select(m => m.Key + "=" + m.Value).ToArray());
            return postUrl + "?" + querystring;
        }


        /// <summary>
        /// 请求接口-return-数据模型
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="request">请求模型</param>
        /// <param name="postUrl">请求地址</param>
        /// <returns></returns>
        public static T GetReturnData<T>(BaseRequestModel request, string postUrl)
        {
            //加签
            request.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(request));

            var post = JsonConvert.SerializeObject(request);
            ReturnModel<T, string> returnInfo = new ReturnModel<T, string>();
            try
            {
                string result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
                returnInfo = JsonConvert.DeserializeObject<ReturnModel<T, string>>(result);
            }
            catch
            {
                returnInfo = null;
            }

            if (returnInfo != null && returnInfo.ReturnCode == 200)
            {
                return returnInfo.ReturnData;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 请求接口-return-返回模型
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="request">请求模型</param>
        /// <param name="postUrl">请求地址</param>
        /// <returns></returns>
        public static ReturnModel<T, string> GetReturnModel<T>(BaseRequestModel request, string postUrl)
        {
            //加签
            request.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(request));
            var post = JsonConvert.SerializeObject(request);
            ReturnModel<T, string> returnInfo = new ReturnModel<T, string>();
            try
            {
                string result = HttpClientHelper.PostAsync(postUrl, post).Result.Content.ReadAsStringAsync().Result;
                returnInfo = JsonConvert.DeserializeObject<ReturnModel<T, string>>(result);
            }
            catch
            {
                returnInfo = null;
            }
            return returnInfo;
        }

        #endregion Function
    }
}