using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn.Customer
{
    public class RegisterReturnModel
    {
        //用户id
        public int UserId { get; set; }
        //用户名
        public string UserName { get; set; }

        public string RecommendCodeName { get; set; }

    }

    public class VerifyCodePhoneReturnModel
    {
        public bool IsSuccess { get; set; }

        public string Msg { get; set; }
    }
}
