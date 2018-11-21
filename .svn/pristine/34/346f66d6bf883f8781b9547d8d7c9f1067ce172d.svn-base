using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.Security;
using ZFCTPC.Data.ApiModel.Customer;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.Customer;
using ZFCTPC.Data.Customers;
using ZFCTPC.Core.ApiEngines;

namespace ZFCTPC.Services.Customers
{
    public interface  ICustomerService
    {
        //LoginResult Login(LoginModel model,out LoginInfoReturn user);
        /// <summary>
        /// 验证用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool ValidUserExit(string userName);
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        bool ValidPhoneExit(string phone);
        /// <summary>
        /// 验证邀请码是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool ValidRecommandCodeExit(ValidateInfo model);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        ReturnModel<LoginReturnModel, string> UserLogin(LoginRequest model, out LoginReturnModel user);
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        bool SendMessage(string phone);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<RegisterReturnModel, string> Register(RegisterRequest model);

        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnModel<bool, string> ForgetPwd(ForgetPwdModel model);
        /// <summary>
        /// 验证手机验证码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        VerifyCodePhoneReturnModel VerifyPhoneCode(VerifyPhoneCode model);
    }

    public class CustomerService : ICustomerService
    {
        public ReturnModel<bool, string> ForgetPwd(ForgetPwdModel model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("ForgetPwd");
            model.Signature= RSAHelper.Encrypt(JsonConvert.SerializeObject(model));

            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result; 
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<bool, string>>(result);

            return resultInfo;
        }

        public VerifyCodePhoneReturnModel VerifyPhoneCode(VerifyPhoneCode model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("VerifyPhoneCode");
            model.Token = "";
            model.Signature= RSAHelper.Encrypt(JsonConvert.SerializeObject(model));

            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result; 
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            
            if (resultInfo.ReturnCode == 200)
            {
                return new VerifyCodePhoneReturnModel()
                {
                    IsSuccess = true,
                    Msg = resultInfo.Message
                };
            }
            else
            {
                return new VerifyCodePhoneReturnModel()
                {
                    IsSuccess = false,
                    Msg = resultInfo.Message
                };
            }
        }

        public ReturnModel<RegisterReturnModel, string> Register(RegisterRequest model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("Register");

            RegisterModel postObject = new RegisterModel
            {
                UserName = model.UserName,
                Phone = model.Phone,
                Password = model.PassWord,
                RecommendCode = model.RecommendCode,
                VerCode = model.PhoneVerifyCode,
                Token = ""
            };
            postObject.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(postObject));

            var postJson = JsonConvert.SerializeObject(postObject);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<RegisterReturnModel, string>>(result);
            return resultInfo;
        }

        public bool SendMessage(string phone)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("SendVCodeToMobile");
            var postObject = new SVCodeToMobile
            {
                MobileNumber = phone,
                Token = ""
            };
            postObject.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(postObject));

            var postJson = JsonConvert.SerializeObject(postObject);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result; 
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<string, string>>(result);
            if (resultInfo.ReturnCode == 200)//发送成功
            {
                return true;
            }
            return false;
        }

        public ReturnModel<LoginReturnModel, string> UserLogin(LoginRequest model, out LoginReturnModel user)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("Login");
            LoginInfoModel postObject = new LoginInfoModel
            {
                UserName = model.UserName,
                Password = model.PassWord,
                Token = "",
                IsCompanyLogin= model.IsCompanyLogin
            };
            postObject.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(postObject));

            var postJson = JsonConvert.SerializeObject(postObject);
            var result= HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<LoginReturnModel, string>>(result);

            if (resultInfo.ReturnCode == 200)
            {
                user = resultInfo.ReturnData;
                user.Token = resultInfo.Token;
            }
            else
            {
                user = null;
            }
            return resultInfo;
        }

        public bool ValidPhoneExit(string phone)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("ValidPhoneExit");
            var postObject = new ValidateInfo
            {
                Validate = phone,
                Token = ""
            };
            postObject.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(postObject));

            var postJson = JsonConvert.SerializeObject(postObject);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<bool, string>>(result);
            if (resultInfo.ReturnCode == 200)//手机号码不存在
            {
                return true;
            }
            else//手机号码存在
            {
                return false;
            }
        }

        public bool ValidRecommandCodeExit(ValidateInfo model)
        {
            var postUrl = ApiEngineToConfiguration.GetBhAppSettingsUrl("ValidRecommandCodeExit");
            model.Token = "";
            model.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(model));

            var postJson = JsonConvert.SerializeObject(model);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<bool, string>>(result);
            return resultInfo.ReturnData;
        }

        public bool ValidUserExit(string userNameOrPhone)
        {
            var postUrl= ApiEngineToConfiguration.GetBhAppSettingsUrl("ValidUserNameExit");
            var postObject = new ValidateInfo
            {
                Validate = userNameOrPhone,
                Token = ""
            };
            postObject.Signature = RSAHelper.Encrypt(JsonConvert.SerializeObject(postObject));

            var postJson = JsonConvert.SerializeObject(postObject);
            var result = HttpClientHelper.PostAsync(postUrl, postJson).Result.Content.ReadAsStringAsync().Result;
            var resultInfo = JsonConvert.DeserializeObject<ReturnModel<bool, string>>(result);
            if (resultInfo.ReturnCode == 200)//用户名不存在
            {
                return true;
            }
            else//用户名存在
            {
                return false;
            }
        }

       
    }
}
