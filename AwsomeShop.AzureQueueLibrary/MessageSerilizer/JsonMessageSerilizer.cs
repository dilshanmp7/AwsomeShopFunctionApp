using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AwsomeShop.AzureQueueLibrary.MessageSerilizer
{
    public class JsonMessageSerilizer  :IMessageSerilizer
    {
        public T Deserilize<T>(string message)
        {
            var obj = JsonConvert.DeserializeObject<T>(message);
            return obj;
        }

        public string Serialize(object obj)
        {
            var message = JsonConvert.SerializeObject(obj);
            return message;
        }
    }
}
