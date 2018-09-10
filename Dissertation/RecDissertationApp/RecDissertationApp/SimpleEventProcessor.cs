using Microsoft.Azure.EventHubs.Processor;
using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PubnubApi;

namespace RecDissertationApp
{
    public class SimpleEventProcessor : IEventProcessor
    {
        private Pubnub pubnub;

        public SimpleEventProcessor()
        {
            PNConfiguration config = new PNConfiguration();
            config.PublishKey = "pub-c-408496f2-699f-4cf2-b7e6-8de831fcba3a";
            config.SubscribeKey = "sub-c-68f5dfe0-630d-11e7-898a-02ee2ddab7fe";

            pubnub = new Pubnub(config);
        }
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Processor Shutting Down. Partition '{context.PartitionId}', Reason: '{reason}'.");
            return Task.FromResult<bool>(true);
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"SimpleEventProcessor initialized. Partition: '{context.PartitionId}'");
            return Task.FromResult<bool>(true);
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {

            Console.WriteLine($"Error on Partition: {context.PartitionId}, Error: {error.Message}");
            return Task.FromResult(true);
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                //Configured
                pubnub.Publish()
                    .Channel("Channel-ofc16pagy")
                    .Message(new string[] { data })
                    .Async(new PNPublishResultExt(
                        (result, status) =>
                        {
                            if (result != null)
                            {
                                Console.WriteLine(result.ToString());
                            }
                            if (status != null)
                            {
                                Console.WriteLine(status.StatusCode);
                            }
                        }
                        ));
                Console.WriteLine($"Message received. Partition: '{context.PartitionId}', Data: '{data}'");
            }

            return context.CheckpointAsync();
        }
    }
}
