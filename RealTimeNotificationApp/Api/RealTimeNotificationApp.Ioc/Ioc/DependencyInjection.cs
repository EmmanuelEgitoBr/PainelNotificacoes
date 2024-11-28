using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using RealTimeNotificationApp.Application.Interfaces;
using RealTimeNotificationApp.Application.Mappings;
using RealTimeNotificationApp.Application.Services;
using RealTimeNotificationApp.Domain.Interfaces;
using RealTimeNotificationApp.Infra.Configuration;
using RealTimeNotificationApp.Infra.Repositories;

namespace RealTimeNotificationApp.Ioc.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDeliveryService, DeliveryService>();

            return services;
        }

        public static IServiceCollection AddSwaggerInfrastructure(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gerenciamento de Pedidos",
                    Description = "API REST desenvolvida em .NET Core, usando Clean Architeture" +
                        ", MongoDb como base de dados feita para gerenciar pedidos em tempo real",
                    Contact = new OpenApiContact
                    {
                        Name = "Página de contato",
                        Url = new Uri("https://www.google.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licenciamento",
                        Url = new Uri("https://www.google.com")
                    }
                });
                //var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
            return services;
        }

        public static IServiceCollection AddMongoInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            MongoSettings mongoDBSettings = new MongoSettings
            {
                ConnectionString = configuration.GetSection("MongoSettings:ConnectionString").ToString()
                    ?? throw new InvalidOperationException("Configuração MongoSettings não foi informada"),
                Database = configuration.GetSection("MongoSettings:DatabaseName").ToString()
                    ?? throw new InvalidOperationException("Configuração MongoSettings não foi informada")
            };

            services.AddScoped(services => mongoDBSettings);

            services.AddScoped(provider => new MongoClient(mongoDBSettings.ConnectionString)
                                .GetDatabase(mongoDBSettings.Database));

            return services;
        }
    }
}
