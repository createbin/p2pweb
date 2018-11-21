using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Services.Statistic;
using ZFCTPC.Services.News;
using ZFCTPC.Core.Enums;
using ZFCTPC.Data.ApiModel.Promotion;
using ZFCTPC.Services.Promotion;

namespace ZFCTPC.WebSite.Controllers
{
    public class InfoPublicController : Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly IPromotionService _promotionService;

        public InfoPublicController(IStatisticService statisticService, 
            IPromotionService promotionService)
        {
            _statisticService = statisticService;
            _promotionService = promotionService;
        }

        public IActionResult Index()
        {
            //var comprehensiveData = _statisticService.GetComprehensiveData();
            //ViewBag.ComprehensiveData = comprehensiveData;
            //var investData = _statisticService.GetInvestData();
            //ViewBag.InvestData = investData;
            //var financingData = _statisticService.GetFinancingData();
            //ViewBag.FinancingData = financingData;
            //ViewBag.SecurtyDay = (DateTime.Now - Convert.ToDateTime("2016-4-18")).Days;
            //ViewBag.StatisticDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")+" 23:59:59";
            return View();
        }
        //工商信息
        public IActionResult BusinessInfo()
        {
            return View();
        }
        //备案信息
        public IActionResult RecordInfo()
        {
            return View();
        }
        //股权结构
        public IActionResult OwnershipStruct()
        {
            return View();
        }
        //管理团队
        public IActionResult ManagementTeam()
        {
            return View();
        }
        //组织架构
        public IActionResult Organization()
        {
            return View();
        }
        //重大事项
        public IActionResult MajorIssues()
        {
            return View();
        }
        //运营渠道
        public IActionResult OperatChannel()
        {
            return View();
        }
        //投资人
        public IActionResult Investors()
        {
            return View();
        }
        //风险控制
        public IActionResult riskControl()
        {
            return View();
        }
        //公司简介
        public IActionResult CompanyInfo()
        {
            return View();
        }
        //运营报告
        public IActionResult OperationReport()
        {
            return View();
        }

        public IActionResult _ReportData(int p = 1, int ps = 6, int year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : year;
            var result = _promotionService.Managzie(new ManagizeCountRequestModel { Category = 2, Page = p, PageSize = 10000 ,Year=year})?.PagingData.ToList();
            ViewBag.CompanyManagize = result;
            return View();
        }

        //联系我们
        public IActionResult ContactUs()
        {
            return View();
        }
        //安全保障
        public IActionResult Security()
        {
            return View();
        }
        //审计审核
        public IActionResult AuditReview()
        {
            return View();
        }
        //合法合规
        public IActionResult LegalCompliance()
        {
            return View();
        }
        //政策法规
        public IActionResult PoliciesRegular()
        {
            return View();
        }
        //监管部门
        public IActionResult RegulatoryAuthorities()
        {
            return View();
        }
        //风险提示
        public IActionResult RiskWarning()
        {
            return View();
        }
        //信披承诺书
        public IActionResult LetterCommitment()
        {
            return View();
        }
        //管理制度
        public IActionResult ManagementSystem()
        {
            return View();
        }
    }
}