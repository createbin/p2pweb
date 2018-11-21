using System.Data.SqlTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json;
using ZFCTPC.Core.Enums;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Customer;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;
using ZFCTPC.Services.Account;
using ZFCTPC.Services.Customers;
using ZFCTPC.WebSite.Areas.Enterprise.Models;
using System;
using System.Linq;

namespace ZFCTPC.WebSite.Areas.Enterprise.Controllers
{
    [Area("Enterprise")]
    [Authorize(AuthenticationSchemes = "zfuser")]
    public class CompanyAccountController : Controller
    {

        private readonly IMyAccountService _myAccountService;
        private readonly ICompanyService _companyService;
        private readonly IBhAccountService _bhAccountService;
        private readonly IMyAccountService _iMyAccountService;


        public CompanyAccountController(IMyAccountService myAccountService,ICompanyService companyService,IBhAccountService bhAccountService,
            IMyAccountService iMyAccountService)
        {
            _myAccountService = myAccountService;
            _companyService = companyService;
            _bhAccountService = bhAccountService;
            _iMyAccountService = iMyAccountService;
        }

        public IActionResult Index()
        {
            //获取企业信息
            ViewBag.JieSuan = false;
            ViewBag.BoHai = false;
            var companyInfo = _companyService.CompanyRealInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (companyInfo.ReturnData != null && companyInfo.ReturnData.JieSuan == "1")
                ViewBag.JieSuan = true;
            if (companyInfo.ReturnData != null && companyInfo.ReturnData.BoHai == "1")
                ViewBag.BoHai = true;
            //var userState = _myAccountService.UserState(new BaseRequestModel() { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            //if (userState != null && userState.BoHai.Equals("1") && userState.JieSuan.Equals("1"))
            //    ViewBag.OtherAccount = true;
            //else
            //    ViewBag.OtherAccount = false;

            var result = _myAccountService.FinancingAccount(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RFinancingAccount();
            return View(result);
        }
        //投资户转账充值
        public IActionResult TransferRecharge()
        {
            return View();
        }
        //企业融资
        public IActionResult CorporateFinancing()
        {
            var raise=_myAccountService.MyBiddingLoan(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = 1, PageSize = 50 });
            ViewBag.RaiseInfo = raise;
            var raised = _myAccountService.MyFullLoan(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = 1, PageSize = 50 });
            ViewBag.RaisedInfo = raised;
            return View();
        }





        //还款计划
        public IActionResult EnterpriseRepaymentPlan()
        {
            //获取最近7天的还款计划
            var lastRepay=_companyService.LastDateWaitClear(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = 1, PageSize = 50 });
            ViewBag.LastRepay = lastRepay.ReturnData;
            return View();
        }

        public ActionResult _PartialWaitPayLoan()
        {
            var modelInfo = _companyService.MyRepayLoan(new RequestPageModel
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                Page = 1,
                PageSize = 50
            });
            return PartialView(modelInfo.ReturnData);
        }


        public IActionResult VerifyRepaymentAuth(int id)
        {
            var authInfos = _bhAccountService.AuthQuery(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            var loanPlanDetail = _iMyAccountService.RepayDetail(new SRepayDetail { Token = User.FindFirst(ClaimTypes.Rsa).Value, LoanPlanId = id });
            //59缴费，60还款
            var authInfo = authInfos.ReturnData.AuthInfos.FirstOrDefault(a => a.AuthCode == "59");
            var repaymentAuth = authInfos.ReturnData.AuthInfos.FirstOrDefault(a => a.AuthCode == "60");

            if (authInfo.AuthState != "1")
            {
                return Json(new { success = false, msg = "缴费授权未授权或授权过期" });
            }
            if (repaymentAuth.AuthState != "1")
            {
                return Json(new { success = false, msg = "还款授权未授权或授权过期" });
            }
            if (decimal.Parse(authInfo.AuthMoney) < loanPlanDetail.ServiceFee)
            {
                return Json(new { success = false, msg = "缴费授权金额小于应还总额,请提高授权金额" });
            }
            if (decimal.Parse(repaymentAuth.AuthMoney) < loanPlanDetail.CurrenyWaitPayMoney)
            {
                return Json(new { success = false, msg = "还款授权金额小于应还总额,请提高授权金额" });
            }

            return Json(new { success = true, msg = "" });
        }

        public ActionResult _PartialPayedLoan(int page=1,int pageSize=5)
        {
            var modelInfo = _companyService.MyRepayedLoan(new RequestPageModel
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                Page = page,
                PageSize = pageSize
            });
            return PartialView(modelInfo.ReturnData);
        }


        //还款
        public IActionResult EnterpriseRepayment(int loanId,bool isGuar = false)
        {
            var model = new RRepayDetail();
            var result = _myAccountService.RepayDetail(new SRepayDetail { Token = User.FindFirst(ClaimTypes.Rsa).Value, LoanPlanId = loanId });
            if (result != null)
            {
                model = result;
            }
            ViewBag.IsGuar = isGuar;
            return View(model);
        }
        //企业开户
        public IActionResult EnterpriseOpenAccount()
        {
            //获取企业信息
            var companyInfo = _companyService.CompanyRealInfo(new BaseRequestModel{Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.CompanyInfo = companyInfo.ReturnData;
            return View();
        }

        [HttpPost]
        public JsonResult JsOpenAccount(JieSuanOpenAccount model)
        {
            if (string.IsNullOrEmpty(model.companyName) || string.IsNullOrEmpty(model.realCard) ||
                string.IsNullOrEmpty(model.realName) || model.type==0||string.IsNullOrEmpty(model.contactPhone)||
                string.IsNullOrEmpty(model.contactUser)||string.IsNullOrEmpty(model.idCard))
            {
                return Json(new { success = false, msg = "入参不合法" });
            }
            var postModel = new SJsCoRegisterModel
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                AccountName = model.companyName,
                CompanyName = model.companyName,
                CorperationIdCard = model.realCard,
                CorperationName = model.realName,
                IsGuarantee = model.type,
                ContactPhone = model.contactPhone,
                ContactUser = model.contactUser,
                IdCard = model.idCard,
                LicenseCode = model.licenseCode,
                TaxId = model.taxId
            };
            var result = _companyService.JieSuanCoRegister(postModel);
            return Json(result.ReturnCode == (int) ReturnCodeEnum.Success ? new { success = true, msg = result.ReturnData } : new { success = false, msg = result.Message });
        }

        //企业银行卡管理
        public IActionResult EnterpriseBankManagement()
        {

            return View();
        }
        //企业融资统计
        [HttpPost]
        public JsonResult BhOpenAccount(BoHainOpenAccount model)
        {
            if (string.IsNullOrEmpty(model.accountBank) || string.IsNullOrEmpty(model.accountNo)||string.IsNullOrEmpty(model.accountName))
            {
                return Json(new { success = false, msg = "入参不合法" });
            }
            var postModel = new SJsOpenChargeModel()
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                AccountNo = model.accountNo,
                AccountBk = model.accountBank,
                AccountName = model.accountName
            };
            var result = _companyService.OpenChargeAccount(postModel);
            return Json(result.ReturnCode == (int)ReturnCodeEnum.Success ? new { success = true, msg = result.ReturnData.Url } : new { success = false, msg = result.Message });
        }
        public IActionResult EnterpriseFinanceStatistics()
        {
            var statistics =_companyService.LoanStatics(new BaseRequestModel {Token = User.FindFirst(ClaimTypes.Rsa).Value});
            return View(statistics);
        }
        //企业银行存管
        public IActionResult EnterprisepBankDepository()
        {
            //获取企业信息
            var companyInfo = _companyService.CompanyRealInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (!string.IsNullOrEmpty(companyInfo.ReturnData?.ContactPhone))
            {
                companyInfo.ReturnData.ContactPhone = companyInfo.ReturnData.ContactPhone.Substring(0, 3) + "****" +
                                                      companyInfo.ReturnData.ContactPhone.Substring(7,4);
            }
            ViewBag.CompanyInfo = companyInfo.ReturnData;
            return View();
        }
        //企业授权管理
        public IActionResult EnterpriseAManagement(string msg)
        {
            var authInfos = _bhAccountService.AuthQuery(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.IsRealName = false;
            if (authInfos.ReturnData != null)
            {
                var companyInfo = _companyService.CompanyRealInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
                if (companyInfo.ReturnData.RealNameState == "1")
                {
                    ViewBag.IsRealName = true;
                }
            }
            ViewBag.AuthInfos = authInfos.ReturnData;
            ViewBag.Msg = msg;
            return View();
        }
        //企业充值 我的投资户
        public IActionResult EnterpriseRecharge()
        {
            //获取企业信息
            var companyInfo = _companyService.CompanyRealInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.CompanyInfo = companyInfo.ReturnData;
            return View();
        }
        //企业充值 我的融资户
        public IActionResult EnterpriseFinancing()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CompanyRechargeSyn(string userType="1")
        {
            //获取企业信息
            var companyInfo = _companyService.RechargeSyn(new SUserType { Token = User.FindFirst(ClaimTypes.Rsa).Value,UserType = userType});
            if (companyInfo.ReturnCode == (int) ReturnCodeEnum.Success)
            {
                return Json(new { Balance=companyInfo.ReturnData,success=true});
            }
            else
            {
                return Json(new { Balance ="0.00", success = false });
            }
        } 

        //企业 操作记录
        public IActionResult EnterpriseOperationRecord()
        {
            ViewBag.SDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.EDate = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }
        //企业 交易记录
        public IActionResult EnterpriseTransactionRecord()
        {
            return View();
        }
        //企业 担保管理 替他人还款
        public IActionResult RepaymentForOthers()
        {
            var modelInfo = _companyService.GurRepayedLoan(new RequestPageModel()
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                PageSize = 5,
                Page = 1
            });
            ViewBag.Repayed = modelInfo.ReturnData;
            return View();
        }

        public IActionResult _PatialGurRepayLoan(string loanNo,string name)
        {
            var modelInfo = _companyService.GurRepayLoan(new SGuaranteeLoans
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                LoanNo = loanNo,
                Loaner = name
            });

            return PartialView(modelInfo.ReturnData);
        }


        public IActionResult _PatialGurRepayedLoan(int page,int pageSize)
        {
            var modelInfo = _companyService.GurRepayedLoan(new RequestPageModel()
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                PageSize = pageSize,
                Page = page
            });
            ViewBag.Current = page;
            return PartialView(modelInfo.ReturnData);
        }

        public JsonResult GurRepayedLoan(int page, int pageSize)
        {
            var modelInfo = _companyService.GurRepayedLoan(new RequestPageModel()
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                PageSize = pageSize,
                Page = page
            });
            if (modelInfo.ReturnData != null && modelInfo.ReturnData.Total > 0)
            {
                return Json(new { success = true, result = JsonConvert.SerializeObject(modelInfo.ReturnData) });
            }
            else
            {
                return Json(new { success = false, result = "" });
            }

        }


        public JsonResult RealNameState()
        {
            var realNameState = _companyService.RealNameState(new BaseRequestModel{Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (realNameState.ReturnCode == (int) ReturnCodeEnum.Success)
            {
                return Json(new {success=true,msg=realNameState.ReturnData});
            }
            else
            {
                return Json(new { success = false, msg = realNameState.ReturnData });
            }
        }


    }
}
