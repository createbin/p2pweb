using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZFCTPC.WebSite.Extensions.Redirct
{
    public class CompanyUserRedirectRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            //登陆过期重定向
            if (request.Path.StartsWithSegments("/Customer/ReLogin"))
            {
                request.Cookies.TryGetValue("zfctIsCompany", out string IsCompany);
                if (!string.IsNullOrEmpty(IsCompany) && IsCompany.Equals("true"))
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status302Found;
                    context.Result = RuleResult.EndResponse;
                    context.HttpContext.Response.Headers[HeaderNames.Location] = "/Customer/EnterpriseLogin";
                }
                else {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status302Found;
                    context.Result = RuleResult.EndResponse;
                    context.HttpContext.Response.Headers[HeaderNames.Location] = "/Customer/Login" + request.QueryString;
                }
            
            }

            //个人中心重定向
            if (request.Method.Equals("GET")){
                request.Cookies.TryGetValue("zfctIsCompany", out string IsCompany);
                if (!string.IsNullOrEmpty(IsCompany) && IsCompany.Equals("true"))
                {
                    if (request.Path.StartsWithSegments("/MyAccount"))
                    {
                        context.HttpContext.Response.StatusCode = StatusCodes.Status302Found;
                        context.Result = RuleResult.EndResponse;
                        context.HttpContext.Response.Headers[HeaderNames.Location] = "/Enterprise/CompanyAccount/Index";
                    }
                }
                else {
                    if (request.Path.StartsWithSegments("/Enterprise"))
                    {
                        context.HttpContext.Response.StatusCode = StatusCodes.Status302Found;
                        context.Result = RuleResult.EndResponse;
                        context.HttpContext.Response.Headers[HeaderNames.Location] = "/MyAccount";
                    }
                }
            }
        }
    }
}
