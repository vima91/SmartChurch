using SmartChurch.DataAccess;
using SmartChurch.Services;
using SmartChurch.Services.ChurchServices;
using SmartChurch.Services.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace SmartChurch.Infrastructure
{
    public class SiriusServices
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(SiriusDbContext));
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddTransient<UserResolverService>();

            // using Microsoft.AspNetCore.Identity.UI.Services;
            services.AddSingleton<IEmailSender, SiriusEmailSenderService>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Services

            services.AddTransient<ChurchServicesService>();
            services.AddTransient<PersonService>();
            services.AddTransient<ServiceSubscriptionService>();

            #endregion
        }
    }
}