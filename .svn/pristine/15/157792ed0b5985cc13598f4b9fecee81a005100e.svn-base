using Microsoft.AspNetCore.Mvc;
using ZFCTPC.Core.Helpers;
using ZFCTPC.Core.ApiEngines;
using Newtonsoft.Json;
using System.Linq;

namespace ZFCTPC.WebSite.Controllers
{
    public class NewHandGuideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult RetRetVersion(string Token) {
        //    var request = new { Token = Token };
        //    var result = HttpClientHelper.PostAsync(string.Join(ApiEngineToConfiguration.GetZfctUrl(), "Areas/WebApi/WepApi/RetRetVersion"), JsonConvert.SerializeObject(request));
        //    return Content(result);
        //}

        /// <summary>
        /// 老接口代理
        /// by gaochao 2017-09-26
        /// </summary>
        /// <param name="Method"></param>
        /// <returns></returns>  
        [Route("Areas/WebApi/WepApi/{Method}")]
        public ActionResult WebApiProxy(string Method)
        {
            try
            {
                var request = Request.Form;
                var requestJson = JsonConvert.SerializeObject(request.ToDictionary(s => s.Key, s =>s.Value.ToString()));
                var result = HttpClientHelper.PostAsync(string.Join(ApiEngineToConfiguration.GetZfctUrl(), string.Format("Areas/WebApi/WepApi/{0}", Method)), requestJson).Result.Content.ReadAsStringAsync().Result;
                return Content(result);
            }
            catch
            {
                return Json(new { ReturnCode = 201, Message = "请求参数非法！" });
            }
        }
    }
}