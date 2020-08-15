using System;
using System.Collections.Generic;
using System.Text;
using AwsomeShop.AzureQueueLibrary.Infrastructure;

namespace AwsomeShop.AzureQueueLibrary.Message
{
    public class SendEmailCommand :BaseQueueMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }

        public SendEmailCommand() : base(RouteNames.EmailBox)
        {
        }
    }
}
