using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace ZFCTPC.Core.Helpers
{
    public static class HttpClientExtension
    {

        public static string PostAsync(this HttpClient client, string postUrl, string postJson)
        {
            var reqMsg = new HttpRequestMessage
            {
                RequestUri = new Uri(postUrl),
                Content = new StringContent(postJson)
            };
            reqMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            reqMsg.Method = new HttpMethod("POST");
            client.Timeout= TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            var result = client.SendAsync(reqMsg, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
            return result.Result.Content.ReadAsStringAsync().Result;

        }


    }
}
