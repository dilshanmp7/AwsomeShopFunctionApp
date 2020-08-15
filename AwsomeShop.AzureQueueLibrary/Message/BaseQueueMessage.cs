using System;
using System.Collections.Generic;
using System.Text;

namespace AwsomeShop.AzureQueueLibrary.Message
{
   public abstract class BaseQueueMessage
    {
        public string Route { get; set; }

        protected BaseQueueMessage(string route)
        {
            Route = route;
        }
    }
}
