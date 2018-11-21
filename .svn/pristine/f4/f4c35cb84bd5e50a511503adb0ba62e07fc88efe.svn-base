using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Services.News;
using ZFCTPC.Core.Enums;
using ZFCTPC.Services.Promotion;
using ZFCTPC.Data.ApiModel.Promotion;

namespace ZFCTPC.WebSite.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IPromotionService _promotionService;

        public AboutUsController(
            IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        //公司简介
        public IActionResult Index()
        {
            return View();
        }
        //集团动态
        public IActionResult GroupDynamics(int p = 1, int ps = 5)
        {
            var result= _promotionService.NewsPage(new AdvertisementPageRequestModel { Code = PromotionCodeEnum.CompanyActivity.ToString(), Page = p, PageSize = ps })?.NewsPage;
            ViewBag.CompanyActivity = result?.PagingData?.ToList();
            ViewBag.CurrentPage = p;
            ViewBag.Count = result?.Total;
            ViewBag.PageSize = ps;
            return View();
        }
        //总裁专栏
        public IActionResult PresidentColumn(int p = 1, int ps = 5)
        {
            var result= _promotionService.NewsPage(new AdvertisementPageRequestModel { Code = PromotionCodeEnum.PresidentWords.ToString(), Page = p, PageSize = ps })?.NewsPage;
            ViewBag.SystemNotice = result?.PagingData?.ToList();
            ViewBag.CurrentPage = p;
            ViewBag.Count = result?.Total;
            ViewBag.PageSize = ps;
            return View();
        }
        //平台公告
        public IActionResult PlatformAnnouncement(int p = 1, int ps = 10)
        {
            var result= _promotionService.NewsPage(new AdvertisementPageRequestModel { Code = PromotionCodeEnum.Web_Notice.ToString(), Page = p, PageSize = ps })?.NewsPage;
            ViewBag.SystemNotice = result.PagingData.ToList();
            ViewBag.CurrentPage = p;
            ViewBag.Count = result.Total;
            ViewBag.PageSize = ps;
            return View();
        }
        //行业动态
        public IActionResult IndustryNews(int p = 1, int ps = 6)
        {
            var result = _promotionService.NewsPage(new AdvertisementPageRequestModel { Code = PromotionCodeEnum.FinancialInformation.ToString(), Page = p, PageSize = ps })?.NewsPage;
            ViewBag.IndustryNews = result?.PagingData?.ToList();
            ViewBag.CurrentPage = p;
            ViewBag.Count = result?.Total;
            ViewBag.PageSize = ps;
            return View();
        }
        //营运报告
        public IActionResult OperationalReport(int p = 1, int ps = 6,int year=0)
        {
            year = year == 0 ? DateTime.Now.Year : year;
            var result = _promotionService.Managzie(new ManagizeCountRequestModel { Category = 2, Page = p, PageSize = ps, Year = year });
            ViewBag.CompanyManagize = result.PagingData;
            ViewBag.CurrentPage = p;
            ViewBag.Count = result.TotalPageCount;
            ViewBag.PageSize = ps;
            return View();
        }
        //企业内刊
        public IActionResult EnterpriseInsideMagazine(int p = 1, int ps = 6)
        {
            var result = _promotionService.Managzie(new ManagizeCountRequestModel { Category = 1, Page = p, PageSize = ps });
            ViewBag.CompanyManagize = result.PagingData?.ToList();
            ViewBag.CurrentPage = p;
            ViewBag.Count = result.Total;
            ViewBag.PageSize = ps;
            return View();
        }
        //联系我们
        public IActionResult ContactUs()
        {
            return View();
        }
        //详情页
        public IActionResult ContactUsDetails(int id)
        {
            ViewBag.newData = _promotionService.NewsDetail(new NewsDetailRequestModel { Id = id });
            return View();
        }
        //人才招聘
        public IActionResult Recruitment()
        {
            ViewBag.Recruitment = _promotionService.NewsCount(new AdvertisementCountRequestModel { Code = PromotionCodeEnum.Recruitment.ToString(), Count = -1 })?.NewsList;
            return View();
        }
        //总裁专栏详情
        public IActionResult PresidentColumnDetail(int id)
        {
            ViewBag.PresidentColumnDetail = _promotionService.NewsDetail(new NewsDetailRequestModel { Id = id });
            return View();
        }
        //平台公告详情
        public IActionResult PlatformDetail(int id)
        {
            ViewBag.platformDetail = _promotionService.NewsDetail(new NewsDetailRequestModel { Id = id });
            return View();
        }
        //行业动态详情
        public IActionResult IndustryNewsDetail(int id)
        {
            ViewBag.IndustryNewsDetail = _promotionService.NewsDetail(new NewsDetailRequestModel { Id = id });
            return View();
        }
    }
}