using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Services.News;
using ZFCTPC.Data.ApiModelReturn.News;
using ZFCTPC.Services.Promotion;
using ZFCTPC.Core.Enums;

namespace ZFCTPC.WebSite.Controllers
{
    public class HelpCenterController : Controller
    {
        private readonly IPromotionService _promotionService;


        public HelpCenterController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        //帮助中心列表
        public IActionResult HelpCenterList(string tab)
        {
            ViewBag.Tab = tab;
            //var result = _inewsService.GetNewsList("FAQ", 0);
            var result = _promotionService.NewsCount(new Data.ApiModel.Promotion.AdvertisementCountRequestModel { Code = PromotionCodeEnum.FAQ.ToString(), Count = -1 })?.NewsList;
            ViewBag.Register = null;//注册
            ViewBag.Bind = null;//绑定
            ViewBag.Login = null;//登录
            ViewBag.PwdAndSafe = null;//密码与安全
            ViewBag.Account = null;//开户
            ViewBag.Recharge = null;//充值
            ViewBag.Invest = null;//投资
            ViewBag.Cash = null;//提现
            ViewBag.Payment = null;//回款
            ViewBag.Debt = null;//债权转让
            ViewBag.Red = null;//红包
            ViewBag.Fee = null;//收费标准
            if (result!=null&&result.Count >0)
            {
                var helpList = result.OrderBy(m=>m.CreateTime).ToList();
                ViewBag.Register = helpList.Where(h => h.SkipUrl == "register").ToList();
                ViewBag.Bind= helpList.Where(h => h.SkipUrl == "bind").ToList();
                ViewBag.Login= helpList.Where(h => h.SkipUrl == "login").ToList();
                ViewBag.PwdAndSafe= helpList.Where(h => h.SkipUrl == "passwordsecurity").ToList();
                ViewBag.Account= helpList.Where(h => h.SkipUrl == "open").ToList();
                ViewBag.Recharge= helpList.Where(h => h.SkipUrl == "topup").ToList();
                ViewBag.Invest= helpList.Where(h => h.SkipUrl == "invest").ToList();
                ViewBag.Cash= helpList.Where(h => h.SkipUrl == "withdrawal").ToList();
                ViewBag.Payment= helpList.Where(h => h.SkipUrl == "remittance").ToList();
                ViewBag.Debt= helpList.Where(h => h.SkipUrl == "transfer").ToList();
                ViewBag.Red= helpList.Where(h => h.SkipUrl == "red").ToList();
                ViewBag.Fee= helpList.Where(h => h.SkipUrl == "rates").ToList();
            }
            return View();
        }
    }
}