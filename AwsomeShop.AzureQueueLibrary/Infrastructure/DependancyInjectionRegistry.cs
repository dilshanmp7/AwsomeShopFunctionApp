using System;
using System.Collections.Generic;
using System.Text;
using AwsomeShop.AzureQueueLibrary.MessageSerilizer;
using AwsomeShop.AzureQueueLibrary.QueueConnection;
using Microsoft.Extensions.DependencyInjection;

namespace AwsomeShop.AzureQueueLibrary.Infrastructure
{
    public static class DependancyInjectionRegistry
    {
        public static IServiceCollection AddAzureQueueLibrary(this IServiceCollection service,string queueConnectionString)
        {
            service.AddSingleton(new QueueConfig(queueConnectionString));
            service.AddSingleton<ICloudQueueClientFactory, CloudQueueClientFactory>();
            service.AddSingleton<IMessageSerilizer, JsonMessageSerilizer>();
            service.AddSingleton<IQueueCommunicator, QueueCommunicator>();
            return service;
        }

    }
}
