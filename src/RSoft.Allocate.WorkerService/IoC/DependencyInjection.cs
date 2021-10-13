using GreenPipes;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Allocate.Cross.IoC;
using RSoft.Allocate.WorkerService.Consumers;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Web.Extensions;
using RSoft.Lib.Contracts.Events;
using RSoft.Lib.Messaging.Extensions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.WorkerService.IoC
{

    /// <summary>
    /// Dependency injection register service
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Injection for unit-tests")]
    public static class DependencyInjection
    {

        #region Public methods

        /// <summary>
        /// Register dependency injection services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration object</param>
        public static IServiceCollection AddAllocateWorkerRegister(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddCultureLanguage(configuration);
            services.AddAllocateRegister(configuration, cfg => cfg.AddConsumers());

            ServiceActivator.Configure(services.BuildServiceProvider());

            return services;

        }

        #endregion

        #region Local methods


        /// <summary>
        /// Add consumers for message bus
        /// </summary>
        /// <param name="config">Bus factory configurator instance</param>
        private static void AddConsumers(this IRabbitMqBusFactoryConfigurator config)
        {

            // Retry policy
            config.UseMessageRetry(retryConfig => retryConfig.Incremental(4, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3)));

            // Consumers
            config.AddEventConsumerEndpoint<UserCreatedEvent, UserCreatedEventConsumer>($"{nameof(UserCreatedEvent)}.AllocateService");
            config.AddEventConsumerEndpoint<UserChangedEvent, UserChangedEventConsumer>($"{nameof(UserChangedEvent)}.AllocateService");
            config.AddEventConsumerEndpoint<UserDeletedEvent, UserDeletedEventConsumer>($"{nameof(UserDeletedEvent)}.AllocateService");

        }

        #endregion


    }
}
