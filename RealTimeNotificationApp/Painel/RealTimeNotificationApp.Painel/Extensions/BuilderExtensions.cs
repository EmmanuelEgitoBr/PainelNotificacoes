using RealTimeNotificationApp.Painel.Configuration;
using RealTimeNotificationApp.Painel.Services;
using RealTimeNotificationApp.Painel.Services.Interfaces;

namespace RealTimeNotificationApp.Painel.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IApiService, ApiService>();

            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            services.AddHttpClient("ApiClient", client =>
            {
                var settings = configuration.GetSection("APISettings").Get<ApiSettings>();
                client.BaseAddress = new Uri(settings!.BaseUrl);
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
            });

            return services;
        }
    }
}
