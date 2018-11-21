using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Data.ApiModel.Invests;
using ZFCTPC.Data.Enums;
using ZFCTPC.Services.Invests;
using ZFCTPC.Services.News;
using System.Security.Claims;
using ZFCTPC.Core.Enums;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Data.ApiModel;
using ZFCTPC.Services.Loans;
using ZFCTPC.Services.Tools;
using ZFCTPC.Services.Promotion;
using ZFCTPC.Data.ApiModel.Promotion;

namespace ZFCTPC.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInvestService _investService;
        private readonly ILoanServices _loanServices;
        private readonly IToolsService _toolsService;
        private readonly IPromotionService _promotionService;

        public HomeController(IInvestService investService, 
            ILoanServices loanServices,
            IToolsService toolsService,
            IPromotionService promotionService)
        {
            _investService = investService;
            _loanServices = loanServices;
            _toolsService = toolsService;
            _promotionService = promotionService;
        }

        public IActionResult Index()
        {
            #region 首页统计信息
            var statistics = _toolsService.GetStatistics();
            ViewBag.Statistics = statistics;
            #endregion

            #region 首页标的信息

            //var loanInfos = _investService.GetHomeLoanInfo();
            ////获取新手标
            //var newHand = loanInfos.FirstOrDefault(p => p.loanTypeId == (int)LoanType.NewHand);
            //var newHandInvestor=new List<string>();
            ////新手标投资用户
            //if (newHand != null)
            //{
            //    var requestModel =
            //        new RequestLoanInvester {Page = 1, PageSize = 5, loanId = newHand.loanInfos[0].loanId};
            //    var newInvetor = _investService.GetLoanInvester(requestModel);
            //    if (newInvetor != null&&newInvetor.loanInvesters.Any())
            //    {
            //        newHandInvestor.AddRange(newInvetor.loanInvesters.Select(model => model.invester + "已经成功投资￥" + model.investMoney + "元"));
            //    }
            //}
            //获取智选标
            //var wise = loanInfos.FirstOrDefault(p => p.loanTypeId ==(int)LoanType.Wise);
            //var wiseInvestor=new List<string>();
            //if (wise != null)
            //{
            //    var requestModel2 =
            //        new RequestLoanInvester { Page = 1, PageSize = 5, loanId = wise.loanInfos[0].loanId };
            //    var wiseInvestor1=_investService.GetLoanInvester(requestModel2);
            //    if (wiseInvestor1 != null && wiseInvestor1.loanInvesters.Any())
            //    {
            //        wiseInvestor.AddRange(wiseInvestor1.loanInvesters.Select(model => model.invester + "已经成功投资￥" + model.investMoney + "元"));
            //    }
            //    var requestModel3 =
            //        new RequestLoanInvester { Page = 1, PageSize = 5, loanId = wise.loanInfos[1].loanId };
            //    var wiseInvestor2 = _investService.GetLoanInvester(requestModel3);
            //    if (wiseInvestor2 != null && wiseInvestor2.loanInvesters.Any())
            //    {
            //        wiseInvestor.AddRange(wiseInvestor2.loanInvesters.Select(model => model.invester + "已经成功投资￥" + model.investMoney + "元"));
            //    }
            //}
            //获取智选标
            //var dream = loanInfos.FirstOrDefault(p => p.loanTypeId ==(int)LoanType.Dream);
            //var dreamInvestor = new List<string>();
            //if (dream != null&&dream.loanInfos.Any())
            //{
            //    var requestModel4 =
            //        new RequestLoanInvester { Page = 1, PageSize = 5, loanId = dream.loanInfos[0].loanId };
            //    var dreamInvestor1 = _investService.GetLoanInvester(requestModel4);
            //    if (dreamInvestor1 != null && dreamInvestor1.loanInvesters.Any())
            //    {
            //        dreamInvestor.AddRange(dreamInvestor1.loanInvesters.Select(model => model.invester + "已经成功投资￥" + model.investMoney + "元"));
            //    }
            //    var requestModel5 =
            //        new RequestLoanInvester { Page = 1, PageSize = 5, loanId = dream.loanInfos[1].loanId };
            //    var dreamInvestor2 = _investService.GetLoanInvester(requestModel5);
            //    if (dreamInvestor2 != null && dreamInvestor2.loanInvesters.Any())
            //    {
            //        dreamInvestor.AddRange(dreamInvestor2.loanInvesters.Select(model => model.invester + "已经成功投资￥" + model.investMoney + "元"));
            //    }
            //}
            //ViewBag.NewHand = newHand;
            //ViewBag.Wise = wise;
            //ViewBag.Dream = dream;
            //ViewBag.NewHandInvestor = newHandInvestor;
            //ViewBag.WiseInvestor = wiseInvestor;
            //ViewBag.DreamInvestor = dreamInvestor;
            #endregion

            #region 新闻

            ViewBag.Banner = _promotionService.AdvertisementsCount(new AdvertisementCountRequestModel { Code= PromotionCodeEnum.PCIndexBanner.ToString() ,Count=5});
            ViewBag.PCIndexColumn = _promotionService.AdvertisementsCount(new AdvertisementCountRequestModel { Code = PromotionCodeEnum.PCIndexColumn.ToString(), Count = 1 });
            ViewBag.WebNotice = _promotionService.NewsCount(new AdvertisementCountRequestModel { Code = PromotionCodeEnum.Web_Notice.ToString(), Count = 5 });
            ViewBag.CompanyActivity = _promotionService.NewsCount(new AdvertisementCountRequestModel { Code = PromotionCodeEnum.CompanyActivity.ToString(), Count = 5 });
            ViewBag.LeaderTalk = _promotionService.NewsCount(new AdvertisementCountRequestModel { Code=PromotionCodeEnum.PresidentWords.ToString(),Count=1});
            ViewBag.CompanyManagize = _promotionService.Managzie(new ManagizeCountRequestModel { Category = 1, Page = 1, PageSize = 1 })?.PagingData.ToList();

            #endregion

            var newHnadList = _loanServices.HomeNewHand(1);
            ViewBag.NewHand= newHnadList != null&& newHnadList.Total>0? newHnadList.PagingData.First():null;
            return View();
        }


        public IActionResult _PartialLoanList()
        {
            var model = _loanServices.HomeLoanList(4);
            return PartialView(model.PagingData.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
