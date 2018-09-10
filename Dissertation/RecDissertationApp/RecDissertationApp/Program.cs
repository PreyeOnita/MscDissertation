
using Microsoft.Azure.EventHubs;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.EventHubs.Processor;

namespace RecDissertationApp
{
    class Program
    {
        private const string EhConnectionString = "Endpoint=sb://dissertationhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=URTnx0SjiA9B+jkJ61UXaBCnMXvFcbEiw+Anoztcs+o=";
        private const string EhEntityPath = "disso";
        private const string StorageContainerName = "dissertationcontainer";
        private const string StorageAccountName = "dissertationstorageacc";
        private const string StorageAccountKey = "tDmdmd+N1tHLHcgN2FejjlpvTHfJTdv29fL/FFD0IwbXshaWk9sAw+hAiBwVUNqwM/gMd5b6RACEq4mmP5we2Q==";

        private static readonly string StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Registering EventProcessor...");

            var eventProcessorHost = new EventProcessorHost(
                EhEntityPath,
                PartitionReceiver.DefaultConsumerGroupName,
                EhConnectionString,
                StorageConnectionString,
                StorageContainerName);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press ENTER to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }

    }
}
