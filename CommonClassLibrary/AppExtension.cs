﻿using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClassLibrary
{
   public static class AppExtension
    {
        public static IServiceCollection AddConsulConfig(this IServiceCollection services,IConfiguration configuartion)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consuleconfig=>
            {
                var address = configuartion["Consul:ConsulAddress"];
                consuleconfig.Address = new Uri(address);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtension");
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                ID = configuration["Consul:ServiceId"],
                Name = configuration["Consul:ServiceName"],
                Address = configuration["Consul:ServiceHost"],
                Port = int.Parse(configuration["Consul:ServicePort"])
            };
            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);
            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
            });
            return app;

        }
    }
}
