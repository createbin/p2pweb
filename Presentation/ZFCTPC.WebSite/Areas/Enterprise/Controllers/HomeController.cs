using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZFCTPC.WebSite.Areas.Enterprise.Controllers
{
    [Area("Enterprise")]
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return Content("company");
        }
    }
}
