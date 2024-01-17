using Microsoft.Extensions.DependencyInjection;

namespace CsuChhs.Blazor.Components.Common
{
    public static class AlertMessageExtensions
    {
        public static void AddAlertMessages(this IServiceCollection services)
        {
            services.AddScoped<AlertMessageService>();
        }
    }
}
