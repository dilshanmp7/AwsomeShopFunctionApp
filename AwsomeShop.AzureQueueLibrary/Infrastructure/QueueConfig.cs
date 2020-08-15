using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AwsomeShop.AzureQueueLibrary.Infrastructure
{
    public class QueueConfig
    {
        public  string QueueConnectionString { get; set; }

        public QueueConfig()
        {
                
        }

        public QueueConfig(string queueConnection)
        {
            QueueConnectionString = queueConnection;
        }


    }
}
