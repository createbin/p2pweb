using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Core.Enums;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.ApiModel.MyAccountRequestModels;
using ZFCTPC.Data.ApiModel.Transfers;
using ZFCTPC.Data.Enums;
using ZFCTPC.Services.Account;
using ZFCTPC.Services.Invests;
using ZFCTPC.Services.Transfers;
using ZFCTPC.Services.News;

namespace ZFCTPC.WebSite.Controllers
{
    public class TransferController : Controller
    {
        #region filed

        private readonly ITransferService _transferService;
        private readonly IInvestService _investService;
        private readonly IMyAccountService _accountService;
        private readonly INewsService _inewsService;
        #endregion

        #region CTOR

        public TransferController(ITransferService transferService,IInvestService investService,IMyAccountService accountService, INewsService inewsService)
        {
            _transferService = transferService;
            _investService = investService;
            _accountService = accountService;
            _inewsService = inewsService;
        }
        #endregion
        public IActionResult Index(int p=1,int ps=10)
        {
            return View();
        }
        //债权转让详情
        public IActionResult TransferDetail(int transferId)
        {
            var requestModel=new RequestTransferDetail{transferId = transferId};
            var result = _transferService.TransferDetail(requestModel);
            //标的信息
            var userId = User.FindFirst(ClaimTypes.Sid);
            ViewBag.IsLogin = userId != null;
            ViewBag.TransferDetail = result;

            //还款信息
            //如果标的已经划转请求否则不请求
            var requestModel2=new RequestLoanDetail{LoanId = result.LoanId};
            var repaymentPlan = _investService.LoaneRepaymentPlan(requestModel2);
            ViewBag.RepaymentPlan = repaymentPlan;

            //投资信息
            if (result.TransferStateId == (int) ProjectStateEnum.HasTransfer)
            {
                var invester = _transferService.TransferInvester(requestModel);
                ViewBag.TransferInvester = invester;
            }
            ViewBag.RemainMoney = 0;
            ViewBag.OpenAccount = false;
            if (userId != null)
            {
                var requestModel3 = new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value };
                var remianMoneyInfo = _accountService.RemainMoney(new SJsQueryChargeAccount
                {
                    Token = User.FindFirst(ClaimTypes.Rsa).Value,
                    UserAttribute = 1
                });
                if (remianMoneyInfo.ReturnCode == (int)ReturnCodeEnum.Success)
                {
                    ViewBag.RemainMoney = remianMoneyInfo.ReturnData.WithdrawAmount;
                    ViewBag.OpenAccount = true;
                }
            }

            return View();
        }

        [HttpPost]
        public JsonResult InvestTransfer(int loanId,int transferId,decimal investMoney)
        {
            var model = new InvestTransfer
            {
                loanId = loanId,
                transferId = transferId,
                investMoney = investMoney
            };
            model.Token = User.FindFirst(ClaimTypes.Rsa).Value;
            var result = _transferService.InvestTransfer(model);
            if (result.ReturnCode != (int)ReturnCodeEnum.Processing)
            {
                return Json(new
                {
                    success = false,
                    code=result.ReturnCode,
                    message = result.Message
                });
            }
            return Json(new
            {
                success = true,
                message = "投资跳转中",
                code = result.ReturnCode,
                redirect = result.ReturnData.SubmitUrl
            });
        }


        //债权标

        public IActionResult ClaimsList()
        {
            return View();
        }


        public IActionResult _PartialClaimsList(int page=1,int pageSize=10)
        {
            var requestPage = new RequestPageModel
            {
                Page = page,
                PageSize = pageSize
            };
            var list = _transferService.TransferList(requestPage);
            ViewBag.Total = list.Total;
            return PartialView(list);
        }

    }
}