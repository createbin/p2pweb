using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Polly;
using Polly.Timeout;
using ZFCTPC.Core.ApiEngines;

namespace ZFCTPC.Core.Helpers
{
    public class HttpClientHelper
    {
        private static HttpClient httpClient;
        private static readonly string ApiAddress = ApiEngineToConfiguration.GetZfctUrl();

        static HttpClientHelper()
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.Proxy = null;
                httpClient = new HttpClient(handler) { BaseAddress = new Uri(ApiAddress) };
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
                httpClient.Timeout = TimeSpan.FromSeconds(1000);
                httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                //帮HttpClient热身
                httpClient.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("HEAD"),
                    RequestUri = new Uri(ApiAddress + "/")
                }).Result.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static  Task<HttpResponseMessage> PostAsync(string postUrl, string postJson)
        {
            try
            {
                Policy policy = Policy.Timeout(3, TimeoutStrategy.Pessimistic);
                return policy.Wrap(Policy.Bulkhead(50)).Execute(() =>
                {
                    HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
                    return (httpClient ?? GetDefaultClient()).PostAsync(postUrl, httpContent);
                });
            }
            catch (Exception ex)
            {
                LogsHelper.WriteLog("链接处理时发生错误 错误信息：" + ex.Message);
                return null;
            }
        }

        public static string GetAsync(string getUrl)
        {
            var responseJson = "";
            try
            {
                responseJson = (httpClient ?? GetDefaultClient()).GetAsync(getUrl).Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }
            return responseJson;
        }

        public static void PostAsync1(string postUrl, string postJson)
        {
            try
            {
                HttpContent httpContent = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
                httpClient.PostAsync(postUrl, httpContent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static HttpClient GetDefaultClient()
        {
            if (httpClient != null) return httpClient;
            LogsHelper.WriteLog("重新生成httpclient");
            httpClient = new HttpClient();
            var handler = new HttpClientHandler();
            handler.Proxy = null;
            httpClient = new HttpClient(handler) { BaseAddress = new Uri(ApiAddress) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            httpClient.Timeout = TimeSpan.FromMinutes(30);
            httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            //帮HttpClient热身
            httpClient.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("HEAD"),
                RequestUri = new Uri(ApiAddress + "/")
            }).Result.EnsureSuccessStatusCode();
            return httpClient;
        }
    }
}