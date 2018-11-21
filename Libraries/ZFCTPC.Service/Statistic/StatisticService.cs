using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Caching;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.Statistics;

namespace ZFCTPC.Services.Statistic
{

    public interface IStatisticService
    {
        ComprehensiveData GetComprehensiveData();

        InvestmentData GetInvestData();

        FinancingData GetFinancingData();
    }

    public class StatisticService:IStatisticService
    {
        private static string comprehensiveCache = "comCache";
        private static string investCache = "invCache";
        private static string financingCache = "finCache";
        private static string overdueCache = "oveCache";
        private readonly  ICacheManager _cacheManager;

        public StatisticService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public ComprehensiveData GetComprehensiveData()
        {
            if (!_cacheManager.IsSet(comprehensiveCache))
            {
                var returnInfo=new ComprehensiveData();
                string postUrl = ApiEngineToConfiguration.GetStatisticAppSettingUrl("ComprehensiveData");
                try
                {
                    var result = HttpClientHelper.PostAsync(postUrl, "").Result.Content.ReadAsStringAsync().Result;

                    returnInfo = JsonConvert.DeserializeObject<ComprehensiveData>(result);
                    _cacheManager.Set(comprehensiveCache,returnInfo,60);
                    return returnInfo;
                }
                catch
                {
                    return returnInfo;
                }
            }
            else
            {
                return _cacheManager.Get<ComprehensiveData>(comprehensiveCache);
            }
        }

        public InvestmentData GetInvestData()
        {
            if (!_cacheManager.IsSet(investCache))
            {
                var returnInfo = new InvestmentData();
                string postUrl = ApiEngineToConfiguration.GetStatisticAppSettingUrl("InvestmentData");
                try
                {
                    var result = HttpClientHelper.PostAsync(postUrl, "").Result.Content.ReadAsStringAsync().Result;
                    returnInfo = JsonConvert.DeserializeObject<InvestmentData>(result);
                    _cacheManager.Set(investCache,returnInfo,60);
                    return returnInfo;
                }
                catch
                {
                    return returnInfo;
                }
            }
            else
            {
                return _cacheManager.Get<InvestmentData>(investCache);
            }
        }

        public FinancingData GetFinancingData()
        {
            if (!_cacheManager.IsSet(financingCache))
            {
                var returnInfo=new FinancingData();
                string postUrl = ApiEngineToConfiguration.GetStatisticAppSettingUrl("FinancingData");
                try
                {
                    var result = HttpClientHelper.PostAsync(postUrl, "").Result.Content.ReadAsStringAsync().Result;
                    returnInfo = JsonConvert.DeserializeObject<FinancingData>(result);
                    _cacheManager.Set(financingCache,returnInfo,60);
                    return returnInfo;
                }
                catch
                {
                    return returnInfo;
                }
            }
            else
            {
                return _cacheManager.Get<FinancingData>(financingCache);

            }
        }

    }
}
