using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TryFi.Hotspot.Application.Commands;
using TryFi.Hotspot.Application.Handlers;
using TryFi.Hotspot.Application.Queries;
using TryFi.Hotspot.Application.Queries.Profiles;
using TryFi.Hotspot.Data;
using TryFi.Hotspot.Data.Repositories;
using TryFi.Hotspot.Domain.Repositories;
using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.Messages.Notifications;

namespace TryFi.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {


        public static IServiceCollection AddTryFi(this IServiceCollection services, ConfigurationManager configuration)
        {

            // MediatR Core
            services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

            // Mediator Custom
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Hotspot Services
            services.AddHotspotServices(configuration);

            return services;
        }

        private static IServiceCollection AddHotspotServices(this IServiceCollection services, ConfigurationManager configuration)
        {

            // Configure Db Context
            services.AddDbContext<HotspotDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("HotspotDbConnectionString")));

            // Repositories
            services.AddScoped<IPlanRepository, PlanRepository>();

            // Command/Handlers
            services.AddScoped<IRequestHandler<RegisterPlanCommand, bool>, PlanCommandHandlers>();

            // Queries
            services.AddScoped<IPlanQueries, PlanQueries>();


            // AutoMapper Profiles Injection by Assembly
            services.AddAutoMapper(typeof(PlanProfile));

            return services;
        }

    }
}
