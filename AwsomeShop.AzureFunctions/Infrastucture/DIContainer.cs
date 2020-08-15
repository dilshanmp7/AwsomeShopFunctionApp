using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AwsomeShop.AzureFunctions.Email;
using AwsomeShop.AzureQueueLibrary.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AwsomeShop.AzureFunctions.Infrastucture
{
    public sealed class DIContainer
    {
        private static readonly IServiceProvider _instance=Build();

        public static IServiceProvider Instance = _instance;
     


        private static IServiceProvider Build()
        {
            var services = new ServiceCollection();
            var Configuration=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json",optional:true,reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();
            services.AddSingleton(
                new EmailConfig(Configuration["EmailHost"],Convert.ToInt32(Configuration["EmailPort"]), Configuration["EmailSender"], Configuration["EmailPassword"])
                );
            services.AddSingleton<SendEmailCommandHandler.ISendEmailCommandHandler, SendEmailCommandHandler>();

            services.AddAzureQueueLibrary(Configuration["AzureWebJobsStorage"]);
            return services.BuildServiceProvider();
        }

    }
}
