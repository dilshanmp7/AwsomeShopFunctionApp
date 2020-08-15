using System;
using System.Collections.Generic;
using System.Text;

namespace AwsomeShop.AzureQueueLibrary.MessageSerilizer
{
    public interface IMessageSerilizer
    {
        T Deserilize<T>(string message);
        string Serialize(object ob);
    }
}
