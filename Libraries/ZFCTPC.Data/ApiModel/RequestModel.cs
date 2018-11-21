using Newtonsoft.Json;
using System;
using ZFCTPC.Core.Enums;

namespace ZFCTPC.Data.ApiModel
{
    public class BaseRequestModel
    {
        //签名
        public string Signature { get; set; }
        //Token
        public string Token { get; set; }

        public long TimeStamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
        //请求Ip
        public string IPAddress { get; set; }
        //接口名称
        public string ApiName { get; set; }
        //请求来源
        public int RequestSource { get; set; } =(int)UserSource.PC;
    }


    public class RequestPageModel : BaseRequestModel
    {
        //页数
        public int Page { get; set; }
        //页码
        public int PageSize { get; set; }
    }



}
