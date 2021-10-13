using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Allocate.Core.Ports;
using RSoft.Allocate.Core.Services;
using RSoft.Allocate.Infra;
using RSoft.Allocate.Infra.Providers;
using RSoft.Lib.Common.Options;
using RSoft.Lib.Design.Infra.Data;
using RSoft.Lib.Design.IoC;
using System;
using System.Collections.Generic;
using RSoft.Lib.Messaging.Abstractions;
using RSoft.Lib.Messaging.Options;
using MassTransit.RabbitMqTransport;

namespace RSoft.Allocate.Cross.IoC
{

    /// <summary>
    /// Dependency injection register service
    /// </summary>
    public static class DependencyInjection
    {

        /// <summary>
        /// Register dependency injection services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration object</param>
        /// <param name="aditionalConfig">Action to adicional configuration for messaging</param>
        public static IServiceCollection AddAllocateRegister
        (
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IRabbitMqBusFactoryConfigurator> aditionalConfig = null
        )
        {

            services.AddRSoftRegister<AllocateContext>(configuration, true);

            #region Options

            services.Configure<CultureOptions>(options => configuration.GetSection("Application:Culture").Bind(options));
            services.Configure<MessagingOption>(options => configuration.GetSection("Messaging:Server").Bind(options));

            #endregion

            services.AddMassTransitUsingRabbitMq(configuration, cfg => aditionalConfig?.Invoke(cfg));

            #region Infra

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEntryProvider, EntryProvider>();
            services.AddScoped<IAccrualPeriodProvider, AccrualPeriodProvider>();
            services.AddScoped<ICategoryProvider, CategoryProvider>();
            services.AddScoped<IUserProvider, UserProvider>();

            #endregion

            #region Domain

            services.AddScoped<IEntryDomainService, EntryDomainService>();
            services.AddScoped<IAccrualPeriodDomainService, AccrualPeriodDomainService>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<IUserDomainService, UserDomainService>();

            #endregion

            #region Application

            services.AddServicesMediatR();

            #endregion

            return services;

        }

        /// <summary>
        /// Add mediator services 
        /// </summary>
        /// <param name="services">Service collection object</param>
        private static IServiceCollection AddServicesMediatR(this IServiceCollection services)
        {

            List<string> assembliesNames = new()
            {
                "RSoft.Allocate.Application"
            };


            assembliesNames
                .ForEach(assemblyName =>
                {
                    var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                    services.AddMediatR(assembly);
                });

            return services;

        }

    }
}
