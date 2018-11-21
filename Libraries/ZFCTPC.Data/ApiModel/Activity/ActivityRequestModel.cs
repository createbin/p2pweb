using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.Activity
{
    public class ActivityRequestModel
    {
        public class InvitedRewardSubmitModel
        {

            public bool IsYear { get; set; }

            public string StartTime { get; set; }

            public string EndTime { get; set; }

            //签名
            public string Signature { get; set; }
            //Token
            public string Token { get; set; }
            //时间戳
            public long TimeStamp { get; set; }
            //请求Ip
            public string IPAddress { get; set; }
            //用户名
            public string UserAccount { get; set; }
        }
    }

    public class InvestPersonRank:BaseRequestModel
    {
        public int Count { get; set; }
    }

    public class ActivityRank: BaseRequestModel
    {
        public int ActitityId { get; set; }

        public int Count { get; set; }
    }
}
