using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZFCTPC.Core.Enums;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModelReturn.InvestModelReturns;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;
using ZFCTPC.Data.Enums;
using ZFCTPC.Services.Account;
using ZFCTPC.Services.Invests;
using ZFCTPC.Services.Loans;
using ZFCTPC.Services.Tools;
using ZFCTPC.WebSite.ViewModels.InvestsModels;
using ZFCTPC.Services.News;

namespace ZFCTPC.WebSite.Controllers
{
    public class MyInvestController : Controller
    {
        #region

        private readonly IInvestService _investService;
        private readonly IMyAccountService _accountService;
        private readonly IToolsService _toolService;
        private readonly INewsService _inewsService;
        private readonly ILoanServices _loanServices;
        private readonly IBhAccountService _bhAccountService;
        #endregion

        #region CTOR

        public MyInvestController(IInvestService investService, IMyAccountService accountService, IToolsService toolService,
            INewsService inewsService,ILoanServices loanServices,
            IBhAccountService bhAccountService)
        {
            _investService = investService;
            _accountService = accountService;
            _toolService = toolService;
            _inewsService = inewsService;
            _loanServices = loanServices;
            _bhAccountService = bhAccountService;
        }

        #endregion

        #region P2P3.1

        //�Ƽ���
        public IActionResult RecommendedList()
        {
            return View();
        }

        public IActionResult _PartialLoanList(int page = 1, int pageSize = 10)
        {
            var pageInfo = new RequestPageModel
            {
                Page = page,
                PageSize = pageSize
            };

            var model = _loanServices.LoanList(pageInfo);
            ViewBag.Total = model.Total;
            return PartialView(model);
        }

        //ծȨ��

        public IActionResult ClaimsList()
        {
            return View();
        }


        #endregion

        #region ���ֱ�

        public IActionResult NewHandList()
        {
            return View();
        }

        public IActionResult _PartialNewHand(int page = 1, int pageSize = 10)
        {
            var pageInfo = new RequestPageModel
            {
                Page = page,
                PageSize = pageSize
            };

            var model = _loanServices.NewHandList(pageInfo);
            ViewBag.Total = model.Total;
            return PartialView(model);
        }

        #endregion


        public IActionResult InvestDetail(int loanId)
        {
            var requestModel = new RequestLoanDetail { LoanId = loanId };
            var result = _investService.LoanDetail(requestModel);
            //�����Ϣ
            var userId = User.FindFirst(ClaimTypes.Sid);
            ViewBag.IsLogin = userId != null;
            ViewBag.LoanDetail = result;
            ViewBag.LoanTypeName = GetLoanTypeName(result.LoanType);
            //������Ϣ
            //�������Ѿ���ת�����������
            if (result.LoanStateId == (int)ProjectStateEnum.Repayment ||
                result.LoanStateId == (int)ProjectStateEnum.Settled ||
                result.LoanStateId == (int)ProjectStateEnum.Overdue)
            {
                var repaymentPlan = _investService.LoaneRepaymentPlan(requestModel);
                ViewBag.RepaymentPlan = repaymentPlan;
            }
            //�����û��Ƿ����Ͷ���ֱ���ȥ�Ƽ���
            string token = User.FindFirst(ClaimTypes.Rsa) == null ? "" : User.FindFirst(ClaimTypes.Rsa).Value;
            var recommandLoan = _investService.RecommandLoan(token);
            ViewBag.RecommandLoan = recommandLoan;

            //Ͷ�ʼ�¼
            var requestModel2 =
                new RequestLoanInvester { Page = 1, PageSize = 5, LoanId = loanId };
            var invester = _investService.GetLoanInvester(requestModel2);

            ViewBag.Invester = invester;
            ViewBag.loanrisktype = GetRiskTypeDesc(result.LoanRiskType,3);
            ViewBag.RemainMoney = 0;;
            ViewBag.CanInvest = true;
            ViewBag.UserState = new UserState();
            var redCount = 0;
            if (userId != null)
            {
                var requestModel3 = new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value };
                //�����������ֱ�
                if (result.LoanType == (int)LoanType.NewHand)
                {
                    var invested = _investService.IsNewHand(requestModel3);
                    ViewBag.CanInvest = invested;
                }
                var remianMoneyInfo = _accountService.RemainMoney(new SJsQueryChargeAccount
                {
                    Token = User.FindFirst(ClaimTypes.Rsa).Value,
                    UserAttribute = 1});
                if (remianMoneyInfo.ReturnCode == (int)ReturnCodeEnum.Success)
                {
                    ViewBag.RemainMoney = remianMoneyInfo.ReturnData.WithdrawAmount;
                }
                requestModel3.Signature = null;
                redCount = _investService.AvaliableRedCount(requestModel3);

                #region �û���Ȩ״̬
                var requestModel4 = new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value };
                var userState = _bhAccountService.UserState(requestModel4);
                if (userState.ReturnCode == (int)ReturnCodeEnum.Success)
                {
                    ViewBag.UserState = userState.ReturnData;
                }
                #endregion
            }
            ViewBag.RedCount = redCount;


            bool existLogin = userId == null && !string.IsNullOrEmpty(HttpContext.Session.GetString("userLoginFalied"));
            ViewBag.ExistLogin = existLogin;
            return View(result);
        }

        public IActionResult _PartialFinancingInformation(int loanId)
        {
            var requestModel = new RequestLoanDetail { LoanId = loanId };
            var modelInfo = _investService.LoanProjectDetails(requestModel);
            return PartialView(modelInfo);
        }

        public IActionResult _PartialLoanFlow(int loanId)
        {
            var requestModel = new RequestLoanDetail { LoanId = loanId };
            var modelInfo = _investService.TrackingDetails(requestModel);
            return PartialView(modelInfo);
        }

        public IActionResult _PartialLoanInvester(int loanId, int p = 1, int ps = 5)
        {
            //Ͷ�ʼ�¼
            var requestModel =
                new RequestLoanInvester { Page = 1, PageSize = 5, LoanId = loanId };
            var invester = _investService.GetLoanInvester(requestModel);
            ViewBag.CurrentPage = p;
            ViewBag.Count = invester.Total;
            return PartialView(invester);
        }

        public JsonResult RedList(int loanId, decimal investMoney, int page = 1, int pageSize = 1000)
        {
            var returnList = new List<InvestRedPackage>();
            var model = new LoanRedPackage
            {
                InvestMoney = investMoney,
                LoanId = loanId,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var result = _investService.LoanRedPackage(model);
            if (result.Any())
            {
                var canUse = result.FirstOrDefault(p => p.State);
                if (canUse != null && canUse.RedPackages.Any())
                {
                    foreach (var loanRedPackage in canUse.RedPackages)
                    {
                        var returnPackage1 = new InvestRedPackage
                        {
                            redId = loanRedPackage.RedId,
                            redName = loanRedPackage.RedName,
                            redMoney = loanRedPackage.RedMoney,
                            expireDate = loanRedPackage.EndDate,
                            state = true,
                            des = HandleBr(loanRedPackage.Condition),
                            introduction = loanRedPackage.Condition
                        };
                        returnList.Add(returnPackage1);
                    }
                }
                var notUser = result.FirstOrDefault(p => !p.State);
                if (notUser != null && notUser.RedPackages.Any())
                {
                    foreach (var loanRedPackage in notUser.RedPackages)
                    {
                        var returnPackage2 = new InvestRedPackage
                        {
                            redId = loanRedPackage.RedId,
                            redName = loanRedPackage.RedName,
                            redMoney = loanRedPackage.RedMoney,
                            expireDate = loanRedPackage.EndDate,
                            state = false,
                            des = HandleBr(loanRedPackage.Condition),
                            introduction = loanRedPackage.Condition
                        };
                        returnList.Add(returnPackage2);
                    }
                }
            }
            var returnResult = returnList.OrderByDescending(p => p.state).ThenByDescending(p => p.redMoney)
                .Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                Success = "true",
                Data = JsonConvert.SerializeObject(returnResult)
            });


        }

        public JsonResult BestRedInfo(int loanId, decimal investMoney)
        {
            var model = new LoanRedPackage
            {
                InvestMoney = investMoney,
                LoanId = loanId,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var returnInfo = _investService.BestRedInfo(model);
            if (returnInfo != null && returnInfo.RedMoney != 0)
            {
                return Json(new
                {
                    Success = "true",
                    Data = JsonConvert.SerializeObject(returnInfo)
                });
            }
            else
            {
                return Json(new
                {
                    Success = "false",
                    Data = ""
                });
            }
        }

        public JsonResult LoanInvester(int loanId, int page = 1, int pageSize = 5)
        {
            //Ͷ�ʼ�¼
            var requestModel =
                new RequestLoanInvester { Page = page, PageSize = pageSize, LoanId = loanId };
            var invester = _investService.GetLoanInvester(requestModel);
            return Json(new
            {
                Sucess = "true",
                Data = JsonConvert.SerializeObject(invester.PagingData)
            });
        }

        public JsonResult InvestIncome(int loanId, decimal money, string repayment, string deadLine, string loanRate)
        {
            var model = new RequestInvestIncome
            {
                LoanId = loanId,
                BillDay = "1",
                RepaymentType = repayment,
                InvestMoney = money,
                DeadLine = deadLine,
                InType = "4",
                LoanRate = loanRate
            };
            var result = _investService.InvestIncome(model);
            return Json(new
            {
                success = "true",
                result = result
            });
        }

        public JsonResult LoanAvaliableMoney(int loanId)
        {
            var requestModel = new RequestLoanDetail { LoanId = loanId };
            var result = _investService.LoanAvaliableMoney(requestModel);
            return Json(new
            {
                success = "true",
                result = result
            });
        }
        [HttpPost]
        public JsonResult InvestLoan(int loanId, int redId, decimal investMoney)
        {
            var model = new SInvestLoan
            {
                LoanId = loanId,
                RedId = redId,
                Money = investMoney,
                RequestSource = (int) UserSource.PC,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var result = _investService.InvestLoan(model);
            if (result.ReturnCode != (int)ReturnCodeEnum.Success)
            {
                return Json(new
                {
                    success = "false",
                    message = result.Message,
                    code = result.ReturnCode
                });
            }
            return Json(new
            {
                success = "true",
                message = result.ReturnData.ErrorInfo,
                code = result.ReturnCode
            });
        }


        [HttpPost]
        public JsonResult WaitInvest(int investId)
        {
            var model = new WaitPay
            {
                investId = investId,
                source = (int)UserSource.PC,
                Token = User.FindFirst(ClaimTypes.Rsa).Value
            };
            var result = _investService.WaitPay(model);
            if (result.ReturnCode != (int)ReturnCodeEnum.Processing)
            {
                return Json(new
                {
                    success = "false",
                    message = result.Message,
                    code = result.ReturnCode
                });
            }
            return Json(new
            {
                success = "true",
                message = "Ͷ����ת��",
                code = result.ReturnCode,
                redirect = result.ReturnData.SubmitUrl
            });
        }

        private string HandleBr(string des)
        {
            if (des.Contains("<br"))
            {
                var index = des.IndexOf("<br/>", StringComparison.Ordinal);
                return des.Substring(0, index) + "," + des.Substring(index + 5, des.Length - index - 5);
            }
            return des;
        }

        private string GetLoanTypeName(int loanType)
        {
            if (loanType == (int)LoanType.NewHand)
            {
                return "��ѡ�ƻ�";
            }
            if (loanType == (int)LoanType.Wise)
            {
                return "��ѡ�ƻ�";
            }
            if (loanType == (int)LoanType.Dream)
            {
                return "����ƻ�";
            }
            return "";
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="loanRiskType"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CheckUserInvestType(string loanRiskType)
        {
            var result = _accountService.UserInvestType(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            if (!string.IsNullOrEmpty(result))
            {
                if (!string.IsNullOrEmpty(loanRiskType)) {
                    if (loanRiskType.Equals("������") && !result.Equals("������"))
                        return Json(new { investerrisktype = true, loanrisktype = false, msg1 = GetRiskTypeDesc(result, 1), msg2 = GetRiskTypeDesc(loanRiskType, 2) });
                    if (loanRiskType.Equals("�Ƚ���") && result.Equals("������"))
                        return Json(new { investerrisktype = true, loanrisktype = false, msg1 = GetRiskTypeDesc(result, 1), msg2 = GetRiskTypeDesc(loanRiskType, 2) });
                }
                return Json(new { investerrisktype = true, loanrisktype = true });
            }
            else
            {
                return Json(new { investerrisktype = false });
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="riskType"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetRiskTypeDesc(string riskType,int type){
            var riskTypeDesc = string.Empty;
            switch (riskType) {
                case "������":
                    riskTypeDesc = type ==1 ? "�����ͣ����ճ��������ϵ�":
                         type == 2 ? "�����ͣ����սϵ�":"\"������\"������"; break;
                case "�Ƚ���":
                    riskTypeDesc = type == 1 ? "�Ƚ���, ���ճ�������һ��":
                        type == 2 ? "�Ƚ���, ����һ��": "\"�Ƚ���\"������"; break;
                case "������":
                    riskTypeDesc = type == 1 ? "�����ͣ����ճ��������ϸ�":
                           type == 2 ? "�����ͣ����սϸ�" : "\"������\""; break;
                default:
                    if (type == 3)
                        riskTypeDesc = "���������";
                    break;

            }
            return riskTypeDesc;
        }


    }
}