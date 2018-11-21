using Microsoft.Extensions.DependencyInjection;
using ZFCTPC.Services.Account;
using ZFCTPC.Services.Activity;
using ZFCTPC.Services.Customers;
using ZFCTPC.Services.Invests;
using ZFCTPC.Services.Invites;
using ZFCTPC.Services.Loans;
using ZFCTPC.Services.News;
using ZFCTPC.Services.Promotion;
using ZFCTPC.Services.Statistic;
using ZFCTPC.Services.Tools;
using ZFCTPC.Services.Transfers;

namespace ZFCTPC.Services
{
    public class DependencyRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(serviceType: typeof(ICustomerService), implementationType: typeof(CustomerService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IInvestService), implementationType: typeof(InvestService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IMyAccountService), implementationType: typeof(MyAccountService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(INewsService), implementationType: typeof(NewsService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IToolsService), implementationType: typeof(ToolsService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(ITransferService), implementationType: typeof(TransferService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IInviteService), implementationType: typeof(InviteService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IActivityService), implementationType: typeof(ActivityService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IStatisticService), implementationType: typeof(StatisticService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IPromotionService), implementationType: typeof(PromotionService), lifetime: ServiceLifetime.Transient));
            
            #region 新渤海
            services.Add(new ServiceDescriptor(serviceType: typeof(IBhAccountService), implementationType: typeof(BhAccountService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(ILoanServices), implementationType: typeof(LoanServices), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(ICompanyService), implementationType: typeof(CompanyService), lifetime: ServiceLifetime.Transient));
            #endregion
        }
    }
}
