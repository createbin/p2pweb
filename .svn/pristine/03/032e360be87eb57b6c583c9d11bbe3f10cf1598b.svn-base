using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel.News;
using ZFCTPC.Data.ApiModel.Promotion;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.Promotion;

namespace ZFCTPC.Services.Promotion
{
    public interface IPromotionService
    {
        /// <summary>
        /// 按条数获取广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AdvertCountReturnModel AdvertisementsCount(AdvertisementCountRequestModel model);
        /// <summary>
        /// 分页获取广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AdvertPageReturnModel AdvertisementsPage(AdvertisementPageRequestModel model);
        /// <summary>
        /// 按条获取新闻
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        NewsCountReturnModel NewsCount(AdvertisementCountRequestModel model);
        /// <summary>
        /// 分页获取新闻
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        NewsPageReturnModel NewsPage(AdvertisementPageRequestModel model);
        /// <summary>
        /// 新闻详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        NewsDetailReturnModel NewsDetail(NewsDetailRequestModel model);
        /// <summary>
        /// 企业内刊/运营报告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnPageData<tbInternalMagazine> Managzie(ManagizeCountRequestModel model);
    }

    public class PromotionService : IPromotionService
    {
        public AdvertCountReturnModel AdvertisementsCount(AdvertisementCountRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("AdvertisementsCount");
            //postUrl = "http://localhost:56672/api/Promotion/AdvertisementsCount";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            string postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<ReturnModel<AdvertCountReturnModel, string>>(result).ReturnData;
            }
            catch
            {
                return null;
            }
        }

        public AdvertPageReturnModel AdvertisementsPage(AdvertisementPageRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("AdvertisementsPage");
            //postUrl = "http://localhost:56672/api/Promotion/AdvertisementsPage";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            string postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<ReturnModel<AdvertPageReturnModel, string>>(result).ReturnData;
            }
            catch
            {
                return null;
            }
        }

        public ReturnPageData<tbInternalMagazine> Managzie(ManagizeCountRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyManagizes");
            //postUrl = "http://localhost:56672/api/Promotion/Managizes";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            string postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<ReturnModel<ReturnPageData<tbInternalMagazine>, string>>(result).ReturnData;
            }
            catch
            {
                return null;
            }
        }

        public NewsCountReturnModel NewsCount(AdvertisementCountRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyNewsCount");
            //postUrl = "http://localhost:56672/api/Promotion/NewsCount";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            string postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<ReturnModel<NewsCountReturnModel, string>>(result).ReturnData;
            }
            catch
            {
                return null;
            }
        }

        public NewsDetailReturnModel NewsDetail(NewsDetailRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyNewsDetail");
            //postUrl = "http://localhost:56672/api/Promotion/NewsDetail";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            string postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<ReturnModel<NewsDetailReturnModel, string>>(result).ReturnData;
            }
            catch
            {
                return null;
            }
        }

        public NewsPageReturnModel NewsPage(AdvertisementPageRequestModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("CompanyNewPage");
            //postUrl = "http://localhost:56672/api/Promotion/NewsPage";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));
            string postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            try
            {
                return JsonConvert.DeserializeObject<ReturnModel<NewsPageReturnModel, string>>(result).ReturnData;
            }
            catch
            {
                return null;
            }
        }
    }
}
