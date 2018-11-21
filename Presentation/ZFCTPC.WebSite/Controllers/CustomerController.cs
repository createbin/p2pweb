using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Data.ApiModelReturn.Customer;
using ZFCTPC.Data.Customers;
using ZFCTPC.Services.ApiEngines;
using ZFCTPC.Services.Customers;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Data.ApiModel.Customer;
using ZFCTPC.Services.News;
using ZFCTPC.WebSite.ViewModels.CompanyModels;
using ZFCTPC.Services.Account;
using System.Linq;
using System.Threading;
using ZFCTPC.Services.Promotion;
using ZFCTPC.Data.ApiModel.Promotion;
using ZFCTPC.Core.Enums;

namespace ZFCTPC.WebSite.Controllers
{
    public class CustomerController : Controller
    {
        #region construct

        private readonly ICustomerService _customerService;
        private IMemoryCache _memoryCache;
        private readonly INewsService _inewsService;
        private int saveUserInfoMin = 60 * 24 * 30;//用户名保存30天
        private ICompanyService _companyService;
        private IMyAccountService _myAccountService;
        private IPromotionService _promotionService;


        public CustomerController(ICustomerService customerService,
            IMemoryCache memoryCache,
            INewsService inewsService,
            ICompanyService companyService,
            IMyAccountService myAccountService,
            IPromotionService promotionService)
        {
            _customerService = customerService;
            _memoryCache = memoryCache;
            _inewsService = inewsService;
            _companyService = companyService;
            _myAccountService = myAccountService;
            _promotionService = promotionService;
        }

        #endregion

        #region 登录注册
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            string userName = Request.Cookies["zfctLoginInfo"];
            bool isFaild = !string.IsNullOrEmpty(HttpContext.Session.GetString("userLoginFalied"));
            ViewBag.returnUrl = returnUrl;
            ViewBag.LoginUserName = userName;
            ViewBag.IsFaild = isFaild;
            ViewBag.LoginAdvert = _promotionService.AdvertisementsCount(new AdvertisementCountRequestModel
            {
                Code = PromotionCodeEnum.PCLoginAdvertPos.ToString(),
                Count = 100
            });
            return View();
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Register(string yqm)
        {
            ViewBag.yqm = yqm;
            ViewBag.RegisterAdvert = _promotionService.AdvertisementsCount(new AdvertisementCountRequestModel
            {
                Code = PromotionCodeEnum.PCRegisterAdvertPos.ToString(),
                Count = 100
            });
            return View();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(LoginRequest model)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userLoginFalied")))
            {
                string picVerifyCode = HttpContext.Session.GetString("PicVerifyCode");
                if (!string.IsNullOrEmpty(picVerifyCode))
                {
                    if (string.IsNullOrEmpty(model.VerifyCode) || model.VerifyCode.ToLower() != picVerifyCode)
                    {
                        return Json(new
                        {
                            Success = false,
                            Msg = "验证码输入错误"
                        });
                    }
                }
            }
            LoginReturnModel user = null;
            model.IP = HttpContext.Request.Headers["X-Forwarded-For"];
            if(string.IsNullOrEmpty(model.IP))
                model.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = _customerService.UserLogin(model, out user);
            if (result.ReturnCode == 200)//登录成功
            {
                var identity = new ClaimsIdentity("Forms");
                identity.AddClaim(new Claim(ClaimTypes.Sid, user.UserId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.Phone.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.GroupSid, user.IsCompanyLogin.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.IsGur.ToString()));
                if (!string.IsNullOrEmpty(user.picUrl))
                {
                    identity.AddClaim(new Claim(ClaimTypes.UserData,user.picUrl.ToString()));
                }
                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.UserData, "/images/account_pic.png"));
                }
                identity.AddClaim(new Claim(ClaimTypes.Rsa, user.Token.ToString()));

                var princpal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("zfuser", princpal,new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                    IsPersistent = false,
                    AllowRefresh = false  
                });

                if (model.IsRemember)//记住用户名
                {
                    Response.Cookies.Append("zfctLoginInfo", model.UserName, new CookieOptions { Expires = new DateTimeOffset(DateTime.Now.AddMinutes(saveUserInfoMin)),SameSite = SameSiteMode.None});
                }
                else
                {
                    Response.Cookies.Append("zfctLoginInfo", model.UserName, new CookieOptions { Expires = new DateTimeOffset(DateTime.Now.AddMinutes(-1)), SameSite = SameSiteMode.None });
                }
                if (model.IsCompanyLogin)
                {
                    Response.Cookies.Append("zfctIsCompany", "true", new CookieOptions {SameSite = SameSiteMode.None});
                }
                else
                {
                    Response.Cookies.Append("zfctIsCompany", "false", new CookieOptions { SameSite = SameSiteMode.None });
                }

                HttpContext.Session.SetString("PicVerifyCode", "");//清除验证码
                HttpContext.Session.SetString("userLoginFalied", "");//清除登录失败记录
                return Json(new
                {
                    Success = true,
                    ReturnUrl = string.IsNullOrEmpty(model.ReturnUrl) ? "/home/index" : model.ReturnUrl
                });
            }
            else
            {
                HttpContext.Session.SetString("userLoginFalied", "Falied");
                return Json(new
                {
                    Success = false,
                    Msg = result.Message//错误信息
                });
            }
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserRegister(RegisterRequest model)
        {
            var PicVerifyCode = HttpContext.Session.GetString("PicVerifyCode");
            if (string.IsNullOrEmpty(model.PicVerifyCode) || PicVerifyCode != model.PicVerifyCode.ToLower())
            {
                return Json(new
                {
                    success = false,
                    msg = "图形验证码错误"
                });
            }
            var result = _customerService.Register(model);
            if (result.ReturnCode == 200)//注册成功
            {
                var identity = new ClaimsIdentity("Forms");
                identity.AddClaim(new Claim(ClaimTypes.Name, model.UserName.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, model.Phone.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Rsa, result.Token.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Sid, result.ReturnData.UserId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.UserData, "/images/account_pic.png"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                var princpal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("zfuser", princpal);

                HttpContext.Session.SetString("PicVerifyCode", "");
                Response.Cookies.Append("zfctIsCompany","false", new CookieOptions { SameSite = SameSiteMode.None });
                Response.Cookies.Append("zfctLoginInfo", model.UserName, new CookieOptions { Expires = new DateTimeOffset(DateTime.Now.AddMinutes(saveUserInfoMin)) });
                return Json(new
                {
                    success = true
                });
            }
            return Json(new
            {
                success = false,
                msg = result.Message,
                returnCode = result.ReturnCode
            });
        }
        #endregion

        #region 退出登录

        public async Task<ActionResult> LoginOut()
        {
            var claim = User.FindFirst(ClaimTypes.GroupSid);

            await HttpContext.SignOutAsync("zfuser");

            if (claim != null && (claim.Value.ToLower().Equals("true")))
            {
                return RedirectToAction("EnterpriseLogin", "Customer");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            
        }

        #endregion

        #region 忘记密码

        public ActionResult ForgetPwd(ForgetPwdModel model)
        {
            var result = _customerService.ForgetPwd(model);
            if (result.ReturnCode == 200)
            {
                return Json(new { success=true});
            }
            return Json(new { success=false,msg=result.Message});
        }

        //忘记密码
        public IActionResult ForgetPassword()
        {
            return View();
        }
        //忘记密码2
        public IActionResult ForgetPassword2(string phone, string code)
        {
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(code))
            {
                return Redirect("ForgetPassword");
            }
            ViewBag.phone = phone;
            ViewBag.code = code;
            return View();
        }
        //忘记密码3
        public IActionResult ForgetPassword3()
        {
            return View();
        }

        #endregion

        #region 登录注册验证
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ActionResult UserNameIsExit(string userName)
        {
            bool result = _customerService.ValidUserExit(userName);
            if (result && UserInfoVerifyHelper.VerifyPhone(userName))//用户名不存在，验证是否为手机号码登录
            {
                result = _customerService.ValidPhoneExit(userName);
            }
            return Content(result.ToString());
        }

        /// <summary>
        /// 验证手机号是否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public ActionResult PhoneIsExit(string phone)
        {
            string msg = null;
            bool success = false;
            if (UserInfoVerifyHelper.VerifyPhone(phone))
            {
                var result = _customerService.ValidPhoneExit(phone);
                if (result)
                {
                    msg = "";
                    success = true;
                }
                else
                {
                    msg = "手机号码存在";
                    success = false;
                }
            }
            else
            {
                msg = "手机号码格式错误";
                success = false;
            }
            return Json(new
            {
                msg = msg,
                success = success
            });
        }
        /// <summary>
        /// 获取图形验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidCode()
        {
            ImageHelper validCode = new ImageHelper();
            var imageByte = validCode.Create(out string code, 4).ToArray();
            //将验证码存在session中
            HttpContext.Session.SetString("PicVerifyCode", code.ToLower());
            return File(imageByte, "image/Jpeg");
        }



        public ActionResult ForgetPwdPhoneCode(string phone)
        {
            var msg = "";
            var result = _customerService.ValidPhoneExit(phone);
            if (!result)
            {
                bool success = _customerService.SendMessage(phone);
                msg = success ? "验证码发送成功" : "验证码发送失败";
                return Json(new { success = success, msg = msg });
            }
            else
            {
                return Json(new { success = false, msg = "手机号不存在"});
            }
        }

        /// <summary>
        /// 手机验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult PhoneValidCode(string phone,string picVerifyCode)
        {
            var PicVerifyCode = HttpContext.Session.GetString("PicVerifyCode");
            if (string.IsNullOrEmpty(picVerifyCode) || PicVerifyCode != picVerifyCode.ToLower())
            {
                return Json(new
                {
                    msg = "图形验证码错误"
                });
            }

            string msg = "";
            bool success = _customerService.SendMessage(phone);
            if (success)
                msg = "验证码发送成功";
            else
                msg = "";
            return Json(new { success = success, msg = msg});
        }

        /// <summary>
        /// 手机验证码
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = "zfuser")]
        public ActionResult PhoneValidCodeNoVerifyCode(string phone)
        {
            string msg = "";
            bool success = _customerService.SendMessage(phone);
            if (success)
                msg = "验证码发送成功";
            else
                msg = "";
            return Json(new { success = success, msg = msg });
        }

        public ActionResult VerifyRecommandCode(ValidateInfo model)
        {
            var result = _customerService.ValidRecommandCodeExit(model);
            return Json(new { success=result});
        }

        public ActionResult PhoneCode(VerifyCompanyInfo model)
        {
            //验证手机验证
            var result = _customerService.VerifyPhoneCode(new VerifyPhoneCode
            {
                PhoneNumber=model.PhoneNumber,
                VerCode=model.VerCode
            });
            var IsSuccess = result.IsSuccess;
            var Msg = result.Msg;

            //验证证件号
            if (result != null && result.IsSuccess
                &&(!string.IsNullOrEmpty(model.InstuCode)
                || !string.IsNullOrEmpty(model.BusiCode)
                ||!string.IsNullOrEmpty(model.TaxCode)
                ||!string.IsNullOrEmpty(model.IDCard)))
            {
                var companyInfo = _myAccountService.VerifyCompanyInfo(new SVerifyCompanyInfo
                {
                    InstuCode=model.InstuCode,
                    BusiCode=model.BusiCode,
                    TaxCode=model.TaxCode
                });
                if (!string.IsNullOrEmpty(model.InstuCode) && companyInfo.ReturnData.Any(c =>c.IsExit && c.Type.Equals("InstuCode", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "组织机构代码已存在";
                }
                if(!string.IsNullOrEmpty(model.BusiCode) && companyInfo.ReturnData.Any(c => c.IsExit && c.Type.Equals("BusiCode", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "营业执照编号已存在";
                }
                if(!string.IsNullOrEmpty(model.TaxCode) && companyInfo.ReturnData.Any(c => c.IsExit && c.Type.Equals("TaxCode", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "税务登记号已存在";
                }
                if (!string.IsNullOrEmpty(model.IDCard) && companyInfo.ReturnData.Any(c => c.IsExit && c.Type.Equals("IDCard", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "";
                }
            }

            return Json(new { IsSuccess =IsSuccess, Msg = Msg });
        }
        #endregion

        public IActionResult VerifyCompayInfo(SVerifyCompanyInfo model)
        {
            var IsSuccess = true;
            var Msg = "";
            if ((!string.IsNullOrEmpty(model.InstuCode)
                || !string.IsNullOrEmpty(model.BusiCode)
                || !string.IsNullOrEmpty(model.TaxCode)))
            {
                var companyInfo = _myAccountService.VerifyCompanyInfo(new SVerifyCompanyInfo
                {
                    InstuCode = model.InstuCode,
                    BusiCode = model.BusiCode,
                    TaxCode = model.TaxCode
                });

                if (!string.IsNullOrEmpty(model.InstuCode) && companyInfo.ReturnData.Any(c => c.IsExit && c.Type.Equals("InstuCode", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "组织机构代码已存在";
                }
                if (!string.IsNullOrEmpty(model.BusiCode) && companyInfo.ReturnData.Any(c => c.IsExit && c.Type.Equals("BusiCode", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "营业执照编号已存在";
                }
                if (!string.IsNullOrEmpty(model.TaxCode) && companyInfo.ReturnData.Any(c => c.IsExit && c.Type.Equals("TaxCode", StringComparison.OrdinalIgnoreCase)))
                {
                    IsSuccess = false;
                    Msg = "税务登记号已存在";
                }
               
            }
            return Json(new { success = IsSuccess, msg = Msg });
        }


        public IActionResult CompanyForgetPwdValidator(CompanyInfoValidator model)
        {
            var result = _myAccountService.CompanyForgetPwdValidator(model);
            return Json(new { isSuccess = result.ReturnData, msg = result.Message });
        }

        //企业登录
        public ActionResult EnterpriseLogin(string returnUrl)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userLoginFalied")))
            {
                ViewBag.IsFaild = true;
            }
            return View();
        }

        //企业注册
        public ActionResult EnterpriseRegister(string returnUrl)
        {
            return View();
        }

        //企业注册第二步
        public ActionResult EnterpriseRegisterN(string returnUrl)
        {
            return View();
        }
        //企业注册第三步
        public ActionResult EnterpriseRegisterL(string returnUrl)
        {
            return View();
        }
        //企业忘记密码第一步
        public ActionResult EnterpriseForgetPassword(string returnUrl)
        {
            return View();
        }
        //企业忘记密码第二步
        public ActionResult EnterpriseForgetPassword2(string returnUrl)
        {
            return View();
        }
        //企业忘记密码第三步
        public ActionResult EnterpriseForgetPassword3(string returnUrl)
        {
            return View();
        }


        #region 企业注册
        [HttpPost]
        public JsonResult CompanyRegister(CompanyRegister model)
        {
            var picVerifyCode = HttpContext.Session.GetString("PicVerifyCode");
            if (string.IsNullOrEmpty(model.imgCode) || picVerifyCode != model.imgCode.ToLower())
            {
                return Json(new
                {
                    success = false,
                    msg = "图形验证码错误"
                });
            }
            var postModel=new SCompanyRegisterModel
            {
                Phone = model.contractPhone,
                Password = model.password,
                VerCode = model.phoneCode,
                IsOne = model.isOne=="1",
                OrganizationCode = model.organization,
                TaxCode=model.tax,
                BusinessLicense = model.business,
                SocialCredit = model.social,
                ContactUser = model.contractUser
            };
            var result = _companyService.CompanyRegister(postModel);
            if (result.ReturnCode == 200)//注册成功
            {
                return Json(new
                {
                    success = true
                });
            }
            return Json(new
            {
                success = false,
                msg = result.Message,
                returnCode = result.ReturnCode
            });
        }

        [HttpPost]
        public string NowPicCode()
        {
            return HttpContext.Session.GetString("PicVerifyCode");
        }

        #endregion
    }
}