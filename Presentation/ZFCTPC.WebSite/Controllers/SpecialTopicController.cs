using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZFCTPC.Services.Account;
using ZFCTPC.Data.ApiModel;
using System.Security.Claims;
using ZFCTPC.Data.ApiModelReturn.MyAccountReturnModels;

namespace ZFCTPC.WebSite.Controllers
{
    public class SpecialTopicController : Controller
    {
        private readonly IMyAccountService _iMyAccountService;

        public SpecialTopicController(IMyAccountService myAccountService)
        {
            _iMyAccountService = myAccountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NjBank()
        {
            return View();
        }

        [Authorize(AuthenticationSchemes = "zfuser")]
        public IActionResult RiskingTest(int redirctType, int itemid)
        {
            var model = _iMyAccountService.RiskQuestionnaire(new BaseRequestModel())?? new List<RiskQuestionnaireModel>();
            ViewBag.redirctType = redirctType;
            ViewBag.ItemId = itemid;
            return View(model);
        }

        [Authorize(AuthenticationSchemes = "zfuser")]
        public IActionResult RiskingTestResult(int redirctType, int itemid)
        {
            var result = _iMyAccountService.UserInvestType(new BaseRequestModel { Token = User.FindFirst(ClaimTypes.Rsa).Value });
            ViewBag.redirctType = redirctType;
            if (!string.IsNullOrEmpty(result))
            {
                ViewBag.investType = result;
                ViewBag.ItemId = itemid;
            }
            else
            {
                RedirectToAction($"RiskingTest?redirctType={redirctType}&itemid={itemid}");
            }
            return View();
        }

        //合规进度页面
        public IActionResult CompProgress()
        {
            return View();
        }
    }
}