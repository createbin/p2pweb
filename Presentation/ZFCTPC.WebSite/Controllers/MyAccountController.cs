using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Invites;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModelReturn;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;
using ZFCTPC.Services.Account;
using ZFCTPC.Services.Customers;
using ZFCTPC.Services.Invites;
using ZFCTPC.Services.Tools;
using ZFCTPC.WebSite.ViewModels.MyAccountModels;

namespace ZFCTPC.WebSite.Controllers
{
    [Authorize(AuthenticationSchemes = "zfuser")]
    public class MyAccountController : Controller
    {
        private readonly IMyAccountService _iMyAccountService;
        private readonly IInviteService _inviteService;
        private readonly IBhAccountService _bhAccountService;
        private readonly IToolsService _toolsService;
        private readonly ICustomerService _customerService;
        private static decimal transferRate = 0.0m;

        public MyAccountController(IMyAccountService iMyAccountService, IInviteService inviteService, IBhAccountService bhAccountService,
            IToolsService toolsService,
            ICustomerService customerService)
        {
            _iMyAccountService = iMyAccountService;
            _inviteService = inviteService;
            _bhAccountService = bhAccountService;
            _toolsService = toolsService;
            _customerService = customerService;
        }

        #region 首页

        public IActionResult Index()
        {
            var returnModel = _iMyAccountService.PCAccountStatistics(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RPCAccountStatistics();
            if (returnModel.HasLoan)
            {
                ViewBag.RFinancingAccount = _iMyAccountService.FinancingAccount(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RFinancingAccount();
            }
            return View(returnModel);
        }

        [HttpPost]
        public IActionResult MyAccountBH(string accountMoney = null, int userAttribute = 1)
        {
            var resultModel = _iMyAccountService.RBHAccountInfo(new SJsQueryChargeAccount() { Token = User.FindFirst(ClaimTypes.Rsa).Value, UserAttribute = userAttribute }) ?? new RBHAccountInfo();
            return Json(new
            {
                success = true,
                accountMoney = string.Format("{0:N}", decimal.Parse(string.IsNullOrEmpty(accountMoney) ? "0" : accountMoney) + resultModel.TotalAmount + resultModel.FreezeAmout),
                freezing_amount = string.Format("{0:N}", resultModel.FreezeAmout),
                enable_amount = string.Format("{0:N}", resultModel.TotalAmount),
                //withdraw_amount = string.Format("{0:N}", resultModel.WithdrawAmount),
            });
        }

        //我的业务统计
        public IActionResult MyBusiness()
        {
            var model = _iMyAccountService.BusinessStatistics(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RBusinessStatistics();
            return Json(new
            {
                loanCount = model.LoanCount,
                investCount = model.InvestCount,
                tranferCount = model.TransferCount,
                redCount = model.CanUserRedCount
            });

        }

        /// <summary>
        /// 是否借款
        /// </summary>
        /// <returns></returns>
        public IActionResult HasLoan()
        {
            return Json(new
            {
                result = _iMyAccountService.HasLoan(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value })
            });

        }

        #endregion 首页

        #region 我的投资

        public IActionResult MyInvestList(int tabid = 0, string msg = null)
        {
            var remodel = _iMyAccountService.InvestAccountStatistics(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RInvestAccountStatistics();
            var model = new MyInvestListModel
            {
                invest_money = string.Format("{0:N}", remodel.InvestMoney),
                collect_interest = string.Format("{0:N}", remodel.WaitRepayEarnings),
                principal_amount = string.Format("{0:N}", remodel.WaitRepayPrincipal),
                earned_interest = string.Format("{0:N}", remodel.RepayEarnings),
                recovered_principal = string.Format("{0:N}", remodel.RepayPrincipal)
            };
            var result = _iMyAccountService.UserState(new BaseRequestModel() { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null && result.BoHai.Equals("1") && result.JieSuan.Equals("1"))
                ViewBag.OtherAccount = true;
            else
                ViewBag.OtherAccount = false;

            ViewBag.msg = msg;
            ViewBag.TabId = tabid;
            return View(model);
        }

        [HttpPost]
        public IActionResult MyInvestData(int Type, int Page = 1, int PageSize = 5)
        {

            dynamic returnData = null;
            switch (Type)
            {
                case 2:
                    returnData = _iMyAccountService.MyBiddingInvest(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
                case 4:
                    returnData = _iMyAccountService.MyRepaymentInvest(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
                case 3:
                    returnData = _iMyAccountService.MyClearedInvest(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
            }
            ViewData["type"] = Type;
            ViewData["TotalData"] = returnData?.Total;
            return PartialView("/Views/MyAccount/_PartialInvestList.cshtml", returnData?.PagingData);
        }

        #endregion 我的投资

        #region 我的借款

        public IActionResult MyLoan(int tabid = 0)
        {
            ViewBag.TabId = tabid;
            return View();
        }

        [HttpPost]
        public IActionResult MyLoanData(int type = 1, int page = 1, int pageSize = 5)
        {
            dynamic returnData = null;
            switch (type)
            {
                case 0:
                    returnData = _iMyAccountService.MyRepaymentLoan(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = page, PageSize = pageSize });
                    break;
                case 1:
                    returnData = _iMyAccountService.MyBiddingLoan(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = page, PageSize = pageSize });
                    break;
                case 2:
                    returnData = _iMyAccountService.MyFullLoan(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = page, PageSize = pageSize });
                    break;
                case 3:
                    returnData = _iMyAccountService.MyClearedLoan(new Data.ApiModel.MyAccountRequestModels.MyLoanList { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = page, PageSize = pageSize });
                    break;

            }
            ViewData["type"] = type;
            ViewData["TotalData"] = returnData?.Total;
            return PartialView("/Views/MyAccount/_PartialLoanList.cshtml", returnData?.PagingData);
        }

        //借款统计
        public IActionResult LoanStatistics()
        {
            var model = _iMyAccountService.LoanAccountStatistics(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RLoanAccountStatistics();
            return View(model);
        }

        public IActionResult LoanStatisticsData(int Page = 1, int PageSize = 5)
        {
            int totaldata = 0;
            IEnumerable<RLoanItemDetail> model = new List<RLoanItemDetail>();
            var list = _iMyAccountService.MyLoanDetail(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
            if (list != null && list.PagingData != null)
            {
                model = list.PagingData;
                totaldata = list.Total;
            }
            ViewData["TotalData"] = totaldata;
            return PartialView("/Views/MyAccount/_PartialLoanStatisticsList.cshtml", model);
        }

        #endregion 我的借款

        #region 还款计划

        public IActionResult MyRepaymentPlan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MyRepaymentPlanData(int Type = 1, int Page = 1, int PageSize = 5)
        {
            ViewData["type"] = Type;
            dynamic returnData = null;
            switch (Type)
            {
                case 0:
                    returnData = _iMyAccountService.UserLoanPlanClear(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
                case 1:
                    returnData = _iMyAccountService.UserLoanPlanWaitClear(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
            }
            ViewData["TotalData"] = returnData?.Total;
            return PartialView("/Views/MyAccount/_PartialRePayList.cshtml", returnData?.PagingData);
        }

        /// <summary>
        /// 校验还款授权
        /// </summary>
        /// <returns></returns>
        public IActionResult VerifyRepaymentAuth(int id)
        {
            var authInfos = _bhAccountService.AuthQuery(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            var loanPlanDetail = _iMyAccountService.RepayDetail(new SRepayDetail { Token = User.FindFirst(ClaimTypes.Rsa).Value, LoanPlanId = id });
            if (authInfos.ReturnCode != 200)
            {
                return Json(new { success = false, msg = authInfos.Message });
            }
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

        public IActionResult SignalRepaymentPlan(int id, string name)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            return View();
        }

        //单个项目还款计划
        public IActionResult SignalRepaymentPlanData(int id, int Page = 1, int PageSize = 5)
        {
            int totaldata = 0;
            ViewData["type"] = 2;
            IEnumerable<RMyLoanPlanModel> model = new List<RMyLoanPlanModel>();
            var list = _iMyAccountService.LoanPayPlan(new SLoanPlan { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize, LoanId = id });
            if (list != null && list.PagingData != null)
            {
                model = list.PagingData.ToList();
                totaldata = list.Total;
            }
            ViewData["TotalData"] = totaldata;
            return PartialView("/Views/MyAccount/_PartialRePayList.cshtml", model);
        }

        #endregion 还款计划

        #region 债权转让

        public IActionResult ClaimsTransfer(int tabid = 0, string msg = null)
        {
            ViewBag.TabId = tabid;
            ViewBag.msg = msg;
            return View();
        }

        [HttpPost]
        public IActionResult ClaimsTransferData(int Type = 1, int Page = 1, int PageSize = 5)
        {
            dynamic returnData = null;
            ViewData["type"] = Type;
            switch (Type)
            {
                case 3:
                    returnData = _iMyAccountService.CanTransfer(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    transferRate = decimal.Parse(returnData?.Extra1);
                    ViewData["TotalData"] = returnData?.Total;
                    return PartialView("/Views/MyAccount/_PartialCanTransferList.cshtml", returnData?.PagingData);
                case 0:
                    returnData = _iMyAccountService.Transfering(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
                case 1:
                    returnData = _iMyAccountService.TransferOut(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
                case 2:
                    returnData = _iMyAccountService.TransferIn(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
                    break;
            }
            ViewData["TotalData"] = returnData?.Total;
            return PartialView("/Views/MyAccount/_PartialClaimsTransferList.cshtml", returnData?.PagingData);
        }

        #endregion 债权转让

        #region 我的红包

        public IActionResult MyRedEnvelope()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MyRedEnvelopeData(int Page = 1, int PageSize = 5)
        {
            var model = new List<RRedEnvelopesModel>();
            var totalData = 0;
            var returnPageData = _iMyAccountService.UserRedPage(new RequestPageModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize });
            if (returnPageData != null && returnPageData.PagingData != null)
            {
                model = returnPageData.PagingData.ToList();
                totalData = returnPageData.Total;
            }
            ViewData["TotalData"] = totalData;
            return PartialView("/Views/MyAccount/_PartialRedList.cshtml", model);
        }

        #endregion 我的红包

        #region 充值提现

        public IActionResult RechargeAndWithdraw(string msg = null)
        {
            ViewBag.OtherAccount = false;
            ViewBag.msg = msg;
            var result = _iMyAccountService.UseBaseInfo(new BaseRequestModel() { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.BoHai && result.JieSuan)
                {
                    ViewBag.PersonalChargeAccount = result.PersonalChargeAccount;
                    ViewBag.RealName = result.RealName;
                    ViewBag.OtherAccount = true;
                }
            }
            return View();
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        public IActionResult Recharge()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Recharge(decimal money, int userAttribute = 1)
        {
            var result = _iMyAccountService.BHAccountRecharge(new SBHAccountRecharge
            {
                Money = money,
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                UserAttribute = userAttribute
            });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "充值失败！" });
            }
        }

        /// <summary>
        /// 可用余额
        /// </summary>
        /// <param name="userAttribute"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RemainMoney(int userAttribute = 1)
        {
            var result = _iMyAccountService.RBHAccountInfo(new SJsQueryChargeAccount
            {
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                UserAttribute = userAttribute
            });
            if (result != null)
            {
                return Json(new { success = true, msg = string.Format("{0:N}", result.WithdrawAmount), remainmoney = result.WithdrawAmount });
            }
            return Json(new { success = false, msg = string.Format("{0:N}", 0), remainmoney = 0 });
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <returns></returns>
        public IActionResult Withdrawal(int userAttribute = 1)
        {
            ViewBag.UserAttribute = userAttribute;
            return View();
        }

        [HttpPost]
        public IActionResult WithdrawFee(decimal money)
        {
            var result = _iMyAccountService.CalcWithdrawFee(new SBHAccountWithdraw
            {
                Money = money,
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
            });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    var isFrist = bool.Parse(result.Message);
                    var withdrawFee = result.ReturnData;
                    var arriveMoeny = isFrist ? money : (money - withdrawFee);
                    return Json(new { success = true, fee = withdrawFee, arrivemoeny = arriveMoeny, isfrist = isFrist });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public IActionResult Withdrawal(decimal money, int userAttribute = 1)
        {
            var result = _iMyAccountService.BHAccountWithdraw(new SBHAccountWithdraw
            {
                Money = money,
                Token = User.FindFirst(ClaimTypes.Rsa).Value,
                UserAttribute = userAttribute
            });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "提现失败！" });
            }
        }

        #endregion 充值提现

        #region 邀请奖励

        public IActionResult InvitationToReward()
        {
            var requestModel = new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value };
            var statistics = _inviteService.InviteStatistics(requestModel);
            ViewBag.Statistics = statistics;
            var requestModel2 = new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value };
            var monthAbstracts = _inviteService.InviteMonthAbstract(requestModel2);
            ViewBag.Abstracts = monthAbstracts;
            if (monthAbstracts.Count > 0)
            {
                var overviews = monthAbstracts.RewardOverviews;
                var requestModel3 = new MonthInvester
                {
                    Month = overviews[0].Month,
                    Year = overviews[0].Year,
                    Token = User.FindFirst(ClaimTypes.Rsa).Value
                };
                var monthDetails = _inviteService.InviteMonthDetail(requestModel3);
                ViewBag.Details = monthDetails;
            }
            return View();
        }

        [HttpPost]
        public JsonResult MonthInviterDetails(int year, int month)
        {
            var model = new MonthInvester
            {
                Month = month,
                Year = year,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var monthDetails = _inviteService.InviteMonthDetail(model);
            if (monthDetails.Count > 0)
            {
                return Json(new
                {
                    Success = "000",
                    Result = JsonConvert.SerializeObject(monthDetails.InvesterDetails)
                });
            }
            return Json(new
            {
                Success = "999",
                Result = JsonConvert.SerializeObject(monthDetails.InvesterDetails)
            });
        }

        #endregion 邀请奖励

        #region 安全中心

        public IActionResult SecurityCenter()
        {
            var resuleModel = _iMyAccountService.UseBaseInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new UseBaseInfoModel();
            var result = _iMyAccountService.UserInvestType(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.InvestType = result;
            return View(resuleModel);
        }

        /// <summary>
        /// 发送邮箱验证码
        /// </summary>
        /// <param name="emial"></param>
        /// <returns></returns>
        public ActionResult SendEmialCode(string emial)
        {
            var result = _iMyAccountService.SendVCodeToEmail(new SVCodeToEmail { Token = User.FindFirst(ClaimTypes.Rsa).Value, EmailCode = emial });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = "发送成功" });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }

            }
            return Json(new { success = false, msg = "发送失败，未知错误" });
        }

        /// <summary>
        /// 发送渤海手机号验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public ActionResult SendMobileVCodeToBhUser(string phone)
        {
            var result = _iMyAccountService.SendMobileVCodeToBhUser(new Data.ApiModel.Customer.SVCodeToMobile { Token = User.FindFirst(ClaimTypes.Rsa).Value, MobileNumber = phone });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = "发送成功" });
                }
                else if (result.ReturnCode == 206)
                {
                    return Json(new { success = false, msg1 = result.Message });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }

            }
            return Json(new { success = false, msg = "发送失败，未知错误" });
        }

        /// <summary>
        /// 修改手机号码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="verCode"></param>
        /// <returns></returns>
        public ActionResult ChangePhone(string phone, string verCode)
        {
            var result = _iMyAccountService.ChangePhone(new SChangePhoneModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, PhoneNumber = phone, VerCode = verCode });

            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = "修改成功" });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }

            }
            return Json(new { success = false, msg = "修改失败，未知错误" });
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="newPwd"></param>
        /// <param name="oldPwd"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(string newPwd, string oldPwd)
        {
            var result = _iMyAccountService.ChangeLoginPassword(new SChangeLoginPasswordModel { Token = User.FindFirst(ClaimTypes.Rsa).Value, OldPassword = oldPwd, Password = newPwd });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = "修改成功" });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }

            }
            return Json(new { success = false, msg = "修改失败，未知错误" });
        }


        /// <summary>
        /// 修改渤海密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeBhPassword(string operationType = "1")
        {
            var result = _iMyAccountService.BoHaiBindPass(new SBoHaiBindPass { Token = User.FindFirst(ClaimTypes.Rsa).Value, OperationType = operationType });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }

            }
            return Json(new { success = false, msg = "修改失败，未知错误" });
        }

        /// <summary>
        /// 修改渤海手机号
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeBhPhone(string newPhone, string vCode)
        {
            var result = _iMyAccountService.BoHaiBindMobile(new SBhBindMobile { Token = User.FindFirst(ClaimTypes.Rsa).Value, NewPhone = newPhone, VerCode = vCode });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            return Json(new { success = false, msg = "修改失败，未知错误" });
        }

        #endregion 安全中心

        #region 交易记录

        public IActionResult TransactionRecord()
        {
            return View();
        }

        public IActionResult TransactionRecordData(int Type = 1, int Page = 1, int PageSize = 5, int DateType = 1)
        {
            int totaldata = 0;
            ViewData["type"] = Type;
            List<RTradingModel> model = new List<RTradingModel>();
            var submitModel = new SAccountTrading { Token = User.FindFirst(ClaimTypes.Rsa).Value, Page = Page, PageSize = PageSize, Type = Type };

            if (DateType != 1)
            {
                switch (DateType)
                {
                    case 2:
                        submitModel.Min = DateTime.Now.Date;
                        submitModel.Max = DateTime.Now.Date;
                        break;

                    case 3:
                        submitModel.Min = DateTime.Now.AddDays(-7).Date;
                        submitModel.Max = DateTime.Now.Date;
                        break;

                    case 4:
                        submitModel.Min = DateTime.Now.AddMonths(-1).Date;
                        submitModel.Max = DateTime.Now.Date;
                        break;

                    case 5:
                        submitModel.Min = DateTime.Now.AddMonths(-2).Date;
                        submitModel.Max = DateTime.Now.Date;
                        break;

                    case 6:
                        submitModel.Min = DateTime.Now.AddMonths(-3).Date;
                        submitModel.Max = DateTime.Now.Date;
                        break;
                    case 7:
                        submitModel.Min = DateTime.Now.AddDays(-3).Date;
                        submitModel.Max = DateTime.Now.Date;
                        break;
                }
            }

            var list = _iMyAccountService.TradingInfo(submitModel);
            if (list != null && list.PagingData != null)
            {
                model = list.PagingData.ToList();
                totaldata = list.Total;
            }
            ViewData["TotalData"] = totaldata;
            return PartialView("/Views/MyAccount/_PartialTransactionRecordList.cshtml", model);
        }

        /// <summary>
        /// 线下充值记录
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="PageSize"></param>
        /// <param name="DateArea"></param>
        /// <returns></returns>
        public IActionResult OfflineRechargeData(int Page = 1, string DateArea = "")
        {
            IEnumerable<RToTradingModel> reusltData = new List<RToTradingModel>();
            int totaldata = 0;
            var dateArray = DateArea.Split("~", StringSplitOptions.RemoveEmptyEntries);

            if (dateArray.Length == 2)
            {
                DateTime.TryParse(dateArray[0], out DateTime sDate);
                DateTime.TryParse(dateArray[1], out DateTime eDate);
                var result = _bhAccountService.OfflineRechargeRecord(new OfflineRechargeRecord()
                {
                    SDate = sDate,
                    EDate = eDate,
                    Token = User.FindFirst(ClaimTypes.Rsa).Value,
                    Page = Page,
                });//?.ReturnData;

                if (result != null)
                {
                    if (result.ReturnData != null)
                    {
                        reusltData = result.ReturnData.PagingData;
                        totaldata = result.ReturnData.TotalPageCount;
                    }
                    else
                    {
                        TempData["ErrorMsg"] = result.Message;
                    }
                }
            }
            else
            {
                TempData["ErrorMsg"] = "日期选择错误";
            }
            ViewData["TotalData"] = totaldata;

            return View(reusltData);
        }

        #endregion 交易记录

        #region 还款

        public IActionResult RepaymentNow(int id)
        {
            RRepayDetail model = new RRepayDetail();
            var result = _iMyAccountService.RepayDetail(new SRepayDetail { Token = User.FindFirst(ClaimTypes.Rsa).Value, LoanPlanId = id });
            if (result != null)
            {
                model = result;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult RepayNow(int id, string VerCode, bool isGuar = false)
        {
            LoanInfoDeatil model = new LoanInfoDeatil();
            //var result = _iMyAccountService.RepaymentPlanData(new Data.ApiModel.MyAccountRequestModels.RepaymentPlanData { Token = User.FindFirst(ClaimTypes.Rsa).Value, id = id, VerCode = VerCode });
            var result = _iMyAccountService.Repayment(new SRepayment() { LoanPlanId = id, IsGuar = isGuar, VerCode = VerCode, Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.Message });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message, code = result.ReturnCode });
                }
            }
            else
            {
                return Json(new { success = false, msg = "还款失败！" });
            }
        }

        #endregion 还款

        #region 银行卡管理

        public ActionResult BankCardManage(string msg = "")
        {
            ViewBag.Msg = msg;
            var thirdPart = _iMyAccountService.ThirdPartInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.ThirdPart = thirdPart.ReturnData;
            ViewBag.BankList = _toolsService.BankInfos();
            return View();
        }

        [HttpPost]
        public ActionResult BHOpenAccount(string bankCode, string bankNumber)
        {
            bankNumber = bankNumber.Trim();
            var realInfo = new RealName
            {
                BankCode = bankCode,
                BankCodeNo = bankNumber,
                UserAttr = 1,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var result = _bhAccountService.BoHaiRealName(realInfo);
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }

            }
            else
            {
                return Json(new { success = false, msg = "绑卡失败！" });
            }
        }

        [HttpPost]
        public ActionResult ChangeCard()
        {
            var result = _iMyAccountService.BoHaiBindCard(new SBHAccountRecharge { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else if (result.ReturnCode == 206)
                {
                    return Json(new { success = true, msg = result.Message, isopenaccount = false });
                }
            }
            return Json(new { success = false, msg = "修改绑定银行卡失败！" });

        }
        #endregion 银行卡管理

        #region 开户

        //开户信息
        public ActionResult OpenAccountInfo()
        {
            var userBase = _bhAccountService.UserBaseInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.UserBase = userBase;
            var fisrtRegister = userBase.RealName == null;
            ViewBag.FirstRegister = fisrtRegister;
            return View();
        }

        //开户
        [HttpPost]
        public ActionResult OpenAccount(string name, string idCard,int accountType)
        {
            var model = new JsRegister
            {
                RealName = name,
                BusinessProperty = accountType,
                IdCard = idCard,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var result = _bhAccountService.JieSuanRegister(model);
            if (result != null)
            {
                return Json(new { success = false, msg = result });
            }
            else
            {
                return Json(new { success = false, msg = "开户失败！" });
            }
        }

        #endregion 开户

        #region 发送手机验证码

        [HttpPost]
        public ActionResult SendMsg()
        {
            bool success = _customerService.SendMessage(User.FindFirst(ClaimTypes.MobilePhone).Value);
            //var result = _iMyAccountService.SendSms(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (success)
            {
                return Json(new { success = true, msg = "发送失败" });
            }
            else
            {
                return Json(new { success = false, msg = "服务器异常,发送失败！" });
            }
        }

        #endregion 发送手机验证码

        #region 债权转让申请

        [HttpPost]
        public IActionResult DoTransferData(int id, decimal idualMoney, decimal discount)
        {
            var result = _iMyAccountService.DoTransfer(new SDoTransferData { InvestId = id, IdualMoney = idualMoney, Discount = discount, Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.Message });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "转让失败！" });
            }
        }

        //债权转让费率计算
        public IActionResult TransferFee(decimal idualMoney, decimal discount)
        {
            var transferFee = idualMoney * transferRate / 100;
            var transferMoney = idualMoney * discount / 100;
            var actualMoney = transferMoney - transferFee;
            return Json(new
            {
                transferFee = transferFee,
                transferMoney = transferMoney,
                actualMoney = actualMoney
            });
        }

        #endregion 债权转让申请

        #region 债权转让撤回

        public IActionResult RecallTransfer(int id)
        {
            var result = _iMyAccountService.RecallTransfer(new SRecallTransfer { Id = id, Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.Message });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "撤回失败！" });
            }
        }

        #endregion 债权转让撤回

        #region 下载投资人合同

        [HttpPost]
        public IActionResult InvesterFile(int id)
        {
            var result = _iMyAccountService.DownInvestContract(new Data.ApiModel.Customer.SDownInvestContract { InvestId = id, Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "合同下载失败，请稍后再试！" });
            }
        }

        #endregion 下载投资人合同

        #region 下载借款人合同

        [HttpPost]
        public IActionResult LoanerFile(int id)
        {
            var result = _iMyAccountService.DownLoanContract(new Data.ApiModel.Customer.SDownLoanContract { LoanId = id, Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "合同下载失败，请稍后再试！" });
            }
        }

        #endregion 下载借款人合同

        #region 汇付跳转页面

        public ActionResult HuiFuReturnUrl(string msg = "操作成功！")
        {
            ViewBag.msg = msg;
            return View();
        }

        #endregion 汇付跳转页面

        #region 我的收益

        [HttpPost]
        public IActionResult MyEarnings()
        {
            var model = _iMyAccountService.InvestEarnings(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (model == null)
            {
                model = new RInvestEarnings();
            }
            return Json(new
            {
                username = model.UserName,
                accumulated_income = string.Format("{0:N}", model.AccumulativeEarnings),
                thirtyDays_income = string.Format("{0:N}", model.ThridDayEarnings)
            });
        }

        #endregion 我的收益

        #region 提交积分

        [HttpPost]
        public IActionResult PostQuestionScore(int score, List<SQuestionnAnswer> answers)
        {
            var result = _iMyAccountService.PostQuestionScore(new SQuestionScore { score = score, Token = User.FindFirst(ClaimTypes.Rsa).Value, answers = answers });
            if (result)
            {
                return Json(new { success = true, msg = "提交成功!" });
            }
            else
            {
                return Json(new { success = false, msg = "提交失败!" });
            }
        }

        #endregion 提交积分

        #region 用户投资类型

        [HttpPost]
        public IActionResult UseInvestType()
        {
            var result = _iMyAccountService.UserInvestType(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (!string.IsNullOrEmpty(result))
            {
                return Json(new { success = true, msg = result });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion 用户投资类型

        #region 投资户转账充值

        public IActionResult TransferRecharge()
        {

            return View();
        }

        [HttpPost]
        public IActionResult TransferRecharge(decimal money)
        {
            var result = _iMyAccountService.FinanceTransfer(new SFinanceTransfer { Token = User.FindFirst(ClaimTypes.Rsa).Value, Money = money });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = "转账成功" });
                }
                else
                {
                    return Json(new { success = false, msg = result.Message });
                }
            }
            else
            {
                return Json(new { success = false, msg = "转账失败！" });
            }
        }

        #endregion 投资户转账充值

        /// <summary>
        /// 银行存管-银行卡管理
        /// </summary>
        /// <returns></returns>
        public IActionResult BankCardManageNext()
        {
            var result = _iMyAccountService.UserState(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new UserState();
            ViewBag.IsJieSuan = result.JieSuan;
            ViewBag.IsBoHai = result.BoHai;
            return View();
        }

        public IActionResult MyBankInfos()
        {
            var resultModel = _iMyAccountService.UserBankInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new RUserBankInfo();
            ViewBag.Url = ApiEngineToConfiguration.GetBhApiAddress().Replace("/api", "");
            return PartialView("/Views/MyAccount/_PartialBankInfo.cshtml", resultModel);
        }

        [HttpPost]
        public IActionResult UpdateBankInfos()
        {
            var resultModel = _iMyAccountService.UpdateBankInfo(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value }) ?? new ReturnModel<bool, string>();
            if (resultModel.ReturnData)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        /// <summary>
        /// 银行卡管理-授权管理
        /// </summary>
        /// <returns></returns>
        public IActionResult BankCardManageThird(string msg)
        {
            var authInfos = _bhAccountService.AuthQuery(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.AuthInfos = authInfos.ReturnData;
            ViewBag.Msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult AutoAuth(int type = 1)
        {
            var result = _bhAccountService.BoHaiAutoAuth(new SAuthType() { AuthType = type.ToString(), Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (result != null)
            {
                if (result.ReturnCode == 200)
                {
                    return Json(new { success = true, msg = result.ReturnData.Url });
                }
                else if (result.ReturnCode == 206)
                {
                    return Json(new { success = true, msg = result.Message, isopenaccount = false });
                }
            }
            return Json(new { success = false, msg = "发起授权失败！" });
        }

        //充值提现-我的融资户
        public ActionResult PersonalFinancing()
        {
            return View();
        }
        //充值提现-充值提现记录
        public ActionResult RechargeWithdrawalRecord()
        {
            //18212345678
            ViewBag.SDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.EDate = DateTime.Now.ToString("yyyy-MM-dd");

            return View();
        }
        //我的投资户-提现
        public ActionResult InvestmentWithdraw()
        {
            return View();
        }
        //我的融资户-提现
        public ActionResult FinancingWithdraw()
        {

            return View();
        }
        //充值状态
        public ActionResult RechargeState(string msg)
        {
            ViewBag.Success = !string.IsNullOrEmpty(msg);
            ViewBag.Msg = msg;
            return View();
        }
        //提现状态
        public ActionResult WidtdrawState(string msg)
        {
            ViewBag.Success = !string.IsNullOrEmpty(msg);
            ViewBag.Msg = msg;
            return View();
        }
        //融资户充值状态
        public ActionResult FinancingState()
        {
               return View();
        }
    }
}