using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ZFCTPC.Core.ApiEngines;
using ZFCTPC.Core.Caching;
using ZFCTPC.Services;

namespace ZFCTPC.WebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Dictionary<string, string>>(Configuration.GetSection("Mime"));
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            services.AddMemoryCache();
            //add register
            DependencyRegistrar.Register(services);
            #region Cookie

            services.AddAuthentication("zfuser")
                .AddCookie("zfuser", option =>
                {
                    option.LoginPath = "/Customer/ReLogin";
                    option.Cookie.Name = "zfauth";
                    option.Cookie.Path = "/";
                    option.Cookie.HttpOnly = true;
                    option.Cookie.Expiration = TimeSpan.FromMinutes(30);
                    option.Cookie.SameSite = SameSiteMode.None;
                });
            #endregion

            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IOptions<Dictionary<string, string>> option)
        {
            if (ApiEngineToConfiguration.GetCurrentEnv() == "False")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseBrowserLink();
                #region Http To Https
                //app.UseForwardedHeaders(new ForwardedHeadersOptions
                //{
                //    ForwardedHeaders = ForwardedHeaders.XForwardedProto
                //});
                //var options = new RewriteOptions()
                //    .AddRedirectToHttpsPermanent();
                //app.UseRewriter(options);
                #endregion
                app.UseExceptionHandler("/Error");

            }
            app.UseRewriter(new RewriteOptions().Add(new Extensions.Redirct.CompanyUserRedirectRule()));
            var provider = new FileExtensionContentTypeProvider();
            foreach (var key in option.Value.Keys)
            {
                provider.Mappings.Add(key,option.Value[key]);
            }
            app.UseStaticFiles(new StaticFileOptions() { ContentTypeProvider = provider });
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(
                    name: "EnterpriseArea",
                    areaName: "Enterprise",
                    template: "Enterprise/{controller=User}/{action=index}");
            });

        }
    }
}
