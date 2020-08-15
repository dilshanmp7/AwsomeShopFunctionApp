using System;
using AwsomeShop.AzureFunctions.Infrastucture;
using AwsomeShop.AzureQueueLibrary.Infrastructure;
using AwsomeShop.AzureQueueLibrary.Message;
using AwsomeShop.AzureQueueLibrary.QueueConnection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AwsomeShop.AzureFunctions.Email
{
    public static class EmailQueueTrigger
    {
        [FunctionName("EmailQueueTrigger")]
        public static async void Run([QueueTrigger(RouteNames.EmailBox, Connection = "AzureWebJobsStorage")]string message,ILogger log)
        {
            try
            {
                var queueCommunicator = DIContainer.Instance.GetService<IQueueCommunicator>();
                var command = queueCommunicator.Read<SendEmailCommand>(message);

                var handler = DIContainer.Instance.GetService<SendEmailCommandHandler.ISendEmailCommandHandler>();
                await handler.Handle(command);
            }
            catch (Exception ex)
            {
               log.LogError(ex,$"Something went wrong with the EmailQueueTrigger {message}");
            }
        }
    }
}
