using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AwsomeShop.AzureQueueLibrary.Message;
using AwsomeShop.AzureQueueLibrary.MessageSerilizer;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AwsomeShop.AzureQueueLibrary.QueueConnection
{
    public interface IQueueCommunicator
    {
        T Read<T>(string message);
        Task SendAsync<T>(T obj) where T :BaseQueueMessage;

    }


    public class QueueCommunicator : IQueueCommunicator
    {
        private readonly IMessageSerilizer _messageSerilizer;
        private readonly ICloudQueueClientFactory _clientFactory;

        public QueueCommunicator(IMessageSerilizer messageSerilizer,
            ICloudQueueClientFactory clientFactory)
        {
            _messageSerilizer = messageSerilizer;
            _clientFactory = clientFactory;
        }
        public T Read<T>(string message)
        {
            return _messageSerilizer.Deserilize<T>(message);
        }

        public async Task SendAsync<T>(T obj) where T :BaseQueueMessage
        {
            var queueReference = _clientFactory.GetClient().GetQueueReference(obj.Route);
            await queueReference.CreateIfNotExistsAsync();

            var serializeMessage = _messageSerilizer.Serialize(obj);
            var cloudQueueMessage= new CloudQueueMessage(serializeMessage);

            await queueReference.AddMessageAsync(cloudQueueMessage);
        }
    }
}
